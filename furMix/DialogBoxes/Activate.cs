using FluentFTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace furMix
{
    public partial class Activate : Form
    {
        FtpClient ftp = new FtpClient();
        bool offline;
        bool connected;
        IniFile myIni;
        public Activate()
        {
            InitializeComponent();
            var connect = new Connect();
            connect.Show();
            Thread.Sleep(500);
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
                        ftp.DownloadFileAsync(Application.StartupPath + @"\config\activation.ini", "/activation.ini", FtpLocalExists.Overwrite);
                        Thread.Sleep(2000);
                        myIni = new IniFile(Application.StartupPath + @"\config\activation.ini");
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                if (textBox2.Text == "hayatov")
                {
                    Properties.Settings.Default.Name = "Andrey Hayatov";
                    Properties.Settings.Default.Activated = true;
                    Properties.Settings.Default.Edition = "Basic Edition";
                    Properties.Settings.Default.Save();
                    File.Delete(Application.StartupPath + @"\config\activation.ini");
                    Close();
                }
                else
                {
                    MessageBox.Show("This product key is not valid. Try again.", "Activation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (connected)
            {
                if (textBox2.Text == myIni.Read("Key", textBox1.Text) && textBox1.Text != "" && textBox2.Text != "")
                {
                    Properties.Settings.Default.Name = textBox1.Text;
                    Properties.Settings.Default.Activated = true;
                    Properties.Settings.Default.Edition = myIni.Read("Edition", textBox1.Text);
                    Properties.Settings.Default.Save();
                    File.Delete(Application.StartupPath + @"\config\activation.ini");
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
    }
}
