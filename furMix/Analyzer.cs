﻿using furMix.Controls;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Threading;
using Un4seen.Bass;
using Un4seen.BassWasapi;

namespace furMix.Utilities
{

    internal class Analyzer
    {
        private bool _enable;                                       //enabled status
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
            
        }

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
        }
    }
}