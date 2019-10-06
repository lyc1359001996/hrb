using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DXApplication2.UL
{
    public partial class 退出 : Form
    {
        public 退出()
        {
            InitializeComponent();
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "McSkin";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int num = Application.OpenForms.Count;
            for (int i = 0; i < num; i++)
            {
                Form f = Application.OpenForms[i];
                if (f.Name != "登录")
                {
                    f.Dispose();
                    num = num - 1;
                    i = i - 1;
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int num = Application.OpenForms.Count;
            for (int i = 0; i < num; i++)
            {
                Form f = Application.OpenForms[i];
                if (f.Name != "登录")
                {
                    f.Dispose();
                    num = num - 1;
                    i = i - 1;
                }
            }
            Main main = new Main();
            main.Show();
        }

        private void 退出_FormClosing(object sender, FormClosingEventArgs e)
        {
            int num = Application.OpenForms.Count;
            for (int i = 0; i < num; i++)
            {
                Form f = Application.OpenForms[i];
                if (f.Name != "登录")
                {
                    f.Dispose();
                    num = num - 1;
                    i = i - 1;
                }
            }
            Main main = new Main();
            main.Show();
        }

        private void 退出_Load(object sender, EventArgs e)
        {

        }
    }
}
