﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace furMix
{
    public partial class NetSettings : Form
    {
        public NetSettings()
        {
            InitializeComponent();
            IPTxt.Text = "IP: " + GetLocalIPAddress();
            PortTxt.Text = Properties.Settings.Default.NetPort.ToString();
            PassTxt.Text = "Password: " + Main.pass;
        }

        public static string GetLocalIPAddress()
        {
            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostEntry(hostName).AddressList[2].ToString();
            return myIP;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.NetPort = Convert.ToInt32(PortTxt.Text);
                Properties.Settings.Default.Save();
                //Main.StartServer();
                Close();
            }
            catch
            {
                MessageBox.Show("Port cannot be converted into number. Check port number and try again.", "Server error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
