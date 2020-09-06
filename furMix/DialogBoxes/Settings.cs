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
            CasinoChk.Checked = !Properties.Settings.Default.Casino;
            Analyzer anal = new Analyzer();
            anal.SetPlaybackList(devs);
            for (int i = 0; i < devs.Count; i++)
            {
                devlist.Items.Add(devs[i]);
            }
            devlist.SelectedIndex = 0;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CasinoChk.Checked)
            {
                Properties.Settings.Default.Casino = false;
            }
            else
            {
                Properties.Settings.Default.Casino = true;
            }
            string[] array = (devlist.Items[devlist.SelectedIndex] as string).Split(' ');
            int devindex = Convert.ToInt32(array[0]);
            Properties.Settings.Default.PlaybackDevice = devindex;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
