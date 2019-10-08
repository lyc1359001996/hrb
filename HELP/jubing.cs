using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DXApplication2.HELP
{
    class jubing
    {
        [DllImport("user32.dll")]
        public static extern int GetCursorPos(ref Point lpPoint);
        [DllImport("user32.dll")]
        public static extern int WindowFromPoint(int xPoint, int yPoint);
        [DllImport("user32.dll")]
        public static extern int GetWindowText(int hwnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        public static extern int GetClassName(int hwnd, StringBuilder lpstring, int nMaxCount);         
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, string lParam);
        bool isMouseUp = false;
        Point pi = new Point();
        int hwnd;
        StringBuilder name = new StringBuilder(256);
        string Name = "";
        public string timer()
        {
            if (isMouseUp)
            {
                GetCursorPos(ref pi);
                hwnd = WindowFromPoint(pi.X, pi.Y);
                GetWindowText(hwnd, name, 256);
                Name = name.ToString();
                GetClassName(hwnd, name, 256);
            }
            else
            {
                if (pi.X != 0)
                {
                    hwnd = WindowFromPoint(pi.X, pi.Y);
                    GetWindowText(hwnd, name, 256);
                    Name = name.ToString();
                    GetClassName(hwnd, name, 256);
                }
            }
            return Name;

        }
    }
}
