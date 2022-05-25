using furMix.DialogBoxes;
using furMix.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace furMix
{
    public partial class Splash : Form
    {
        List<string> devs = new List<string>();
        public static int daysleft;
        public static bool trial;
        public static string name;
        public static bool Store = false;

        public Splash()
        {
            InitializeComponent();
            Log.CreateLog();
            Log.LogEvent("Starting furMix...");
            if (Store)
            {
                Log.LogEvent("Setting edition...");
                Properties.Settings.Default.Edition = "Professional Edition";
                Log.LogEvent("Setting name...");
                Properties.Settings.Default.Name = Environment.UserName;
                Log.LogEvent("Activating...");
                Properties.Settings.Default.Activated = true;
                Log.LogEvent("Saving configuration...");
                Properties.Settings.Default.Save();
            }
            label2.Text = Properties.Settings.Default.Version;
            label4.Text = Properties.Settings.Default.Edition;
            if (label4.Text == "Misha Pidor Edition" || label4.Text == "Misha Ter Edition")
            {
                pictureBox2.Visible = true;
            }
            /*if (Properties.Settings.Default.PlaybackDevice == 0)
            {
                Analyzer anal = new Analyzer();
                anal.SetPlaybackList(devs);
                string[] array = devs[0].Split(' ');
                int devindex = Convert.ToInt32(array[0]);
                Properties.Settings.Default.PlaybackDevice = devindex;
                Properties.Settings.Default.Save();
            }*/
            Log.LogEvent("Loading assemblies...");
            if (!Splash.Store && Properties.Settings.Default.CheckUpdates)
            {
                Log.LogEvent("Checking for updates...");
                try
                {
                    string version = new StreamReader(WebRequest.Create("https://danimat.org/furMix/version.txt").GetResponse().GetResponseStream()).ReadToEnd();

                    System.Reflection.Assembly executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                    FileVersionInfo fileVer = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
                    Version oldVer = Version.Parse(fileVer.FileVersion);
                    Version newVer = null;
                    foreach (string ver in version.Split(' '))
                    {
                        if (ver.Contains(".")) newVer = Version.Parse(ver);
                    }
                    if (oldVer < newVer)
                    {
                        Log.LogEvent("Update available");
                        UpdateDialog ud = new UpdateDialog(newVer);
                        ud.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    Log.LogEvent("Error occurred while checking for updates. Error: " + ex.Message);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            name = Properties.Settings.Default.Name;
            if (Properties.Settings.Default.Activated && !Properties.Settings.Default.Trial)
            {
                trial = false;
                timer1.Dispose();
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else if (Properties.Settings.Default.Activated && Properties.Settings.Default.Trial)
            {
                DateTime install = Properties.Settings.Default.TrialDate;
                TimeSpan days = DateTime.Now - install;
                if (days.Days > 30)
                {
                    Properties.Settings.Default.Activated = false;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Your trial period has been expired. Activate furMix now", "License expired", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Restart();
                }
                else
                {
                    daysleft = 30 - days.Days;
                    trial = true;
                    timer1.Dispose();
                    Main main = new Main();
                    main.Show();
                    this.Hide();
                }
            }
            else
            {
                timer1.Dispose();
                Activate act = new Activate();
                act.ShowDialog();
                Application.Restart();
            }
        }
    }
}
