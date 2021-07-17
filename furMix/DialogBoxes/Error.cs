using furMix.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace furMix
{
    public partial class Error : Form
    {
        public Error()
        {
            InitializeComponent();
            if (Properties.Settings.Default.VideoError)
            {
                try
                {
                    //ZipFile.ExtractToDirectory(Application.StartupPath + @"\system\error.cfg", Path.GetTempPath());
                    File.WriteAllBytes(Path.GetTempPath() + @"\error.mp4", Properties.Resources.error);
                }
                catch
                {

                }
                ErrorVideo.URL = Path.GetTempPath() + @"\error.mp4";
            }
            if (!Log.isCreated) Log.CreateLog();
            Log.LogEvent("Error thrown");
        }

        public void ShowError(Exception ex)
        {
            Log.LogEvent(ex.ToString());
            ErrorInfo.Text = ex.ToString();
            if (Properties.Settings.Default.VideoError)
            {
                ErrorVideo.Ctlcontrols.play();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log.LogEvent("Error dialog closing");
            try
            {
                File.Delete(Path.GetTempPath() + @"\error.mp4");
            }
            catch
            {

            }
            File.Delete(Path.GetTempPath() + @"\error.mp4");
            this.Close();
        }

        private void Error_FormClosed(object sender, FormClosingEventArgs e)
        {
            Log.LogEvent("Error dialog closing");
            try
            {
                File.Delete(Path.GetTempPath() + @"\error.mp4");
                //this.Close();
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Log.SendBug();
            Close();
        }
    }
}
