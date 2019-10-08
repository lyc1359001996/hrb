using DXApplication2.HELP;
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
using tools;

namespace DXApplication2.UL
{
    public partial class 修改密码 : Form
    {
        ControlHelp control = new ControlHelp();
        IniFile ini = new IniFile(@"config\set.ini");
        public 修改密码()
        {
            InitializeComponent();
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "McSkin";
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            textEdit1.Text = "";
            textEdit2.Text = "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (IsDigitOrNumber(textEdit2.Text) == 1)
            {
                var json=WebUtils.MakeRequest1(ini.IniReadValue("mySqlCon1", "updatePwd"), "{\"oldPassword\":\"" + textEdit1.Text+ "\",\"newPassword\":\"" + textEdit2.Text+"\"}","post","http", ini.IniReadValue("mySqlCon2", "authorization") + ini.IniReadValue("mySqlCon2", "authorization1")).Replace("{","").Replace("}","").Replace("\"","");
                if (int.Parse(json.Split(',')[1].Split(':')[1])==0)
                {
                    MessageBox.Show("修改成功！");
                    this.Close();
                }else if (int.Parse(json.Split(',')[1].Split(':')[1]) == 1)
                {
                    MessageBox.Show("账户或密码不能为空！");
                }
                else if (int.Parse(json.Split(',')[1].Split(':')[1]) == 2)
                {
                    MessageBox.Show("账户或密码不在指定长度！");
                }
                else if (int.Parse(json.Split(',')[1].Split(':')[1]) == 3)
                {
                    MessageBox.Show("账户或密码错误！");
                }
                else if (int.Parse(json.Split(',')[1].Split(':')[1]) == 4)
                {
                    MessageBox.Show("帐户未激活！");
                }
                else if (int.Parse(json.Split(',')[1].Split(':')[1]) == 5)
                {
                    MessageBox.Show("该帐户不存在！");
                }
                else if (int.Parse(json.Split(',')[1].Split(':')[1]) == 6)
                {
                    MessageBox.Show("手机号格式不正确！");
                }
                else if (int.Parse(json.Split(',')[1].Split(':')[1]) == 7)
                {
                    MessageBox.Show("账户包含非法字符！");
                }
                else if (int.Parse(json.Split(',')[1].Split(':')[1]) == 8)
                {
                    MessageBox.Show("失败！");
                }
                else if (int.Parse(json.Split(',')[1].Split(':')[1]) == 9)
                {
                    MessageBox.Show("运行异常！");
                }
                else if (int.Parse(json.Split(',')[1].Split(':')[1]) == 10)
                {
                    MessageBox.Show("token失效,请重新登录！");
                }
            }
        }

        private int IsDigitOrNumber(string str)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(str, @"[`~!@#$%^&*()+=|{}':;',\\[\\].<>/?~！@#￥%……&*（）——+|{}【】‘；：”“’。，、？]|[a-z]"))
                return 1;
            else return 0;
        }

        private void 修改密码_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Dispose();
        }

        private void 修改密码_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            textEdit1.Text = "";
            textEdit2.Text = "";
        }
    }
}
