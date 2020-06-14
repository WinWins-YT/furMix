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
            InitializeComponent();
            foreach (string temp in File.ReadLines(Application.StartupPath + @"\config\lastvideo.lst"))
            {
                LastList.Items.Add(temp);
            }
            foreach (string temp in File.ReadLines(Application.StartupPath + @"\config\lastphoto.lst"))
            {
                LastList1.Items.Add(temp);
            }
            filepath = "";
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
            }
        }

        private void BrowBtn1_Click(object sender, EventArgs e)
        {
            try
            {
                if (FilePhoto.ShowDialog() == DialogResult.OK)
                {
                    filepath = FilePhoto.FileName;
                    filepathTxt.Text = filepath;
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
            }
        }

        private void OKbtn_Click(object sender, EventArgs e)
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
                type = 0;
                color = pictureBox1.BackColor;
                filepath = "";
            }
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            canceled = true;
            Close();
        }

        private void LastList_SelectedIndexChanged(object sender, EventArgs e)
        {
            filepathTxt.Text = LastList.SelectedItem.ToString();
        }

        private void LastList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filepathTxt1.Text = LastList1.SelectedItem.ToString();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            LastList.Items.Clear();
            File.Delete(Application.StartupPath + @"\config\lastvideo.lst");
            File.Create(Application.StartupPath + @"\config\lastvideo.lst");
        }

        private void ClearBtn1_Click(object sender, EventArgs e)
        {
            LastList1.Items.Clear();
            File.Delete(Application.StartupPath + @"\config\lastphoto.lst");
            File.Create(Application.StartupPath + @"\config\lastphoto.lst");
        }
    }
}
