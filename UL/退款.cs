using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using thsoft_core;
using tools;

namespace DXApplication2.UL
{
    public partial class 退款 : Form
    {
        IniFile ini = new IniFile(@"config\set.ini");
        public 退款()
        {
            InitializeComponent();
            labelControl1.Text=ini.IniReadValue("mySqlCon5", "orderon");
            textEdit1.Text=ini.IniReadValue("mySqlCon5", "realPayAmount");
        }

        private void 退款_Load(object sender, EventArgs e)
        {
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var json=WebUtils.MakeRequest(ini.IniReadValue("mySqlCon1", "loginurl"), "{\"userAccount\":\"" + ini.IniReadValue("mySqlCon2", "username") + "\",\"password\":\"" + textEdit3.Text + "\"}", "post", "http").Replace("\"", "").Replace("{", "").Replace("}", "");
            Console.WriteLine(json.Split(',')[1].Split(':')[1]);
            if (textEdit3.Text.Length>=6||textEdit3.Text.Length<=16)
            {
                MessageBox.Show("密码长度为6—16位");
            }else if (json.Split(',')[1].Split(':')[1].Equals("3"))
            {
                MessageBox.Show(json.Split(',')[2].Split(':')[1]);
            }else if (json.Split(',')[1].Split(':')[1].Equals("0"))
            {
                this.Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            textEdit2.Text = textEdit1.Text;
        }
    }
}
