using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using furMix.DialogBoxes;
using furMix.Utilities;
//using AForge.Video.FFMPEG;
//using NetComm;

namespace furMix
{
    public partial class Main : Form
    {
        string filepath;
        bool full, playing, playing1, loop, mute, net;
        int type = 1;
        int port, scrindex, tip = 0;
        int typeshow;
        Play1 pl1 = new Play1();
        Play2 pl2 = new Play2();
        Background back = new Background();
        //Graphics gr;
        //Bitmap bmp;
        Color color;
        List<string> filepath1 = new List<string>();
        List<int> type1 = new List<int>();
        List<Color> color1 = new List<Color>();
        List<string> photofolder = new List<string>();
        List<string> photoshow = new List<string>();
        List<string> presfolder;
        List<string> presshow;
        //Host server;
        public static string pass;
        public static bool spectr;
        Analyzer anal;
        Graphics gr;
        Bitmap bmp;
        //VideoFileReader videonet = new VideoFileReader();

        public Main()
        {
            InitializeComponent();
            try
            {
                pl1.Opacity = 0;
                Preview.settings.mute = true;
                pl1.Video.settings.mute = true;
                pl2.Video.settings.mute = true;
                if (!Splash.trial)
                {
                    VerTxt.Text = "furMix 2020. Build " + Properties.Settings.Default.Version + ". Beta 3.\n For testing purposes only.";
                }
                else
                {
                    VerTxt.Text = "furMix 2020 Trial. Build " + Properties.Settings.Default.Version + ". Beta 3.\n For testing purposes only.";
                }
                //server = new Host(Properties.Settings.Default.NetPort);
                //server.onConnection += Server_onConnection;
                //server.lostConnection += Server_lostConnection;
                //server.DataReceived += Server_DataReceived;
                pass = RandomString(6);
                anal = new Analyzer(volumeLevel);
                anal.Enable = true;
                scrindex = Properties.Settings.Default.Screen;
                Screen[] sc = Screen.AllScreens;
                gr = CreateGraphics();
                bmp = new Bitmap(sc[scrindex].Bounds.Width, sc[scrindex].Bounds.Height, gr);
                using (SoundPlayer sp = new SoundPlayer())
                {
                    sp.Stream = Properties.Resources.hoy;
                    sp.Play();
                }
                if (!Properties.Settings.Default.Welcome)
                {
                    Welcome();
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
                TipBack.Location = new Point(fullbtn.Left + fullbtn.Width + 10, fullbtn.Top + fullbtn.Height + 10);
                TipTitle.Location = new Point(TipBack.Left + 23, TipBack.Top + 19);
                TipText.Location = new Point(TipBack.Left + 24, TipBack.Top + 43);
                TipTitle.Text = "Fullscreen button";
                TipText.Text = "This button grabs your second monitor (you can change it in settings) for showing content, that you supplied";
                TipBack.BringToFront();
                TipTitle.BringToFront();
                TipText.BringToFront();
            }
            else if (tip == 2)
            {
                TipBack.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
                TipBack.Location = new Point(button6.Left + button6.Width - 10, button6.Top - button6.Height - TipBack.Height + 10);
                TipTitle.Location = new Point(TipBack.Left + 23, TipBack.Top + 19);
                TipText.Location = new Point(TipBack.Left + 24, TipBack.Top + 43);
                TipTitle.Text = "Add input button";
                TipText.Text = "This button gets content (photos, videos and color) to show on second screen";
                TipBack.BringToFront();
                TipTitle.BringToFront();
                TipText.BringToFront();
            }
            else if (tip == 3)
            {
                TipBack.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
                TipBack.Location = new Point(listView1.Left + listView1.Width / 2 - 10, listView1.Top + listView1.Height / 2 - 10);
                TipTitle.Location = new Point(TipBack.Left + 23, TipBack.Top + 19);
                TipText.Location = new Point(TipBack.Left + 24, TipBack.Top + 43);
                TipTitle.Text = "Content list";
                TipText.Text = "This list contains photos and videos, that you added through Add input button";
                TipBack.BringToFront();
                TipTitle.BringToFront();
                TipText.BringToFront();
            }
            else if (tip == 4)
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
            else if (tip == 5)
            {
                TipBack.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                TipBack.Location = new Point(picture.Left - 10, picture.Top + picture.Height + 10);
                TipTitle.Location = new Point(TipBack.Left + 23, TipBack.Top + 19);
                TipText.Location = new Point(TipBack.Left + 24, TipBack.Top + 43);
                TipTitle.Text = "Live";
                TipText.Text = "This window shows content on second screen";
                TipBack.BringToFront();
                TipTitle.BringToFront();
                TipText.BringToFront();
            }
            else if (tip == 6)
            {
                TipBack.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                TipBack.Location = new Point(cutbtn.Left + cutbtn.Width + 10, cutbtn.Top + cutbtn.Height + 10);
                TipTitle.Location = new Point(TipBack.Left + 23, TipBack.Top + 19);
                TipText.Location = new Point(TipBack.Left + 24, TipBack.Top + 43);
                TipTitle.Text = "Cut button";
                TipText.Text = "This button shows content on second screen (Fade do the same, but with fade transition (very buggy))";
                TipBack.BringToFront();
                TipTitle.BringToFront();
                TipText.BringToFront();
            }
            else if (tip == 7)
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
            else if (tip == 8)
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
            else if (tip == 9)
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
                    back.Left = sc[scrindex].Bounds.Width;
                    back.Top = sc[scrindex].Bounds.Height;
                    back.Location = sc[scrindex].Bounds.Location;
                    back.WindowState = FormWindowState.Maximized;
                    back.Show();
                    pl1.Left = sc[scrindex].Bounds.Width;
                    pl1.Top = sc[scrindex].Bounds.Height;
                    pl1.Location = sc[scrindex].Bounds.Location;
                    pl1.WindowState = FormWindowState.Maximized;
                    pl1.Show();
                    pl2.Left = sc[scrindex].Bounds.Width;
                    pl2.Top = sc[scrindex].Bounds.Height;
                    pl2.Location = sc[scrindex].Bounds.Location;
                    pl2.WindowState = FormWindowState.Maximized;
                    pl2.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Preview.Ctlcontrols.stop();
                pl1.Opacity = 1;
                pl2.Opacity = 0;
                pl2.Video.close();
                typeshow = type;
                if (type == 0)
                {
                    pl1.Opacity = 0;
                    pl1.Video.close();
                    back.BackColor = color;
                }
                else if (type == 1 || type == 2)
                {
                    pl1.Video.URL = filepath;
                    pl1.Video.Visible = true;
                    pl1.Video.Ctlcontrols.play();
                    playing = false;
                    button4_Click(sender, e);
                }
                else if (type == 3)
                {
                    pl1.Video.Visible = true;
                    playing = false;
                    button4_Click(sender, e);
                }
                else if (type == 4)
                {
                    pl1.Video.Visible = true;
                    playing = false;
                    button4_Click(sender, e);
                }
                if (type == 2)
                {
                    loop = false;
                    loopbtn_Click(sender, e);
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
                    pl1.Video.URL = photofolder[0];
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
                    pl1.Video.URL = presshow[0];
                    playbtn.Visible = false;
                    timelineShow.Visible = true;
                    timeShow.Visible = true;
                }
                if (net)
                {
                    if (type == 2)
                    {
                        NetTimer.Enabled = false;
                        Bitmap pict = new Bitmap(filepath);
                        using (var stream = new MemoryStream())
                        {
                            pict.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                            //server.SendData("furMixStream", stream.ToArray());
                        }
                    }
                    else if (type == 1)
                    {
                        NetTimer.Enabled = true;
                        //videonet.Open(filepath);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (full)
                {
                    HideFurry();
                    full = false;
                    timer1.Enabled = false;
                    fullbtn.BackColor = Color.FromArgb(100, 100, 100);
                }
                else
                {
                    timer1.Enabled = true;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Screen[] sc = Screen.AllScreens;
                if (sc.Length > 1)
                {
                    //Graphics gr = CreateGraphics();
                    //Bitmap bmp = new Bitmap(sc[scrindex].Bounds.Width, sc[scrindex].Bounds.Height, gr);
                    gr = Graphics.FromImage(bmp);
                    gr.CopyFromScreen(sc[scrindex].Bounds.X, sc[scrindex].Bounds.Y, 0, 0, new Size(sc[scrindex].Bounds.Width, sc[scrindex].Bounds.Height));
                    picture.Image = bmp;
                    //gr.Dispose();
                    //bmp.Dispose();
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

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Preview.Ctlcontrols.stop();
                pl1.Video.Ctlcontrols.stop();
                pl2.Video.Ctlcontrols.stop();
                //server.CloseConnection();
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
                if (playing)
                {
                    if (pl1.Opacity == 1)
                    {
                        pl1.Video.Ctlcontrols.pause();
                    }
                    else if (pl2.Opacity == 1)
                    {
                        pl2.Video.Ctlcontrols.play();
                    }
                    playbtn.Text = "Pause";
                    playing = false;
                }
                else
                {
                    if (pl1.Opacity == 1)
                    {
                        pl1.Video.Ctlcontrols.play();
                    }
                    else if (pl2.Opacity == 1)
                    {
                        pl2.Video.Ctlcontrols.pause();
                    }
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
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
                if (mute)
                {
                    if (pl1.Opacity == 1)
                    {
                        pl1.Video.settings.mute = false;
                    }
                    else if (pl2.Opacity == 1)
                    {
                        pl2.Video.settings.mute = false;
                    }
                    mute = false;
                    mutebtn.BackColor = Color.FromArgb(100, 100, 100);
                }
                else
                {
                    if (pl1.Opacity == 1)
                    {
                        pl1.Video.settings.mute = true;
                    }
                    else if (pl2.Opacity == 1)
                    {
                        pl2.Video.settings.mute = true;
                    }
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
                if (loop)
                {
                    if (pl1.Opacity == 1)
                    {
                        pl1.Video.settings.setMode("loop", false);
                    }
                    else if (pl2.Opacity == 1)
                    {
                        pl2.Video.settings.setMode("loop", false);
                    }
                    loop = false;
                    loopbtn.BackColor = Color.FromArgb(100, 100, 100);
                }
                else
                {
                    if (pl1.Opacity == 1)
                    {
                        pl1.Video.settings.setMode("loop", true);
                    }
                    else if (pl2.Opacity == 1)
                    {
                        pl2.Video.settings.setMode("loop", true);
                    }
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
                if (listView1.SelectedItems.Count == 0)
                {
                    return;
                }
                Preview.Ctlcontrols.stop();
                type = type1[listView1.SelectedItems[0].Index];
                if (type != 0)
                {
                    if (type == 1)
                    {
                        playing1 = false;
                        button2_Click_1(sender, e);
                    }
                    if (type == 1 || type == 2)
                    {
                        filepath = filepath1[listView1.SelectedItems[0].Index];
                        Preview.Visible = true;
                        Preview.URL = filepath;
                        if (type == 2)
                        {
                            Preview.settings.setMode("loop", true);
                        }
                        else
                        {
                            Preview.settings.setMode("loop", false);
                        }
                    }
                    else if (type == 3)
                    {
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
                    }
                    else if (type == 4)
                    {
                        filepath = filepath1[listView1.SelectedItems[0].Index];
                        presfolder = new ConvertPresentation(filepath).Convert();
                        timelinePrev.Value = 0;
                        timelinePrev.Maximum = presfolder.Count - 1;
                        PreviewTime.Text = "1/" + (timelinePrev.Maximum + 1);
                        Preview.Visible = true;
                        Preview.URL = presfolder[0];
                        Preview.settings.setMode("loop", true);
                    }
                }
                else
                {
                    color = color1[listView1.SelectedItems[0].Index];
                    Preview.Visible = false;
                    Preview.Ctlcontrols.stop();
                    pictureBox1.BackColor = color;
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
                    if (type == 2)
                    {
                        PreviewTime.Visible = false;
                        timelinePrev.Visible = false;
                        playbtnprev.Visible = false;
                    }
                    else if (type == 1)
                    {
                        timelinePrev.Visible = true;
                        PreviewTime.Visible = true;
                        playbtnprev.Visible = true;
                        int seconds = Convert.ToInt32(Preview.currentMedia.durationString.Substring(0, 2)) * 60 + Convert.ToInt32(Preview.currentMedia.durationString.Substring(3, 2));
                        timelinePrev.Maximum = seconds;
                        Console.WriteLine(seconds);
                        previewTimer.Enabled = true;
                    }
                    else if (type == 3)
                    {
                        timelinePrev.Visible = true;
                        PreviewTime.Visible = true;
                        playbtnprev.Visible = false;
                    }
                    else if (type == 4)
                    {
                        timelinePrev.Visible = true;
                        PreviewTime.Visible = true;
                        playbtnprev.Visible = false;
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
                if (full)
                {
                    if (timelineShow.Visible && playbtn.Visible)
                    {
                        if (pl1.Opacity == 1)
                        {
                            timeShow.Text = pl1.Video.Ctlcontrols.currentPositionString + "/" + pl1.Video.currentMedia.durationString;
                            timelineShow.Value = (int)pl1.Video.Ctlcontrols.currentPosition;
                        }
                        else if (pl2.Opacity == 1)
                        {
                            timeShow.Text = pl2.Video.Ctlcontrols.currentPositionString + "/" + pl2.Video.currentMedia.durationString;
                            timelineShow.Value = (int)pl2.Video.Ctlcontrols.currentPosition;
                        }
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
                if (full)
                {
                    if (typeshow == 1)
                    {
                        if (pl1.Opacity == 1)
                        {
                            pl1.Video.Ctlcontrols.currentPosition = timelineShow.Value;
                        }
                        else if (pl2.Opacity == 1)
                        {
                            pl2.Video.Ctlcontrols.currentPosition = timelineShow.Value;
                        }
                        if (playing)
                        {
                            showTimer.Enabled = true;
                        }
                    }
                    else if (typeshow == 3)
                    {
                        if (pl1.Opacity == 1)
                        {
                            pl1.Video.URL = photoshow[timelineShow.Value];
                        }
                        else if (pl2.Opacity == 1)
                        {
                            pl2.Video.URL = photoshow[timelineShow.Value];
                        }
                        timeShow.Text = (timelineShow.Value + 1) + "/" + (timelineShow.Maximum + 1);
                    }
                    else if (typeshow == 4)
                    {
                        if (pl1.Opacity == 1)
                        {
                            pl1.Video.URL = presshow[timelineShow.Value];
                        }
                        else if (pl2.Opacity == 1)
                        {
                            pl2.Video.URL = presshow[timelineShow.Value];
                        }
                        timeShow.Text = (timelineShow.Value + 1) + "/" + (timelineShow.Maximum + 1);
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

        private void SetBtn_Click(object sender, EventArgs e)
        {
            try
            {
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
            //Bitmap frame = videonet.ReadVideoFrame();
            using (var stream = new MemoryStream())
            {
                //frame.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                //server.SendData("furMixStream", stream.ToArray());
                stream.Dispose();
            }
        }

        private void TipBack_Click(object sender, EventArgs e)
        {
            tip++;
            Welcome();
        }

        private void TipTitle_Click(object sender, EventArgs e)
        {
            tip++;
            Welcome();
        }

        private void TipText_Click(object sender, EventArgs e)
        {
            tip++;
            Welcome();
        }

        private void volumeLevel_DoubleClick(object sender, EventArgs e)
        {
            if (!spectr)
            {
                SpectrumLevel spectrum = new SpectrumLevel();
                spectrum.Show();
                anal.spectrumLevel = spectrum;
                anal.DisplayEnable = true;
                spectr = true;
            }
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Preview.Ctlcontrols.stop();
                if (type == 0)
                {
                    if (pl1.Opacity == 1)
                    {
                        pl2.BackColor = color;
                        pl2.Video.Visible = false;
                        double opacity1 = 1;
                        double opacity2 = 0;
                        while (opacity1 >= 0)
                        {
                            pl1.Opacity = opacity1;
                            pl2.Opacity = opacity2;
                            Thread.Sleep(100);
                            opacity1 -= 0.05;
                            opacity2 += 0.05;
                        }
                        pl1.Video.close();
                    }
                    else if (pl2.Opacity == 1)
                    {
                        pl1.BackColor = color;
                        pl1.Video.Visible = false;
                        double opacity1 = 0;
                        double opacity2 = 1;
                        while (opacity2 >= 0)
                        {
                            pl1.Opacity = opacity1;
                            pl2.Opacity = opacity2;
                            Thread.Sleep(100);
                            opacity1 += 0.05;
                            opacity2 -= 0.05;
                        }
                        pl2.Video.close();
                    }
                }
                else if (type == 1 || type == 2)
                {
                    if (pl1.Opacity == 1)
                    {
                        pl2.Opacity = 0.05;
                        pl2.Video.URL = filepath;
                        pl2.Video.Visible = true;
                        pl2.Video.Ctlcontrols.play();
                        double opacity1 = 1;
                        double opacity2 = 0.05;
                        while (opacity1 > 0)
                        {
                            pl1.Opacity = opacity1;
                            pl2.Opacity = opacity2;
                            Thread.Sleep(100);
                            opacity1 -= 0.05;
                            opacity2 += 0.05;
                        }
                        pl1.Opacity = 0;
                        pl1.Video.close();
                        pl2.Opacity = 1;
                    }
                    else if (pl2.Opacity == 1)
                    {
                        pl1.Opacity = 0.05;
                        pl1.Video.URL = filepath;
                        pl2.Video.Visible = true;
                        pl1.Video.Ctlcontrols.play();
                        double opacity1 = 0.05;
                        double opacity2 = 1;
                        while (opacity2 > 0)
                        {
                            pl1.Opacity = opacity1;
                            pl2.Opacity = opacity2;
                            Thread.Sleep(100);
                            opacity1 += 0.05;
                            opacity2 -= 0.05;
                        }
                        pl1.Opacity = 1;
                        pl2.Opacity = 0;
                        pl2.Video.close();
                    }
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
                    if (pl1.Opacity == 1)
                    {
                        playbtn.Visible = true;
                        timelineShow.Visible = true;
                        timeShow.Visible = true;
                        timelineShow.Maximum = Convert.ToInt32(pl1.Video.currentMedia.durationString.Substring(0, 2)) * 60 + Convert.ToInt32(pl1.Video.currentMedia.durationString.Substring(3, 2));
                        showTimer.Enabled = true;
                    }
                    else if (pl2.Opacity == 1)
                    {
                        playbtn.Visible = true;
                        timelineShow.Visible = true;
                        timeShow.Visible = true;
                        timelineShow.Maximum = Convert.ToInt32(pl2.Video.currentMedia.durationString.Substring(0, 2)) * 60 + Convert.ToInt32(pl2.Video.currentMedia.durationString.Substring(3, 2));
                        showTimer.Enabled = true;
                    }
                }
                else
                {
                    playbtn.Visible = false;
                    timelineShow.Visible = false;
                    timeShow.Visible = false;
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
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
                        listView1.Items.Add("Color\n" + color.Name);
                    }
                    else
                    {
                        filepath1.Add(AddInput.filepath);
                        color1.Add(Color.Black);
                        if (type == 1)
                        {
                            listView1.Items.Add("Video\n" + AddInput.filepath, listView1.Items.Count);
                        }
                        else if (type == 2)
                        {
                            listView1.Items.Add("Photo\n" + AddInput.filepath);
                        }
                        else if (type == 3)
                        {
                            listView1.Items.Add("Photos collection\n" + AddInput.filepath);
                        }
                        else if (type == 4)
                        {
                            listView1.Items.Add("Presentation\n" + AddInput.filepath);
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
                pl2.Hide();
                back.Hide();
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