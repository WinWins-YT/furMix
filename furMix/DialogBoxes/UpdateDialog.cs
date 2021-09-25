using furMix.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace furMix.DialogBoxes
{
    public partial class UpdateDialog : Form
    {
        public UpdateDialog(Version newVersion)
        {
            InitializeComponent();
            textBox1.Text = "furMix v." + newVersion.ToString(3) + "\r\n\r\n";
            string changelog = new StreamReader(WebRequest.Create("https://danimat.ddns.net/furMix/newChangelog.txt").GetResponse().GetResponseStream()).ReadToEnd();
            textBox1.Text += changelog;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Log.LogEvent("Update cancelled");
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log.LogEvent("Downloading update");
            button1.Enabled = false;
            button2.Enabled = false;
            WebClient web = new WebClient();
            web.DownloadProgressChanged += Web_DownloadProgressChanged;
            web.DownloadFileCompleted += Web_DownloadFileCompleted;
            web.DownloadFileAsync(new Uri("https://danimat.ddns.net/furMix/downloads/furMix_setup.exe"), Path.Combine(Path.GetTempPath(), "furMix_setup.exe"));
        }

        private void Web_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Log.LogEvent("Download completed");
            Log.LogEvent("Starting installer...");
            Process p = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = Path.Combine(Path.GetTempPath(), "furMix_setup.exe"),
                    Verb = "runas"
                }
            };
            p.Start();
            Log.LogEvent("Exiting application...");
            Environment.Exit(0);
        }

        private void Web_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}
