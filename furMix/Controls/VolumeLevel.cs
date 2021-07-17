using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using furMix.Utilities;

namespace furMix.Controls
{
    public partial class VolumeLevel : UserControl
    {
        int lch, rch, temp;
        List<PictureBox> LeftBars = new List<PictureBox>();
        List<PictureBox> RightBars = new List<PictureBox>();

        public VolumeLevel()
        {
            InitializeComponent();
            LeftBars.Add(Bar01L);
            LeftBars.Add(Bar02L);
            LeftBars.Add(Bar03L);
            LeftBars.Add(Bar04L);
            LeftBars.Add(Bar05L);
            LeftBars.Add(Bar06L);
            LeftBars.Add(Bar07L);
            LeftBars.Add(Bar08L);
            LeftBars.Add(Bar09L);
            LeftBars.Add(Bar10L);
            LeftBars.Add(Bar11L);
            LeftBars.Add(Bar12L);
            RightBars.Add(Bar01R);
            RightBars.Add(Bar02R);
            RightBars.Add(Bar03R);
            RightBars.Add(Bar04R);
            RightBars.Add(Bar05R);
            RightBars.Add(Bar06R);
            RightBars.Add(Bar07R);
            RightBars.Add(Bar08R);
            RightBars.Add(Bar09R);
            RightBars.Add(Bar10R);
            RightBars.Add(Bar11R);
            RightBars.Add(Bar12R);
        }

        static int Map(int a1, int a2, int b1, int b2, int s) => b1 + (s - a1) * (b2 - b1) / (a2 - a1);

        public int LeftCh
        {
            get { return lch; }
            set
            {
                lch = value;
                temp = Map(0, 100, 0, 12, lch);
                if (temp < 7)
                {
                    for (int i = 0; i < temp; i++)
                    {
                        LeftBars[i].BackColor = Color.LightGreen;
                    }
                    for (int i = temp; i < 7; i++)
                    {
                        LeftBars[i].BackColor = Color.FromArgb(0, 64, 0);
                    }
                    for (int i = 7; i < 10; i++)
                    {
                        LeftBars[i].BackColor = Color.FromArgb(64, 64, 0);
                    }
                    for (int i = 10; i < 12; i++)
                    {
                        LeftBars[i].BackColor = Color.FromArgb(64, 0, 0);
                    }
                }
                else if (lch > 31500)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        LeftBars[i].BackColor = Color.LightGreen;
                    }
                    for (int i = 7; i < 10; i++)
                    {
                        LeftBars[i].BackColor = Color.Yellow;
                    }
                    for (int i = 10; i < 12; i++)
                    {
                        LeftBars[i].BackColor = Color.Red;
                    }
                }
                else if (temp >= 7 && temp < 10)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        LeftBars[i].BackColor = Color.LightGreen;
                    }
                    for (int i = 7; i < temp; i++)
                    {
                        LeftBars[i].BackColor = Color.Yellow;
                    }
                    for (int i = temp; i < 10; i++)
                    {
                        LeftBars[i].BackColor = Color.FromArgb(64, 64, 0);
                    }
                    for (int i = 10; i < 12; i++)
                    {
                        LeftBars[i].BackColor = Color.FromArgb(64, 0, 0);
                    }
                }
                else if (temp >= 10)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        LeftBars[i].BackColor = Color.LightGreen;
                    }
                    for (int i = 7; i < 10; i++)
                    {
                        LeftBars[i].BackColor = Color.Yellow;
                    }
                    for (int i = 10; i < temp; i++)
                    {
                        LeftBars[i].BackColor = Color.Red;
                    }
                    for (int i = temp; i < 12; i++)
                    {
                        LeftBars[i].BackColor = Color.FromArgb(64, 0, 0);
                    }
                }
            }
        }

        public int RightCh
        {
            get { return rch; }
            set
            {
                rch = value;
                temp = Map(0, 100, 0, 12, rch);
                if (temp < 7)
                {
                    for (int i = 0; i < temp; i++)
                    {
                        RightBars[i].BackColor = Color.LightGreen;
                    }
                    for (int i = temp; i < 7; i++)
                    {
                        RightBars[i].BackColor = Color.FromArgb(0, 64, 0);
                    }
                    for (int i = 7; i < 10; i++)
                    {
                        RightBars[i].BackColor = Color.FromArgb(64, 64, 0);
                    }
                    for (int i = 10; i < 12; i++)
                    {
                        RightBars[i].BackColor = Color.FromArgb(64, 0, 0);
                    }
                }
                else if (rch > 31500)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        RightBars[i].BackColor = Color.LightGreen;
                    }
                    for (int i = 7; i < 10; i++)
                    {
                        RightBars[i].BackColor = Color.Yellow;
                    }
                    for (int i = 10; i < 12; i++)
                    {
                        RightBars[i].BackColor = Color.Red;
                    }
                }
                else if (temp >= 7 && temp < 10)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        RightBars[i].BackColor = Color.LightGreen;
                    }
                    for (int i = 7; i < temp; i++)
                    {
                        RightBars[i].BackColor = Color.Yellow;
                    }
                    for (int i = temp; i < 10; i++)
                    {
                        RightBars[i].BackColor = Color.FromArgb(64, 64, 0);
                    }
                    for (int i = 10; i < 12; i++)
                    {
                        RightBars[i].BackColor = Color.FromArgb(64, 0, 0);
                    }
                }
                else if (temp >= 10)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        RightBars[i].BackColor = Color.LightGreen;
                    }
                    for (int i = 7; i < 10; i++)
                    {
                        RightBars[i].BackColor = Color.Yellow;
                    }
                    for (int i = 10; i < temp; i++)
                    {
                        RightBars[i].BackColor = Color.Red;
                    }
                    for (int i = temp; i < 12; i++)
                    {
                        RightBars[i].BackColor = Color.FromArgb(64, 0, 0);
                    }
                }
            }
        }
    }
}
