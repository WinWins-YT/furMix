using FluentFTP;
using furMix.DialogBoxes;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace furMix.Utilities
{
    class Log
    {
        private static string FileName;

        public static void LogEvent(string contents)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            string log = File.ReadAllText(FileName);
            string log1 = "[" + date + "] " + contents + "\n";
            File.WriteAllText(FileName, log + log1);
        }

        public static void CreateLog()
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\DaniMat Corp.\furMix\logs")) Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\DaniMat Corp.\furMix\logs");
            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\DaniMat Corp.\furMix\logs", "*.log");
            if (files.Length >= 7)
            {
                File.Delete(files[0]);
            }
            string date = DateTime.Now.ToString("yyyyMMddHHmm");
            string date1 = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            FileName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\DaniMat Corp.\furMix\logs\log" + date + ".log";
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\DaniMat Corp.\furMix\logs\log" + date + ".log", "[" + date1 + "] Log created\n");
        }

        public static bool isCreated => FileName != null;

        public static void SendBug()
        {
            SendBug sb = new SendBug();
            sb.Show();
            Thread.Sleep(500);
            sb.Status.Text = "Creating FTP object...";
            FtpClient ftp = new FtpClient();
            ftp.Host = "danimat.ddns.net";
            ftp.Credentials = new System.Net.NetworkCredential("furMix", "furMix");
            Thread.Sleep(200);
            sb.Status.Text = "Trying to connect...";
            Thread.Sleep(500);
            try
            {
                ftp.Connect();
            }
            catch
            {
                sb.Status.Text = "Error connecting to server";
                Thread.Sleep(1000);
                sb.Close();
                sb.Dispose();
                return;
            }
            sb.Status.Text = "Successfully connected";
            Thread.Sleep(1000);
            sb.Status.Text = "Sending bug report...";
            Thread.Sleep(1000);
            string date = DateTime.Now.ToString("yyyyMMddHHmmss");
            try
            {
                ftp.UploadFile(FileName, "/bugreports/" + Properties.Settings.Default.Name + "_" + date + ".log", FtpRemoteExists.Overwrite);
            }
            catch
            {
                sb.Status.Text = "Error sending bug report";
                Thread.Sleep(1000);
                sb.Close();
                sb.Dispose();
                return;
            }
            sb.Status.Text = "Successfully uploaded!";
            Thread.Sleep(1000);
            MessageBox.Show("Thank you for helping make furMix even better");
            sb.Close();
            sb.Dispose();
        }
    }
}
