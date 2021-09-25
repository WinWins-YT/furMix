using furMix.Controls;
using furMix.DialogBoxes;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Threading;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using Accord.Math;

namespace furMix.Utilities
{

    public class Analyzer
    {
        private MMDevice device;
        private List<string> devicelist = new List<string>();
        private List<int> spectrumdata = new List<int>();
        private VolumeLevel vl;
        private bool _enable;
        private int deviceindex;
        private WasapiLoopbackCapture capture;
        private int BUFFERSIZE = (int)Math.Pow(2, 13);
        private BufferedWaveProvider bwp;
        private DispatcherTimer t = new DispatcherTimer();

        public bool DisplayEnable { get; set; }

        public SpectrumLevel spectrumLevel { get; set; }

        public BufferedWaveProvider BufferedData { get => bwp; }

        public Analyzer()
        {
            deviceindex = Properties.Settings.Default.PlaybackDevice;
            MMDeviceEnumerator devices = new MMDeviceEnumerator();
            var devs = devices.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            device = devs[deviceindex];
            capture = new WasapiLoopbackCapture(device);
            capture.DataAvailable += Capture_DataAvailable;
            bwp = new BufferedWaveProvider(capture.WaveFormat);
            bwp.BufferLength = BUFFERSIZE * 2;
            bwp.DiscardOnBufferOverflow = true;
            t.Tick += T_Tick;
            t.Interval = TimeSpan.FromMilliseconds(25);
        }

        private void T_Tick(object sender, EventArgs e)
        {
            t.IsEnabled = false;
            PlotLatestData();
            t.IsEnabled = true;
        }

        private void PlotLatestData()
        {
            int frameSize = BUFFERSIZE;
            var audioBytes = new byte[frameSize];
            bwp.Read(audioBytes, 0, frameSize);
            /*if (audioBytes.Length == 0)
                return;
            if (audioBytes[frameSize - 2] == 0)
                return;*/
            int BYTES_PER_POINT = 2;
            int graphPointCount = audioBytes.Length / BYTES_PER_POINT;
            double[] pcm = new double[graphPointCount];
            double[] fft = new double[graphPointCount];
            double[] fftReal = new double[graphPointCount / 2];
            for (int i = 0; i < graphPointCount; i++)
            {
                Int16 val = BitConverter.ToInt16(audioBytes, i * 2);
                pcm[i] = (double)(val) / Math.Pow(2, 16) * 200.0;
            }
            fft = FFT(pcm);
            Array.Copy(fft, fftReal, fftReal.Length);
            int x, y;
            int b0 = 0;
            for (x = 0; x < 17; x++)
            {
                float peak = 0;
                int b1 = (int)Math.Pow(2, x * 10.0 / (15 - 1));
                if (b1 > 1023) b1 = 1023;
                if (b1 <= b0) b1 = b0 + 1;
                for (; b0 < b1; b0++)
                {
                    if (peak < fft[1 + b0]) peak = (float)fft[1 + b0];
                }
                y = (int)(Math.Sqrt(peak) * 3 * 255 - 4);
                //if (y > 255) y = 255;
                if (y < 0) y = 0;
                spectrumdata.Add(y);
            }
            vl.LeftCh = Convert.ToInt32(device.AudioMeterInformation.PeakValues[0] * 100);
            vl.RightCh = Convert.ToInt32(device.AudioMeterInformation.PeakValues[1] * 100);
            int[] toShow = new int[fftReal.Length];
            for (int i = 0; i < fftReal.Length; i++) toShow[i] = (byte)fftReal[i];
            if (DisplayEnable) spectrumLevel.Set(spectrumdata.ToArray());
            spectrumdata.Clear();
        }

        public Analyzer(VolumeLevel vlevel)
        {
            deviceindex = Properties.Settings.Default.PlaybackDevice;
            MMDeviceEnumerator devices = new MMDeviceEnumerator();
            var devs = devices.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            device = devs[deviceindex];
            capture = new WasapiLoopbackCapture(device);
            capture.DataAvailable += Capture_DataAvailable;
            bwp = new BufferedWaveProvider(capture.WaveFormat);
            bwp.BufferLength = BUFFERSIZE * 2;
            bwp.DiscardOnBufferOverflow = true;
            vl = vlevel;
            t.Tick += T_Tick;
            t.Interval = TimeSpan.FromMilliseconds(25);
        }

