using FluentFTP;
using furMix.DialogBoxes;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace furMix.Utilities
{
    class Log
    {
        private static string FileName;

        public static void LogEvent(string contents, LogType type = LogType.INFO)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            string log = File.ReadAllText(FileName);
            string log1 = string.Format("[{0}] [{1}] {2}\n", date, type.ToString(), contents);
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

        public enum LogType
        {
            DEBUG,
            INFO,
            WARNING,
            ERROR
        }

        public static void SendBug()
        {
            SendBug sb = new SendBug();
            sb.Show();
            Task.Delay(1000).Wait();
            sb.Status.Text = "Connecting to server...";
            Task t = new Task(() => SQLWrapper.Connect());
            t.Start();
            t.Wait();
            sb.Status.Text = "Sending report...";
            t = new Task(() => SQLWrapper.WriteLogFile(Properties.Settings.Default.Name, new FileStream(FileName, FileMode.Open, FileAccess.Read)));
            t.Start();
            t.Wait();
            MessageBox.Show("Thank you for helping make furMix even better", "Bug report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sb.Close();
            sb.Dispose();
        }
    }
}
