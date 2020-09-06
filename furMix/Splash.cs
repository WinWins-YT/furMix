using furMix.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace furMix
{
    public partial class Splash : Form
    {
        List<string> devs = new List<string>();
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
            if (Properties.Settings.Default.Activated)
            {
                timer1.Dispose();
                Main main = new Main();
                main.Show();
                this.Hide();
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
