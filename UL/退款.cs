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
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "McSkin";
            this.StartPosition = FormStartPosition.CenterScreen;
            labelControl1.Text = ini.IniReadValue("mySqlCon5", "orderon");
            textEdit1.Text = ini.IniReadValue("mySqlCon5", "realPayAmount");
        }

        private void 退款_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var json = WebUtils.MakeRequest(ini.IniReadValue("mySqlCon1", "loginurl"), "{\"userAccount\":\"" + ini.IniReadValue("mySqlCon2", "username") + "\",\"password\":\"" + textEdit3.Text + "\"}", "post", "http").Replace("\"", "").Replace("{", "").Replace("}", "");
            if (!(textEdit3.Text.Length >= 6 || textEdit3.Text.Length <= 16))
            {
                MessageBox.Show("密码长度为6—16位");
            }else if (decimal.Parse(textEdit2.Text)>decimal.Parse(textEdit1.Text))
            {
                MessageBox.Show("退款金额不能大于实付金额");
            }
            else if (json.Split(',')[1].Split(':')[1].Equals("3"))
            {
                MessageBox.Show(json.Split(',')[2].Split(':')[1]);
            }
            else if (json.Split(',')[1].Split(':')[1].Equals("0"))
            {
                var json1= WebUtils.MakeRequest1(ini.IniReadValue("mySqlCon1", "refundInfo"),"{\"storeId\":"+ini.IniReadValue("mySqlCon3", "storeId") + ",\"storeUserId\":\""+ini.IniReadValue("mySqlCon3", "userId") + "\",\"orderNumber\":\""+ini.IniReadValue("mySqlCon5", "orderon") + "\",\"retreatAmount\":\""+textEdit2.Text+"\"}","post","http", ini.IniReadValue("mySqlCon2", "authorization") + ini.IniReadValue("mySqlCon2", "authorization1")).Replace("\"","").Replace("{","").Replace("}","");
                var json2=WebUtils.MakeRequest1(ini.IniReadValue("mySqlCon1", "getOrderInfo"), "{\"storeUserId\":\""+ ini.IniReadValue("mySqlCon3", "userId") + "\",\"storeId\":\""+ ini.IniReadValue("mySqlCon3", "storeId") + "\",\"orderNumber\":\""+labelControl1.Text+"\"}","post","http", ini.IniReadValue("mySqlCon2", "authorization") + ini.IniReadValue("mySqlCon2", "authorization1")).Replace("\"", "").Replace("{", "").Replace("}", "");
                //Console.WriteLine(json+"\n"+json1+"\n"+json2);
                if (int.Parse(json2.Split(',')[7].Split(':')[1])==3)
                {
                    MessageBox.Show("退款成功");
                    this.Close();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            textEdit2.Text = textEdit1.Text;
        }
    }
}
