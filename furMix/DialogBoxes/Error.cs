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
            if (Properties.Settings.Default.Casino)
            {
                try
                {
                    ZipFile.ExtractToDirectory(Application.StartupPath + @"\system\error.cfg", Application.StartupPath + @"\system");
                }
                catch
                {

                }
                ErrorVideo.URL = Application.StartupPath + @"\system\error.mp4";
            }
        }

        public void ShowError(Exception ex)
        {
            ErrorInfo.Text = ex.ToString();
            if (Properties.Settings.Default.Casino)
            {
                ErrorVideo.Ctlcontrols.play();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(Application.StartupPath + @"\system\error.mp4");
            }
            catch
            {

            }
            File.Delete(Application.StartupPath + @"\system\error.mp4");
            this.Close();
        }

        private void Error_FormClosed(object sender, FormClosingEventArgs e)
        {
            try
            {
                File.Delete(Application.StartupPath + @"\system\error.mp4");
                //this.Close();
            }
            catch
            {

            }
        }
    }
}
