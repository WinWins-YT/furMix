using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using furMix.DialogBoxes;
using furMix.Utilities;
using furMix.Network.Streaming.Browser;
using furMix.Network.WebInterface;

namespace furMix
{
    public partial class Main : Form
    {
        #region Fields
        string filepath;
        bool full, playing, playing1, loop, mute, net, enabled, recording;
        int type;
        int port, scrindex, tip = 0;
        int webport;
        int typeshow;
        int selected;
        DateTime recStart;
        Player pl1 = new Player();
        Color color;
        List<string> filepath1 = new List<string>();
        List<int> type1 = new List<int>();
        List<Color> color1 = new List<Color>();
        List<string> photofolder = new List<string>();
        List<string> photoshow = new List<string>();
        List<string> presfolder;
        List<string> presshow;
        public static string pass;
        public static bool spectr;
        Analyzer anal;
        Graphics gr;
        Bitmap bmp;
        ImageStreamingServer server;
        WebServer webServer;
        Recorder recorder;
        #endregion

        public Main()
        {
            InitializeComponent();
            try
            {
                Preview.settings.mute = true;
                pl1.Video.settings.mute = true;
                if (!Splash.trial)
                {
                    VerTxt.Text = "furMix 2021. Build " + Properties.Settings.Default.Version + ". Beta 4.\n For testing purposes only.";
                }
                else
                {
                    VerTxt.Text = "furMix 2021 Trial. Build " + Properties.Settings.Default.Version + ". Beta 4.\n For testing purposes only.";
                }
                pass = RandomString(6);
                anal = new Analyzer(volumeLevel);
                anal.Enable = true;
                scrindex = Properties.Settings.Default.Screen;
                port = Properties.Settings.Default.NetPort;
                webport = Properties.Settings.Default.WebPort;
                if (!Properties.Settings.Default.Welcome)
                {
                    MessageBox.Show("Now furMix will open ports for remote control through network. It will require administrator privileges.", "Ports warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Log.LogEvent("Opening ports...");
                    WebServer.OpenPorts(webport);
                }
                if (Properties.Settings.Default.WebServer)
                {
                    webServer = new WebServer(webport);
                    webServer.OnItemClicked += WebServer_OnItemClicked;
                    webServer.RunServer();
                }
                Screen[] sc = Screen.AllScreens;
                if (sc.Length > 1)
                {
                    gr = CreateGraphics();
                    bmp = new Bitmap(sc[scrindex].WorkingArea.Width, sc[scrindex].WorkingArea.Height, gr);
                }
                else
                {
                    Log.LogEvent("Only 1 monitor found", Log.LogType.WARNING);
                    fullbtn.Enabled = false;
                    //MessageBox.Show("Only 1 monitor found. To completely use furMix you need at least 2 monitors", "furMix Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (Environment.GetCommandLineArgs().Length > 1)
                {
                    string filename = Environment.GetCommandLineArgs()[1];
                    OpenFile(filename);
                }
                if (Properties.Settings.Default.Edition == "Professional Edition" || Properties.Settings.Default.Edition == "Misha Ter Edition" || Properties.Settings.Default.Edition == "Misha Pidor Edition")
                {
                    NetworkBtn.Visible = true;
                }
                using (SoundPlayer sp = new SoundPlayer())
                {
                    sp.Stream = Properties.Resources.hoy;
                    sp.Play();
                }
                if (!Properties.Settings.Default.Welcome)
                {
                    Welcome();
                }
                CheckForIllegalCrossThreadCalls = false;
                Log.LogEvent("furMix started");
                Log.LogEvent("furMix v." + Properties.Settings.Default.Version);
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void WebServer_OnItemClicked(object sender, ItemEventArgs e)
        {
            int index = e.SelectedIndex;
            selected = index;
            type = type1[index];
            if (type == 1 || type == 2) filepath = filepath1[index];
            else if (type == 3) filepath = filepath1[index];
            else if (type == 0) color = color1[index];
            else if (type == 4) filepath = filepath1[index];
            ShowBtn_Click(this, new EventArgs());
        }

        private void Welcome()
        {
            if (tip == 0)
            {
                Controls.Add(TipBack);
                Controls.Add(TipTitle);
                Controls.Add(TipText);
                TipBack.BringToFront();
                TipTitle.BringToFront();
                TipText.BringToFront();
            }
            else if (tip == 1)
            {
                TipBack.Location = new Point(EnableBtn.Left + EnableBtn.Width + 10, EnableBtn.Top + EnableBtn.Height + 10);
                TipTitle.Location = new Point(TipBack.Left + 23, TipBack.Top + 19);
                TipText.Location = new Point(TipBack.Left + 24, TipBack.Top + 43);
                TipTitle.Text = "Enable button";
                TipText.Text = "This button enables video engine, open new window with live screen. To start using furMix, you must click this button";
                TipBack.BringToFront();
                TipTitle.BringToFront();
                TipText.BringToFront();
            }
            else if (tip == 2)
            {
                TipBack.Location = new Point(fullbtn.Left + fullbtn.Width + 10, fullbtn.Top + fullbtn.Height + 10);
                TipTitle.Location = new Point(TipBack.Left + 23, TipBack.Top + 19);
                TipText.Location = new Point(TipBack.Left + 24, TipBack.Top + 43);
                TipTitle.Text = "Fullscreen button";
                TipText.Text = "This button grabs your second monitor (you can change it in settings) for showing content, that you supplied";
                TipBack.BringToFront();
                TipTitle.BringToFront();
                TipText.BringToFront();
            }
            else if (tip == 3)
            {
                TipBack.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
                TipBack.Location = new Point(AddMediaBtn.Left + AddMediaBtn.Width - 10, AddMediaBtn.Top - AddMediaBtn.Height - TipBack.Height + 10);
                TipTitle.Location = new Point(TipBack.Left + 23, TipBack.Top + 19);
                TipText.Location = new Point(TipBack.Left + 24, TipBack.Top + 43);
                TipTitle.Text = "Add media button";
                TipText.Text = "This button gets content (photos, videos and color) to show on second screen";
                TipBack.BringToFront();
                TipTitle.BringToFront();
                TipText.BringToFront();
            }
            else if (tip == 4)
            {
                TipBack.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
                TipBack.Location = new Point(listView1.Left + listView1.Width / 2 - 10, listView1.Top + listView1.Height / 2 - 10);
                TipTitle.Location = new Point(TipBack.Left + 23, TipBack.Top + 19);
                TipText.Location = new Point(TipBack.Left + 24, TipBack.Top + 43);
                TipTitle.Text = "Content list";
                TipText.Text = "This list contains photos and videos, that you added through Add media button";
                TipBack.BringToFront();
                TipTitle.BringToFront();
                TipText.BringToFront();
            }
            else if (tip == 5)
            {
                TipBack.Location = new Point(Preview.Left + Preview.Width - 10, Preview.Top + Preview.Height - 10);
                TipTitle.Location = new Point(TipBack.Left + 23, TipBack.Top + 19);
                TipText.Location = new Point(TipBack.Left + 24, TipBack.Top + 43);
                TipTitle.Text = "Preview";
                TipText.Text = "This window shows content before showing on second screen";
                TipBack.BringToFront();
                TipTitle.BringToFront();
                TipText.BringToFront();
            }
            else if (tip == 6)
            {
                TipBack.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                TipBack.Location = new Point(LivePic.Left - 10 - TipBack.Width, LivePic.Top + LivePic.Height + 10);
                TipTitle.Location = new Point(TipBack.Left + 23, TipBack.Top + 19);
                TipText.Location = new Point(TipBack.Left + 24, TipBack.Top + 43);
                TipTitle.Text = "Live";
                TipText.Text = "This window shows content on second screen";
                TipBack.BringToFront();
                TipTitle.BringToFront();
                TipText.BringToFront();
            }
            else if (tip == 7)
            {
                TipBack.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                TipBack.Location = new Point(cutbtn.Left + cutbtn.Width + 10, cutbtn.Top + cutbtn.Height + 10);
                TipTitle.Location = new Point(TipBack.Left + 23, TipBack.Top + 19);
                TipText.Location = new Point(TipBack.Left + 24, TipBack.Top + 43);
                TipTitle.Text = "Show button";
                TipText.Text = "This button shows content on second screen";
                TipBack.BringToFront();
                TipTitle.BringToFront();
                TipText.BringToFront();
            }
            else if (tip == 8)
            {
                TipBack.Location = new Point(volumeLevel.Left + volumeLevel.Width, volumeLevel.Top + volumeLevel.Height);
                TipTitle.Location = new Point(TipBack.Left + 23, TipBack.Top + 19);
                TipText.Location = new Point(TipBack.Left + 24, TipBack.Top + 43);
                TipTitle.Text = "Sound analyzer";
                TipText.Text = "This is two channel volume analyzer. Double click here to open advanced sound analyzer";
                TipBack.BringToFront();
                TipTitle.BringToFront();
                TipText.BringToFront();
            }
            else if (tip == 9)
            {
                TipBack.Location = new Point(511, 423);
                TipTitle.Location = new Point(TipBack.Left + 23, TipBack.Top + 19);
                TipText.Location = new Point(TipBack.Left + 24, TipBack.Top + 43);
                TipTitle.Text = "How to use";
                TipText.Text = "Click Enable, add media, click on it in content list, it begins to play in preview window. Click Show, to show it on live screen.";
                TipBack.BringToFront();
                TipTitle.BringToFront();
                TipText.BringToFront();
            }
            else if (tip == 10)
            {
                TipBack.Location = new Point(511, 423);
                TipTitle.Location = new Point(TipBack.Left + 23, TipBack.Top + 19);
                TipText.Location = new Point(TipBack.Left + 24, TipBack.Top + 43);
                TipTitle.Text = "Thank you";
                TipText.Text = "Thank you for choosing and using furMix. We hope, that you will enjoy this product";
                TipBack.BringToFront();
                TipTitle.BringToFront();
                TipText.BringToFront();
            }
            else if (tip == 11)
            {
                Controls.Remove(TipBack);
                Controls.Remove(TipText);
                Controls.Remove(TipTitle);
                Properties.Settings.Default.Welcome = true;
                Properties.Settings.Default.Save();
            }
        }

        private void Server_DataReceived(string ID, byte[] Data)
        {
            try
            {
                MessageBox.Show("ID: " + ID + "\nData: " + Encoding.ASCII.GetString(Data), "Data received", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (Encoding.ASCII.GetString(Data).Substring(0, 4) == "Pass")
                {
                    if (Encoding.ASCII.GetString(Data).Substring(4, Encoding.ASCII.GetString(Data).Length - 4) == pass)
                    {
                        //server.SendData("Password", Encoding.ASCII.GetBytes("OK"));
                        NetBtn.BackColor = Color.Green;
                        //NetTimer.Enabled = true;
                    }
                    else
                    {
                        //server.SendData("Password", Encoding.ASCII.GetBytes("Wrong"));
                    }
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void Server_lostConnection(string id)
        {
            
        }

        private void Server_onConnection(string id)
        {
            MessageBox.Show("ID: " + id);
        }

        public static string RandomString(int length)
        {
            try
            {
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string(Enumerable.Repeat(chars, length)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
                return null;
            }
        }

        public void StartServer()
        {
            try
            {
                //server = new Host(port);
                //server.StartConnection();
                NetBtn.BackColor = Color.Red;
                //while (!server.Listening);
                NetBtn.BackColor = Color.Orange;
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void ShowFurry()
        {
            try
            {
                Screen[] sc;
                sc = Screen.AllScreens;
                if (sc.Length > 1)
                {
                    pl1.Left = sc[scrindex].Bounds.Width;
                    pl1.Top = sc[scrindex].Bounds.Height;
                    pl1.Location = sc[scrindex].Bounds.Location;
                    pl1.WindowState = FormWindowState.Maximized;
                    pl1.FormBorderStyle = FormBorderStyle.None;
                    pl1.Show();
                }
                else
                {
                    throw new MonitorNotFound("Only 1 monitor was found. To use furMix, you need at least 2 monitors");
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void ShowBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Log.LogEvent("Cut button clicked");
                Preview.Ctlcontrols.stop();
                typeshow = type;
                switch (type)
                {
                    case 0:
                        pl1.Video.close();
                        Bitmap bmp = new Bitmap(Screen.AllScreens[scrindex].Bounds.Width, Screen.AllScreens[scrindex].Bounds.Height);
                        Graphics g = Graphics.FromImage(bmp);
                        g.FillRectangle(new SolidBrush(color), new Rectangle(0, 0, Screen.AllScreens[scrindex].Bounds.Width, Screen.AllScreens[scrindex].Bounds.Height));
                        bmp.Save(Path.GetTempPath() + @"\color.png");
                        pl1.Video.URL = Path.GetTempPath() + @"\color.png";
                        pl1.Video.Ctlcontrols.play();
                        loop = false;
                        loopbtn_Click(sender, e);
                        playbtn.Visible = false;
                        timelineShow.Visible = false;
                        timeShow.Visible = false;
                        break;
                    case 1:
                        pl1.Video.URL = filepath;
                        pl1.Video.Ctlcontrols.play();
                        playing = false;
                        button4_Click(sender, e);
                        playbtn.Visible = true;
                        timelineShow.Visible = true;
                        timeShow.Visible = true;
                        timelineShow.Maximum = Convert.ToInt32(pl1.Video.currentMedia.durationString.Substring(0, 2)) * 60 + Convert.ToInt32(pl1.Video.currentMedia.durationString.Substring(3, 2));
                        showTimer.Enabled = true;
                        break;
                    case 2:
                        pl1.Video.URL = filepath;
                        pl1.Video.Ctlcontrols.play();
                        playing = false;
                        button4_Click(sender, e);
                        loop = false;
                        loopbtn_Click(sender, e);
                        playbtn.Visible = false;
                        timelineShow.Visible = false;
                        timeShow.Visible = false;
                        break;
                    case 3:
                        playing = false;
                        button4_Click(sender, e);
                        loop = false;
                        loopbtn_Click(sender, e);
                        FileInfo[] files = new DirectoryInfo(filepath).GetFiles("*.bmp");
                        FileInfo[] files1 = new DirectoryInfo(filepath).GetFiles("*.jpg");
                        FileInfo[] files2 = new DirectoryInfo(filepath).GetFiles("*.png");
                        photoshow.Clear();
                        foreach (FileInfo fileinfo in files)
                        {
                            photoshow.Add(fileinfo.FullName);
                        }
                        foreach (FileInfo fileinfo in files1)
                        {
                            photoshow.Add(fileinfo.FullName);
                        }
                        foreach (FileInfo fileinfo in files2)
                        {
                            photoshow.Add(fileinfo.FullName);
                        }
                        timelineShow.Value = 0;
                        timelineShow.Maximum = photoshow.Count - 1;
                        timeShow.Text = "1/" + (timelineShow.Maximum + 1);
                        pl1.Video.URL = photofolder[0];
                        pl1.Video.Ctlcontrols.play();
                        playbtn.Visible = false;
                        timelineShow.Visible = true;
                        timeShow.Visible = true;
                        break;
                    case 4:
                        playing = false;
                        button4_Click(sender, e);
                        loop = false;
                        loopbtn_Click(sender, e);
                        presshow = presfolder;
                        timelineShow.Value = 0;
                        timelineShow.Maximum = presshow.Count - 1;
                        timeShow.Text = "1/" + (timelineShow.Maximum + 1);
                        pl1.Video.URL = presshow[0];
                        pl1.Video.Ctlcontrols.play();
                        playbtn.Visible = false;
                        timelineShow.Visible = true;
                        timeShow.Visible = true;
                        break;
                }
                typeshow = type;
                webServer.SelectedIndex = selected;
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void FullBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Log.LogEvent("Fullscreen clicked");
                if (full)
                {
                    //HideFurry();
                    pl1.WindowState = FormWindowState.Normal;
                    pl1.FormBorderStyle = FormBorderStyle.Sizable;
                    pl1.Size = new Size(640, 480);
                    pl1.Location = Location;
                    full = false;
                    //timer1.Enabled = false;
                    fullbtn.BackColor = Color.FromArgb(100, 100, 100);
                }
                else
                {
                    //timer1.Enabled = true;
                    ShowFurry();
                    full = true;
                    fullbtn.BackColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void Enable_Click(object sender, EventArgs e)
        {
            Log.LogEvent("Enable button clicked");
            if (!enabled)
            {
                pl1.FormBorderStyle = FormBorderStyle.Sizable;
                pl1.Size = new Size(640, 480);
                pl1.Location = Location;
                pl1.Show();
                timer1.Enabled = true;
                Screen[] sc = Screen.AllScreens;
                if (sc.Length > 1) fullbtn.Enabled = true;
                NetworkBtn.Enabled = true;
                cutbtn.Enabled = true;
                recBtn.Enabled = true;
                enabled = true;
                EnableBtn.BackColor = Color.Green;
            }
            else
            {
                if (full)
                {
                    full = false;
                    fullbtn.BackColor = Color.FromArgb(100, 100, 100);
                }
                if (recording)
                {
                    recording = false;
                    recorder.Dispose();
                    recTimer.Enabled = false;
                    recBtn.BackColor = Color.FromArgb(100, 100, 100);
                    recTimeTxt.Visible = false;
                }
                pl1.Video.Ctlcontrols.stop();
                EnableBtn.BackColor = Color.FromArgb(100, 100, 100);
                timer1.Enabled = false;
                fullbtn.Enabled = false;
                NetworkBtn.Enabled = false;
                cutbtn.Enabled = false;
                recBtn.Enabled = false;
                if (net) NetworkBtn_Click(this, e);
                Bitmap bmpimg = new Bitmap(LivePic.Width, LivePic.Height);
                var graph = Graphics.FromImage(bmpimg);
                graph.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, bmpimg.Width, bmp.Height));
                LivePic.Image = bmpimg;
                enabled = false;
                pl1.Hide();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //Screen[] sc = Screen.AllScreens;
                //gr = Graphics.FromImage(bmp);
                //gr.CopyFromScreen(sc[scrindex].Bounds.X, sc[scrindex].Bounds.Y, 0, 0, new Size(sc[scrindex].Bounds.Width, sc[scrindex].Bounds.Height));
                bmp = pl1.Video.DrawToImage();
                LivePic.Image = bmp;
                //GC.Collect();
                //GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Log.LogEvent("Program closed");
                Preview.Ctlcontrols.stop();
                pl1.Video.Ctlcontrols.stop();
                Application.Exit();
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Log.LogEvent("Show play button clicked");
                if (playing)
                {
                    pl1.Video.Ctlcontrols.pause();
                    playbtn.Text = "Pause";
                    playing = false;
                }
                else
                {
                    pl1.Video.Ctlcontrols.play();
                    playbtn.Text = "Play";
                    playing = true;
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void Info_Click(object sender, EventArgs e)
        {
            try
            {
                Log.LogEvent("About button clicked");
                /*if (!Splash.trial)
                {
                    MessageBox.Show("This program has been made as alternative to vMix. \n Made by WinWins and odinokoe_4m0 \n Design: WinWins and odinokoe_4m0 \n Judge: Misha Ter \n \n Licensed to " + Splash.name + "\n \n Version " + Properties.Settings.Default.Version + " Beta 3 \n (C) 2020 DaniMat Corp.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("This program has been made as alternative to vMix. \n Made by WinWins and odinokoe_4m0 \n Design: WinWins and odinokoe_4m0 \n Judge: Misha Ter \n \n Licensed to " + Splash.name + "\n" + "TRIAL VERSION" + "\n" + Splash.daysleft.ToString() + " days left until expired" + "\n \n Version " + Properties.Settings.Default.Version + " Beta 3 \n (C) 2020 DaniMat Corp.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }*/
                About about = new About();
                about.ShowDialog();
                about.Dispose();
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Log.LogEvent("Mute button clicked");
                if (mute)
                {
                    pl1.Video.settings.mute = false;
                    mute = false;
                    mutebtn.BackColor = Color.FromArgb(100, 100, 100);
                }
                else
                {
                    pl1.Video.settings.mute = true;
                    mute = true;
                    mutebtn.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void loopbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Log.LogEvent("Loop button clicked");
                if (loop)
                {
                    pl1.Video.settings.setMode("loop", false);
                    loop = false;
                    loopbtn.BackColor = Color.FromArgb(100, 100, 100);
                }
                else
                {
                    pl1.Video.settings.setMode("loop", true);
                    loop = true;
                    loopbtn.BackColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Log.LogEvent("List clicked");
                if (listView1.SelectedItems.Count == 0)
                {
                    return;
                }
                selected = listView1.SelectedItems[0].Index;
                Preview.Ctlcontrols.stop();
                type = type1[listView1.SelectedItems[0].Index];
                //0 - color
                //1 - video
                //2 - photo
                //3 - photos
                //4 - presentation
                switch (type)
                {
                    case 0:
                        color = color1[listView1.SelectedItems[0].Index];
                        Preview.Visible = false;
                        Preview.Ctlcontrols.stop();
                        pictureBox1.BackColor = color;
                        break;
                    case 1:
                        playing1 = false;
                        PrevPlay_Click(sender, e);
                        filepath = filepath1[listView1.SelectedItems[0].Index];
                        Preview.Visible = true;
                        Preview.URL = filepath;
                        Preview.settings.setMode("loop", false);
                        break;
                    case 2:
                        playing1 = false;
                        PrevPlay_Click(sender, e);
                        filepath = filepath1[listView1.SelectedItems[0].Index];
                        Preview.Visible = true;
                        Preview.URL = filepath;
                        Preview.settings.setMode("loop", true);
                        break;
                    case 3:
                        filepath = filepath1[listView1.SelectedItems[0].Index];
                        FileInfo[] files = new DirectoryInfo(filepath).GetFiles("*.bmp");
                        FileInfo[] files1 = new DirectoryInfo(filepath).GetFiles("*.jpg");
                        FileInfo[] files2 = new DirectoryInfo(filepath).GetFiles("*.png");
                        photofolder.Clear();
                        foreach (FileInfo fileinfo in files)
                        {
                            photofolder.Add(fileinfo.FullName);
                        }
                        foreach (FileInfo fileinfo in files1)
                        {
                            photofolder.Add(fileinfo.FullName);
                        }
                        foreach (FileInfo fileinfo in files2)
                        {
                            photofolder.Add(fileinfo.FullName);
                        }
                        timelinePrev.Value = 0;
                        timelinePrev.Maximum = photofolder.Count - 1;
                        PreviewTime.Text = "1/" + (timelinePrev.Maximum + 1);
                        Preview.Visible = true;
                        Preview.URL = photofolder[0];
                        Preview.settings.setMode("loop", true);
                        break;
                    case 4:
                        filepath = filepath1[listView1.SelectedItems[0].Index];
                        presfolder = Directory.GetFiles(filepath, "*.jpg").ToList();
                        timelinePrev.Value = 0;
                        timelinePrev.Maximum = presfolder.Count - 1;
                        PreviewTime.Text = "1/" + (timelinePrev.Maximum + 1);
                        Preview.Visible = true;
                        Preview.URL = presfolder[0];
                        Preview.settings.setMode("loop", true);
                        break;
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void previewTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (type == 1)
                {
                    timelinePrev.Value = Convert.ToInt32(Preview.Ctlcontrols.currentPosition);
                    PreviewTime.Text = Preview.Ctlcontrols.currentPositionString + "/" + Preview.currentMedia.durationString;
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void Preview_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            try
            {
                if (Preview.openState == WMPLib.WMPOpenState.wmposMediaOpen)
                {
                    Preview.settings.mute = true;
                    switch (type)
                    {
                        case 1:
                            timelinePrev.Visible = true;
                            PreviewTime.Visible = true;
                            playbtnprev.Visible = true;
                            int seconds = Convert.ToInt32(Preview.currentMedia.durationString.Substring(0, 2)) * 60 + Convert.ToInt32(Preview.currentMedia.durationString.Substring(3, 2));
                            timelinePrev.Maximum = seconds;
                            Console.WriteLine(seconds);
                            previewTimer.Enabled = true;
                            break;
                        case 2:
                            PreviewTime.Visible = false;
                            timelinePrev.Visible = false;
                            playbtnprev.Visible = false;
                            break;
                        case 3:
                            timelinePrev.Visible = true;
                            PreviewTime.Visible = true;
                            playbtnprev.Visible = false;
                            break;
                        case 4:
                            timelinePrev.Visible = true;
                            PreviewTime.Visible = true;
                            playbtnprev.Visible = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void timelinePrev_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (type == 1)
                {
                    previewTimer.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void timelinePrev_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                Log.LogEvent("Preview timeline scrolled");
                if (type == 1)
                {
                    Preview.Ctlcontrols.pause();
                    Preview.Ctlcontrols.currentPosition = timelinePrev.Value;
                    if (playing1)
                    {
                        Preview.Ctlcontrols.play();
                        previewTimer.Enabled = true;
                    }
                }
                else if (type == 3)
                {
                    Preview.URL = photofolder[timelinePrev.Value];
                    PreviewTime.Text = (timelinePrev.Value + 1) + "/" + (timelinePrev.Maximum + 1);
                }
                else if (type == 4)
                {
                    Preview.URL = presfolder[timelinePrev.Value];
                    PreviewTime.Text = (timelinePrev.Value + 1) + "/" + (timelinePrev.Maximum + 1);
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void showTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (typeshow == 1)
                {
                    timeShow.Text = pl1.Video.Ctlcontrols.currentPositionString + "/" + pl1.Video.currentMedia.durationString;
                    if (timelineShow.Maximum == 0)
                    {
                        timelineShow.Maximum = Convert.ToInt32(pl1.Video.currentMedia.durationString.Substring(0, 2)) * 60 + Convert.ToInt32(pl1.Video.currentMedia.durationString.Substring(3, 2));
                    }
                    timelineShow.Value = (int)pl1.Video.Ctlcontrols.currentPosition;
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void timelineShow_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                showTimer.Enabled = false;
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void timelineShow_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                Log.LogEvent("Show timeline scrolled");
                if (typeshow == 1)
                {
                    pl1.Video.Ctlcontrols.currentPosition = timelineShow.Value;
                    if (playing)
                    {
                        showTimer.Enabled = true;
                    }
                }
                else if (typeshow == 3)
                {
                    pl1.Video.URL = photoshow[timelineShow.Value];
                    timeShow.Text = (timelineShow.Value + 1) + "/" + (timelineShow.Maximum + 1);
                    pl1.Video.Ctlcontrols.play();
                }
                else if (typeshow == 4)
                {
                    pl1.Video.URL = presshow[timelineShow.Value];
                    timeShow.Text = (timelineShow.Value + 1) + "/" + (timelineShow.Maximum + 1);
                    pl1.Video.Ctlcontrols.play();
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void SetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Log.LogEvent("Settings button clicked");
                Settings set = new Settings();
                set.ShowDialog();
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void NetTimer_Tick(object sender, EventArgs e)
        {
            ClientNum.Text = "Connected clients: " + server.Clients.Count();
        }

        private void TipBack_Click(object sender, EventArgs e)
        {
            try
            {
                tip++;
                Welcome();
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void TipTitle_Click(object sender, EventArgs e)
        {
            try
            {
                tip++;
                Welcome();
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void TipText_Click(object sender, EventArgs e)
        {
            try
            {
                tip++;
                Welcome();
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void ContentListContext_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    DeleteContext.Enabled = false;
                }
                else
                {
                    DeleteContext.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void DeleteContext_Click(object sender, EventArgs e)
        {
            try
            {
                Log.LogEvent("Delete list clicked");
                color1.RemoveAt(listView1.SelectedItems[0].Index);
                type1.RemoveAt(listView1.SelectedItems[0].Index);
                filepath1.RemoveAt(listView1.SelectedItems[0].Index);
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Log.LogEvent("Save file clicked");
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "furMix Content|*.fmc";
                saveFile.Title = "Save content";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(saveFile.FileName, FileMode.OpenOrCreate);
                    XmlTextWriter xw = new XmlTextWriter(fs, Encoding.Unicode);
                    xw.WriteStartDocument();
                    xw.WriteStartElement("items");
                    foreach (ListViewItem item in listView1.Items)
                    {
                        xw.WriteStartElement("item");
                        xw.WriteAttributeString("type", type1[item.Index].ToString());
                        xw.WriteAttributeString("filepath", filepath1[item.Index].ToString());
                        xw.WriteStartElement("color");
                        xw.WriteAttributeString("r", color1[item.Index].R.ToString());
                        xw.WriteAttributeString("g", color1[item.Index].G.ToString());
                        xw.WriteAttributeString("b", color1[item.Index].B.ToString());
                        xw.WriteEndElement();
                        xw.WriteEndElement();
                    }
                    xw.WriteEndElement();
                    xw.Flush();
                    fs.Close();
                    MessageBox.Show("Save successful", "furMix Save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Log.LogEvent("Open file clicked");
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Title = "Open content";
                openFile.Multiselect = false;
                openFile.Filter = "furMix Content|*.fmc";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    OpenFile(openFile.FileName);
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void OpenFile(string filename)
        {
            try
            {
                int opentype = 0;
                listView1.Clear();
                type1.Clear();
                filepath1.Clear();
                color1.Clear();
                FileStream fs = new FileStream(filename, FileMode.Open);
                XmlTextReader xr = new XmlTextReader(fs);
                while (xr.Read())
                {
                    if (xr.NodeType == XmlNodeType.Element)
                    {
                        if (xr.Name == "item")
                        {
                            opentype = Convert.ToInt32(xr.GetAttribute("type"));
                            type1.Add(Convert.ToInt32(xr.GetAttribute("type")));
                            filepath1.Add(xr.GetAttribute("filepath"));
                            if (opentype == 1)
                            {
                                listView1.Items.Add("Video\n" + xr.GetAttribute("filepath"));
                            }
                            else if (opentype == 2)
                            {
                                listView1.Items.Add("Photo\n" + xr.GetAttribute("filepath"));
                            }
                            else if (opentype == 3)
                            {
                                listView1.Items.Add("Photos collection\n" + xr.GetAttribute("filepath"));
                            }
                            else if (opentype == 4)
                            {
                                listView1.Items.Add("Presentation\n" + xr.GetAttribute("filepath"));
                            }
                        }
                        else if (xr.Name == "color")
                        {
                            color1.Add(Color.FromArgb(Convert.ToInt32(xr.GetAttribute("r")), Convert.ToInt32(xr.GetAttribute("g")), Convert.ToInt32(xr.GetAttribute("b"))));
                            if (opentype == 0)
                            {
                                listView1.Items.Add("Color\n" + Color.FromArgb(Convert.ToInt32(xr.GetAttribute("r")), Convert.ToInt32(xr.GetAttribute("g")), Convert.ToInt32(xr.GetAttribute("b"))).Name);
                            }
                        }
                    }
                }
                fs.Close();
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Log.LogEvent("New file clicked");
                listView1.Clear();
                type1.Clear();
                filepath1.Clear();
                color1.Clear();
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void NetworkBtn_Click(object sender, EventArgs e)
        {
            if (net)
            {
                NetworkBtn.BackColor = Color.FromArgb(100, 100, 100);
                net = false;
                ClientNum.Visible = false;
                server.Dispose();
                NetTimer.Enabled = false;
            }
            else
            {
                Screen[] sc = Screen.AllScreens;
                server = new ImageStreamingServer(pl1.Video);
                server.Start(port);
                NetTimer.Enabled = true;
                ClientNum.Visible = true;
                NetworkBtn.BackColor = Color.Green;
                net = true;
                MessageBox.Show("Open your browser and go to http://" + NetSettings.GetLocalIPAddress() + ":" + port, "Network server", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void recTimer_Tick(object sender, EventArgs e)
        {
            if (recBtn.BackColor == Color.Red) recBtn.BackColor = Color.FromArgb(100, 100, 100);
            else recBtn.BackColor = Color.Red;
            TimeSpan duration = DateTime.Now.Subtract(recStart);
            string time = "";
            if (duration.Hours < 10) time += "0";
            time += duration.Hours;
            time += ":";
            if (duration.Minutes < 10) time += "0";
            time += duration.Minutes;
            time += ":";
            if (duration.Seconds < 10) time += "0";
            time += duration.Seconds;
            recTimeTxt.Text = time;
        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            throw new Exception("Test exception");
        }

        private void recBtn_Click(object sender, EventArgs e)
        {
            if (!recording)
            {
                Log.LogEvent("Started recording");
                string filename = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos) + @"\furMix";
                if (!Directory.Exists(filename)) Directory.CreateDirectory(filename);
                filename += @"\Recording_" + DateTime.Now.ToString("MMddyyyyhhmmss") + ".avi";
                recStart = DateTime.Now;
                recTimeTxt.Text = "00:00:00";
                recTimeTxt.Visible = true;
                recorder = new Recorder(new RecorderParams(pl1, filename, 15, SharpAvi.KnownFourCCs.Codecs.MotionJpeg, 70));
                recording = true;
                fullbtn.Enabled = false;
                recTimer.Enabled = true;
            }
            else
            {
                Log.LogEvent("Stopped recording");
                recording = false;
                fullbtn.Enabled = true;
                recTimer.Enabled = false;
                recBtn.BackColor = Color.FromArgb(100, 100, 100);
                recTimeTxt.Text = "Saving...";
                Log.LogEvent("Saving recording...");
                new Thread(() =>
                {
                    recorder.Dispose();
                    recTimeTxt.Visible = false;
                    Log.LogEvent("Recording saved");
                }).Start();
            }
        }

        private void volumeLevel_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Log.LogEvent("Double clicked analyzer");
                if (!spectr)
                {
                    SpectrumLevel spectrum = new SpectrumLevel();
                    spectrum.Show();
                    anal.spectrumLevel = spectrum;
                    anal.DisplayEnable = true;
                    spectr = true;
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Preview.Ctlcontrols.stop();
            //pl1.Video.Ctlcontrols.stop();
            anal.Enable = false;
            Application.Exit();
        }

        private void NetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!net)
                {
                    NetSettings nt = new NetSettings();
                    nt.ShowDialog();
                    port = Properties.Settings.Default.NetPort;
                    BackgroundWorker startserv = new BackgroundWorker();
                    startserv.DoWork += Startserv_DoWork;
                    //startserv.RunWorkerAsync();
                    //while (startserv.IsBusy);
                    StartServer();
                    net = true;
                }
                else
                {
                    //server.CloseConnection();
                    NetBtn.BackColor = Color.FromArgb(100, 100, 100);
                    net = false;
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void Startserv_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                StartServer();
                while (true);
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void PrevPlay_Click(object sender, EventArgs e)
        {
            try
            {
                Log.LogEvent("Preview play button clicked");
                if (!playing1)
                {
                    Preview.Ctlcontrols.play();
                    playbtnprev.Text = "Pause";
                    playing1 = true;
                }
                else
                {
                    Preview.Ctlcontrols.pause();
                    playbtnprev.Text = "Play";
                    playing1 = false;
                }
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private Bitmap ImageOpacity(Image image, float opacity)
        {
            //create a Bitmap the size of the image provided  
            Bitmap bmp = new Bitmap(image.Width, image.Height);

            //create a graphics object from the image  
            using (Graphics gfx = Graphics.FromImage(bmp))
            {

                //create a color matrix object  
                ColorMatrix matrix = new ColorMatrix();

                //set the opacity  
                matrix.Matrix33 = opacity;

                //create image attributes  
                ImageAttributes attributes = new ImageAttributes();

                //set the color(opacity) of the image  
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                //now draw the image  
                gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Log.LogEvent("Fade button clicked");
                Preview.Ctlcontrols.stop();
                if (type == 0)
                {
                    Rectangle rect = new Rectangle(0, 0, pl1.Video.Width, pl1.Video.Height);
                    Bitmap old = new Bitmap(pl1.Video.Width, pl1.Video.Height);
                    old = pl1.Video.DrawToImage();
                    pl1.Video.close();
                    Bitmap bmp = new Bitmap(Screen.AllScreens[scrindex].Bounds.Width, Screen.AllScreens[scrindex].Bounds.Height);
                    Graphics g = Graphics.FromImage(bmp);
                    g.FillRectangle(new SolidBrush(color), new Rectangle(0, 0, Screen.AllScreens[scrindex].Bounds.Width, Screen.AllScreens[scrindex].Bounds.Height));
                    bmp.Save(Path.GetTempPath() + @"\color.png");
                    pl1.Video.URL = Path.GetTempPath() + @"\color.png";
                    pl1.Video.Ctlcontrols.play();
                    loop = false;
                    loopbtn_Click(sender, e);
                    playing = false;
                    button4_Click(sender, e);
                    Thread t = new Thread(() => {
                        for (float i = 0f; i <= 1f; i += 0.05f)
                        {
                            Image img = bmp.Clone() as Bitmap;
                            Image oldimg = old.Clone() as Bitmap;
                            g = Graphics.FromImage(oldimg);
                            //g.DrawImage(oldimg, 0, 0);
                            img = ImageOpacity(img, i);
                            g.DrawImage(img, 0, 0);
                            LivePic.Image = oldimg;
                            Thread.Sleep(10);
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }
                    });
                    t.Start();
                }
                else if (type == 1 || type == 2)
                {
                    Rectangle rect = new Rectangle(0, 0, pl1.Video.Width, pl1.Video.Height);
                    Bitmap old = new Bitmap(pl1.Video.Width, pl1.Video.Height);
                    old = pl1.Video.DrawToImage();
                    pl1.Video.close();
                    pl1.Video.URL = filepath;
                    pl1.Video.Ctlcontrols.play();
                    Bitmap newbmp;
                    //var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                    MemoryStream ms = new MemoryStream();
                    //ffMpeg.GetVideoThumbnail(filepath, ms, 5);
                    if (type == 1) newbmp = Image.FromStream(ms) as Bitmap;
                    else if (type == 2) newbmp = Image.FromFile(filepath) as Bitmap;
                    else newbmp = new Bitmap(pl1.Video.Width, pl1.Video.Height);
                    Graphics g;
                    Thread t = new Thread(() => {
                        for (float i = 0f; i <= 1f; i += 0.05f)
                        {
                            Image img = newbmp.Clone() as Bitmap;
                            Image oldimg = old.Clone() as Bitmap;
                            g = Graphics.FromImage(oldimg);
                            //g.DrawImage(oldimg, 0, 0);
                            img = ImageOpacity(img, i);
                            g.DrawImage(img, 0, 0);
                            LivePic.Image = oldimg;
                            Thread.Sleep(10);
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }
                    });
                    t.Start();
                    if (type == 2)
                    {
                        loop = false;
                        loopbtn_Click(sender, e);
                    }
                    playing = false;
                    button4_Click(sender, e);
                }
                if (type == 1)
                {
                    playbtn.Visible = true;
                }
                else
                {
                    playbtn.Visible = false;
                }
                if (type == 1)
                {
                    playbtn.Visible = true;
                    timelineShow.Visible = true;
                    timeShow.Visible = true;
                    timelineShow.Maximum = Convert.ToInt32(pl1.Video.currentMedia.durationString.Substring(0, 2)) * 60 + Convert.ToInt32(pl1.Video.currentMedia.durationString.Substring(3, 2));
                    showTimer.Enabled = true;
                }
                else if (type == 2 || type == 0)
                {
                    playbtn.Visible = false;
                    timelineShow.Visible = false;
                    timeShow.Visible = false;
                }
                else if (type == 3)
                {
                    FileInfo[] files = new DirectoryInfo(filepath).GetFiles("*.bmp");
                    FileInfo[] files1 = new DirectoryInfo(filepath).GetFiles("*.jpg");
                    FileInfo[] files2 = new DirectoryInfo(filepath).GetFiles("*.png");
                    photoshow.Clear();
                    foreach (FileInfo fileinfo in files)
                    {
                        photoshow.Add(fileinfo.FullName);
                    }
                    foreach (FileInfo fileinfo in files1)
                    {
                        photoshow.Add(fileinfo.FullName);
                    }
                    foreach (FileInfo fileinfo in files2)
                    {
                        photoshow.Add(fileinfo.FullName);
                    }
                    timelineShow.Value = 0;
                    timelineShow.Maximum = photoshow.Count - 1;
                    timeShow.Text = "1/" + (timelineShow.Maximum + 1);
                    Rectangle rect = new Rectangle(0, 0, pl1.Video.Width, pl1.Video.Height);
                    Bitmap old = new Bitmap(pl1.Video.Width, pl1.Video.Height);
                    old = pl1.Video.DrawToImage();
                    pl1.Video.close();
                    pl1.Video.URL = photofolder[0];
                    pl1.Video.Ctlcontrols.play();
                    Thread.Sleep(500);
                    Bitmap newbmp = new Bitmap(pl1.Video.Width, pl1.Video.Height);
                    newbmp = pl1.Video.DrawToImage();
                    Graphics g;
                    Thread t = new Thread(() => {
                        for (float i = 0f; i <= 1f; i += 0.05f)
                        {
                            Image img = newbmp.Clone() as Bitmap;
                            Image oldimg = old.Clone() as Bitmap;
                            g = Graphics.FromImage(oldimg);
                            //g.DrawImage(oldimg, 0, 0);
                            img = ImageOpacity(img, i);
                            g.DrawImage(img, 0, 0);
                            LivePic.Image = oldimg;
                            Thread.Sleep(10);
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }
                    });
                    t.Start();
                    playbtn.Visible = false;
                    timelineShow.Visible = true;
                    timeShow.Visible = true;
                }
                else if (type == 4)
                {
                    presshow = presfolder;
                    timelineShow.Value = 0;
                    timelineShow.Maximum = presshow.Count - 1;
                    timeShow.Text = "1/" + (timelineShow.Maximum + 1);
                    Rectangle rect = new Rectangle(0, 0, pl1.Video.Width, pl1.Video.Height);
                    Bitmap old = new Bitmap(pl1.Video.Width, pl1.Video.Height);
                    old = pl1.Video.DrawToImage();
                    pl1.Video.close();
                    pl1.Video.URL = presshow[0];
                    pl1.Video.Ctlcontrols.play();
                    Bitmap newbmp = new Bitmap(pl1.Video.Width, pl1.Video.Height);
                    newbmp = pl1.Video.DrawToImage();
                    Graphics g;
                    Thread t = new Thread(() => {
                        for (float i = 0f; i <= 1f; i += 0.05f)
                        {
                            Image img = newbmp.Clone() as Bitmap;
                            Image oldimg = old.Clone() as Bitmap;
                            g = Graphics.FromImage(oldimg);
                            //g.DrawImage(oldimg, 0, 0);
                            img = ImageOpacity(img, i);
                            g.DrawImage(img, 0, 0);
                            LivePic.Image = oldimg;
                            Thread.Sleep(10);
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }
                    });
                    t.Start();
                    playbtn.Visible = false;
                    timelineShow.Visible = true;
                    timeShow.Visible = true;
                }
                if (type == 3)
                {
                    loop = false;
                    loopbtn_Click(sender, e);
                }
                else if (type == 4)
                {
                    loop = false;
                    loopbtn_Click(sender, e);
                }
                typeshow = type;
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void AddMedia_Click(object sender, EventArgs e)
        {
            try
            {
                Log.LogEvent("Add input clicked");
                AddInput addInput = new AddInput();
                addInput.ShowDialog();
                if (!AddInput.canceled)
                {
                    type = AddInput.type;
                    if (AddInput.filepath == "" && type > 0)
                    {
                        return;
                    }
                    type1.Add(type);
                    if (type == 0)
                    {
                        filepath1.Add("");
                        color = AddInput.color;
                        color1.Add(color);
                        listView1.Items.Add("Color \n" + color.Name);
                    }
                    else
                    {
                        filepath1.Add(AddInput.filepath);
                        color1.Add(Color.Black);
                        if (type == 1)
                        {
                            listView1.Items.Add("Video \n" + AddInput.filepath);
                        }
                        else if (type == 2)
                        {
                            listView1.Items.Add("Photo \n" + AddInput.filepath);
                        }
                        else if (type == 3)
                        {
                            listView1.Items.Add("Photos collection \n" + AddInput.filepath);
                        }
                        else if (type == 4)
                        {
                            listView1.Items.Add("Presentation \n" + AddInput.filepath);
                        }
                    }
                    if (webServer.IsRunning)
                    {
                        webServer.MediaList.Clear();
                        for (int i = 0; i < listView1.Items.Count; i++) 
                        {
                            string str = listView1.Items[i].Text;
                            webServer.MediaList.Add(str);
                        }
                    }
                }
                //throw new NotImplementedException("Еще не готово, хули жмешь");
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void HideFurry()
        {
            try
            {
                pl1.Hide();
                pl1.FormBorderStyle = FormBorderStyle.Sizable;
                pl1.Size = new Size(640, 480);
                pl1.Location = LivePic.Location;
                pl1.Show();
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }
    }
}