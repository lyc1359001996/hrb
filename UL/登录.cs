using Common.Utility;
using DemoMessageBox;
using DevExpress.XtraEditors.Controls;
using DXApplication2.HELP;
using DXApplication2.MODEL;
using GalaSoft.MvvmLight.Messaging;
using SISS_thsoft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using thsoft_core;
using tools;
using WindowsFormsApplication16;

namespace DXApplication2.UL
{
    public partial class 登录 : Form
    {
        代理 daili = new 代理();
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        private ControlHelp Control = new ControlHelp();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        public const int WM_CLOSE = 0x10;
        IniFile ini = new IniFile(@"config\set.ini");
        private bool isUserCancle = false;
        public 登录()
        {
            InitializeComponent();
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "McSkin";
            WaitFormService.Cancle += WaitFormService_Cancle;
            ini.IniWriteValue("mySqlCon2", "authorization", "");
            ini.IniWriteValue("mySqlCon2", "authorization1", "");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private bool WaitFormService_Cancle()
        {
            return isUserCancle;
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {
            daili.Show();
        }
        /*
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (ini.IniReadValue("mySqlCon2", "authorization").Equals("") && ini.IniReadValue("mySqlCon2", "authorization1").Equals(""))
            {
                string json = WebUtils.MakeRequest(ini.IniReadValue("mySqlCon1", "loginurl"), "{\"userAccount\":\"" + textEdit2.Text + "\",\"password\":\"" + textEdit1.Text + "\"}", "post", "http").Replace("\"", "").Replace("{", "").Replace("}", "");
                if (json.Split(',')[1].Split(':')[1].Equals("8"))
                {
                    MessageBox.Show("账号登录身份错误");
                }
                else if (json.Split(',')[1].Split(':')[1].Equals("9"))
                {
                    MessageBox.Show("账号或密码错误");
                }
                else if (json.Split(',')[1].Split(':')[1].Equals("0"))
                {
                    ini.IniWriteValue("mySqlCon3", "merchantId", json.Split(',')[4].Replace("merchantId:", ""));
                    ini.IniWriteValue("mySqlCon3", "storeId", json.Split(',')[5].Replace("storeId:", ""));
                    ini.IniWriteValue("mySqlCon3", "userId", json.Split(',')[6].Replace("userId:", ""));
                    ini.IniWriteValue("mySqlCon2", "authorization", json.Split(',')[3].Replace("data:authorization:", "").Substring(0, 65));
                    ini.IniWriteValue("mySqlCon2", "authorization1", json.Split(',')[3].Replace("data:authorization:", "").Substring(65));
                    var json1= WebUtils.MakeRequest1(ini.IniReadValue("mySqlCon1", "StoreInfo"), "{\"userId\":" + json.Split(',')[6].Replace("userId:", "")+ ",\"storeId\":"+ json.Split(',')[5].Replace("storeId:", "")+"}", "post","http",ini.IniReadValue("mySqlCon2", "authorization")+ ini.IniReadValue("mySqlCon2", "authorization1"));
                    ini.IniWriteValue("mySqlCon2", "username", textEdit2.Text);
                    string[] condition = { "}," };
                    StoreName StoreName = ConvertJson.DeserializeJsonToObject<StoreName>(json1.Replace("{\"success\":true,\"errorCode\":0,\"msg\":\"success\",\"data\":[", "").Replace("]}", "").Split(condition, StringSplitOptions.RemoveEmptyEntries)[0]+"}");
                    ini.IniWriteValue("mySqlCon3", "username", StoreName.userName);
                    ini.IniWriteValue("mySqlCon3", "roleId", StoreName.roleId.ToString());
                    ini.IniWriteValue("mySqlCon3", "storeName", StoreName.storeName);
                    ini.IniWriteValue("mySqlCon3", "userAccount", StoreName.userAccount);

                    th = new Thread(new ThreadStart(ExecWaitForm));
                    th.IsBackground = true;
                    th.Name = "ThreadExecWaitForm";
                    th.Start();

                    Main main = new Main();
                    this.Visible = false;
                    main.Show();
                }
            }
            */
            /*
            login(textEdit2.Text, textEdit1.Text);
            try
            {
                if (textEdit2.Text.Length == 12)
                {
                    if (textEdit1.Text.Length <= 16 && textEdit1.Text.Length >= 6)
                    {
                        if (IsDigitOrNumber(textEdit1.Text) == 0)
                        {
                            if (user.login(textEdit2.Text, textEdit1.Text))
                            {
                                IniFile ini = new IniFile(@"config\set.ini");
                                ini.IniWriteValue("mySqlCon2", "username", textEdit2.Text);

                                Main main = new Main();
                                //this.WindowState = FormWindowState.Minimized;
                                //simpleButton1.Visible = false;
                                this.Visible = false;
                                main.Show();
                            }
                            else
                            {
                                MessageBox.Show("账号或密码错误", "提示", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("密码必须为大写字母数字混合", "提示", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("密码必须为6-16位", "提示", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("账号不足12位", "提示", MessageBoxButtons.OK);
                }
            }
            catch (Exception e1) { { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); } }
            
        }
        */
        public bool IsNumberic(string message)
        {
            bool flag = false;
            string temp = @"/^(([1-9][0-9]*)|(([0]\.\d{1,2}|[1-9][0-9]*\.\d{1,2})))$/";
            Regex rex = new Regex(temp);

            if (rex.IsMatch(message))
            {
                flag = true;
                return flag;
            }
            else
            {
                MessageBox.Show("请确保您只输入了整数或带两位小数的实数");
                return flag;
            }
        }

        public string Date()
        {
            string NowYear = DateTime.Now.ToString("yyyy");
            string NowMouth = DateTime.Now.ToString("MM");
            string NowDay = DateTime.Now.ToString("dd");
            if (NowMouth.Length == 1)
            {
                NowMouth = "0" + NowMouth;
            }
            if (NowDay.Length == 1)
            {
                NowDay = "0" + NowDay;
            }
            return NowYear + NowMouth + NowDay;
        }

        public string CreateCheckCode()
        {
            char[] CharArray = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string sCode = "";
            Random random = new Random();
            for (int i = 0; i < 1; i++)
            {
                sCode += CharArray[random.Next(CharArray.Length)];
            }
            return sCode;
        }

        private int IsDigitOrNumber(string str)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(str, @"[`~!@#$%^&*()+=|{}':;',\\[\\].<>/?~！@#￥%……&*（）——+|{}【】‘；：”“’。，、？]|[a-z]"))
                return 1;
            else return 0;
        }

