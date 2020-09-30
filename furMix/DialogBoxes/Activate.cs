using FluentFTP;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace furMix
{
    public partial class Activate : Form
    {
        FtpClient ftp = new FtpClient();
        bool offline;
        bool connected;
        bool trial = false;
        IniFile myIni;
        public Activate()
        {
            InitializeComponent();
            var connect = new Connect();
            connect.Show();
            ftp.Host = "danimat.ddns.net";
            ftp.Credentials = new System.Net.NetworkCredential("furMix", "furMix");
            try
            {
                ftp.Connect();
                while (!ftp.IsConnected)
                {

                }
                Thread.Sleep(2000);
                if (ftp.IsConnected)
                {
                    connected = true;
                    try
                    {
                        ftp.DownloadFileAsync(Path.GetTempPath() + @"\activation.ini", "/activation.ini", FtpLocalExists.Overwrite);
                        Thread.Sleep(2000);
                        myIni = new IniFile(Path.GetTempPath() + @"\activation.ini");
                    }
                    catch
                    {
                        connect.Close();
                        connect.Dispose();
                        offline = true;
                        MessageBox.Show("Server error. Try enter only offline product key, that you were supplied after buying, without name", "Offline activation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Enabled = false;
                    }
                }
            }
            catch
            {
                connect.Close();
                connect.Dispose();
                offline = true;
                MessageBox.Show("Server error. Try enter only offline product key, that you were supplied after buying, without name", "Offline activation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Enabled = false;
            }
            connect.Close();
            connect.Dispose();
            if (Properties.Settings.Default.Trial)
            {
                label5.ForeColor = Color.Gray;
                label5.Cursor = Cursors.Default;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                if (textBox2.Text == "hayatov")
                {
                    Properties.Settings.Default.Name = "Andrey Hayatov";
                    Properties.Settings.Default.Activated = true;
                    Properties.Settings.Default.Trial = false;
                    Properties.Settings.Default.Edition = "Basic Edition";
                    Properties.Settings.Default.Save();
                    File.Delete(Path.GetTempPath() + @"\activation.ini");
                    Close();
                }
                else
                {
                    MessageBox.Show("This product key is not valid. Try again.", "Activation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (trial)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Name could not be empty");
                }
                else
                {
                    Properties.Settings.Default.Name = textBox1.Text;
                    Properties.Settings.Default.Activated = true;
                    Properties.Settings.Default.Edition = "Basic Edition";
                    Properties.Settings.Default.Save();
                    Application.Restart();
                }
            }
            else if (connected)
            {
                if (textBox2.Text == myIni.Read("Key", textBox1.Text) && textBox1.Text != "" && textBox2.Text != "")
                {
                    Properties.Settings.Default.Name = textBox1.Text;
                    Properties.Settings.Default.Activated = true;
                    Properties.Settings.Default.Trial = false;
                    Properties.Settings.Default.Edition = myIni.Read("Edition", textBox1.Text);
                    Properties.Settings.Default.Save();
                    File.Delete(Path.GetTempPath() + @"\activation.ini");
                    Close();
                }
                else
                {
                    MessageBox.Show("This product key is not valid. Try again.", "Activation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            offline = true;
            MessageBox.Show("Try enter only offline product key, that you were supplied after buying, without name", "Offline activation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Enabled = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.Trial)
            {
                trial = true;
                Properties.Settings.Default.Trial = true;
                Properties.Settings.Default.TrialDate = DateTime.Now;
                Properties.Settings.Default.Save();
                textBox2.Enabled = false;
                MessageBox.Show("Enter your name in textbox above and click Activate", "Trial period", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
