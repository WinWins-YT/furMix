using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace furMix.Utilities
{
    static class Capture
    {
        public static Bitmap CaptureScreen()
        {
            return CaptureWindow(User32.GetDesktopWindow());
        }

        public static Bitmap CaptureWindow(IntPtr handle)
        {

            IntPtr hdcSrc = User32.GetWindowDC(handle);

            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);

            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;

            IntPtr hdcDest = Gdi32.CreateCompatibleDC(hdcSrc);
            IntPtr hBitmap = Gdi32.CreateCompatibleBitmap(hdcSrc, width, height);

            IntPtr hOld = Gdi32.SelectObject(hdcDest, hBitmap);
            Gdi32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, SRCCOPY);
            Gdi32.SelectObject(hdcDest, hOld);
            Gdi32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);

            Bitmap image = Image.FromHbitmap(hBitmap);
            Gdi32.DeleteObject(hBitmap);

            return image;
        }

        public static Bitmap DrawToImage(this Control control)
        {
            return CaptureWindow(control.Handle);
        }

        public const int SRCCOPY = 13369376;
    }
}
