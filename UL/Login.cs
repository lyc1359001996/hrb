using Common.Utilities;
using DXApplication2.BLL;
using GalaSoft.MvvmLight.Messaging;
using SISS_thsoft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thsoft_core;

namespace DXApplication2.UL
{
    public partial class Login : Form
    {
        Daili daili = new Daili();
        string cfgINI = @"config\set.ini";
        B_User user = new B_User();
        
        public Login()
        {
            InitializeComponent();
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {
            daili.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(cfgINI);
            if (user.login(textEdit2.Text,textEdit1.Text))
            {
                Main main = new Main(textEdit2.Text);
                if (checkEdit1.Checked == true)
                {
                    ini.IniWriteValue("mySqlCon2", "username", textEdit2.Text);
                    ini.IniWriteValue("mySqlCon2", "pwd", textEdit1.Text);
                }else
                {
                    ini.IniWriteValue("mySqlCon2", "username", "");
                    ini.IniWriteValue("mySqlCon2", "pwd", "");
                }
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("账号或密码错误", "提示", MessageBoxButtons.OK);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(cfgINI);
            textEdit2.Text= ini.IniReadValue("mySqlCon2","username");
            textEdit1.Text =ini.IniReadValue("mySqlCon2", "pwd");
        }
    }
}
