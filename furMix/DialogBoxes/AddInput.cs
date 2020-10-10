using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace furMix
{
    public partial class AddInput : Form
    {
        public static string filepath;
        public static int type;
        public static Color color;
        public static bool canceled;

        public AddInput()
        {
            try
            {
                InitializeComponent();
                foreach (string temp in File.ReadLines(Application.StartupPath + @"\config\lastvideo.lst"))
                {
                    LastList.Items.Add(temp);
                }
                foreach (string temp in File.ReadLines(Application.StartupPath + @"\config\lastphoto.lst"))
                {
                    LastList1.Items.Add(temp);
                }
                foreach (string temp in File.ReadLines(Application.StartupPath + @"\config\lastphotos.lst"))
                {
                    LastList2.Items.Add(temp);
                }
                foreach (string temp in File.ReadLines(Application.StartupPath + @"\config\lastpres.lst"))
                {
                    LastList3.Items.Add(temp);
                }
                filepath = "";
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void BrowBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileVideo.ShowDialog() == DialogResult.OK)
                {
                    filepath = FileVideo.FileName;
                    filepathTxt.Text = FileVideo.FileName;
                    int count = 0;
                    foreach (string temp in LastList.Items)
                    {
                        if (temp == filepath)
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        LastList.Items.Add(filepath);
                        List<string> temp1 = new List<string>();
                        foreach (string temp in LastList.Items)
                        {
                            temp1.Add(temp);
                        }
                        File.WriteAllLines(Application.StartupPath + @"\config\lastvideo.lst", temp1);
                    }
                    type = 1;
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

        private void BrowBtn1_Click(object sender, EventArgs e)
        {
            try
            {
                if (FilePhoto.ShowDialog() == DialogResult.OK)
                {
                    filepath = FilePhoto.FileName;
                    filepathTxt1.Text = filepath;
                    int count = 0;
                    foreach (string temp in LastList1.Items)
                    {
                        if (temp == filepath)
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        LastList1.Items.Add(filepath);
                        List<string> temp1 = new List<string>();
                        foreach (string temp in LastList1.Items)
                        {
                            temp1.Add(temp);
                        }
                        File.WriteAllLines(Application.StartupPath + @"\config\lastphoto.lst", temp1);
                    }
                    type = 2;
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

        private void ColorBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.BackColor = colorDialog1.Color;
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

        private void OKbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    type = 1;
                    filepath = filepathTxt.Text;
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    type = 2;
                    filepath = filepathTxt1.Text;
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    type = 3;
                    filepath = filepathTxt2.Text;
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    type = 0;
                    color = pictureBox1.BackColor;
                    filepath = "";
                }
                else if (tabControl1.SelectedIndex == 4)
                {
                    type = 4;
                    filepath = filepathTxt3.Text;
                }
                Close();
            }
            catch (Exception ex) 
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                canceled = true;
                Close();
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void LastList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (LastList.SelectedItems.Count > 0)
                {
                    filepathTxt.Text = LastList.SelectedItem.ToString();
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

        private void LastList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (LastList1.SelectedItems.Count > 0)
                {
                    filepathTxt1.Text = LastList1.SelectedItem.ToString();
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

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            try
            {
                LastList.Items.Clear();
                File.Delete(Application.StartupPath + @"\config\lastvideo.lst");
                File.Create(Application.StartupPath + @"\config\lastvideo.lst");
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void ClearBtn1_Click(object sender, EventArgs e)
        {
            try
            {
                LastList1.Items.Clear();
                File.Delete(Application.StartupPath + @"\config\lastphoto.lst");
                File.Create(Application.StartupPath + @"\config\lastphoto.lst");
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void BrowBtn2_Click(object sender, EventArgs e)
        {
            try
            {
                if (FolderPhotos.ShowDialog() == DialogResult.OK)
                {
                    FileInfo[] files = new DirectoryInfo(FolderPhotos.SelectedPath).GetFiles("*.bmp");
                    FileInfo[] files1 = new DirectoryInfo(FolderPhotos.SelectedPath).GetFiles("*.jpg");
                    FileInfo[] files2 = new DirectoryInfo(FolderPhotos.SelectedPath).GetFiles("*.png");
                    //string[] files = Directory.GetFiles(FolderPhotos.SelectedPath + @"\*.bmp");
                    //string[] files1 = Directory.GetFiles(FolderPhotos.SelectedPath + @"\*.png");
                    //string[] files2 = Directory.GetFiles(FolderPhotos.SelectedPath + @"\*.jpg");
                    if (files.Length > 0 || files1.Length > 0 || files2.Length > 0)
                    {
                        filepath = FolderPhotos.SelectedPath;
                        filepathTxt2.Text = filepath;
                        int count = 0;
                        foreach (string temp in LastList2.Items)
                        {
                            if (temp == filepath)
                            {
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            LastList2.Items.Add(filepath);
                            List<string> temp1 = new List<string>();
                            foreach (string temp in LastList2.Items)
                            {
                                temp1.Add(temp);
                            }
                            File.WriteAllLines(Application.StartupPath + @"\config\lastphotos.lst", temp1);
                        }
                        type = 3;
                    }
                    else
                    {
                        MessageBox.Show("No photos found in this folder. Try another one", "Add Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void ClearBtn2_Click(object sender, EventArgs e)
        {
            try
            {
                LastList2.Items.Clear();
                File.Delete(Application.StartupPath + @"\config\lastphotos.lst");
                File.Create(Application.StartupPath + @"\config\lastphotos.lst");
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.ShowError(ex);
                error.ShowDialog();
                error.Dispose();
            }
        }

        private void LastList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (LastList2.SelectedItems.Count > 0)
                {
                    filepathTxt2.Text = LastList2.SelectedItem.ToString();
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

        private void BrowBtn3_Click(object sender, EventArgs e)
        {
            try
            {
                if (FilePres.ShowDialog() == DialogResult.OK)
                {
                    filepath = FilePres.FileName;
                    filepathTxt3.Text = filepath;
                    int count = 0;
                    foreach (string temp in LastList3.Items)
                    {
                        if (temp == filepath)
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        LastList3.Items.Add(filepath);
                        List<string> temp1 = new List<string>();
                        foreach (string temp in LastList3.Items)
                        {
                            temp1.Add(temp);
                        }
                        File.WriteAllLines(Application.StartupPath + @"\config\lastpres.lst", temp1);
                    }
                    type = 4;
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

        private void LastList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (LastList3.SelectedItems.Count > 0)
                {
                    filepathTxt3.Text = LastList3.SelectedItem.ToString();
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

        private void ClearBtn3_Click(object sender, EventArgs e)
        {
            try
            {
                LastList3.Items.Clear();
                File.Delete(Application.StartupPath + @"\config\lastpres.lst");
                File.Create(Application.StartupPath + @"\config\lastpres.lst");
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
