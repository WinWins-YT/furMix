using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furMix.Network.WebInterface
{
    public class ItemEventArgs
    {
        public int SelectedIndex { get; private set; }
        public string SelectedText { get; private set; }

        public ItemEventArgs(int index, string text)
        {
            SelectedIndex = index;
            SelectedText = text;
        }
    }
}