        public bool login(string name,string pwd)
        {
            if (ini.IniReadValue("mySqlCon2", "authorization").Equals("")&& ini.IniReadValue("mySqlCon2", "authorization1").Equals(""))
            {
                string json = WebUtils.MakeRequest(ini.IniReadValue("mySqlCon1", "loginurl"), "{\"userAccount\":\"" + name + "\",\"password\":\"" + pwd + "\"}", "post", "http").Replace("\"", "").Replace("{", "").Replace("}", "");
                if (json.Split(',')[1].Split(':')[1].Equals("8"))
                {
                    MessageBox.Show("账号登录身份错误");
                    return false;
                }
                else if (json.Split(',')[1].Split(':')[1].Equals("9"))
                {
                    MessageBox.Show("账号或密码错误");
                    return false;
                }
                else if(json.Split(',')[1].Split(':')[1].Equals("0"))
                {
                    ini.IniWriteValue("mySqlCon2", "authorization", json.Split(',')[3].Replace("data:authorization:", "").Substring(0,57));
                    ini.IniWriteValue("mySqlCon2", "authorization1", json.Split(',')[3].Replace("data:authorization:", "").Substring(57));
                    WebUtils.HttpGet(ini.IniReadValue("mySqlCon1", "StoreInfo"),ini.IniReadValue("mySqlCon2", "authorization")+ ini.IniReadValue("mySqlCon2", "authorization1"));
                    return true;
                }
            }
            return false;
        }


        private void Login_Load(object sender, EventArgs e)
        {
            textEdit2.Text = ini.IniReadValue("mySqlCon2", "username");
            textEdit1.Text = ini.IniReadValue("mySqlCon2", "pwd");
            MessageBoxHelper.IsWorking = true;
            MessageBoxHelper.FindAndKillWindow();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //textEdit1.Text = "";
        }

        private void 账号清除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textEdit2.Text = "";
        }

