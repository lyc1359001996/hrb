using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thsoft_core;

namespace DXApplication2.UL
{
    public partial class XuanFu : Form
    {
        const int WM_NCHITTEST = 0x0084;
        const int HTCLIENT = 0x0001;
        const int HTCAPTION = 0x0002;
        private Point ptMouseCurrrnetPos, ptMouseNewPos, ptFormPos, ptFormNewPos;
        public bool blnMouseDown = false;
        public string jine;
        IniFile ini = new IniFile(@"config\set.ini");
        /// <summary>
        /// 获取窗体的句柄函数
        /// </summary>
        /// <param name="lpClassName">窗口类名</param>
        /// <param name="lpWindowName">窗口标题名</param>
        /// <returns>返回句柄</returns>
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);

        /// <summary>
        /// 通过句柄，窗体显示函数
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="cmdShow">显示方式</param>
        /// <returns>返工成功与否</returns>
        [DllImport("user32.dll", EntryPoint = "ShowWindowAsync", SetLastError = true)]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        //public const int HTCAPTION = 0x0002;

        const int WM_NCLBUTTONDBLCLK = 0xA3;
        public const int WM_RBUTTONDOWN = 0x0204;
        public bool ISMIN = true;
        private void labelControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                //Return back signal
                blnMouseDown = false;
        }

        private void labelControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (blnMouseDown)
            {
                //Get the current position of the mouse in the screen
                ptMouseNewPos = Control.MousePosition;
                //Set window position
                ptFormNewPos.X = ptMouseNewPos.X - ptMouseCurrrnetPos.X + ptFormPos.X;
                ptFormNewPos.Y = ptMouseNewPos.Y - ptMouseCurrrnetPos.Y + ptFormPos.Y;
                //Save window position
                Location = ptFormNewPos;
                ptFormPos = ptFormNewPos;
                //Save mouse position
                ptMouseCurrrnetPos = ptMouseNewPos;

            }
        }

        private void labelControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                blnMouseDown = true;
                // Save window position and mouse position
                ptMouseCurrrnetPos = Control.MousePosition;
                ptFormPos = Location;
            }

            ReleaseCapture();
        }

        private void labelControl2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                //Return back signal
                blnMouseDown = false;
        }

        private void labelControl2_MouseMove(object sender, MouseEventArgs e)
        {
            if (blnMouseDown)
            {
                //Get the current position of the mouse in the screen
                ptMouseNewPos = Control.MousePosition;
                //Set window position
                ptFormNewPos.X = ptMouseNewPos.X - ptMouseCurrrnetPos.X + ptFormPos.X;
                ptFormNewPos.Y = ptMouseNewPos.Y - ptMouseCurrrnetPos.Y + ptFormPos.Y;
                //Save window position
                Location = ptFormNewPos;
                ptFormPos = ptFormNewPos;
                //Save mouse position
                ptMouseCurrrnetPos = ptMouseNewPos;

            }
        }
        private void labelControl2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                blnMouseDown = true;
                // Save window position and mouse position
                ptMouseCurrrnetPos = Control.MousePosition;
                ptFormPos = Location;
            }

            ReleaseCapture();
        }

        public string Message(string str)
        {
            ISMIN = true;
            return str;
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            
            IntPtr mainHandle = FindWindow(null, "Main");
            string jnie = ini.IniReadValue("mySqlCon2", "jine").Replace("￥", "");
            labelControl1.Text = "    " +jnie;
            ini.IniWriteValue("mySqlCon2", "jubing","");
            if (ISMIN == true)
            {
                if (mainHandle != IntPtr.Zero)
                {
                    bool result = ShowWindowAsync(mainHandle, 1);
                }
                else
                {

                }
            }
            else
            {

            }
            
        }

        public const int WM_LBUTTONDOWN = 0x0201;

        private void timer1_Tick(object sender, EventArgs e)
        {
                if (!ini.IniReadValue("mySqlCon2", "jubing").Equals(""))
                {
                    Console.WriteLine(ini.IniReadValue("mySqlCon2", "jubing").Replace("￥", ""));
                    labelControl1.Text = "    " +ini.IniReadValue("mySqlCon2", "jubing").Replace("￥", "");
                }
                else
                {
                    labelControl1.Text = "    " +ini.IniReadValue("mySqlCon2", "jubing").Replace("￥","");
                }
        }

        public XuanFu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            timer1.Start();
        }
    }
}
