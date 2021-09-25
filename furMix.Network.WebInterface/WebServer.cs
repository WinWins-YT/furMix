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
        BackgroundWorker server = new BackgroundWorker();
        BackgroundWorker api = new BackgroundWorker();
        public bool IsRunning { get => server.IsBusy; }
        public int Port { get; }
        public int PortAPI { get; }
        public List<string> MediaList { get; } = new List<string>();
        public int SelectedIndex { get; set; }
        public event OnItemClickedEventHandler OnItemClicked;

        public WebServer(int port, int portapi)
        {
            Port = port;
            PortAPI = portapi;
            server.DoWork += Server_DoWork;
            server.WorkerSupportsCancellation = true;
            api.DoWork += Api_DoWork;
            api.WorkerSupportsCancellation = true;
            listener.Prefixes.Add("http://+:" + Port + "/");
        }

        public delegate void OnItemClickedEventHandler(object sender, ItemEventArgs e);

        public static void ClosePort(int port)
        {
            Process p1 = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "netsh",
                    Arguments = "http delete urlacl url = \"http://+:" + port + "/\" user = everyone",
                    Verb = "runas"
                }
            };
            Process p2 = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "netsh",
                    Arguments = "http delete urlacl url = \"http://*:" + port + "/\" user = everyone",
                    Verb = "runas"
                }
            };
            p1.Start();
            p2.Start();
        }

        public static void OpenPort(int port)
        {
            Process p1 = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "netsh",
                    Arguments = "http add urlacl url = \"http://+:" + port + "/\" user = everyone",
                    Verb = "runas"
                }
            };
            Process p2 = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "netsh",
                    Arguments = "http add urlacl url = \"http://*:" + port + "/\" user = everyone",
                    Verb = "runas"
                }
            };
            p1.Start();
            p2.Start();
        }

        public void RunServer()
        {
            server.RunWorkerAsync();
            api.RunWorkerAsync();
        }

        public void StopServer()
        {
            server.CancelAsync();
        }

        private void Api_DoWork(object sender, DoWorkEventArgs e)
        {
            Route.Add("/api/{id}", (request, response, arguments) =>
            {
                int index = Convert.ToInt32(arguments["id"].Substring(0, arguments["id"].Length - 1));
                ItemEventArgs args = new ItemEventArgs(index, MediaList[index]);
                OnItemClicked.Invoke(this, args);
            });
            HttpServer.ListenAsync(PortAPI, CancellationToken.None, Route.OnHttpRequestAsync).Wait();
        }

        private void Server_DoWork(object sender, DoWorkEventArgs e)
        {
            listener.Start();
            while (!server.CancellationPending)
            {
                var context = listener.GetContext();
                string ending = "   </div>\n</body>\n</html>";
                string response = Properties.Resources.WebPage;
                for (int i = 0; i < MediaList.Count; i++)
                {
                    if (i == SelectedIndex)
                    {
                        string str = MediaList[i];
                        response += "   <form action =\"http://" + GetLocalIPAddress() + ":" + PortAPI + "/api/" + i.ToString() + "\" method=\"get\">\n" +
                        "       <input type=\"submit\" value=\"" + str + "\" style=\"background-color: green\" />\n" +
                        "   </form>\n<br/>\n";
                    }
                    else
                    {
                        string str = MediaList[i];
                        response += "   <form action =\"http://" + GetLocalIPAddress() + ":" + PortAPI + "/api/" + i.ToString() + "\" method=\"get\">\n" +
                        "       <input type=\"submit\" value=\"" + str + "\" />\n" +
                        "   </form>\n<br/>\n";
                    }
                }
                response += ending;
                context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(response);
                context.Response.StatusCode = 200;
                using (Stream output = context.Response.OutputStream) {
                    using (StreamWriter sw = new StreamWriter(output))
                    {
                        sw.Write(response);
                    }
                }
            }
            listener.Stop();
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
