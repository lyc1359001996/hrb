using DXApplication2.HELP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DXApplication2.UL
{
    public partial class 代理 : Form
    {
        Internet Internet = new Internet();
        public 代理()
        {
            InitializeComponent();
            this.ControlBox = false;
            simpleButton2.Enabled = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if(textEdit1.Text.Equals("")||textEdit2.Text.Equals("")){
                MessageBox.Show("请输入ip信息");
            }
            if (comboBoxEdit1.SelectedIndex==0)
            {
                if (Internet.yanzhen(textEdit1.Text, int.Parse(textEdit2.Text)))
                {
                    Internet.SetIEProxy(textEdit1+":"+textEdit2.Text);
                    textEdit1.Text = "";
                    textEdit2.Text = "";
                }
                else
                {
                    MessageBox.Show("代理IP格式不正确", "提示", MessageBoxButtons.OK);
                }
            }else
            {
                Internet.SetIEProxy(string.Empty);
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
                    f.Visible = false;
                    num = num - 1;
                    i = i - 1;
                }
            }
        }

        private void 代理_FormClosing(object sender, FormClosingEventArgs e)
        {
            int num = Application.OpenForms.Count;
            for (int i = 0; i < num; i++)
            {
                Form f = Application.OpenForms[i];
                if (f.Name != "登录")
                {
                    f.Visible = false;
                    num = num - 1;
                    i = i - 1;
                }
            }
        }

        private void 代理_Load(object sender, EventArgs e)
        {

        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            simpleButton2.Enabled = true;
        }
    }
}
