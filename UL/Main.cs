using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Common.Utility;
using CustomPrint;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using DXApplication2.BLL;
using DXApplication2.DAL;
using DXApplication2.HELP;
using DXApplication2.MODEL;
using DXApplication2.UL;
using GalaSoft.MvvmLight.Messaging;
using Hook;
using java.security;
using KellComUtility;
using Maticsoft.Common;
using Microsoft.Win32;
using OCR.ImageRecognition;
using QQ截图工具;
using ScanningAfter;
using SISS_thsoft;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using thsoft_core;
using tools;
using USBControlUtility;
using Utilities;
using static System.Net.WebRequestMethods;

namespace DXApplication2
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        private B_User user = new B_User();
        private B_Order Order = new B_Order();
        private Calculator Calcuator = new Calculator();
        XuanFu xuanfu = new XuanFu();
        private ControlHelp Control = new ControlHelp();
        private StringBuilder inputKey = new StringBuilder();
        private DateTime previewTime = DateTime.Now;
        private B_quicksetting quicksetting = new B_quicksetting();
        private Setting setting = new Setting();
        private readonly KeyboardHook1 _keyboardHook = new KeyboardHook1();
        private MouseHook _mouseHook = new MouseHook();
        private Helper helper = new Helper();
        jubing jubing = new jubing();
        IniFile ini = new IniFile(@"config\set.ini");
        B_currencysetting currencysetting = new B_currencysetting();
        private static PrintDocument printDocument;
        private static Order printOrder;
        private static object lockObj;
        private UpdPwd Updpwd = new UpdPwd();
        private ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        public bool isTog { get; set; }
        LabelControl labelq = new LabelControl();
        QRcode QRcode = new QRcode();
        public decimal totalAmount;
        public bool ishoudo = false;
        private string strPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        AspriseOCR ocr = new AspriseOCR();
        Cutter cutter = null;
        private bool Iscome { get; set; }
        private bool Isgo { get; set; }
        private string name = "";
        [DllImport("user32.dll")]
        public static extern int GetCursorPos(ref Point lpPoint);  //获取鼠标坐标，该坐标是光标所在的屏幕坐标位置
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(int xPoint, int yPoint);  //指定坐标处窗体句柄
        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hwnd, StringBuilder lpString, int nMaxCount);//获取窗体标题名称
        [DllImport("user32.dll")]
        public static extern int GetClassName(IntPtr hwnd, StringBuilder lpstring, int nMaxCount); //获取窗体类名称           
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, string lParam);
        bool isMouseUp = false;
        Point pi = new Point();
        Point p = new Point();
        IntPtr hwnd;
        string WM_SETTEXT = "&HC";
        StringBuilder name3 = new StringBuilder(256);
        KeyboardHook BarCode = new KeyboardHook();
        private SetControlRectangle Rectory;
        public Main()
        {
            InitializeComponent();
            BarCode.KeyDownEvent += BarCode_KeyDownEvent;
            Messenger.Default.Register<string>(this, m => xuanfu.Message(m));
            _keyboardHook.SetHook();
        }
        
        public Main(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void BarCode_KeyDownEvent(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                string temp = string.Empty;
                DateTime nowTime = DateTime.Now;
                if ((e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9))
                {
                    temp = (e.KeyData.ToString()).Last().ToString();
                    //Content.Text = (e.KeyData.ToString()).Last().ToString();
                }
                else
                {
                    temp = e.KeyData.ToString();
                }
                if ((nowTime - previewTime).Milliseconds < 20)
                {
                    if (e.KeyValue == (int)Keys.Return && inputKey.Length > 2)
                    {
                        previewTime = DateTime.Now;
                        return;
                    }
                    inputKey.Append(temp);
                    string tempContent = inputKey.ToString();
                    if (isTog == false && ishoudo == false)
                    {
                        if (tempContent.Contains("Space"))
                        {
                            string s = tempContent.Substring(tempContent.LastIndexOf("Space") + 5);
                            //Content.Text = s;
                            Console.WriteLine(s);
                        }
                        else
                        {
                            Console.WriteLine(tempContent);
                        }
                    }
                    else if (isTog == true && ishoudo == false)
                    {
                        if (tempContent.Contains("Space"))
                        {
                            string s = tempContent.Substring(tempContent.LastIndexOf("Space") + 5);
                            Console.WriteLine(s);
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        //Content.Text = "";
                    }
                }
                else
                {
                    inputKey = new StringBuilder(temp);
                }
                previewTime = DateTime.Now;
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Control.ButtonStyle(simpleButton1);
                Control.ButtonStyle1(simpleButton4, simpleButton2, simpleButton3, simpleButton5);
                xtraTabControl1.SelectedTabPageIndex = 0;
                BarCode.Start();
                byte[] key = Convert.FromBase64String("YWJjZGVmZ2hpamtsbW5vcHFyc3R1dnd4");
                byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };      //当模式为ECB时，IV无用
                System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                byte[] data = utf8.GetBytes("中国ABCabc123");
                byte[] str3 = Des3.Des3EncodeCBC(key, iv, data);
                System.Console.WriteLine(Convert.ToBase64String(str3));
            }
            catch (Exception e1){ MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
            
        }

        public void InitConsumer()
        {
            try
            {
                //创建连接工厂
                IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
                //通过工厂构建连接
                IConnection connection = factory.CreateConnection();
                //这个是连接的客户端名称标识
                connection.ClientId = "firstQueueListener";
                //启动连接，监听的话要主动启动连接
                connection.Start();
                //通过连接创建一个会话
                ISession session = connection.CreateSession();
                //通过会话创建一个消费者，这里就是Queue这种会话类型的监听参数设置
                IMessageConsumer consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("firstQueue"), "filter='demo'");
                //注册监听事件
                consumer.Listener += new MessageListener(consumer_Listener);
                //connection.Stop();
                //connection.Close();  
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        void consumer_Listener(IMessage message)
        {
            try
            {
                ITextMessage msg = (ITextMessage)message;
                //异步调用下，否则无法回归主线程

                labelControl1.Invoke(new DelegateRevMessage(RevMessage), msg);
            } catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); } 
        }

        public delegate void DelegateRevMessage(ITextMessage message);

        public void RevMessage(ITextMessage message)
        {
            try
            {
                Console.WriteLine(string.Format(@"接收到:{0}{1}", message.Text, Environment.NewLine));
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
           
            
        }


        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                Log4NetHelper.InitLog4Net(Application.StartupPath + "/log4net.config");
                xuanfu.Show();
                Control.GridControl(gridView2);
                Control.TimeEdit(dateEdit1);
                Control.TimeEdit(dateEdit2);
                Control.ComboBoxEdit(comboBoxEdit1);
                Control.ComboBoxEdit(comboBoxEdit2);
                gridControl1.DataSource = Order.SelectOrder();
                gridControl2.DataSource = Order.SelectOrder();
                Control.comboBoxEdit1(comboBoxEdit1);
                Control.comboBoxEdit2(comboBoxEdit2);
                //Control.xtraTabControl(xtraTabControl1,xtraTabPage1, xtraTabPage2, xtraTabPage3, xtraTabPage4);
                //xtraTabControl1.SelectedTabPageIndex = 3;
                Control.OrderSetting(dateEdit1, labelControl16, labelControl15, labelControl17, labelControl13, labelControl14, labelControl12, labelControl11, labelControl23, labelControl22, labelControl24);
                Control.radioGroup(radioGroup1);
                labelControl1.Text = user.Select(this.name).Rows[0][3].ToString();
                labelControl2.Text = user.Select1(user.Select(this.name).Rows[0][0].ToString()).Rows[0][0].ToString();
                setting.Fillgraspsetting(toggleSwitch1, radioGroup1, comboBoxEdit3,
    comboBoxEdit4, comboBoxEdit6, comboBoxEdit5, spinEdit1, toggleSwitch2, textEdit4, textEdit5, toggleSwitch3, spinEdit2, textEdit6,
    comboBoxEdit7, textEdit7, comboBoxEdit8, textEdit8, comboBoxEdit9, textEdit9, comboBoxEdit10, textEdit10, comboBoxEdit11,
    textEdit11, comboBoxEdit12, checkEdit1, comboBoxEdit13, this.name);
                Control.print5(comboBoxEdit23);
                Control.fillprint(toggleSwitch6, toggleSwitch7, toggleSwitch8, spinEdit3, spinEdit4, comboBoxEdit23, this.name);
                Control.currencysetting1(toggleSwitch9, toggleSwitch10, toggleSwitch11, toggleSwitch12, toggleSwitch16, spinEdit5, toggleSwitch14, toggleSwitch13, toggleSwitch17, this.name);
                Control.AccountInformation(comboBoxEdit24, this.name, labelControl109);
                labelControl108.Text = this.name;
                if (toggleSwitch12.IsOn == true)
                {
                    xuanfu.Show();
                }
                else
                {
                    xuanfu.Hide();
                }
                if (toggleSwitch4.IsOn == true)
                {
                    timer1.Start();
                }
                InitConsumer();
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
            
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_Resize(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    Messenger.Default.Send(this.WindowState);
                }
            }
            catch (Exception e1){ MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
            
        }

        private void textEdit2_TextChanged(object sender, EventArgs e)
        {

            Console.WriteLine(textEdit2.Text);
        }

        private void textEdit2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (textEdit2.Text.Length == 4)
                {
                    textEdit2.Text += "-";
                }
                else if (textEdit2.Text.Length == 9)
                {
                    textEdit2.Text += "-";
                }
                else if (textEdit2.Text.Length == 14)
                {
                    textEdit2.Text += "-";
                }
            }
            catch (Exception e1){ MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Control.ButtonStyle(simpleButton2);
                Control.ButtonStyle1(simpleButton4, simpleButton1, simpleButton3, simpleButton5);
                BarCode.Start();
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。");  Log4NetHelper.WriteErrorLog(e1.Message); }
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Control.ButtonStyle(simpleButton3);
                Control.ButtonStyle1(simpleButton4, simpleButton2, simpleButton1, simpleButton5);
                xtraTabControl1.SelectedTabPageIndex = 2;
                Control.OrderSetting(dateEdit1, labelControl16, labelControl15, labelControl17, labelControl13, labelControl14, labelControl12, labelControl11, labelControl23, labelControl22, labelControl24);
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                Control.ButtonStyle(simpleButton4);
                Control.ButtonStyle1(simpleButton1, simpleButton2, simpleButton3, simpleButton5);
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //fileDialog.Title = "导出Excel";
                saveFileDialog1.Filter = "Excel文件(*.xls)|*.xls";
                saveFileDialog1.FileName = DateTime.Now.ToShortDateString().ToString().Replace("/", "-");
                DialogResult dialogResult = saveFileDialog1.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                    gridControl1.ExportToXls(saveFileDialog1.FileName);
                    DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                gridControl2.DataSource = Order.SelectOrder();
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                Control.print5(gridView2.GetFocusedRowCellValue("OrderBH").ToString(), comboBoxEdit23.Text);
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void repositoryItemButtonEdit3_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            Console.WriteLine(3);
        }

        private void simpleButton23_Click(object sender, EventArgs e)
        {
            try
            {
                Control.OrderSetting2(dateEdit2, dateEdit1, gridControl2, comboBoxEdit1, comboBoxEdit2, comboBoxEdit2, searchControl1);
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }



        private void simpleButton6_Click(object sender, EventArgs e)
        {
            Calcuator.add("7",textEdit1);
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            Calcuator.add("8", textEdit1);
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            Calcuator.add("9", textEdit1);
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            Calcuator.add("4", textEdit1);
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            Calcuator.add("5", textEdit1);
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            Calcuator.add("6", textEdit1);
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            Calcuator.add("1", textEdit1);
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            Calcuator.add("2", textEdit1);
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            Calcuator.add("3", textEdit1);
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            Calcuator.add("0", textEdit1);
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            Calcuator.add("00", textEdit1);
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            Calcuator.add(".", textEdit1);
        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            Calcuator.Del(textEdit1);
        }

        private void simpleButton22_Click(object sender, EventArgs e)
        {
            Calcuator.empty(textEdit1);
        }

        private void simpleButton19_Click(object sender, EventArgs e)
        {
            try
            {
                labelControl29.Text = "应收" + textEdit1.Text + "元";
                WebUtils.MakeRequest("http://47.111.139.146:8080/ali/pay", "{\"totalAmount\":\"" + ini.IniReadValue("mySqlCon2", "jubing").Replace("￥", "") + "\",\"orderNo\":\"" + GetTimeStamp() + "\"}", "post", "http");
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
            labelControl29.Text = "应收"+textEdit1.Text+"元";
        }

        private void labelControl30_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                Control.ButtonStyle(simpleButton5);
                Control.ButtonStyle1(simpleButton1, simpleButton2, simpleButton3, simpleButton4);
                xtraTabControl1.SelectedTabPageIndex = 3;
                Control.radioGroup(radioGroup1);
                Control.baudrate(comboBoxEdit4);
                setting.Fillgraspsetting(toggleSwitch1, radioGroup1, comboBoxEdit3,
    comboBoxEdit4, comboBoxEdit6, comboBoxEdit5, spinEdit1, toggleSwitch2, textEdit4, textEdit5, toggleSwitch3, spinEdit2, textEdit6,
    comboBoxEdit7, textEdit7, comboBoxEdit8, textEdit8, comboBoxEdit9, textEdit9, comboBoxEdit10, textEdit10, comboBoxEdit11,
    textEdit11, comboBoxEdit12, checkEdit1, comboBoxEdit13, this.name);
                Control.quicksetting(toggleSwitch5, comboBoxEdit14, textEdit12, comboBoxEdit15, textEdit13, comboBoxEdit17, textEdit15, comboBoxEdit16, textEdit14, comboBoxEdit19, textEdit17, comboBoxEdit18, textEdit16, comboBoxEdit21, textEdit19, comboBoxEdit20, textEdit18, comboBoxEdit22, textEdit20, this.name);
                Control.fillprint(toggleSwitch6, toggleSwitch7, toggleSwitch8, spinEdit3, spinEdit4, comboBoxEdit23, this.name);
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }
        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            
            
            //Console.WriteLine(ocr.Recognize("C:/Users/Administrator/Desktop/3.jpg"));
        }

        private void xtraTabControl3_Click(object sender, EventArgs e)
        {
              
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioGroup1.SelectedIndex == 1)
                {
                    xtraTabControl3.SelectedTabPageIndex = 1;
                }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void simpleButton24_Click(object sender, EventArgs e)
        {
            try
            {
                if (xtraTabControl3.SelectedTabPageIndex == 1)
                {
                    setting.Updgraspsetting1(toggleSwitch1, radioGroup1, toggleSwitch4, spinEdit1, toggleSwitch2, textEdit4, textEdit5, toggleSwitch3, spinEdit2, textEdit6,
    comboBoxEdit7, textEdit7, comboBoxEdit8, textEdit8, comboBoxEdit9, textEdit9, comboBoxEdit10, textEdit10, comboBoxEdit11,
    textEdit11, comboBoxEdit12, checkEdit1, comboBoxEdit13, this.name);
                    setting.Fillgraspsetting(toggleSwitch1, radioGroup1, comboBoxEdit3,
    comboBoxEdit4, comboBoxEdit6, comboBoxEdit5, spinEdit1, toggleSwitch2, textEdit4, textEdit5, toggleSwitch3, spinEdit2, textEdit6,
    comboBoxEdit7, textEdit7, comboBoxEdit8, textEdit8, comboBoxEdit9, textEdit9, comboBoxEdit10, textEdit10, comboBoxEdit11,
    textEdit11, comboBoxEdit12, checkEdit1, comboBoxEdit13, this.name);
                }
                else
                {
                    setting.Updgraspsetting(toggleSwitch1, radioGroup1, comboBoxEdit3,
    comboBoxEdit4, comboBoxEdit6, comboBoxEdit5, spinEdit1, toggleSwitch2, textEdit4, textEdit5, toggleSwitch3, spinEdit2, textEdit6,
    comboBoxEdit7, textEdit7, comboBoxEdit8, textEdit8, comboBoxEdit9, textEdit9, comboBoxEdit10, textEdit10, comboBoxEdit11,
    textEdit11, comboBoxEdit12, checkEdit1, comboBoxEdit13, this.name);
                    setting.Fillgraspsetting(toggleSwitch1, radioGroup1, comboBoxEdit3,
    comboBoxEdit4, comboBoxEdit6, comboBoxEdit5, spinEdit1, toggleSwitch2, textEdit4, textEdit5, toggleSwitch3, spinEdit2, textEdit6,
    comboBoxEdit7, textEdit7, comboBoxEdit8, textEdit8, comboBoxEdit9, textEdit9, comboBoxEdit10, textEdit10, comboBoxEdit11,
    textEdit11, comboBoxEdit12, checkEdit1, comboBoxEdit13, this.name);
                }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }

        }

        private void simpleButton25_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabControl2_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            try
            {
                if (xtraTabControl2.SelectedTabPageIndex == 1)
                {
                    //setting.Fillquicksetting(toggleSwitch5,comboBoxEdit14,comboBoxEdit15,comboBoxEdit16,comboBoxEdit17,comboBoxEdit18,comboBoxEdit19,comboBoxEdit20,comboBoxEdit21,comboBoxEdit22,textEdit12,textEdit13,textEdit14,textEdit15,textEdit16,textEdit17,textEdit18,textEdit19,textEdit20,this.name);
                }
                else if (xtraTabControl2.SelectedTabPageIndex == 0)
                {
                    setting.Fillgraspsetting(toggleSwitch1, radioGroup1, comboBoxEdit3,
    comboBoxEdit4, comboBoxEdit6, comboBoxEdit5, spinEdit1, toggleSwitch2, textEdit4, textEdit5, toggleSwitch3, spinEdit2, textEdit6,
    comboBoxEdit7, textEdit7, comboBoxEdit8, textEdit8, comboBoxEdit9, textEdit9, comboBoxEdit10, textEdit10, comboBoxEdit11,
    textEdit11, comboBoxEdit12, checkEdit1, comboBoxEdit13, this.name);
                }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }

        }

        private void textEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void xtraTabControl2_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine(e.KeyChar);
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {

            Console.WriteLine(e.KeyData+""+e.KeyValue);
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyData+""+e.KeyValue);
        }

        private void textEdit6_KeyPress(object sender, KeyPressEventArgs e)
        {
            textEdit6.Text = e.KeyChar.ToString().ToUpper();
        }

        private void textEdit7_KeyPress(object sender, KeyPressEventArgs e)
        {
            textEdit7.Text = e.KeyChar.ToString().ToUpper();
        }

        private void textEdit8_KeyPress(object sender, KeyPressEventArgs e)
        {
            textEdit8.Text = e.KeyChar.ToString().ToUpper();
        }

        private void textEdit9_KeyPress(object sender, KeyPressEventArgs e)
        {
            textEdit9.Text = e.KeyChar.ToString().ToUpper();
        }

        private void textEdit10_KeyPress(object sender, KeyPressEventArgs e)
        {
            textEdit10.Text = e.KeyChar.ToString().ToUpper();
        }

        private void textEdit11_KeyPress(object sender, KeyPressEventArgs e)
        {
            textEdit6.Text = e.KeyChar.ToString().ToUpper();
        }

        private void textEdit12_KeyPress(object sender, KeyPressEventArgs e)
        {
            textEdit12.Text = e.KeyChar.ToString().ToUpper();
        }

        private void textEdit13_KeyPress(object sender, KeyPressEventArgs e)
        {
            textEdit13.Text = e.KeyChar.ToString().ToUpper();
        }

        private void textEdit15_KeyPress(object sender, KeyPressEventArgs e)
        {
            textEdit15.Text = e.KeyChar.ToString().ToUpper();
        }

        private void textEdit14_KeyPress(object sender, KeyPressEventArgs e)
        {
            textEdit14.Text = e.KeyChar.ToString().ToUpper();
        }

        private void textEdit17_KeyPress(object sender, KeyPressEventArgs e)
        {
            textEdit17.Text = e.KeyChar.ToString().ToUpper();
        }

        private void textEdit16_KeyPress(object sender, KeyPressEventArgs e)
        {
            textEdit16.Text = e.KeyChar.ToString().ToUpper();
        }

        private void textEdit19_KeyPress(object sender, KeyPressEventArgs e)
        {
            textEdit19.Text = e.KeyChar.ToString().ToUpper();
        }

        private void textEdit18_KeyPress(object sender, KeyPressEventArgs e)
        {
            textEdit18.Text = e.KeyChar.ToString().ToUpper();
        }

        private void textEdit20_KeyPress(object sender, KeyPressEventArgs e)
        {
            textEdit20.Text = e.KeyChar.ToString().ToUpper();
        }

        private void xtraTabControl2_Click(object sender, EventArgs e)
        {
            
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                SerialPort sp = sender as SerialPort;
                byte[] buf = new byte[sp.BytesToRead];
                sp.Read(buf, 0, buf.Length);
                builder.Append(ComUtility.GetHex(buf).ToUpper());
                string content = builder.ToString();
                this.Invoke((EventHandler)(delegate
                {

                    string str = helper.HexStringToString(content.Replace(" ", "").Replace("QA", ""), Encoding.UTF8);
                    Console.WriteLine(str);
                    Regex reg = new Regex(@"(([1-9][0-9]{0,14})|([0]{1})|(([0]\\.\\d{1,2}|[1-9][0-9]{0,14}\\.\\d{1,2})))");
                    var mat = reg.Matches(str);
                    string str111 = "";
                    foreach (Match item in mat)
                    {
                        str111 += item.Groups[1] + ".";
                    }
                    string str2 = str111.Remove(str111.Length - 1, 1);
                    string str3 = str2.Remove(str2.Length - 1, 1);
                    string str4 = str3.Remove(str3.Length - 1, 1);
                    ini.IniWriteValue("mySqlCon2", "jine", "");
                    ini.IniWriteValue("mySqlCon2", "jine", str4);
                    this.totalAmount = decimal.Parse(str4);
                }));
            }
           catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            try
            {
                if (toggleSwitch1.IsOn == true)
                {
                    if (radioGroup1.SelectedIndex == 0 && !comboBoxEdit3.Text.Equals(""))
                    {
                        serialPort1.PortName = comboBoxEdit3.Text;
                        Chuankou.OpenOrClosePort(true, serialPort1, comboBoxEdit4);
                    }
                }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            try
            {
                if (xtraTabControl1.SelectedTabPageIndex == 3)
                {
                    setting.Fillgraspsetting(toggleSwitch1, radioGroup1, comboBoxEdit3,
    comboBoxEdit4, comboBoxEdit6, comboBoxEdit5, spinEdit1, toggleSwitch2, textEdit4, textEdit5, toggleSwitch3, spinEdit2, textEdit6,
    comboBoxEdit7, textEdit7, comboBoxEdit8, textEdit8, comboBoxEdit9, textEdit9, comboBoxEdit10, textEdit10, comboBoxEdit11,
    textEdit11, comboBoxEdit12, checkEdit1, comboBoxEdit13, this.name);
                    Control.baudrate(comboBoxEdit4);
                }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

       

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (radioGroup1.SelectedIndex == 1)
                {
                    if (isMouseUp)//左键是否被按下
                    {
                        GetCursorPos(ref pi); //获取鼠标坐标值
                        Console.WriteLine("坐标：X=" + pi.X + "  |  Y=" + pi.Y); //label1显示鼠标坐标值的x值与y值
                        hwnd = WindowFromPoint(pi.X, pi.Y);//获取坐标值下的窗体句柄
                        Console.WriteLine("句柄：" + hwnd.ToString());//lable2显示句柄，貌似SPY++是十六进制的，这个是十进制的
                        GetWindowText(hwnd, name3, 256);//name得到窗体的标题
                        ini.IniWriteValue("mySqlCon2", "jubing", name3.ToString());//label3显示标题
                        GetClassName(hwnd, name3, 256);//name得到class的名称（这个我也不知道叫什么）
                        Console.WriteLine("名称：" + name3.ToString());//显示class的名称
                    }
                    else
                    {
                        if (pi.X != 0)
                        {
                            //Console.WriteLine("坐标：X=" + pi.X + "  |  Y=" + pi.Y); //label1显示鼠标坐标值的x值与y值
                            hwnd = WindowFromPoint(pi.X, pi.Y);//获取坐标值下的窗体句柄
                            Console.WriteLine("句柄：" + hwnd.ToString());//lable2显示句柄，貌似SPY++是十六进制的，这个是十进制的
                            GetWindowText(hwnd, name3, 256);//name得到窗体的标题
                            Console.WriteLine("标题：" + name3.ToString());//label3显示标题
                            ini.IniWriteValue("mySqlCon2", "jubing", name3.ToString());
                            GetClassName(hwnd, name3, 256);//name得到class的名称（这个我也不知道叫什么）
                            Console.WriteLine("名称：" + name3.ToString());//显示class的名称
                        }
                    }
                }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void toggleSwitch4_Toggled(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void simpleButton1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        private void simpleButton20_Click(object sender, EventArgs e)
        {
            try
            {
                Maticsoft.Common.WebClient client = new WebClient();
                string json = WebUtils.MakeRequest("http://47.111.139.146:8080/ali/pay", "{\"totalAmount\":\"" + ini.IniReadValue("mySqlCon2", "jubing").Replace("￥", "") + "\",\"orderNo\":\"" + GetTimeStamp() + "\"}", "post", "http");
                QRcode.Create("https:" + json.Replace("\"", "").Replace("{", "").Replace("}", "").Replace("alipay_trade_precreate_response", "").Replace("\\", "").Split(',')[3].Split(':')[2], 4, "E:/hrb/");
                labelControl4.Appearance.Image = Image.FromFile("E:/hrb/1.jpg");
                labelControl29.Text = "应收" + this.totalAmount.ToString() + "元";
                //string NamestoreId= my_sql.listTable("SELECT Id FROM namestore WHERE NameStore='"+labelControl2.Text+"';").Rows[0][0].ToString();
                //string Name= my_sql.listTable("SELECT Id FROM `user` WHERE UserName='"+labelControl1.Text+"';").Rows[0][0].ToString();
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void labelControl66_Click(object sender, EventArgs e)
        {
            
        }

        private void toggleSwitch4_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseUp = false;//鼠标左右键被弹起
            Cursor = Cursors.Default;//改变鼠标样式为默认
        }

        private void toggleSwitch4_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseUp = true;//鼠标左右键被按下
            Cursor = Cursors.Cross; //改变鼠标样式为十字架
        }

        private void simpleButton26_Click(object sender, EventArgs e)
        {
            try
            {
                Control.UPdprint(toggleSwitch6, toggleSwitch7, toggleSwitch8, spinEdit3, spinEdit4, comboBoxEdit23, this.name);
                Control.fillprint(toggleSwitch6, toggleSwitch7, toggleSwitch8, spinEdit3, spinEdit4, comboBoxEdit23, this.name);
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void toggleSwitch9_Toggled(object sender, EventArgs e)
        {
            try {
            string path = Application.ExecutablePath;
            RegistryKey rk = Registry.LocalMachine;
            RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            if (toggleSwitch9.IsOn == true)
            {
                rk2.SetValue("JcShutdown", path);
                rk2.Close();
                rk.Close();
            }
            else
            {
                rk2.DeleteValue("JcShutdown", false);
                rk2.Close();
                rk.Close();
            }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void toggleSwitch12_Toggled(object sender, EventArgs e)
        {
            try
            {
                if (toggleSwitch12.IsOn == true)
                {
                    xuanfu.Show();
                }
                else
                {
                    xuanfu.Hide();
                }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void simpleButton27_Click(object sender, EventArgs e)
        {
            try
            {
                Control.currencysetting(toggleSwitch9, toggleSwitch10, toggleSwitch11, toggleSwitch12, toggleSwitch16, spinEdit5, toggleSwitch14, toggleSwitch13, toggleSwitch17, this.name);
                Control.currencysetting1(toggleSwitch9, toggleSwitch10, toggleSwitch11, toggleSwitch12, toggleSwitch16, spinEdit5, toggleSwitch14, toggleSwitch13, toggleSwitch17, this.name);
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void simpleButton29_Click(object sender, EventArgs e)
        {
            Updpwd.Show();
        }

        private void simpleButton28_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void textEdit12_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton30_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioGroup1.SelectedIndex == 2)
                {
                    Bitmap CatchBmp = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);

                    Graphics g = Graphics.FromImage(CatchBmp);
                    g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));

                    cutter = new Cutter();
                    cutter.BackgroundImage = CatchBmp;

                    if (cutter.ShowDialog() == DialogResult.OK)
                    {
                        Image image = Clipboard.GetImage();
                        image.Save(Application.StartupPath + "/3.jpg");
                        /*
                        IDataObject iData = Clipboard.GetDataObject();
                        DataFormats.Format format = DataFormats.GetFormat(DataFormats.Bitmap);
                        if (iData.GetDataPresent(DataFormats.Bitmap))
                        {
                            richTextBox1.Paste(format);
                           //Image image= Image.FromFile(DataFormats.Bitmap);
                            //image.Save(Application.StartupPath + "/1.jpg");
                            Clipboard.Clear();
                        }
                        */
                    }
                }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }

            try
            {
                var client = new Baidu.Aip.Ocr.Ocr("3IL98imwLlPURYu55BzPVmyp", "54T4P2Yxulnx2XhyOB0tWliGyXDvnKVr");
                client.Timeout = 60000;
                var image = System.IO.File.ReadAllBytes(Application.StartupPath + "/3.jpg");
                var result = client.GeneralBasic(image);
                result = client.GeneralBasic(image);
                Regex reg = new Regex(@"(([1-9][0-9]{0,14})|([0]{1})|(([0]\\.\\d{1,2}|[1-9][0-9]{0,14}\\.\\d{1,2})))");
                var mat = reg.Matches(result.ToString().Split(':')[4].Replace("\"", "").Replace("}", "").Replace("]", "").Replace("\n", ""));
                string str111 = "";
                foreach (Match item in mat)
                {
                    str111 += item.Groups[0] + ".";
                }
                Console.WriteLine(str111);
                ini.IniWriteValue("mySqlCon2", "jubing", str111.Remove(str111.Length-1,1));
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }
    }
}
