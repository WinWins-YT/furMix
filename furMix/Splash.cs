using furMix.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace furMix
{
    public partial class Splash : Form
    {
        List<string> devs = new List<string>();
        public static int daysleft;
        public static bool trial;
        public static string name;
        public Splash()
        {
            InitializeComponent();
            label2.Text = Properties.Settings.Default.Version;
            label4.Text = Properties.Settings.Default.Edition;
            if (label4.Text == "Misha Pidor Edition")
            {
                pictureBox2.Visible = true;
            }
            if (Properties.Settings.Default.PlaybackDevice == 0)
            {
                Analyzer anal = new Analyzer();
                anal.SetPlaybackList(devs);
                string[] array = devs[0].Split(' ');
                int devindex = Convert.ToInt32(array[0]);
                Properties.Settings.Default.PlaybackDevice = devindex;
                Properties.Settings.Default.Save();
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
