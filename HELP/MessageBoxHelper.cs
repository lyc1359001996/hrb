using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoMessageBox
{
    public class MessageBoxHelper
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr FindWindow(IntPtr hwnd, string title);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern void MoveWindow(IntPtr hwnd, int x, int y, int nWidth, int nHeight, bool rePaint);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern bool GetWindowRect(IntPtr hwnd, out Rectangle rect);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int PostMessage(IntPtr hwnd, int msg, uint wParam, uint lParam);

        public const int WM_CLOSE = 0x10; 

        public const int WM_KEYDOWN = 0x0100;

        public const int WM_KEYUP = 0x0101;

        public const int VK_RETURN = 0x0D;

        public static bool IsWorking = false;
        
        public static string[] titles = new string[4] { "请选择", "提示", "错误", "警告" };
        
        public static void FindAndMoveWindow(string title, int x, int y)
        {
            Thread t = new Thread(() =>
            {
                IntPtr msgBox = IntPtr.Zero;
                while ((msgBox = FindWindow(IntPtr.Zero, title)) == IntPtr.Zero) ;
                Rectangle r = new Rectangle();
                GetWindowRect(msgBox, out r);
                MoveWindow(msgBox, x, y, r.Width - r.X, r.Height - r.Y, true);
            });
            t.Start();
        }
        
        private static void FindAndKillWindow(string title)
        {
            IntPtr ptr = FindWindow(IntPtr.Zero, title);
            if (ptr != IntPtr.Zero)
            {
                int ret = PostMessage(ptr, WM_CLOSE, 0, 0);
                Thread.Sleep(1000);
                ptr = FindWindow(IntPtr.Zero, title);
                if (ptr != IntPtr.Zero)
                {
                    PostMessage(ptr, WM_KEYDOWN, VK_RETURN, 0);
                    PostMessage(ptr, WM_KEYUP, VK_RETURN, 0);
                }
            }
        }
        
        public static void FindAndKillWindow()
        {
            Thread t = new Thread(() =>
            {
                while (IsWorking)
                {
                    foreach (string title in titles)
                    {
                        FindAndKillWindow(title);
                    }
                    Thread.Sleep(3000);
                }
            }); 

             t.Start();
        }
    }
}