        private void 密码清除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textEdit1.Text = "";
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void textEdit2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textEdit2_TextChanged_1(object sender, EventArgs e)
        {
            if (textEdit2.Text.Length >= 18)
            {
                MessageBox.Show("输入框位数不应超过18位");
            }
        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            if (textEdit1.Text.Length >= 18)
            {
                MessageBox.Show("输入框位数不应超过18位");
            }
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ExecWaitForm()
        {
            try
            {
                WaitFormService.Show();
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex.Message);
            }
        }
        private void labelControl6_Click(object sender, EventArgs e)
        {
            login();
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                login();
            }
        }

        public void login()
        {
                if (ini.IniReadValue("mySqlCon2", "authorization").Equals("") && ini.IniReadValue("mySqlCon2", "authorization1").Equals(""))
                {
                    var json = WebUtils.MakeRequest(ini.IniReadValue("mySqlCon1", "loginurl"), "{\"userAccount\":\"" + textEdit2.Text + "\",\"password\":\"" + textEdit1.Text + "\"}", "post", "http").Replace("\"", "").Replace("{", "").Replace("}", "");
                    if (json.Split(',')[1].Split(':')[1].Equals("4"))
                    {
                        MessageBox.Show("帐户未激活");
                    }
                    else if (json.Split(',')[1].Split(':')[1].Equals("3"))
                    {
                        MessageBox.Show("账号或密码错误");
                    }
                    else if (json.Split(',')[1].Split(':')[1].Equals("0"))
                    {
                        ini.IniWriteValue("mySqlCon3", "merchantId", json.Split(',')[4].Replace("merchantId:", ""));
                        ini.IniWriteValue("mySqlCon3", "storeId", json.Split(',')[5].Replace("storeId:", ""));
                        ini.IniWriteValue("mySqlCon3", "userId", json.Split(',')[6].Replace("userId:", ""));
                        ini.IniWriteValue("mySqlCon2", "authorization", json.Split(',')[3].Replace("data:authorization:", "").Substring(0, 66));
                        ini.IniWriteValue("mySqlCon2", "authorization1", json.Split(',')[3].Replace("data:authorization:", "").Substring(66));
                        Console.WriteLine(json.Split(',')[3].Replace("data:authorization:", "").Substring(0, 66)+ json.Split(',')[3].Replace("data:authorization:", "").Substring(66));
                        Console.WriteLine(json.Split(',')[3].Replace("data:authorization:", ""));
                        var json1 = WebUtils.MakeRequest1(ini.IniReadValue("mySqlCon1", "StoreInfo"), "{\"userId\":" + json.Split(',')[6].Replace("userId:", "") + ",\"storeId\":" + json.Split(',')[5].Replace("storeId:", "") + "}", "post", "http", ini.IniReadValue("mySqlCon2", "authorization") + ini.IniReadValue("mySqlCon2", "authorization1"));
                        ini.IniWriteValue("mySqlCon2", "username", textEdit2.Text);
                        string[] condition = { "}," };
                        StoreName StoreName = ConvertJson.DeserializeJsonToObject<StoreName>(json1.Replace("{\"success\":true,\"errorCode\":0,\"msg\":\"success\",\"data\":[", "").Replace("]}", "").Split(condition, StringSplitOptions.RemoveEmptyEntries)[0] + "}");
                        ini.IniWriteValue("mySqlCon3", "username", StoreName.userName);
                        ini.IniWriteValue("mySqlCon3", "roleId", StoreName.roleId.ToString());
                        ini.IniWriteValue("mySqlCon3", "storeName", StoreName.storeName);
                        ini.IniWriteValue("mySqlCon3", "userAccount", StoreName.userAccount);
                        MessageBox.Show(this,"登录成功","提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Main main = new Main();
                        this.Visible = false;
                        main.Show();
                    }
                }
        }

        private void 登录_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBoxHelper.IsWorking = false;
        }

        private void labelControl6_MouseMove(object sender, MouseEventArgs e)
        {
            labelControl6.Appearance.BackColor = Color.FromArgb(14, 144, 254);
            labelControl6.Appearance.BackColor = Color.FromArgb(14, 144, 254);
            labelControl6.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            //labelControl6.BorderStyle = BorderStyles.Simple;
        }

        private void labelControl6_MouseLeave(object sender, EventArgs e)
        {
            labelControl6.Appearance.BackColor = Color.White;
            labelControl6.Appearance.BackColor = Color.White;
            //labelControl6.BorderStyle = BorderStyles.Simple;
        }
    }
}
