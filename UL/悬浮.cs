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
    public partial class 悬浮 : Form
    {
        const int WM_NCHITTEST = 0x0084;
        const int HTCLIENT = 0x0001;
        const int HTCAPTION = 0x0002;
        private Point ptMouseCurrrnetPos, ptMouseNewPos, ptFormPos, ptFormNewPos;
        public bool blnMouseDown = false;
        public string jine;
        IniFile ini = new IniFile(@"config\set.ini");
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "ShowWindowAsync", SetLastError = true)]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;

        const int WM_NCLBUTTONDBLCLK = 0xA3;
        public const int WM_RBUTTONDOWN = 0x0204;
        public bool ISMIN = true;
        private void labelControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                blnMouseDown = false;
        }

        private void labelControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (blnMouseDown)
            {
                ptMouseNewPos = Control.MousePosition;
                ptFormNewPos.X = ptMouseNewPos.X - ptMouseCurrrnetPos.X + ptFormPos.X;
                ptFormNewPos.Y = ptMouseNewPos.Y - ptMouseCurrrnetPos.Y + ptFormPos.Y;
                Location = ptFormNewPos;
                ptFormPos = ptFormNewPos;
                ptMouseCurrrnetPos = ptMouseNewPos;

            }
        }

        private void labelControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                blnMouseDown = true;
                ptMouseCurrrnetPos = Control.MousePosition;
                ptFormPos = Location;
            }

            ReleaseCapture();
        }

        private void labelControl2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                blnMouseDown = false;
        }

        private void labelControl2_MouseMove(object sender, MouseEventArgs e)
        {
            if (blnMouseDown)
            {
                ptMouseNewPos = Control.MousePosition;
                ptFormNewPos.X = ptMouseNewPos.X - ptMouseCurrrnetPos.X + ptFormPos.X;
                ptFormNewPos.Y = ptMouseNewPos.Y - ptMouseCurrrnetPos.Y + ptFormPos.Y;
                Location = ptFormNewPos;
                ptFormPos = ptFormNewPos;
                ptMouseCurrrnetPos = ptMouseNewPos;

            }
        }
        private void labelControl2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                blnMouseDown = true;
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
            int num = Application.OpenForms.Count;
            for (int i = 0; i < num; i++)
            {
                Form f = Application.OpenForms[i];
                if (f.Name != "登录")
                {
                    if (f.Name != "悬浮")
                    {
                        f.Dispose();
                        num = num - 1;
                        i = i - 1;
                    }
                }
            }

            IntPtr mainHandle = FindWindow(null, "Main");
            string jnie = ini.IniReadValue("mySqlCon2", "jine").Replace("￥", "").Replace(".0.0",".0");
            labelControl1.Text = "      " + jnie;
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

        private void 悬浮_Click(object sender, EventArgs e)
        {
            
        }

        private void 悬浮_DoubleClick(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {
            
        }

        private void labelControl2_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void labelControl1_DoubleClick(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            int num = Application.OpenForms.Count;
            for (int i = 0; i < num; i++)
            {
                Form f = Application.OpenForms[i];
                if (f.Name != "登录")
                {
                    f.Show();
                }

                if (f.Name == "悬浮")
                {
                    f.Hide();
                }
            }
            悬浮 悬浮 = new 悬浮();
            悬浮.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ini.IniReadValue("mySqlCon2", "jubing").Length!=0)
                {
                labelControl1.Text = "      " + ini.IniReadValue("mySqlCon2", "jubing").Replace("￥", "").Replace(".0.0", ".0");
                }
                else
                {
                labelControl1.Text = "      " + ini.IniReadValue("mySqlCon2", "jubing").Replace("￥","").Replace(".0.0", ".0");
                }
        }

        public 悬浮()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            timer1.Start();
            this.TopMost = true;
            this.Left = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - 300;
            this.Top = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
