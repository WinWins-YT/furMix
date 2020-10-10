using System.Collections.Generic;
using System.Windows.Forms;

namespace furMix.DialogBoxes
{
    public partial class SpectrumLevel : Form
    {
        public SpectrumLevel()
        {
            InitializeComponent();
        }

        public void Set(List<byte> spectrum)
        {
            spectrumBar1.Level = spectrum[0];
            spectrumBar2.Level = spectrum[1];
            spectrumBar3.Level = spectrum[2];
            spectrumBar4.Level = spectrum[3];
            spectrumBar5.Level = spectrum[4];
            spectrumBar6.Level = spectrum[5];
            spectrumBar7.Level = spectrum[6];
            spectrumBar8.Level = spectrum[7];
            spectrumBar9.Level = spectrum[8];
            spectrumBar10.Level = spectrum[9];
            spectrumBar11.Level = spectrum[10];
            spectrumBar12.Level = spectrum[11];
            spectrumBar13.Level = spectrum[12];
            spectrumBar14.Level = spectrum[13];
            spectrumBar15.Level = spectrum[14];
        }

        private void SpectrumLevel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main.spectr = false;
        }
    }
}
