using furMix.Utilities;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace furMix
{
    public partial class Activate : Form
    {
        DataTable dt = null;
        bool offline;
        bool trial = false;
        public Activate()
        {
            InitializeComponent();
            Log.LogEvent("Activate dialog opened");
            var connect = new Connect();
            connect.Show();
            try
            {
                Task t = Task.Run(() => SQLWrapper.Connect());
                //t.Start();
                t.Wait();
                dt = SQLWrapper.GetActivationData();
                connect.Close();
                connect.Dispose();
                if (Properties.Settings.Default.Trial)
                {
                    label5.ForeColor = Color.Gray;
                    label5.Cursor = Cursors.Default;
                }
                Log.LogEvent("Connected to server");
            }
            catch (Exception ex)
            {
                Log.LogEvent("Connection error");
                Log.LogEvent(ex.Message);
                connect.Close();
                connect.Dispose();
                offline = true;
                MessageBox.Show("Server error. Try enter only offline product key, that you were supplied after buying, without name", "Offline activation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Enabled = false;
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
            else if (dt != null)
            {
                if (IsExists(textBox2.Text, "Key") && IsExists(textBox1.Text, "Login") && textBox1.Text != "" && textBox2.Text != "")
                {
                    int row = GetRowID(textBox2.Text, "Key");
                    Properties.Settings.Default.Name = textBox1.Text;
                    Properties.Settings.Default.Activated = true;
                    Properties.Settings.Default.Trial = false;
                    Properties.Settings.Default.Edition = dt.Rows[row]["Edition"].ToString();
                    Properties.Settings.Default.Save();
                    Close();
                }
                else
                {
                    MessageBox.Show("This product key is not valid. Try again.", "Activation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int GetRowID(string text, string column)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][column].ToString() == text) return i;
            }
            return -1;
        }

        private bool IsExists(string text, string column)
        {
            foreach (DataRow row in dt.Rows) if (row[column].ToString() == text) return true;
            return false;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Process()
            {
                StartInfo = new ProcessStartInfo("https://danimat.ddns.net/furMix/Purchase")
            }.Start();
        }
    }
}
