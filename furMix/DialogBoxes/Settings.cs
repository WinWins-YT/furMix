using furMix.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace furMix
{
    public partial class Settings : Form
    {
        List<string> devs = new List<string>();
        public Settings()
        {
            InitializeComponent();
            VideoChk.Checked = !Properties.Settings.Default.VideoError;
            Analyzer anal = new Analyzer();
            anal.SetPlaybackList(devs);
            for (int i = 0; i < devs.Count; i++)
            {
                devlist.Items.Add(devs[i]);
            }
            devlist.SelectedIndex = 0;
            Screen[] scr = Screen.AllScreens;
            for (int i = 0; i < scr.Length; i++)
            {
                Screen sc = scr[i];
                scrlist.Items.Add(string.Format("{0} - {1}", i, sc.DeviceName));
            }
            scrlist.SelectedIndex = scr.Length - 1;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (VideoChk.Checked)
            {
                Properties.Settings.Default.VideoError = false;
            }
            else
            {
                Properties.Settings.Default.VideoError = true;
            }
            string[] array = (devlist.Items[devlist.SelectedIndex] as string).Split(' ');
            int devindex = Convert.ToInt32(array[0]);
            array = (scrlist.Items[scrlist.SelectedIndex] as string).Split(' ');
            int scrindex = Convert.ToInt32(array[0]);
            Properties.Settings.Default.PlaybackDevice = devindex;
            Properties.Settings.Default.Screen = scrindex;
            Properties.Settings.Default.Save();
            MessageBox.Show("Restart application to save settings", "Settings saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Close();
        }
    }
}
