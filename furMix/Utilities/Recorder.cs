using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using SharpAvi;
using SharpAvi.Codecs;
using SharpAvi.Output;
using System.Windows.Forms;
using System.IO;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using FFMpegCore;

namespace furMix.Utilities
{
    // Used to Configure the Recorder
    public class RecorderParams
    {
        public RecorderParams(string filename, int FrameRate, FourCC Encoder, int Quality)
        {
            FileName = filename;
            FramesPerSecond = FrameRate;
            Codec = Encoder;
            this.Quality = Quality;

            Height = Screen.PrimaryScreen.Bounds.Height;
            Width = Screen.PrimaryScreen.Bounds.Width;
        }

        public RecorderParams(Control control, string filename, int FrameRate, FourCC Encoder, int Quality)
        {
            FileName = filename;
            FramesPerSecond = FrameRate;
            Codec = Encoder;
            this.Quality = Quality;
            Control = control;

            Height = control.Height;
            Width = control.Width;
        }

        public string FileName;
        public string TempFileName = Path.Combine(Path.GetTempPath(), "furMix", "recording.avi");
        public int FramesPerSecond, Quality;
        FourCC Codec;
        public Control Control;

        public int Height { get; private set; }
        public int Width { get; private set; }

        public AviWriter CreateAviWriter()
        {
            if (!Directory.Exists(Path.Combine(Path.GetTempPath(), "furMix"))) Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "furMix"));
            return new AviWriter(TempFileName)
            {
                FramesPerSecond = FramesPerSecond,
                EmitIndex1 = true,
            };
        }

        public IAviVideoStream CreateVideoStream(AviWriter writer)
        {
            // Select encoder type based on FOURCC of codec
            if (Codec == KnownFourCCs.Codecs.Uncompressed)
                return writer.AddUncompressedVideoStream(Width, Height);
            else if (Codec == KnownFourCCs.Codecs.MotionJpeg)
                return writer.AddMotionJpegVideoStream(Width, Height, Quality);
            else
            {
                return writer.AddMpeg4VideoStream(Width, Height, (double)writer.FramesPerSecond,
                    quality: Quality,
                    codec: Codec,
                    forceSingleThreadedAccess: true);
            }
        }

        public IAviAudioStream CreateAudioStream(AviWriter writer, WaveFormat waveFormat, bool encode, int bitRate)
        {
            // Create encoding or simple stream based on settings
            if (encode)
            {
                // LAME DLL path is set in App.OnStartup()
                return writer.AddMp3AudioStream(waveFormat.Channels, waveFormat.SampleRate, bitRate);
            }
            else
            {
                return writer.AddAudioStream(
                    channelCount: waveFormat.Channels,
                    samplesPerSecond: waveFormat.SampleRate,
                    bitsPerSample: waveFormat.BitsPerSample);
            }
        }

        public static WaveFormat ToWaveFormat(SupportedWaveFormat waveFormat)
        {
            switch (waveFormat)
            {
                case SupportedWaveFormat.WAVE_FORMAT_44M16:
                    return new WaveFormat(44100, 16, 1);
                case SupportedWaveFormat.WAVE_FORMAT_44S16:
                    return new WaveFormat(44100, 16, 2);
                default:
                    throw new NotSupportedException("Wave formats other than '16-bit 44.1kHz' are not currently supported.");
            }
        }
    }

    public class Recorder : IDisposable
    {
        #region Fields
        AviWriter writer;
        RecorderParams Params;
        IAviVideoStream videoStream;
        Thread screenThread;
        ManualResetEvent stopThread = new ManualResetEvent(false);
        MMDevice device;
        WasapiLoopbackCapture capture;
        BufferedWaveProvider bwp;
        WaveFileWriter wwriter;
        private readonly AutoResetEvent videoFrameWritten = new AutoResetEvent(false);
        private string AudioFileName = Path.Combine(Path.GetTempPath(), "furMix", "recording.wav");
        #endregion

        public Recorder(RecorderParams Params)
        {
            GlobalFFOptions.Configure(new FFOptions() { BinaryFolder = Environment.CurrentDirectory + @"\ffmpeg", TemporaryFilesFolder = Path.Combine(Path.GetTempPath(), "furMix") });
            this.Params = Params;

            writer = Params.CreateAviWriter();

            int deviceindex = Properties.Settings.Default.PlaybackDevice;
            MMDeviceEnumerator devices = new MMDeviceEnumerator();
            var devs = devices.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            device = devs[deviceindex];
            capture = new WasapiLoopbackCapture(device);
            capture.DataAvailable += Capture_DataAvailable;
            bwp = new BufferedWaveProvider(capture.WaveFormat);
            if (!Directory.Exists(Path.Combine(Path.GetTempPath(), "furMix"))) Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "furMix"));
            wwriter = new WaveFileWriter(AudioFileName, capture.WaveFormat);

            videoStream = Params.CreateVideoStream(writer);
            videoStream.Name = "furMix";

            if (capture != null)
            {
                videoFrameWritten.Set();
                capture.StartRecording();
            }

            screenThread = new Thread(RecordScreen)
            {
                Name = typeof(Recorder).Name + ".RecordScreen",
                IsBackground = true
            };

            screenThread.Start();
        }

        private void Capture_DataAvailable(object sender, WaveInEventArgs e)
        {
            wwriter.Write(e.Buffer, 0, e.BytesRecorded);
        }

        public void Dispose()
        {
            stopThread.Set();
            screenThread.Join();
            capture.StopRecording();
            capture.DataAvailable -= Capture_DataAvailable;
            wwriter.Dispose();

            writer.Close();

            stopThread.Dispose();

            FFMpeg.ReplaceAudio(Params.TempFileName, AudioFileName, Params.FileName);
            File.Delete(AudioFileName);
            File.Delete(Params.TempFileName);
        }

        void RecordScreen()
        {
            var frameInterval = TimeSpan.FromSeconds(1 / (double)writer.FramesPerSecond);
            var buffer = new byte[Params.Width * Params.Height * 4];
            Task videoWriteTask = null;
            var timeTillNextFrame = TimeSpan.Zero;

            while (!stopThread.WaitOne(timeTillNextFrame))
            {
                var timestamp = DateTime.Now;

                Screenshot(buffer);

                videoWriteTask?.Wait();

                videoWriteTask = videoStream.WriteFrameAsync(true, buffer, 0, buffer.Length);

                timeTillNextFrame = timestamp + frameInterval - DateTime.Now;
                if (timeTillNextFrame < TimeSpan.Zero)
                    timeTillNextFrame = TimeSpan.Zero;
            }

            videoWriteTask?.Wait();
        }

        public void Screenshot(byte[] Buffer)
        {
            if (Params.Control != null)
            {
                using (Bitmap BMP = Params.Control.DrawToImage())
                {
                    var bits = BMP.LockBits(new Rectangle(0, 0, BMP.Width, BMP.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                    Marshal.Copy(bits.Scan0, Buffer, 0, Buffer.Length);
                    BMP.UnlockBits(bits);
                }
                return;
            }
            using (var BMP = new Bitmap(Params.Width, Params.Height))
            {
                using (var g = Graphics.FromImage(BMP))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, new Size(Params.Width, Params.Height), CopyPixelOperation.SourceCopy);

                    g.Flush();

                    var bits = BMP.LockBits(new Rectangle(0, 0, Params.Width, Params.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
                    Marshal.Copy(bits.Scan0, Buffer, 0, Buffer.Length);
                    BMP.UnlockBits(bits);
                }
            }
        }
    }
}