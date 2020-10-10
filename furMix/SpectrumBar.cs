using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace furMix.Controls
{
    public partial class SpectrumBar : UserControl
    {
        byte level;
        List<PictureBox> Bars = new List<PictureBox>();
        public const int onePiece = 36;

        public SpectrumBar()
        {
            InitializeComponent();
            Bars.Add(Bar01);
            Bars.Add(Bar02);
            Bars.Add(Bar03);
            Bars.Add(Bar04);
            Bars.Add(Bar05);
            Bars.Add(Bar06);
            Bars.Add(Bar07);
        }

        public byte Level
        {
            get { return level; }
            set
            {
                level = value;
                int temp = level / onePiece;
                for (int i = 0; i < temp; i++)
                {
                    if (i < 3)
                    {
                        Bars[i].BackColor = Color.LightGreen;
                    }
                    else if (i >= 3 && i < 5)
                    {
                        Bars[i].BackColor = Color.Yellow;
                    }
                    else if (i >= 5)
                    {
                        Bars[i].BackColor = Color.Red;
                    }
                }
                for (int i = temp; i < 7; i++)
                {
                    if (i < 3)
                    {
                        Bars[i].BackColor = Color.FromArgb(0, 64, 0);
                    }
                    else if (i >= 3 && i < 5)
                    {
                        Bars[i].BackColor = Color.FromArgb(64, 64, 0);
                    }
                    else if (i >= 5)
                    {
                        Bars[i].BackColor = Color.FromArgb(64, 0, 0);
                    }
                }
            }
        }
    }
}
