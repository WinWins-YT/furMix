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

        string FileName;
        public int FramesPerSecond, Quality;
        FourCC Codec;
        public Control Control;

        public int Height { get; private set; }
        public int Width { get; private set; }

        public AviWriter CreateAviWriter()
        {
            return new AviWriter(FileName)
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
    }

    public class Recorder : IDisposable
    {
        #region Fields
        AviWriter writer;
        RecorderParams Params;
        IAviVideoStream videoStream;
        IAviAudioStream audioStream;
        Thread screenThread;
        ManualResetEvent stopThread = new ManualResetEvent(false);
        MMDevice device;
        WasapiLoopbackCapture capture;
        BufferedWaveProvider bwp;
        byte[] audioBuffer;
        #endregion

        public Recorder(RecorderParams Params)
        {
            this.Params = Params;

            writer = Params.CreateAviWriter();

            videoStream = Params.CreateVideoStream(writer);
            videoStream.Name = "furMix";
            audioStream = writer.AddAudioStream(2, 44100, 16);
            audioStream.Name = "furMix";

            var audioByteRate = (audioStream.BitsPerSample / 8) * audioStream.ChannelCount * audioStream.SamplesPerSecond;
            var audioBlockSize = (int)(audioByteRate / writer.FramesPerSecond);
            audioBuffer = new byte[audioBlockSize];

            int deviceindex = Properties.Settings.Default.PlaybackDevice;
            MMDeviceEnumerator devices = new MMDeviceEnumerator();
            var devs = devices.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            device = devs[deviceindex];
            capture = new WasapiLoopbackCapture(device);
            capture.DataAvailable += Capture_DataAvailable;
            bwp = new BufferedWaveProvider(capture.WaveFormat);
            bwp.BufferLength = audioBlockSize;
            bwp.DiscardOnBufferOverflow = true;

            screenThread = new Thread(RecordScreen)
            {
                Name = typeof(Recorder).Name + ".RecordScreen",
                IsBackground = true
            };

            screenThread.Start();
        }

        private void Capture_DataAvailable(object sender, WaveInEventArgs e)
        {
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        public void Dispose()
        {
            stopThread.Set();
            screenThread.Join();

            writer.Close();

            stopThread.Dispose();
        }

        void RecordScreen()
        {
            var frameInterval = TimeSpan.FromSeconds(1 / (double)writer.FramesPerSecond);
            var buffer = new byte[Params.Width * Params.Height * 4];
            Task videoWriteTask = null;
            Task audioWriteTask = null;
            var timeTillNextFrame = TimeSpan.Zero;

            while (!stopThread.WaitOne(timeTillNextFrame))
            {
                var timestamp = DateTime.Now;

                Screenshot(buffer);
                bwp.Read(audioBuffer, 0, audioBuffer.Length);

                videoWriteTask?.Wait();
                audioWriteTask?.Wait();

                videoWriteTask = videoStream.WriteFrameAsync(true, buffer, 0, buffer.Length);
                audioWriteTask = audioStream.WriteBlockAsync(audioBuffer, 0, audioBuffer.Length);

                timeTillNextFrame = timestamp + frameInterval - DateTime.Now;
                if (timeTillNextFrame < TimeSpan.Zero)
                    timeTillNextFrame = TimeSpan.Zero;
            }

            videoWriteTask?.Wait();
            audioWriteTask?.Wait();
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