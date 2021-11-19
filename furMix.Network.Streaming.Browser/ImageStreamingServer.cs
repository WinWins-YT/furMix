using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace furMix.Network.Streaming.Browser
{

    /// <summary>
    /// Provides a streaming server that can be used to stream any images source
    /// to any client.
    /// </summary>
    public class ImageStreamingServer:IDisposable
    {

        private List<Socket> _Clients;
        private Thread _Thread;
        private Socket Server;

        public ImageStreamingServer():this(Screen.Snapshots(System.Windows.Forms.Screen.PrimaryScreen,true))
        {

        }

        public ImageStreamingServer(System.Windows.Forms.Screen screen):this(Screen.Snapshots(screen, false))
        {

        }

        public ImageStreamingServer(System.Windows.Forms.Control control):this(Screen.ControlSnapshots(control))
        {

        }

        public ImageStreamingServer(IEnumerable<Image> imagesSource)
        {

            _Clients = new List<Socket>();
            _Thread = null;

            this.ImagesSource = imagesSource;
            this.Interval = 50;

        }


        /// <summary>
        /// Gets or sets the source of images that will be streamed to the 
        /// any connected client.
        /// </summary>
        public IEnumerable<Image> ImagesSource { get; set; }

        /// <summary>
        /// Gets or sets the interval in milliseconds (or the delay time) between 
        /// the each image and the other of the stream (the default is . 
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// Gets a collection of client sockets.
        /// </summary>
        public IEnumerable<Socket> Clients { get { return _Clients; } }

        /// <summary>
        /// Returns the status of the server. True means the server is currently 
        /// running and ready to serve any client requests.
        /// </summary>
        public bool IsRunning { get { return (_Thread != null && _Thread.IsAlive); } }

        /// <summary>
        /// Starts the server to accepts any new connections on the specified port.
        /// </summary>
        /// <param name="port"></param>
        public void Start(int port)
        {

            lock (this)
            {
                _Thread = new Thread(new ParameterizedThreadStart(ServerThread));
                _Thread.IsBackground = true;
                _Thread.Start(port);
            }

        }

        /// <summary>
        /// Starts the server to accepts any new connections on the default port (8080).
        /// </summary>
        public void Start()
        {
            this.Start(8080);
        }

        public void Stop()
        {
            if (this.IsRunning)
            {
                try
                {
                    Server.Close();
                    _Thread = null;
                    lock (_Clients)
                    {

                        foreach (var s in _Clients)
                        {
                            try
                            {
                                s.Close();
                            }
                            catch { }
                        }
                        _Clients.Clear();

                    }
                    //_Thread.Join();
                    //_Thread.Abort();
                }
                finally
                {

                    lock (_Clients)
                    {
                        
                        foreach (var s in _Clients)
                        {
                            try
                            {
                                s.Close();
                            }
                            catch { }
                        }
                        _Clients.Clear();

                    }

                    _Thread = null;
                }
            }
        }

        /// <summary>
        /// This the main thread of the server that serves all the new 
        /// connections from clients.
        /// </summary>
        /// <param name="state"></param>
        private void ServerThread(object state)
        {

            try
            {
                Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                Server.Bind(new IPEndPoint(IPAddress.Any,(int)state));
                Server.Listen(10);

                System.Diagnostics.Debug.WriteLine(string.Format("Server started on port {0}.", state));
                foreach (Socket client in Server.IncommingConnectoins())
                {
                    if (_Thread.ThreadState == ThreadState.AbortRequested) break;
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ClientThread), client);
                }
            
            }
            catch { }
            finally
            {
                lock (_Clients)
                {

                    foreach (var s in _Clients)
                    {
                        try
                        {
                            s.Close();
                        }
                        catch { }
                    }
                    _Clients.Clear();

                }

                _Thread = null;
            }

            this.Stop();
        }

        /// <summary>
        /// Each client connection will be served by this thread.
        /// </summary>
        /// <param name="client"></param>
        private void ClientThread(object client)
        {

            Socket socket = (Socket)client;
            System.Diagnostics.Debug.WriteLine(string.Format("New client from {0}",socket.RemoteEndPoint.ToString()));

            lock (_Clients)
                _Clients.Add(socket);

            try
            {
                using (MjpegWriter wr = new MjpegWriter(new NetworkStream(socket, true)))
                {

                    // Writes the response header to the client.
                    wr.WriteHeader();

                    // Streams the images from the source to the client.
                    foreach (var imgStream in Screen.Streams(this.ImagesSource))
                    {
                        if (this.Interval > 0)
                            Thread.Sleep(this.Interval);

                        wr.Write(imgStream);
                    }

                }
            }
            catch { }
            finally
            {
                lock (_Clients)
                {
                    _Clients.Remove(socket);
                }
            }
        }


        #region IDisposable Members

        public void Dispose()
        {
            this.Stop();
        }

        #endregion
    }

    static class SocketExtensions
    {

        public static IEnumerable<Socket> IncommingConnectoins(this Socket server)
        {
            while(true)
                yield return server.Accept();
        }

    }


    static class Screen
    {


        public static IEnumerable<Image> Snapshots()
        {
            return Screen.Snapshots(System.Windows.Forms.Screen.PrimaryScreen,true);
        }

        /// <summary>
        /// Returns a 
        /// </summary>
        /// <param name="delayTime"></param>
        /// <returns></returns>
        public static IEnumerable<Image> Snapshots(System.Windows.Forms.Screen screen, bool showCursor)
        {
            int width = screen.Bounds.Width;
            int height = screen.Bounds.Height;
            Size size = new Size(screen.Bounds.Width, screen.Bounds.Height);
            
            Bitmap srcImage = new Bitmap(size.Width, size.Height);
            Graphics srcGraphics = Graphics.FromImage(srcImage);

            bool scaled = (width != size.Width || height != size.Height);

            Bitmap dstImage = srcImage;
            Graphics dstGraphics = srcGraphics;

            if(scaled)
            {
                dstImage = new Bitmap(width, height);
                dstGraphics = Graphics.FromImage(dstImage);
            }

            Rectangle src = new Rectangle(0, 0, size.Width, size.Height);
            Rectangle dst = new Rectangle(0, 0, width, height);
            Size curSize = new Size(32, 32);

            while (true)
            {
                srcGraphics.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, size);

                if (showCursor)
                    Cursors.Default.Draw(srcGraphics,new Rectangle(Cursor.Position,curSize));

                if (scaled)
                    dstGraphics.DrawImage(srcImage, dst, src, GraphicsUnit.Pixel);
       
                yield return dstImage;

            }

            srcGraphics.Dispose();
            dstGraphics.Dispose();

            srcImage.Dispose();
            dstImage.Dispose();

            yield break;
        }

        public static IEnumerable<Image> ControlSnapshots(Control control)
        {
            int width = control.Width;
            int height = control.Height;
            Size size = new Size(control.Width, control.Height);

            Bitmap srcImage = new Bitmap(size.Width, size.Height);
            Graphics srcGraphics = Graphics.FromImage(srcImage);

            bool scaled = (width != size.Width || height != size.Height);

            Bitmap dstImage = srcImage;
            Graphics dstGraphics = srcGraphics;

            if (scaled)
            {
                dstImage = new Bitmap(width, height);
                dstGraphics = Graphics.FromImage(dstImage);
            }

            Rectangle src = new Rectangle(0, 0, size.Width, size.Height);
            Rectangle dst = new Rectangle(0, 0, width, height);
            Size curSize = new Size(32, 32);
            while (true)
            {
                dstImage = control.DrawToImage();

                yield return dstImage;

            }
        }

        internal static IEnumerable<MemoryStream> Streams(this IEnumerable<Image> source)
        {
            MemoryStream ms = new MemoryStream();

            foreach (var img in source)
            {
                ms.SetLength(0);
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                yield return ms;
            }

            ms.Close();
            ms = null;

            yield break;
        }

    }
}
