using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using SimpleHttp;
using System.Diagnostics;

namespace furMix.Network.WebInterface
{
    public class WebServer
    {
        HttpListener listener = new HttpListener();
        BackgroundWorker api = new BackgroundWorker();
        public bool IsRunning { get => api.IsBusy; }
        public int Port { get; }
        public List<string> MediaList { get; } = new List<string>();
        public int SelectedIndex { get; set; }
        public event OnItemClickedEventHandler OnItemClicked;

        public WebServer(int port)
        {
            Port = port;
            api.DoWork += Api_DoWork;
            api.WorkerSupportsCancellation = true;
            listener.Prefixes.Add("http://+:" + Port + "/");
        }

        public delegate void OnItemClickedEventHandler(object sender, ItemEventArgs e);

        public static void OpenPorts(int port)
        {
            Process p = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = Environment.CurrentDirectory + @"\utils\ports.bat",
                    Arguments = port  + " " + Environment.UserDomainName + @"\" + Environment.UserName,
                    Verb = "runas",
                    UseShellExecute = true
                }
            };
            p.Start();
            p.WaitForExit();
        }

        public void RunServer()
        {
            api.RunWorkerAsync();
        }

        private void Api_DoWork(object sender, DoWorkEventArgs e)
        {
            Route.Add("/api/{id}", (request, response, arguments) =>
            {
                int index = Convert.ToInt32(arguments["id"].Substring(0, arguments["id"].Length - 1));
                ItemEventArgs args = new ItemEventArgs(index, MediaList[index]);
                OnItemClicked.Invoke(this, args);
                response.AsRedirect("http://" + GetLocalIPAddress() + ":" + Port + "/");
            });
            Route.Add("/", (request, response, arguments) =>
            {
                response.StatusCode = 200;
                string ending = "   </div>\n</body>\n</html>";
                string page = Properties.Resources.WebPage;
                for (int i = 0; i < MediaList.Count; i++)
                {
                    if (i == SelectedIndex)
                    {
                        string str = MediaList[i];
                        page += "   <form action =\"http://" + GetLocalIPAddress() + ":" + Port + "/api/" + i.ToString() + "\" method=\"get\">\n" +
                        "       <input type=\"submit\" value=\"" + str + "\" style=\"background-color: green\" />\n" +
                        "   </form>\n<br/>\n";
                    }
                    else
                    {
                        string str = MediaList[i];
                        page += "   <form action =\"http://" + GetLocalIPAddress() + ":" + Port + "/api/" + i.ToString() + "\" method=\"get\">\n" +
                        "       <input type=\"submit\" value=\"" + str + "\" />\n" +
                        "   </form>\n<br/>\n";
                    }
                }
                page += ending;
                response.AsText(page);
            });
            HttpServer.ListenAsync(Port, CancellationToken.None, Route.OnHttpRequestAsync).Wait();
        }

        public static string GetLocalIPAddress()
        {
            string hostName = Dns.GetHostName();
            var myIPs = Dns.GetHostEntry(hostName).AddressList;
            string myIP = "";
            foreach (IPAddress IP in myIPs)
            {
                if (IP.ToString().Contains("192.168")) myIP = IP.ToString();
            }
            if (myIP == "")
            {
                foreach (IPAddress IP in myIPs)
                {
                    if (IP.ToString().Contains(".")) myIP = IP.ToString();
                }
            }
            if (myIP == "") myIP = myIPs[0].ToString();
            return myIP;
        }
    }
}
