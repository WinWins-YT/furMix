using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace furMix
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.ThreadException += Application_ThreadException;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                var path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
                FileInfo fi = new FileInfo(path);
                if (!Directory.Exists(fi.DirectoryName)) Directory.CreateDirectory(fi.DirectoryName);
                if (Debugger.IsAttached)
                {
                    string version = Properties.Settings.Default.Version;
                    int build = Convert.ToInt32(version.Split('.')[2]);
                    Properties.Settings.Default.Version = version.Split('.')[0] + "." + version.Split('.')[1] + "." + ++build;
                    Properties.Settings.Default.Save();
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Splash());
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Error error = new Error();
            error.ShowError(e.Exception);
            error.ShowDialog();
            error.Dispose();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Error error = new Error();
            error.ShowError(e.ExceptionObject as Exception);
            error.ShowDialog();
            error.Dispose();
        }
    }
}
