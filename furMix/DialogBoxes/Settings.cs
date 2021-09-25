using furMix.Network.WebInterface;
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
            UpdateCheck.Checked = Properties.Settings.Default.CheckUpdates;
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
            if (Properties.Settings.Default.Edition == "Professional Edition" || Properties.Settings.Default.Edition == "Misha Ter Edition" || Properties.Settings.Default.Edition == "Misha Pidor Edition")
            {
                NetLabel.Visible = true;
                NetPortTxt.Visible = true;
                WebAPIPortTxt.Visible = true;
                WebAPIPortLabel.Visible = true;
                WebPortLabel.Visible = true;
                WebPortTxt.Visible = true;
                WebInterfaceChk.Visible = true;
                NetPortTxt.Text = Properties.Settings.Default.NetPort.ToString();
                WebPortTxt.Text = Properties.Settings.Default.WebPort.ToString();
                WebAPIPortTxt.Text = Properties.Settings.Default.WebAPIPort.ToString();
                WebInterfaceChk.Checked = Properties.Settings.Default.WebServer;
            }
            Log.LogEvent("Settings dialog opened");
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.VideoError = !VideoChk.Checked;
            Properties.Settings.Default.CheckUpdates = UpdateCheck.Checked;
            string[] array = (devlist.Items[devlist.SelectedIndex] as string).Split(' ');
            int devindex = Convert.ToInt32(array[0]);
            array = (scrlist.Items[scrlist.SelectedIndex] as string).Split(' ');
            int scrindex = Convert.ToInt32(array[0]);
            Properties.Settings.Default.PlaybackDevice = devindex;
            Properties.Settings.Default.Screen = scrindex;
            if (Properties.Settings.Default.Edition == "Professional Edition" || Properties.Settings.Default.Edition == "Misha Ter Edition" || Properties.Settings.Default.Edition == "Misha Pidor Edition")
            {
                if (!int.TryParse(NetPortTxt.Text, out int port))
                {
                    MessageBox.Show("Network port is invalid", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (!int.TryParse(WebPortTxt.Text, out int webport))
                {
                    MessageBox.Show("Web interface port is invalid", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (!int.TryParse(WebAPIPortTxt.Text, out int webapiport))
                {
                    MessageBox.Show("Web API port is invalid", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (port == webport || webport == webapiport || port == webapiport)
                {
                    MessageBox.Show("Port numbers cannot be equal", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (webport != Properties.Settings.Default.WebPort)
                {
                    WebServer.ClosePort(Properties.Settings.Default.WebPort);
                    WebServer.OpenPort(webport);
                }
                if (webapiport != Properties.Settings.Default.WebAPIPort)
                {
                    WebServer.ClosePort(Properties.Settings.Default.WebAPIPort);
                    WebServer.OpenPort(webapiport);
                }
                Properties.Settings.Default.NetPort = port;
                Properties.Settings.Default.WebPort = webport;
                Properties.Settings.Default.WebAPIPort = webapiport;
                Properties.Settings.Default.WebServer = WebInterfaceChk.Checked;
            }
            Properties.Settings.Default.Save();
            MessageBox.Show("Restart application to save settings", "Settings saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Close();
        }
    }
}