        private void Capture_DataAvailable(object sender, WaveInEventArgs e)
        {
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        public bool Enable
        {
            get { return _enable; }
            set
            {
                _enable = value;
                if (value)
                {
                    capture.StartRecording();
                }
                else capture.StopRecording();
                t.IsEnabled = value;
            }
        }

        public void SetPlaybackList(List<string> pbox)
        {
            MMDeviceEnumerator devices = new MMDeviceEnumerator();
            var devs = devices.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            for (int i = 0; i < devs.Count; i++)
            {
                var device = devs[i];
                pbox.Add(string.Format("{0} - {1}", i, device.FriendlyName));
            }
        }

        public double[] FFT(double[] data)
        {
            double[] fft = new double[data.Length];
            System.Numerics.Complex[] fftComplex = new System.Numerics.Complex[data.Length];
            for (int i = 0; i < data.Length; i++)
                fftComplex[i] = new System.Numerics.Complex(data[i], 0.0);
            FourierTransform.FFT(fftComplex, FourierTransform.Direction.Forward);
            for (int i = 0; i < data.Length; i++)
                fft[i] = fftComplex[i].Magnitude;
            return fft;
        }

        /*private bool _enable;                                       //enabled status
        private DispatcherTimer _t;                                 //timer that refreshes the display
        private float[] _fft;                                       //buffer for fft data
        private WASAPIPROC _process;                                //callback function to obtain data
        private int _lastlevel;                                     //last output level
        private int _hanctr;                                        //last output level counter
        private List<byte> _spectrumdata;                           //spectrum data buffer
        private List<string> _devicelist = new List<string>();      //device list
        private bool _initialized;                                  //initialized flag
        private int devindex;                                       //used device index
        private VolumeLevel _vl;                                    //volume display
        private int _lines = 15;                                    // number of spectrum lines

        //ctor
        public Analyzer(VolumeLevel vl)
        {
            _fft = new float[1024];
            _lastlevel = 0;
            _hanctr = 0;
            _t = new DispatcherTimer();
            _t.Tick += _t_Tick;
            _t.Interval = TimeSpan.FromMilliseconds(25); //40hz refresh rate
            _t.IsEnabled = false;
            _process = new WASAPIPROC(Process);
            _spectrumdata = new List<byte>();
            _initialized = false;
            _vl = vl;
            Init();
        }

        public Analyzer()
        {
            BassNet.Registration("winwins@danimat.ddns.net", "2X322928249318");
        }

        // Spectrum monitor
        public SpectrumLevel spectrumLevel { get; set; }

        // Serial port for arduino output
        public SerialPort Serial { get; set; }

        // flag for display enable
        public bool DisplayEnable { get; set; }

        //flag for enabling and disabling program functionality
        public bool Enable
        {
            get { return _enable; }
            set
            {
                try
                {
                    _enable = value;
                    if (value)
                    {
                        if (!_initialized)
                        {
                            //var array = (_devicelist[0] as string).Split(' ');
                            //devindex = Convert.ToInt32(array[0]);
                            devindex = Properties.Settings.Default.PlaybackDevice;
                            bool result = BassWasapi.BASS_WASAPI_Init(devindex, 0, 0, BASSWASAPIInit.BASS_WASAPI_BUFFER, 1f, 0.05f, _process, IntPtr.Zero);
                            if (!result)
                            {
                                var error = Bass.BASS_ErrorGetCode();
                                //MessageBox.Show(error.ToString());
                                throw new Exception(error.ToString());
                            }
                            else
                            {
                                _initialized = true;
                            }
                        }
                        BassWasapi.BASS_WASAPI_Start();
                    }
                    else BassWasapi.BASS_WASAPI_Stop(true);
                    System.Threading.Thread.Sleep(500);
                    _t.IsEnabled = value;
                }
                catch (Exception ex)
                {
                    Error error = new Error();
                    error.ShowError(ex);
                    error.ShowDialog();
                    error.Dispose();
                }
            }
        }

        public void SetPlaybackList(List<string> pbox)
        {
            try
            {
                for (int i = 0; i < BassWasapi.BASS_WASAPI_GetDeviceCount(); i++)
                {
                    var device = BassWasapi.BASS_WASAPI_GetDeviceInfo(i);
                    if (device.IsEnabled && device.IsLoopback)
                    {
                        pbox.Add(string.Format("{0} - {1}", i, device.name));
                    }
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        // initialization
        private void Init()
        {
            try
            {
                BassNet.Registration("winwins@danimat.ddns.net", "2X322928249318");
                bool result = false;
                Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATETHREADS, false);
                result = Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                if (!result) throw new Exception("Init Error");
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        //timer 
        private void _t_Tick(object sender, EventArgs e)
        {
            try
            {
                int ret = BassWasapi.BASS_WASAPI_GetData(_fft, (int)BASSData.BASS_DATA_FFT2048); //get channel fft data
                if (ret < -1) return;
                int x, y;
                int b0 = 0;

                //computes the spectrum data, the code is taken from a bass_wasapi sample.
                for (x = 0; x < _lines; x++)
                {
                    float peak = 0;
                    int b1 = (int)Math.Pow(2, x * 10.0 / (_lines - 1));
                    if (b1 > 1023) b1 = 1023;
                    if (b1 <= b0) b1 = b0 + 1;
                    for (; b0 < b1; b0++)
                    {
                        if (peak < _fft[1 + b0]) peak = _fft[1 + b0];
                    }
                    y = (int)(Math.Sqrt(peak) * 3 * 255 - 4);
                    if (y > 255) y = 255;
                    if (y < 0) y = 0;
                    _spectrumdata.Add((byte)y);
                }
                if (DisplayEnable) { spectrumLevel.Set(_spectrumdata); }
                _spectrumdata.Clear();

                int level = BassWasapi.BASS_WASAPI_GetLevel();
                _vl.LeftCh = Utils.LowWord32(level);
                _vl.RightCh = Utils.HighWord32(level);
                if (level == _lastlevel && level != 0) _hanctr++;
                _lastlevel = level;

                //Required, because some programs hang the output. If the output hangs for a 75ms
                //this piece of code re initializes the output so it doesn't make a gliched sound for long.
                if (_hanctr > 3)
                {
                    _hanctr = 0;
                    Free();
                    Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                    _initialized = false;
                    Enable = true;
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        // WASAPI callback, required for continuous recording
        private int Process(IntPtr buffer, int length, IntPtr user)
        {
            return length;
        }

        //cleanup
        public void Free()
        {
            BassWasapi.BASS_WASAPI_Free();
            Bass.BASS_Free();
        }*/
    }
}
