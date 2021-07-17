using System.Diagnostics;
using System.Windows.Forms;
using furMix.Utilities;

namespace furMix.DialogBoxes
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            VerTxt.Text = "Version " + Properties.Settings.Default.Version;
            LicensedTxt.Text = "This product is licensed to " + Splash.name;
            Log.LogEvent("About dialog opened");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "https://danimat.ddns.net/furMix";
            process.StartInfo = psi;
            process.Start();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "mailto:winwins@danimat.ddns.net";
            process.StartInfo = psi;
            process.Start();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
