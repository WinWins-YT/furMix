using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using furMix.DialogBoxes;

namespace furMix.Utilities
{
    class ConvertPresentation
    {
        static string file;
        static string folder;

        public ConvertPresentation(string filename)
        {
            file = filename;
            FileInfo fileinfo = new FileInfo(file);
            folder = Path.GetTempPath() + @"\" + fileinfo.Name;
        }

        public List<string> Convert()
        {
            Loading load = new Loading();
            load.Show();
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            List<string> slides = new List<string>();
            Application ppt = new Application();
            Presentation pres = ppt.Presentations.Open(file, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);
            foreach (Slide slide in pres.Slides)
            {
                slide.Export(string.Format(folder + @"\Slide{0}.jpg", slide.SlideIndex), "jpg");
                slides.Add(string.Format(folder + @"\Slide{0}.jpg", slide.SlideIndex));
            }
            load.Close();
            load.Dispose();
            return slides;
        }
    }
}
