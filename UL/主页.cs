
using Common.Utility;
using CustomPrint;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTab;
using DXApplication2;
using DXApplication2.HELP;
using DXApplication2.Properties;
using DXApplication2.UL;
using GalaSoft.MvvmLight.Messaging;
using Hook;
using java.security;
using KellComUtility;
using Maticsoft.Common;
using Microsoft.Win32;
using OCR.ImageRecognition;
using OCR.TesseractWrapper;
using QQ截图工具;
using ScanningAfter;
using SISS_thsoft;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using thsoft_core;
using tools;
using USBControlUtility;
using Utilities;
using WindowsFormsApplication16;
using static System.Net.WebRequestMethods;

namespace DXApplication2
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        private System.Threading.Thread th;
        private Calculator Calcuator = new Calculator();
        悬浮 xuanfu = new 悬浮();
        private ControlHelp Control = new ControlHelp();
        private StringBuilder inputKey = new StringBuilder();
        private DateTime previewTime = DateTime.Now;
        private Setting setting = new Setting();
        private readonly KeyboardHook1 _keyboardHook = new KeyboardHook1();
        private Helper helper = new Helper();
        jubing jubing = new jubing();
        IniFile ini = new IniFile(@"config\set.ini");
        private 修改密码 Updpwd = new 修改密码();
        退出 退出 = new 退出();
        public bool isTog { get; set; }
        LabelControl labelq = new LabelControl();
        QRcode QRcode = new QRcode();
        public decimal totalAmount;
        public bool ishoudo = false;
        private string strPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        AspriseOCR ocr = new AspriseOCR();
        Cutter cutter = null;
        public int curPage = 1;
        public int pageSize = 100;
        Cutter cutter1 = new Cutter();
        private bool Iscome { get; set; }
        private bool Isgo { get; set; }
        public Class11 Class11 = new Class11();
        private string name = "";
        private decimal num1;
        private decimal num2;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        /// <summary>
        /// 得到当前活动的窗口
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern System.IntPtr GetForegroundWindow();
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern int GetCursorPos(ref Point lpPoint);  //获取鼠标坐标，该坐标是光标所在的屏幕坐标位置
        [DllImport("user32.dll")]
        public static extern int WindowFromPoint(int xPoint, int yPoint);  //指定坐标处窗体句柄
        [DllImport("user32.dll")]
        public static extern int GetWindowText(int hwnd, StringBuilder lpString, int nMaxCount);//获取窗体标题名称
        [DllImport("user32.dll")]
        public static extern int GetClassName(int hwnd, StringBuilder lpstring, int nMaxCount); //获取窗体类名称           
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, string lParam);
        //bool isMouseUp = false;
        //Point pi = new Point();
        //Point p = new Point();
        //int hwnd;
        StringBuilder name3 = new StringBuilder(256);
        //string WM_SETTEXT = "&HC";
        KeyboardHook BarCode = new KeyboardHook();
        private string FUN = "";
        public Main()
        {
            InitializeComponent();
            WaitFormService.Cancle += WaitFormService_Cancle;
            BarCode.KeyDownEvent += BarCode_KeyDownEvent;
            Messenger.Default.Register<string>(this, m => xuanfu.Message(m));
            Log4NetHelper.InitLog4Net("/log4net.config");
            this.name = ini.IniReadValue("mySqlCon2", "username");
            ini.IniWriteValue("mySqlCon2", "pwd", "");
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private bool isUserCancle = false;
        private bool WaitFormService_Cancle()
        {
            return isUserCancle;
        }

        public string getcode()
        {
            return Date() + "010" + ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000) + CreateCheckCode();
        }

        private void BarCode_KeyDownEvent(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                string temp = string.Empty;
                DateTime nowTime = DateTime.Now;
                if ((e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9))
                {
                    temp = (e.KeyData.ToString())[(e.KeyData.ToString()).Length - 1].ToString();
                    //temp = (e.KeyData.ToString()).Last().ToString();
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
                        }
                        else
                        {
                            if (tempContent.Length == 18)
                            {
                                textEdit2.Text = tempContent;
                            }
                        }
                    }
                    else if (isTog == true && ishoudo == false)
                    {
                        if (tempContent.Contains("Space"))
                        {
                            string s = tempContent.Substring(tempContent.LastIndexOf("Space") + 5);
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
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }


        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Main_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            //this.defaultLookAndFeel1.LookAndFeel.SkinName = "McSkin";
            xuanfu.Show();
            comboBoxEdit24.Enabled = false;
            Control.GridControl(gridView2);
            Control.TimeEdit(dateEdit1);
            Control.TimeEdit(dateEdit2);
            bind1();
            Control.radioGroup(radioGroup1);
            labelControl1.Text = ini.IniReadValue("mySqlCon3", "username");
            labelControl2.Text = ini.IniReadValue("mySqlCon3", "storeName");
            labelControl109.Text = ini.IniReadValue("mySqlCon3", "username");
            //ini.IniWriteValue("mySqlCon3", "username", "");
            ini.IniWriteValue("mySqlCon3", "roleId", "");
            //ini.IniWriteValue("mySqlCon3", "storeName", "");
            ini.IniWriteValue("mySqlCon3", "userAccount", "");
            Control.quicksetting(toggleSwitch5, comboBoxEdit14, textEdit12, comboBoxEdit15, textEdit13, comboBoxEdit17, textEdit15, comboBoxEdit16, textEdit14, comboBoxEdit19, textEdit17, comboBoxEdit18, textEdit16, comboBoxEdit21, textEdit19, comboBoxEdit20, textEdit18, comboBoxEdit22, textEdit20, this.name);
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
            timer2.Start();
            ini.IniWriteValue("mySqlCon2", "jietu", "");
            ini.IniWriteValue("mySqlCon2", "jubing", "");
            timer1.Start();
            simpleButton16.Enabled = false;
            simpleButton31.Enabled = false;
            simpleButton32.Enabled = false;
            simpleButton15.Enabled = false;
            this.ActiveControl = textEdit3;
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
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }

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

        private void textEdit2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textEdit2.Text.Length == 0)
                {
                    MessageBox.Show("请输入付款码");
                }
                if (textEdit3.Text.Length == 0)
                {
                    MessageBox.Show("请输入金额");
                }
                else
                {
                    if (textEdit2.Text.Length == 18)
                    {
                        if (textEdit3.Text.Substring(0, 1).Equals(".") || decimal.Parse(textEdit3.Text) == 0)
                        {
                            MessageBox.Show("请输入合法金额格式");
                        }
                        else
                        {
                            if (textEdit3.Text.Contains("."))
                            {
                                if (Control.IsNumber(textEdit3.Text.Replace("￥", ""), textEdit3.Text.Replace("￥", "").Split('.')[0].Length + 1, textEdit3.Text.Replace("￥", "").Split('.')[1].Length + 1))
                                {
                                    if (!textEdit3.Text.Equals(""))
                                    {
                                        if ("" != textEdit3.Text.Trim())
                                        {
                                            double input = 0;
                                            input = Convert.ToDouble(textEdit3.Text.Trim());
                                            textEdit3.Text = input.ToString();

                                            Maticsoft.Common.WebClient client = new Maticsoft.Common.WebClient();
                                            string json = "";
                                            if (ini.IniReadValue("mySqlCon2", "jubing").Length != 0)
                                            {
                                                ini.IniWriteValue("mySqlCon4", "lins", getcode());
                                                json = WebUtils.MakeRequest1(ini.IniReadValue("mySqlCon1", "genOrder"), "{\"orderNumber\":\"" + ini.IniReadValue("mySqlCon4", "lins") + "\",\"storeId\":\"" + ini.IniReadValue("mySqlCon3", "storeId") + "\",\"storeUserId\":\"" + ini.IniReadValue("mySqlCon3", "userId") + "\",\"merchantId\":\"" + ini.IniReadValue("mySqlCon3", "merchantId") + "\",\"orderAmount\":" + ini.IniReadValue("mySqlCon2", "jubing").Replace("￥", "") + ",\"terminal\":" + 1 + ",\"qrCode\":\"" + textEdit2.Text + "\"}", "post", "http", ini.IniReadValue("mySqlCon2", "authorization") + ini.IniReadValue("mySqlCon2", "authorization1"));
                                                th = new System.Threading.Thread(new ThreadStart(ExecWaitForm));
                                                th.IsBackground = true;
                                                th.Name = "ThreadExecWaitForm";
                                                th.Start();
                                                timer3.Start();
                                            }
                                            else
                                            {
                                                if (int.Parse(textEdit2.Text.Substring(0, 2)) < 15)
                                                {
                                                    ini.IniWriteValue("mySqlCon4", "mathod", "2");
                                                }
                                                else
                                                {
                                                    ini.IniWriteValue("mySqlCon4", "mathod", "1");
                                                }
                                                ini.IniWriteValue("mySqlCon4", "lins", getcode());
                                                json = WebUtils.MakeRequest1(ini.IniReadValue("mySqlCon1", "genOrder"), "{\"orderNumber\":\"" + ini.IniReadValue("mySqlCon4", "lins") + "\",\"storeId\":\"" + ini.IniReadValue("mySqlCon3", "storeId") + "\",\"storeUserId\":\"" + ini.IniReadValue("mySqlCon3", "userId") + "\",\"merchantId\":\"" + ini.IniReadValue("mySqlCon3", "merchantId") + "\",\"orderAmount\":" + textEdit3.Text + ",\"terminal\":" + 1 + ",\"qrCode\":\"" + textEdit2.Text + "\"}", "post", "http", ini.IniReadValue("mySqlCon2", "authorization") + ini.IniReadValue("mySqlCon2", "authorization1"));
                                                textEdit2.Text = "";
                                                textEdit3.Text = "";
                                                if (this.IsHandleCreated)
                                                {
                                                    this.Invoke((MethodInvoker)delegate
                                                    {
                                                        th = new System.Threading.Thread(new ThreadStart(ExecWaitForm));
                                                        th.IsBackground = true;
                                                        th.Name = "ThreadExecWaitForm";
                                                    });
                                                }
                                                th.Start();
                                                Thread.Sleep(2000);
                                                WaitFormService.Close();
                                                timer3.Start();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("输入不能为空！", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("请输入金额");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("请输入合法金额格式");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(e1.Message); }
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
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }
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
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void simpleButton23_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateEdit1.Text.Length == 0 || dateEdit2.Text.Length == 0)
                {
                    MessageBox.Show("请填写查询时间");
                }
                else if (dateEdit1.Text.Length != 0 || dateEdit2.Text.Length != 0)
                {
                    winFormPage1.RefreshData = bind;
                    bind();
                    if (textEdit21.Text.Length != 0)
                    {
                        winFormPage1.RefreshData = bind;
                        bind();
                    }
                }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        public void bind()
        {
            try
            {
                var date = "";
                if (dateEdit1.Text.Equals(dateEdit2.Text))
                {
                    date = DateTime.Parse(dateEdit2.Text).AddDays(1).ToString();
                }
                else
                {
                    date = dateEdit2.Text;
                }
                if (textEdit21.Text.Length == 0)
                {
                    var json = WebUtils.MakeRequest1(ini.IniReadValue("mySqlCon1", "Orderlist"), "{\"storeId\":" + ini.IniReadValue("mySqlCon3", "storeId") + ",\"startTime\":\"" + dateEdit1.Text + "\",\"endTime\":\"" + date + "\", \"pageNo\":" + winFormPage1.PageIndex + ",\"pageSize\":" + winFormPage1.PageSize + "}", "post", "http", ini.IniReadValue("mySqlCon2", "authorization") + ini.IniReadValue("mySqlCon2", "authorization1")).Replace("{\"success\":true,\"errorCode\":0,\"msg\":\"success\",\"data\":", "").Replace("}}", "").Replace("[", "").Replace("]", "").Replace("{", "").Replace("\"", "");
                    string[] condition = { "rows:" };
                    gridControl2.DataSource = orderlist.toTatable(json.Split(condition, StringSplitOptions.RemoveEmptyEntries)[1]);
                    winFormPage1.Count = int.Parse(json.Split(condition, StringSplitOptions.RemoveEmptyEntries)[0].Split(',')[1].Split(':')[1]);
                    winFormPage1.PageCount = winFormPage1.Count / winFormPage1.PageSize;
                    if (winFormPage1.Count % winFormPage1.PageSize != 0)
                        winFormPage1.PageCount = winFormPage1.PageCount + 1;
                }
                else
                {
                    var json = WebUtils.MakeRequest1(ini.IniReadValue("mySqlCon1", "Orderlist"), "{\"storeId\":" + ini.IniReadValue("mySqlCon3", "storeId") + ",\"orderNo\":\"" + textEdit21.Text + "\",\"startTime\":\"" + dateEdit1.Text + "\",\"endTime\":\"" + date + "\", \"pageNo\":" + winFormPage1.PageIndex + ",\"pageSize\":" + winFormPage1.PageSize + "}", "post", "http", ini.IniReadValue("mySqlCon2", "authorization") + ini.IniReadValue("mySqlCon2", "authorization1")).Replace("{\"success\":true,\"errorCode\":0,\"msg\":\"success\",\"data\":", "").Replace("}}", "").Replace("[", "").Replace("]", "").Replace("{", "").Replace("\"", "");
                    string[] condition = { "rows:" };
                    gridControl2.DataSource = orderlist.toTatable(json.Split(condition, StringSplitOptions.RemoveEmptyEntries)[1]);
                    winFormPage1.Count = int.Parse(json.Split(condition, StringSplitOptions.RemoveEmptyEntries)[0].Split(',')[1].Split(':')[1]);
                    winFormPage1.PageCount = winFormPage1.Count / winFormPage1.PageSize;
                    if (winFormPage1.Count % winFormPage1.PageSize != 0)
                        winFormPage1.PageCount = winFormPage1.PageCount + 1;
                }
            }
            catch { MessageBox.Show("暂无数据");gridControl2.DataSource = null; }
        }

        public void bind1()
        {
            try
            {
                var json = WebUtils.MakeRequest1(ini.IniReadValue("mySqlCon1", "Orderlist"), "{\"storeId\":" + ini.IniReadValue("mySqlCon3", "storeId") + ",\"startTime\":\"" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00" + "\",\"endTime\":\"" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00" + "\", \"pageNo\":" + winFormPage1.PageIndex + ",\"pageSize\":" + winFormPage1.PageSize + "}", "post", "http", ini.IniReadValue("mySqlCon2", "authorization") + ini.IniReadValue("mySqlCon2", "authorization1")).Replace("{\"success\":true,\"errorCode\":0,\"msg\":\"success\",\"data\":", "").Replace("}}", "").Replace("[", "").Replace("]", "").Replace("{", "").Replace("\"", "");
                string[] condition = { "rows:" };
                json.Split(condition, StringSplitOptions.RemoveEmptyEntries);
                gridControl1.DataSource = orderlist.toTatable1(json.Split(condition, StringSplitOptions.RemoveEmptyEntries)[1]);
            }
            catch (Exception ex) { Log4NetHelper.WriteErrorLog(ex.Message); }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            textEdit3.Text = textEdit3.Text + "7";
            simpleButton15.Enabled = true;
            simpleButton16.Enabled = true;
            simpleButton31.Enabled = true;
            simpleButton32.Enabled = true;
            this.Focus();
            if (textEdit3.Text.Length >= 5)
            {
                try
                {
                    if (textEdit3.Text.Split('.')[1].Length > 2)
                    {
                        MessageBox.Show("请确保您只输入了整数或带两位小数的实数");
                        textEdit3.Text = textEdit3.Text.Split('.')[0] + "." + textEdit3.Text.Split('.')[1].Substring(0, 2);
                    }
                }
                catch { }
            }
            if (decimal.Parse(textEdit3.Text) < 0)
            {
                MessageBox.Show("金额不可小于零");
            }

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            textEdit3.Text = textEdit3.Text + "8";
            simpleButton15.Enabled = true;
            simpleButton16.Enabled = true;
            simpleButton31.Enabled = true;
            simpleButton32.Enabled = true;
            labelControl4.Focus();
            if (textEdit3.Text.Length >= 5)
            {
                try
                {
                    if (textEdit3.Text.Split('.')[1].Length > 2)
                    {
                        MessageBox.Show("请确保您只输入了整数或带两位小数的实数");
                        textEdit3.Text = textEdit3.Text.Split('.')[0] + "." + textEdit3.Text.Split('.')[1].Substring(0, 2);
                    }
                }
                catch { }
            }
            if (decimal.Parse(textEdit3.Text) < 0)
            {
                MessageBox.Show("金额不可小于零");
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            textEdit3.Text = textEdit3.Text + "9";
            simpleButton16.Enabled = true;
            simpleButton31.Enabled = true;
            simpleButton32.Enabled = true;
            simpleButton15.Enabled = true;
            labelControl4.Focus();
            if (textEdit3.Text.Length >= 5)
            {
                try
                {
                    if (textEdit3.Text.Split('.')[1].Length > 2)
                    {
                        MessageBox.Show("请确保您只输入了整数或带两位小数的实数");
                        textEdit3.Text = textEdit3.Text.Split('.')[0] + "." + textEdit3.Text.Split('.')[1].Substring(0, 2);
                    }
                }
                catch { }
            }
            if (decimal.Parse(textEdit3.Text) < 0)
            {
                MessageBox.Show("金额不可小于零");
            }
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            textEdit3.Text = textEdit3.Text + "4";
            simpleButton16.Enabled = true;
            simpleButton31.Enabled = true;
            simpleButton32.Enabled = true;
            simpleButton15.Enabled = true;
            labelControl4.Focus();
            if (textEdit3.Text.Length >= 5)
            {
                try
                {
                    if (textEdit3.Text.Split('.')[1].Length > 2)
                    {
                        MessageBox.Show("请确保您只输入了整数或带两位小数的实数");
                        textEdit3.Text = textEdit3.Text.Split('.')[0] + "." + textEdit3.Text.Split('.')[1].Substring(0, 2);
                    }
                }
                catch { }
            }
            if (decimal.Parse(textEdit3.Text) < 0)
            {
                MessageBox.Show("金额不可小于零");
            }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            textEdit3.Text = textEdit3.Text + "5";
            simpleButton16.Enabled = true;
            simpleButton31.Enabled = true;
            simpleButton32.Enabled = true;
            simpleButton15.Enabled = true;
            labelControl4.Focus();
            if (textEdit3.Text.Length >= 5)
            {
                try
                {
                    if (textEdit3.Text.Split('.')[1].Length > 2)
                    {
                        MessageBox.Show("请确保您只输入了整数或带两位小数的实数");
                        textEdit3.Text = textEdit3.Text.Split('.')[0] + "." + textEdit3.Text.Split('.')[1].Substring(0, 2);
                    }
                }
                catch { }
            }
            if (decimal.Parse(textEdit3.Text) < 0)
            {
                MessageBox.Show("金额不可小于零");
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            textEdit3.Text = textEdit3.Text + "6";
            simpleButton16.Enabled = true;
            simpleButton31.Enabled = true;
            simpleButton32.Enabled = true;
            simpleButton15.Enabled = true;
            labelControl4.Focus();
            if (textEdit3.Text.Length >= 5)
            {
                try
                {
                    if (textEdit3.Text.Split('.')[1].Length > 2)
                    {
                        MessageBox.Show("请确保您只输入了整数或带两位小数的实数");
                        textEdit3.Text = textEdit3.Text.Split('.')[0] + "." + textEdit3.Text.Split('.')[1].Substring(0, 2);
                    }
                }
                catch { }
            }
            if (decimal.Parse(textEdit3.Text) < 0)
            {
                MessageBox.Show("金额不可小于零");
            }
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            textEdit3.Text = textEdit3.Text + "1";
            simpleButton16.Enabled = true;
            simpleButton31.Enabled = true;
            simpleButton32.Enabled = true;
            simpleButton15.Enabled = true;
            labelControl4.Focus();
            if (textEdit3.Text.Length >= 5)
            {
                try
                {
                    if (textEdit3.Text.Split('.')[1].Length > 2)
                    {
                        MessageBox.Show("请确保您只输入了整数或带两位小数的实数");
                        textEdit3.Text = textEdit3.Text.Split('.')[0] + "." + textEdit3.Text.Split('.')[1].Substring(0, 2);
                    }
                }
                catch { }
            }
            if (decimal.Parse(textEdit3.Text) < 0)
            {
                MessageBox.Show("金额不可小于零");
            }
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            textEdit3.Text = textEdit3.Text + "2";
            simpleButton16.Enabled = true;
            simpleButton31.Enabled = true;
            simpleButton32.Enabled = true;
            simpleButton15.Enabled = true;
            labelControl4.Focus();
            if (textEdit3.Text.Length >= 5)
            {
                try
                {
                    if (textEdit3.Text.Split('.')[1].Length > 2)
                    {
                        MessageBox.Show("请确保您只输入了整数或带两位小数的实数");
                        textEdit3.Text = textEdit3.Text.Split('.')[0] + "." + textEdit3.Text.Split('.')[1].Substring(0, 2);
                    }
                }
                catch { }
            }
            if (decimal.Parse(textEdit3.Text) < 0)
            {
                MessageBox.Show("金额不可小于零");
            }
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            textEdit3.Text = textEdit3.Text + "3";
            simpleButton16.Enabled = true;
            simpleButton31.Enabled = true;
            simpleButton32.Enabled = true;
            simpleButton15.Enabled = true;
            labelControl4.Focus();
            if (textEdit3.Text.Length >= 5)
            {
                try
                {
                    if (textEdit3.Text.Split('.')[1].Length > 2)
                    {
                        MessageBox.Show("请确保您只输入了整数或带两位小数的实数");
                        textEdit3.Text = textEdit3.Text.Split('.')[0] + "." + textEdit3.Text.Split('.')[1].Substring(0, 2);
                    }
                }
                catch { }
            }
            if (decimal.Parse(textEdit3.Text) < 0)
            {
                MessageBox.Show("金额不可小于零");
            }
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            textEdit3.Text = textEdit3.Text + "0";
            simpleButton16.Enabled = true;
            simpleButton31.Enabled = true;
            simpleButton32.Enabled = true;
            simpleButton15.Enabled = true;
            labelControl4.Focus();
            if (textEdit3.Text.Length >= 5)
            {
                try
                {
                    if (textEdit3.Text.Split('.')[1].Length > 2)
                    {
                        MessageBox.Show("请确保您只输入了整数或带两位小数的实数");
                        textEdit3.Text = textEdit3.Text.Split('.')[0] + "." + textEdit3.Text.Split('.')[1].Substring(0, 2);
                    }
                }
                catch { }
            }
            if (decimal.Parse(textEdit3.Text) < 0)
            {
                MessageBox.Show("金额不可小于零");
            }
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            try
            {
                if (!textEdit3.Text.Equals(""))
                {
                    simpleButton16.Enabled = true;
                }
                FUN = "jia";
                jisuan();
                labelControl4.Focus();
            }
            catch { }
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            if (textEdit3.Text.Contains(".")) { simpleButton15.Enabled = false; } else if (!textEdit3.Text.Contains(".")) { simpleButton15.Enabled = true; Calcuator.add(".", textEdit3); labelControl4.Focus(); }
        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            if (textEdit3.Text.Equals(""))
            {
                this.ActiveControl = textEdit3;
                textEdit3.Text = "";
            }
            else
            {
                textEdit3.Text = Calcuator.Del(textEdit3);
            }
        }

        private void simpleButton22_Click(object sender, EventArgs e)
        {
            if (textEdit3.Text.Contains(".")) { simpleButton15.Enabled = false; } else if (!textEdit3.Text.Contains(".")) { simpleButton15.Enabled = true; Calcuator.add(".", textEdit3); labelControl4.Focus(); }
            this.ActiveControl = textEdit3;
            textEdit3.Text = "";
            labelControl4.Focus();
        }

        private void simpleButton19_Click(object sender, EventArgs e)
        {
            if (textEdit3.Text.Length == 0)
            {
                MessageBox.Show("请输入金额");
            }
            else
            {
                if (textEdit3.Text.Substring(0, 1).Equals(".") || decimal.Parse(textEdit3.Text) == 0)
                {
                    MessageBox.Show("请输入合法金额格式");
                }
                else
                {
                    if (textEdit3.Text.Contains("."))
                    {
                        if (Control.IsNumber(textEdit3.Text.Replace("￥", ""), textEdit3.Text.Replace("￥", "").Split('.')[0].Length + 1, textEdit3.Text.Replace("￥", "").Split('.')[1].Length + 1))
                        {
                            if (!textEdit3.Text.Equals(""))
                            {
                                if ("" != textEdit3.Text.Trim())
                                {
                                    double input = 0;
                                    input = Convert.ToDouble(textEdit3.Text.Trim());
                                    textEdit3.Text = input.ToString();

                                    Maticsoft.Common.WebClient client = new Maticsoft.Common.WebClient();
                                    string json = "";
                                    if (ini.IniReadValue("mySqlCon2", "jubing").Length != 0)
                                    {
                                        ini.IniWriteValue("mySqlCon4", "lins", getcode());
                                        json = WebUtils.MakeRequest1(ini.IniReadValue("mySqlCon1", "genOrder"), "{\"orderNumber\":\"" + ini.IniReadValue("mySqlCon4", "lins") + "\",\"storeId\":\"" + ini.IniReadValue("mySqlCon3", "storeId") + "\",\"storeUserId\":\"" + ini.IniReadValue("mySqlCon3", "userId") + "\",\"merchantId\":\"" + ini.IniReadValue("mySqlCon3", "merchantId") + "\",\"orderAmount\":" + ini.IniReadValue("mySqlCon2", "jubing").Replace("￥", "") + ",\"terminal\":" + 1 + ",\"qrCode\":\"" + textEdit2.Text + "\"}", "post", "http", ini.IniReadValue("mySqlCon2", "authorization") + ini.IniReadValue("mySqlCon2", "authorization1"));
                                        System.Threading.Thread.Sleep(2000);
                                        timer3.Start();
                                    }
                                    else
                                    {
                                        ini.IniWriteValue("mySqlCon4", "lins", getcode());
                                        QRcode qrCode = new QRcode();
                                        qrCode.Create(ini.IniReadValue("mySqlCon1", "barcode") + "?orderNumber=" + ini.IniReadValue("mySqlCon4", "lins") + "&orderAmount=" + textEdit3.Text + "&storeId=" + ini.IniReadValue("mySqlCon3", "storeId") + "&storeUserId=" + ini.IniReadValue("mySqlCon3", "userId") + "&merchantId=" + ini.IniReadValue("mySqlCon3", "merchantId") + "&terminal=1", 4, Application.StartupPath + @"\");
                                        Control.print5(comboBoxEdit23.Text, ini.IniReadValue("mySqlCon3", "storeName"), ini.IniReadValue("mySqlCon3", "username"), "PC", textEdit3.Text);
                                        th = new System.Threading.Thread(new ThreadStart(ExecWaitForm));
                                        th.IsBackground = true;
                                        th.Name = "ThreadExecWaitForm";
                                        th.Start();
                                        System.Threading.Thread.Sleep(2000);
                                        timer3.Start();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("输入不能为空！", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("请输入金额");
                            }
                        }
                        else
                        {
                            MessageBox.Show("请输入合法金额格式");
                        }
                    }
                }
            }
        }
        /*
        private void simpleButton18_Click(object sender, EventArgs e)
        {
            try
            {
                if (textEdit2.Text.Length == 0)
                {
                    MessageBox.Show("请输入付款码");
                }
                if (textEdit3.Text.Length == 0)
                {
                    MessageBox.Show("请输入金额");
                }
                else
                {
                    if (textEdit3.Text.Substring(0, 1).Equals(".") || decimal.Parse(textEdit3.Text) == 0)
                    {
                        MessageBox.Show("请输入合法金额格式");
                    }
                    else
                    {
                        if (textEdit3.Text.Contains("."))
                        {
                            if (Control.IsNumber(textEdit3.Text.Replace("￥", ""), textEdit3.Text.Replace("￥", "").Split('.')[0].Length + 1, textEdit3.Text.Replace("￥", "").Split('.')[1].Length + 1))
                            {
                                if (!textEdit3.Text.Equals(""))
                                {
                                    if ("" != textEdit3.Text.Trim())
                                    {
                                        double input = 0;
                                        input = Convert.ToDouble(textEdit3.Text.Trim());
                                        textEdit3.Text = input.ToString();

                                        Maticsoft.Common.WebClient client = new WebClient();
                                        string json = "";
                                        if (ini.IniReadValue("mySqlCon2", "jubing").Length != 0)
                                        {

                                            json = WebUtils.MakeRequest1("http://192.168.0.138:8838/api/order/genOrder", "{\"orderNumber\":\"" + Date() + "010" + ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000) + CreateCheckCode() + "\",\"storeId\":\"" + ini.IniReadValue("mySqlCon3", "storeId") + "\",\"storeUserId\":\"" + ini.IniReadValue("mySqlCon3", "userId") + "\",\"merchantId\":\"" + ini.IniReadValue("mySqlCon3", "merchantId") + "\",\"orderAmount\":" + ini.IniReadValue("mySqlCon2", "jubing").Replace("￥", "") + ",\"terminal\":" + 1 + ",\"qrCode\":\"" + textEdit2.Text + "\"}", "post", "http", ini.IniReadValue("mySqlCon2", "authorization") + ini.IniReadValue("mySqlCon2", "authorization1"));
                                            System.Threading.Thread.Sleep(2000);
                                            timer3.Start();
                                        }
                                        else
                                        {
                                            if (int.Parse(textEdit2.Text.Substring(0, 2)) < 15)
                                            {
                                                ini.IniWriteValue("mySqlCon4", "mathod", "2");
                                            }
                                            else
                                            {
                                                ini.IniWriteValue("mySqlCon4", "mathod", "1");
                                            }
                                            orderON = Date() + "010" + ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000) + CreateCheckCode();
                                            json = WebUtils.MakeRequest1("http://192.168.0.138:8838/api/order/genOrder", "{\"orderNumber\":\"" + Date() + "010" + ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000) + CreateCheckCode() + "\",\"storeId\":\"" + ini.IniReadValue("mySqlCon3", "storeId") + "\",\"storeUserId\":\"" + ini.IniReadValue("mySqlCon3", "userId") + "\",\"merchantId\":\"" + ini.IniReadValue("mySqlCon3", "merchantId") + "\",\"orderAmount\":" + textEdit3.Text + ",\"terminal\":" + 1 + ",\"qrCode\":\"" + textEdit2.Text + "\"}", "post", "http", ini.IniReadValue("mySqlCon2", "authorization") + ini.IniReadValue("mySqlCon2", "authorization1"));
                                            th = new System.Threading.Thread(new ThreadStart(ExecWaitForm));
                                            th.IsBackground = true;
                                            th.Name = "ThreadExecWaitForm";
                                            th.Start();
                                            System.Threading.Thread.Sleep(2000);
                                            timer3.Start();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("输入不能为空！", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("请输入金额");
                                }
                            }
                            else
                            {
                                MessageBox.Show("请输入合法金额格式");
                            }
                        }
                    }
                }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }
        */
        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabControl3_Click(object sender, EventArgs e)
        {
            if (xtraTabControl3.SelectedTabPageIndex == 0)
            {
                radioGroup1.SelectedIndex = 0;
                ini.IniWriteValue("mySqlCon2", "jietu", "");
                timer2.Stop();
                timer1.Stop();
            }
            if (xtraTabControl3.SelectedTabPageIndex == 1)
            {
                if (toggleSwitch4.IsOn == true)
                {
                    int num = Application.OpenForms.Count;
                    for (int i = 0; i < num; i++)
                    {
                        Form f = Application.OpenForms[i];
                        if (f.Name != "登录")
                        {
                            if (f.Name != "悬浮")
                            {
                                f.Hide();
                                num = num - 1;
                                i = i - 1;
                            }
                        }
                    }
                    timer1.Start();
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = Application.StartupPath + @"\hualongbao.exe";
                    info.Arguments = "";
                    info.WindowStyle = ProcessWindowStyle.Normal;
                    Process pro = Process.Start(info);
                    pro.WaitForExit();
                    if (ini.IniReadValue("mySqlCon2", "vis").Equals("false"))
                    {
                        int num1 = Application.OpenForms.Count;
                        for (int i = 0; i < num1; i++)
                        {
                            Form f = Application.OpenForms[i];
                            if (f.Name != "登录" || f.Name != "主页")
                            {
                                f.Show();
                            }
                            if (f.Name == "主页" || f.Name == "悬浮" || f.Name == "登录")
                            {
                                f.Hide();
                            }
                        }
                        悬浮 悬浮 = new 悬浮();
                        悬浮.Show();
                    }
                }
                timer1.Stop();
                radioGroup1.SelectedIndex = 1;
                ini.IniWriteValue("mySqlCon2", "jietu", "");
                timer2.Stop();
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioGroup1.SelectedIndex == 0)
                {
                    xtraTabControl3.SelectedTabPageIndex = 0;
                }
                if (radioGroup1.SelectedIndex == 1)
                {
                    xtraTabControl3.SelectedTabPageIndex = 1;
                }
                if (radioGroup1.SelectedIndex == 2)
                {
                    xtraTabControl3.SelectedTabPageIndex = 2;
                }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void simpleButton24_Click(object sender, EventArgs e)
        {
            try
            {
                setting.Updgraspsetting1(toggleSwitch1, radioGroup1, toggleSwitch4, spinEdit1, toggleSwitch2, textEdit4, textEdit5, toggleSwitch3, spinEdit2, textEdit6,
    comboBoxEdit7, textEdit7, comboBoxEdit8, textEdit8, comboBoxEdit9, textEdit9, comboBoxEdit10, textEdit10, comboBoxEdit11,
    textEdit11, comboBoxEdit12, checkEdit1, comboBoxEdit13, comboBoxEdit3, comboBoxEdit4, comboBoxEdit5, comboBoxEdit6);
                MessageBox.Show("保存成功！", "确定", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                setting.Fillgraspsetting(toggleSwitch1, radioGroup1, comboBoxEdit3,
comboBoxEdit4, comboBoxEdit6, comboBoxEdit5, spinEdit1, toggleSwitch2, textEdit4, textEdit5, toggleSwitch3, spinEdit2, textEdit6,
comboBoxEdit7, textEdit7, comboBoxEdit8, textEdit8, comboBoxEdit9, textEdit9, comboBoxEdit10, textEdit10, comboBoxEdit11,
textEdit11, comboBoxEdit12, checkEdit1, comboBoxEdit13, this.name);
                if (xtraTabControl3.SelectedTabPageIndex == 2)
                {
                    radioGroup1.SelectedIndex = 2;
                    timer2.Start();
                    timer1.Stop();
                }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }
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

                }
                else if (xtraTabControl2.SelectedTabPageIndex == 0)
                {
                    setting.Fillgraspsetting(toggleSwitch1, radioGroup1, comboBoxEdit3,
    comboBoxEdit4, comboBoxEdit6, comboBoxEdit5, spinEdit1, toggleSwitch2, textEdit4, textEdit5, toggleSwitch3, spinEdit2, textEdit6,
    comboBoxEdit7, textEdit7, comboBoxEdit8, textEdit8, comboBoxEdit9, textEdit9, comboBoxEdit10, textEdit10, comboBoxEdit11,
    textEdit11, comboBoxEdit12, checkEdit1, comboBoxEdit13, this.name);
                }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }

        }

        private void textEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void xtraTabControl2_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {

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
            if (toggleSwitch9.IsOn != true)
            {
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.DeleteValue("JcShutdown", false);
                rk2.Close();
                rk.Close();
            }
            else
            {
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.SetValue("JcShutdown", path);
                rk2.Close();
                rk.Close();
            }
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
            catch (Exception e1) { Log4NetHelper.WriteErrorLog(e1.Message); }
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
                    ini.IniWriteValue("mySqlCon2", "jubing", "");
                    if (str.Contains(".0.0"))
                    {
                        ini.IniWriteValue("mySqlCon2", "jubing", str4.Substring(str4.Length - 1, 2));
                        this.totalAmount = decimal.Parse(str4);
                    }
                    else
                    {
                        ini.IniWriteValue("mySqlCon2", "jubing", str4);
                        this.totalAmount = decimal.Parse(str4);
                    }
                }));
            }
            catch (Exception e1) { Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {

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
                    //Control.baudrate(comboBoxEdit4);
                }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void toggleSwitch4_Toggled(object sender, EventArgs e)
        {

        }

        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
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

        private void simpleButton20_Click(object sender, EventArgs e)
        {
            try
            {
                if (textEdit2.Text.Length == 0)
                {
                    MessageBox.Show("请输入付款码");
                }
                if (textEdit3.Text.Length == 0)
                {
                    MessageBox.Show("请输入金额");
                }
                else
                {
                    if (textEdit3.Text.Substring(0, 1).Equals(".") || decimal.Parse(textEdit3.Text) == 0)
                    {
                        MessageBox.Show("请输入合法金额格式");
                    }
                    else
                    {
                        if (textEdit3.Text.Contains("."))
                        {
                            if (Control.IsNumber(textEdit3.Text.Replace("￥", ""), textEdit3.Text.Replace("￥", "").Split('.')[0].Length + 1, textEdit3.Text.Replace("￥", "").Split('.')[1].Length + 1))
                            {
                                if (!textEdit3.Text.Equals(""))
                                {
                                    if ("" != textEdit3.Text.Trim())
                                    {
                                        double input = 0;
                                        input = Convert.ToDouble(textEdit3.Text.Trim());
                                        textEdit3.Text = input.ToString();

                                        Maticsoft.Common.WebClient client = new Maticsoft.Common.WebClient();
                                        string json = "";
                                        if (ini.IniReadValue("mySqlCon2", "jubing").Length != 0)
                                        {
                                            ini.IniWriteValue("mySqlCon4", "lins", getcode());
                                            json = WebUtils.MakeRequest1(ini.IniReadValue("mySqlCon1", "genOrder"), "{\"orderNumber\":\"" + ini.IniReadValue("mySqlCon4", "lins") + "\",\"storeId\":\"" + ini.IniReadValue("mySqlCon3", "storeId") + "\",\"storeUserId\":\"" + ini.IniReadValue("mySqlCon3", "userId") + "\",\"merchantId\":\"" + ini.IniReadValue("mySqlCon3", "merchantId") + "\",\"orderAmount\":" + ini.IniReadValue("mySqlCon2", "jubing").Replace("￥", "") + ",\"terminal\":" + 1 + ",\"qrCode\":\"" + textEdit2.Text + "\"}", "post", "http", ini.IniReadValue("mySqlCon2", "authorization") + ini.IniReadValue("mySqlCon2", "authorization1"));
                                            System.Threading.Thread.Sleep(2000);
                                            timer3.Start();
                                        }
                                        else
                                        {
                                            if (int.Parse(textEdit2.Text.Substring(0, 2)) < 15)
                                            {
                                                ini.IniWriteValue("mySqlCon4", "mathod", "2");
                                            }
                                            else
                                            {
                                                ini.IniWriteValue("mySqlCon4", "mathod", "1");
                                            }
                                            ini.IniWriteValue("mySqlCon4", "lins", getcode());
                                            json = WebUtils.MakeRequest1(ini.IniReadValue("mySqlCon1", "genOrder"), "{\"orderNumber\":\"" + ini.IniReadValue("mySqlCon4", "lins") + "\",\"storeId\":\"" + ini.IniReadValue("mySqlCon3", "storeId") + "\",\"storeUserId\":\"" + ini.IniReadValue("mySqlCon3", "userId") + "\",\"merchantId\":\"" + ini.IniReadValue("mySqlCon3", "merchantId") + "\",\"orderAmount\":" + textEdit3.Text + ",\"terminal\":" + 1 + ",\"qrCode\":\"" + textEdit2.Text + "\"}", "post", "http", ini.IniReadValue("mySqlCon2", "authorization") + ini.IniReadValue("mySqlCon2", "authorization1"));
                                            th = new System.Threading.Thread(new ThreadStart(ExecWaitForm));
                                            th.IsBackground = true;
                                            th.Name = "ThreadExecWaitForm";
                                            th.Start();
                                            textEdit2.Text = "";
                                            textEdit3.Text = "";
                                            System.Threading.Thread.Sleep(2000);
                                            timer3.Start();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("输入不能为空！", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("请输入金额");
                                }
                            }
                            else
                            {
                                MessageBox.Show("请输入合法金额格式");
                            }
                        }
                    }
                }
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void labelControl66_Click(object sender, EventArgs e)
        {

        }

        private void toggleSwitch4_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void toggleSwitch4_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void simpleButton26_Click(object sender, EventArgs e)
        {
            try
            {
                Control.UPdprint(toggleSwitch6, toggleSwitch7, toggleSwitch8, spinEdit3, spinEdit4, comboBoxEdit23, this.name);
                MessageBox.Show("保存成功！", "确定", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                Control.fillprint(toggleSwitch6, toggleSwitch7, toggleSwitch8, spinEdit3, spinEdit4, comboBoxEdit23, this.name);
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void toggleSwitch9_Toggled(object sender, EventArgs e)
        {
            try
            {
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
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }
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
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void simpleButton27_Click(object sender, EventArgs e)
        {
            Control.currencysetting(toggleSwitch9, toggleSwitch10, toggleSwitch11, toggleSwitch12, toggleSwitch16, spinEdit5, toggleSwitch14, toggleSwitch13, toggleSwitch17, this.name);
            MessageBox.Show("保存成功！", "确定", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            Control.currencysetting1(toggleSwitch9, toggleSwitch10, toggleSwitch11, toggleSwitch12, toggleSwitch16, spinEdit5, toggleSwitch14, toggleSwitch13, toggleSwitch17, this.name);
        }

        private void simpleButton29_Click(object sender, EventArgs e)
        {
            Updpwd.Show();
        }

        private void simpleButton28_Click(object sender, EventArgs e)
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
            登录 login = new 登录();
            login.Show();
        }

        private void textEdit12_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton30_Click(object sender, EventArgs e)
        {
            /***
            this.Size = new Size(0, 0);
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
                    image.Dispose();
                    this.Size = new Size(1047, 670);
                }
            }
            ***/
            this.WindowState=FormWindowState.Minimized;
            Thread.Sleep(200);
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = Application.StartupPath + @"\SnapShot.exe";
                info.Arguments = "";
                info.WindowStyle = ProcessWindowStyle.Normal;
                Process pro = Process.Start(info);
                var info1 = System.IO.File.ReadAllText(Application.StartupPath + "\\rectConfig.txt").Replace("price:", "").Replace("(", "").Replace(")", "");
                Class11.captureScreen(int.Parse(info1.Split(',')[0]), int.Parse(info1.Split(',')[1]), int.Parse(info1.Split(',')[2]),int.Parse(info1.Split(',')[3])).Save(Application.StartupPath+"\\info.png");
        }

        public void shibie()
        {
            try
            {
                Bitmap bmp = new Bitmap(Application.StartupPath + @"\info.png");
                TesseractProcessor process = new TesseractProcessor();
                process.SetPageSegMode(ePageSegMode.PSM_SINGLE_LINE);
                process.Init(Application.StartupPath + "\\", "eng", (int)eOcrEngineMode.OEM_DEFAULT);
                string result = process.Recognize(bmp);
                ini.IniWriteValue("mySqlCon2", "jubing", result.Replace("￥", ""));
                bmp.Dispose();
            }
            catch { }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            退出.Show();
        }
        private void comboBoxEdit24_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit24.Focus() == true)
            {
                Environment.Exit(0);
            }
        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            if (textEdit3.Text.Length == 8)
            {
                MessageBox.Show("金额已到达极限");
            }
        }

        private void labelControl4_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Close();
            this.Dispose();
            Application.Exit();
        }

        private void 隐藏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bind1();
        }

        private void 刷新ToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            try
            {
                var json=WebUtils.MakeRequest1(ini.IniReadValue("mySqlCon1", "getOrderFlowInfo"), "{\"storeId\":"+ini.IniReadValue("mySqlCon3", "storeId") + ",\"startTime\":\""+dateEdit1.Text+ "\",\"endTime\":\""+dateEdit2.Text+"\"}","post","http", ini.IniReadValue("mySqlCon2", "authorization") + ini.IniReadValue("mySqlCon2", "authorization1")).Replace("\"","");
                Control.print7(dateEdit1, dateEdit2, ini.IniReadValue("mySqlCon3", "username"), json.Split(',')[16].Split(':')[1].Replace("}}",""), json.Split(',')[7].Split(':')[1], ini.IniReadValue("mySqlCon3", "storeName"), json.Split(',')[10].Split(':')[1], json.Split(',')[5].Split(':')[1], json.Split(',')[14].Split(':')[1], json.Split(',')[3].Split(':')[2], json.Split(',')[11].Split(':')[1], json.Split(',')[6].Split(':')[1], json.Split(',')[15].Split(':')[1], json.Split(',')[4].Split(':')[1], json.Split(',')[13].Split(':')[1], json.Split(',')[12].Split(':')[1], json.Split(',')[8].Split(':')[1], json.Split(',')[9].Split(':')[1], comboBoxEdit23.Text);
            }
            catch { }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            shibie();
            System.IO.File.Delete(Application.StartupPath + @"\info.png");
            var info1 = System.IO.File.ReadAllText(Application.StartupPath + "\\rectConfig.txt").Replace("price:", "").Replace("(", "").Replace(")", "");
            Class11.captureScreen(int.Parse(info1.Split(',')[0]), int.Parse(info1.Split(',')[1]), int.Parse(info1.Split(',')[2]), int.Parse(info1.Split(',')[3])).Save(Application.StartupPath + "\\info.png");
        }

        public static string PreTreating(string str)
        {
            string myString = str;

            if ("0.00" == myString || "0.0" == myString)
            {
                myString = "0";               
            }
            else if (IsSDC(myString))
            {
                myString = ToDBC(myString);
            }

            return myString;
        }
        public bool IsNumberic(string message, out string errorMsg)
        {
            bool flag = false;
            string temp = @"(^(\d(\.\d{2})?){1}$)|(^([1-9]\d*(\.\d{2})?){1}$)";
            Regex rex = new Regex(temp);

            if (rex.IsMatch(message))
            {
                flag = true;
                errorMsg = "";
                return flag;
            }
            else
            {
                errorMsg = "请确保您只输入了整数或带两位小数的实数";
                return flag;
            }
        }

        /// <summary>
        /// 判断字符串是否为全角字符
        /// </summary>
        /// <param name="strSDC"></param>
        /// <returns></returns>
        public static bool IsSDC(string strSDC)
        {
            bool flag = false;
            if (strSDC.Length != Encoding.Default.GetByteCount(strSDC))
            {
                flag = true;
                return flag;
            }
            else
            {
                return flag;
            }
        }

        /// <summary>
        /// 将全角转换为半角；replace SBC case to DBC case
        /// 全角空格为12288，半角空格为32；
        /// 其他字符半角（33-126）与全角（65281-65374）的对应关系是：均相差65248；
        /// </summary>
        /// <param name="strSBC"></param>
        /// <returns></returns>
        public static string ToDBC(string strSBC)
        {
            char[] ch = strSBC.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i] == 12288)
                {
                    ch[i] = (char)32;
                    continue;
                }
                if (ch[i] > 65280 && ch[i] < 65375)
                {
                    ch[i] = (char)(ch[i] - 65248);
                }
            }
            return new string(ch);
        }

        private void simpleButton31_Click(object sender, EventArgs e)
        {
            try
            {
                FUN = "jian";
                jisuan();
                labelControl4.Focus();
            }
            catch { }
        }

        private void jisuan()
        {
            //获取运算的第一个数字(前一个数字);将字符串类型转换为int类型(int.parse())
            // num1 = Convert.ToInt32(textBox1.Text);第二种转换方式convert
            num1 = decimal.Parse(textEdit3.Text);
            textEdit3.Text = "";//清除屏幕
        }

        private void simpleButton32_Click(object sender, EventArgs e)
        {
            try
            {
                if (!textEdit3.Text.Equals(""))
                {
                    simpleButton32.Enabled = true;
                }
                if (textEdit3.Text.Length == 0 || textEdit3.Text.Equals(""))
                {
                    MessageBox.Show("请数据金额");
                }
                num2 = decimal.Parse(textEdit3.Text);//记录第二个数字
                textEdit3.Text = "";
                if (FUN == "jia")//判断计算类型
                {
                    textEdit3.Text = (num1 + num2).ToString();//括号里进行计算,计算的结果转化为string类型,并显示在屏幕(textEdit1)里;
                }
                if (FUN == "jian")
                {
                    if (num1 == num2)
                    {
                        textEdit3.Text = "0";
                    }
                    else
                    {
                        if (num1 < num2)
                        {
                            MessageBox.Show("金额不能为负数");
                        }
                        else
                        {
                            textEdit3.Text = (num1 - num2).ToString();
                        }
                    }
                }
                if (FUN == "cheng")
                {
                    textEdit3.Text = (num1 * num2).ToString();
                }
                if (FUN == "chu")
                {
                    textEdit3.Text = (num1 / num2).ToString();
                }
                if (FUN == "%")
                {
                    textEdit3.Text = (num1 % num2).ToString();
                }
            }
            catch (Exception e1) { Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                xtraTabControl1.SelectedTabPageIndex = 0;
                BarCode.Start();
                simpleButton1.Image = Resources._2shoukuanB;
                simpleButton2.Image = Resources._2yajin2;
                simpleButton3.Image = Resources._2dingdan1;
                simpleButton4.Image = Resources._2tuikuan2;
                simpleButton5.Image = Resources._2shehzi;
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        /// <summary>
        /// 获取网络日期时间
        /// </summary>
        /// <returns></returns>
        public static string GetNetDateTime()
        {
            WebRequest request = null;
            WebResponse response = null;
            WebHeaderCollection headerCollection = null;
            string datetime = string.Empty;
            try
            {
                request = WebRequest.Create("https://www.baidu.com");
                request.Timeout = 3000;
                request.Credentials = CredentialCache.DefaultCredentials;
                response = (WebResponse)request.GetResponse();
                headerCollection = response.Headers;
                foreach (var h in headerCollection.AllKeys)
                { if (h == "Date") { datetime = headerCollection[h]; } }
                return datetime;
            }
            catch (Exception) { return datetime; }
            finally
            {
                if (request != null)
                { request.Abort(); }
                if (response != null)
                { response.Close(); }
                if (headerCollection != null)
                { headerCollection.Clear(); }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.Text = Convert.ToDateTime(GetNetDateTime()).ToString("yyyy-MM-dd");
                dateEdit2.Text = Convert.ToDateTime(GetNetDateTime()).AddDays(1).ToString("yyyy-MM-dd");
                dateEdit1.Properties.MaxValue = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                dateEdit2.Properties.MaxValue = DateTime.Parse(Convert.ToDateTime(GetNetDateTime()).AddDays(1).ToString("yyyy-MM-dd"));
                winFormPage1.RefreshData = bind;
                bind();
                var json = WebUtils.MakeRequest2(ini.IniReadValue("mySqlCon1", "getOrderCountInfo"), "storeId=" + ini.IniReadValue("mySqlCon3", "storeId"), "post", "http", ini.IniReadValue("mySqlCon2", "authorization") + ini.IniReadValue("mySqlCon2", "authorization1")).Replace("\"", "").Replace("\"", "").Replace("{success:true,errorCode:0,msg:success,data:", "").Replace("}", "").Replace("{", "");
                labelControl12.Text = json.Split(',')[0].Split(':')[1];
                labelControl13.Text = "周:" + json.Split(',')[1].Split(':')[1] + "笔";
                labelControl14.Text = "月:" + json.Split(',')[2].Split(':')[1] + "笔";
                labelControl17.Text = json.Split(',')[3].Split(':')[1].ToString();
                labelControl16.Text = "周:" + json.Split(',')[4].Split(':')[1].ToString() + "元";
                labelControl15.Text = "月:" + json.Split(',')[5].Split(':')[1].ToString() + "元";
                labelControl24.Text = json.Split(',')[6].Split(':')[1].ToString();
                labelControl23.Text = "周:" + json.Split(',')[7].Split(':')[1].ToString() + "元";
                labelControl22.Text = "月:" + json.Split(',')[8].Split(':')[1].ToString() + "元";
                simpleButton3.Image = Resources._2dingdanA;
                simpleButton1.Image = Resources._2shoukuan1;
                simpleButton2.Image = Resources._2yajin2;
                simpleButton4.Image = Resources._2tuikuan2;
                simpleButton5.Image = Resources._2shehzi;
                xtraTabControl1.SelectedTabPageIndex = 2;
                //Control.OrderSetting(dateEdit1, labelControl16, labelControl15, labelControl17, labelControl13, labelControl14, labelControl12, labelControl11, labelControl23, labelControl22, labelControl24);
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                simpleButton5.Image = Resources._2shehziE;
                simpleButton1.Image = Resources._2shoukuan1;
                simpleButton2.Image = Resources._2yajin2;
                simpleButton3.Image = Resources._2dingdan1;
                simpleButton4.Image = Resources._2tuikuan2;
                xtraTabControl1.SelectedTabPageIndex = 3;
                Control.radioGroup(radioGroup1);
                setting.Fillgraspsetting(toggleSwitch1, radioGroup1, comboBoxEdit3,
    comboBoxEdit4, comboBoxEdit6, comboBoxEdit5, spinEdit1, toggleSwitch2, textEdit4, textEdit5, toggleSwitch3, spinEdit2, textEdit6,
    comboBoxEdit7, textEdit7, comboBoxEdit8, textEdit8, comboBoxEdit9, textEdit9, comboBoxEdit10, textEdit10, comboBoxEdit11,
    textEdit11, comboBoxEdit12, checkEdit1, comboBoxEdit13, this.name);
                Control.fillprint(toggleSwitch6, toggleSwitch7, toggleSwitch8, spinEdit3, spinEdit4, comboBoxEdit23, this.name);
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            simpleButton2.Image = Resources._2yajinD;
            simpleButton1.Image = Resources._2shoukuan1;
            simpleButton3.Image = Resources._2dingdan1;
            simpleButton4.Image = Resources._2tuikuan2;
            simpleButton5.Image = Resources._2shehzi;
        }

        private void panelControl8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabControl3_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {

        }

        private void textEdit3_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            textEdit3.Text = PreTreating(textEdit3.Text.Trim());
            if ("" == textEdit3.Text.Trim())
            {
                textEdit3.Text = "";
            }
            else if (IsNumberic(textEdit3.Text.Trim(), out errorMsg))
            {
                e.Cancel = true;
                textEdit3.Select(0, textEdit3.Text.Length);
                this.dxErrorProvider1.SetError(textEdit3, errorMsg);
            }
        }

        private void textEdit3_Validated(object sender, EventArgs e)
        {
            dxErrorProvider1.SetError(textEdit3, "");
            if (textEdit3.Text.Length == 8)
            {
                textEdit3.Enabled = false;
            }
        }

        private void textEdit3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton20.Focus();
            }
        }

        private void textEdit3_TextChanged(object sender, EventArgs e)
        {
            if (textEdit3.Text.Length == 8)
            {
                MessageBox.Show("金额不得超过8位");
            }
            if (textEdit3.Text.Length == 0)
            {
                BarCode.Stop();
            }
            else
            {
                BarCode.Start();
            }
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void labelControl45_Click(object sender, EventArgs e)
        {

        }

        private void labelControl47_Click(object sender, EventArgs e)
        {

        }

        private void labelControl65_Click(object sender, EventArgs e)
        {

        }

        private void labelControl89_Click(object sender, EventArgs e)
        {

        }

        private void toggleSwitch17_Toggled(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            simpleButton4.Image = Resources._2tuikuanC;
            simpleButton1.Image = Resources._2shoukuan1;
            simpleButton2.Image = Resources._2yajin2;
            simpleButton3.Image = Resources._2dingdan1;
            simpleButton5.Image = Resources._2shehzi;
        }

        private void timer3_Tick_1(object sender, EventArgs e)
        {
            try
            {
                var json = WebUtils.MakeRequest1(ini.IniReadValue("mySqlCon1", "getOrderInfo"), "{\"storeUserId\":" + ini.IniReadValue("mySqlCon3", "userId") + ",\"storeId\":" + ini.IniReadValue("mySqlCon3", "storeId") + ",\"orderNumber\":\"" + ini.IniReadValue("mySqlCon4", "lins") + "\"}", "post", "http", ini.IniReadValue("mySqlCon2", "authorization") + ini.IniReadValue("mySqlCon2", "authorization1")).Replace("\"", "").Replace("{", "").Replace("}", "");
                if (int.Parse(json.Split(',')[7].Split(':')[1]) == 1)
                {
                    ini.IniWriteValue("mySqlCon4", "orderAmount", json.Split(',')[3].Split(':')[2]);
                    ini.IniWriteValue("mySqlCon4", "discountAmount", json.Split(',')[4].Split(':')[1]);
                    ini.IniWriteValue("mySqlCon4", "realPayAmount", json.Split(',')[5].Split(':')[1]);
                    ini.IniWriteValue("mySqlCon4", "status", json.Split(',')[6].Split(':')[1]);
                    ini.IniWriteValue("mySqlCon4", "orderOn", json.Split(',')[10].Split(':')[1]);
                    if (json.Split(',')[12].Split(':')[1].Equals("1")) { ini.IniWriteValue("mySqlCon4", "terminal", "PC"); } else if (json.Split(',')[12].Split(':')[1].Equals("2")) { ini.IniWriteValue("mySqlCon4", "terminal", "安卓"); } else if (json.Split(',')[12].Split(':')[1].Equals("2")) { ini.IniWriteValue("mySqlCon4", "terminal", "安卓"); } else if (json.Split(',')[12].Split(':')[1].Equals("3")) { ini.IniWriteValue("mySqlCon4", "terminal", "IOS"); } else if (json.Split(',')[12].Split(':')[1].Equals("4")) { ini.IniWriteValue("mySqlCon4", "terminal", "收银API"); } else if (json.Split(',')[12].Split(':')[1].Equals("5")) { ini.IniWriteValue("mySqlCon4", "terminal", "二维码"); }
                    ini.IniWriteValue("mySqlCon4", "terminal", json.Split(',')[12].Split(':')[1]);
                    ini.IniWriteValue("mySqlCon4", "payTime", json.Split(',')[14].Split(':')[1] + ":" + json.Split(',')[14].Split(':')[2] + ":" + json.Split(',')[14].Split(':')[3]);
                    ini.IniWriteValue("mySqlCon4", "createTime", json.Split(',')[15].Split(':')[1] + ":" + json.Split(',')[15].Split(':')[2] + ":" + json.Split(',')[15].Split(':')[3]);
                    timer3.Stop();
                    textEdit2.Text = "";
                    try
                    {
                        isUserCancle = true;
                        th.Abort();
                        WaitFormService.Close();
                        isUserCancle = false;
                    }
                    catch { }
                    支付详情 支付详情 = new 支付详情();
                    支付详情.Show();
                }
                else
                {
                    if (int.Parse(json.Split(',')[7].Split(':')[1]) == 2)
                    {
                        MessageBox.Show("订单待支付");
                        timer3.Stop();
                    }
                    else if (int.Parse(json.Split(',')[7].Split(':')[1]) == 3)
                    {
                        MessageBox.Show("已退款");
                        timer3.Stop();
                    }
                    else if (int.Parse(json.Split(',')[7].Split(':')[1]) == 4)
                    {
                        MessageBox.Show("支付失败");
                        timer3.Stop();
                    }
                    else if (int.Parse(json.Split(',')[7].Split(':')[1]) == 5)
                    {
                        MessageBox.Show("部分退款");
                        timer3.Stop();
                    }
                    else if (int.Parse(json.Split(',')[7].Split(':')[1]) == 6)
                    {
                        MessageBox.Show("已关闭");
                        timer3.Stop();
                    }
                    else if (int.Parse(json.Split(',')[7].Split(':')[1]) == 7)
                    {
                        MessageBox.Show("未支付");
                        timer3.Stop();
                    }
                    else if (int.Parse(json.Split(',')[7].Split(':')[1]) == 8)
                    {
                        MessageBox.Show("退款失败");
                        timer3.Stop();
                    }
                    else if (int.Parse(json.Split(',')[7].Split(':')[1]) == 9)
                    {
                        MessageBox.Show("订单取消");
                        timer3.Stop();
                    }
                }
            }
            catch { }
        }

        private void repositoryItemButtonEdit4_Click(object sender, EventArgs e)
        {
            try
            {
                winFormPage1.RefreshData = bind;
                bind();
            }
            catch (Exception e1) { MessageBox.Show("当前网络状态不佳，请检查网络。"); Class11.captureWindowUsingPrintWindow(this).Save(Application.StartupPath + @"\log\image\" + DateTime.Now.ToString() + ".jpg"); Log4NetHelper.WriteErrorLog(e1.Message); }
        }

        private void repositoryItemButtonEdit5_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(Decimal.ToInt32(spinEdit3.Value * 1000));
            for (int i = 0; i < Decimal.ToInt32(spinEdit4.Value); i++)
            {
                Control.print3(gridView2.GetFocusedRowCellValue("orderNumber").ToString(), gridView2.GetFocusedRowCellValue("realPayAmount").ToString(), gridView2.GetFocusedRowCellValue("discountAmount").ToString(), gridView2.GetFocusedRowCellValue("orderAmount").ToString(), gridView2.GetFocusedRowCellValue("type").ToString(), gridView2.GetFocusedRowCellValue("status").ToString(), gridView2.GetFocusedRowCellValue("terminal").ToString(), gridView2.GetFocusedRowCellValue("userName").ToString(), gridView2.GetFocusedRowCellValue("storeName").ToString(), gridView2.GetFocusedRowCellValue("payTime").ToString(), comboBoxEdit23.Text);
            }
        }

        private void repositoryItemButtonEdit6_Click(object sender, EventArgs e)
        {
            ini.IniWriteValue("mySqlCon5", "orderon", gridView2.GetFocusedRowCellValue("orderNumber").ToString());
            ini.IniWriteValue("mySqlCon5", "realPayAmount", gridView2.GetFocusedRowCellValue("realPayAmount").ToString());
            退款 退款 = new 退款();
            退款.Show();
        }

        private void simpleButton18_Click_1(object sender, EventArgs e)
        {
            Control.Updquicksetting(toggleSwitch5, comboBoxEdit14, textEdit12, comboBoxEdit15, textEdit13, comboBoxEdit17, textEdit15, comboBoxEdit16, textEdit14, comboBoxEdit19, textEdit17, comboBoxEdit18, textEdit16, comboBoxEdit21, textEdit19, comboBoxEdit20, textEdit18, comboBoxEdit22, textEdit20, this.name);
            MessageBox.Show("保存成功！", "确定", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            Control.quicksetting(toggleSwitch5, comboBoxEdit14, textEdit12, comboBoxEdit15, textEdit13, comboBoxEdit17, textEdit15, comboBoxEdit16, textEdit14, comboBoxEdit19, textEdit17, comboBoxEdit18, textEdit16, comboBoxEdit21, textEdit19, comboBoxEdit20, textEdit18, comboBoxEdit22, textEdit20, this.name);
        }

        private void contextMenuStrip3_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dateEdit1_TextChanged(object sender, EventArgs e)
        {
            dateEdit1.Text = Convert.ToDateTime(dateEdit1.Text).ToString("yyyy-MM-dd");
        }

        private void dateEdit2_TextChanged(object sender, EventArgs e)
        {
            dateEdit2.Text = Convert.ToDateTime(dateEdit2.Text).ToString("yyyy-MM-dd");
        }

        private void simpleButton6_MouseMove(object sender, MouseEventArgs e)
        {
            Control.ButtonStyle1(simpleButton6);
        }

        private void simpleButton6_MouseLeave(object sender, EventArgs e)
        {
            Control.ButtonStyle(simpleButton6);
        }

        private void simpleButton7_MouseMove(object sender, MouseEventArgs e)
        {
            Control.ButtonStyle1(simpleButton7);
        }

        private void simpleButton7_MouseLeave(object sender, EventArgs e)
        {
            Control.ButtonStyle(simpleButton7);
        }

        private void simpleButton8_MouseMove(object sender, MouseEventArgs e)
        {
            Control.ButtonStyle1(simpleButton8);
        }

        private void simpleButton8_MouseLeave(object sender, EventArgs e)
        {
            Control.ButtonStyle(simpleButton8);
        }

        private void simpleButton16_MouseMove(object sender, MouseEventArgs e)
        {
            Control.ButtonStyle1(simpleButton16);
        }

        private void simpleButton16_MouseLeave(object sender, EventArgs e)
        {
            Control.ButtonStyle(simpleButton16);
        }

        private void simpleButton21_MouseMove(object sender, MouseEventArgs e)
        {
            Control.ButtonStyle1(simpleButton21);
        }

        private void simpleButton21_MouseLeave(object sender, EventArgs e)
        {
            Control.ButtonStyle(simpleButton21);
        }

        private void simpleButton11_MouseMove(object sender, MouseEventArgs e)
        {
            Control.ButtonStyle1(simpleButton11);
        }

        private void simpleButton11_MouseLeave(object sender, EventArgs e)
        {
            Control.ButtonStyle(simpleButton11);
        }

        private void simpleButton10_MouseMove(object sender, MouseEventArgs e)
        {
            Control.ButtonStyle1(simpleButton10);
        }

        private void simpleButton10_MouseLeave(object sender, EventArgs e)
        {
            Control.ButtonStyle(simpleButton10);
        }

        private void simpleButton9_MouseMove(object sender, MouseEventArgs e)
        {
            Control.ButtonStyle1(simpleButton9);
        }

        private void simpleButton9_MouseLeave(object sender, EventArgs e)
        {
            Control.ButtonStyle(simpleButton9);
        }

        private void simpleButton14_MouseMove(object sender, MouseEventArgs e)
        {
            Control.ButtonStyle1(simpleButton14);
        }

        private void simpleButton14_MouseLeave(object sender, EventArgs e)
        {
            Control.ButtonStyle(simpleButton14);
        }

        private void simpleButton13_MouseMove(object sender, MouseEventArgs e)
        {
            Control.ButtonStyle1(simpleButton13);
        }

        private void simpleButton13_MouseLeave(object sender, EventArgs e)
        {
            Control.ButtonStyle(simpleButton13);
        }

        private void simpleButton12_MouseMove(object sender, MouseEventArgs e)
        {
            Control.ButtonStyle1(simpleButton12);
        }

        private void simpleButton12_MouseLeave(object sender, EventArgs e)
        {
            Control.ButtonStyle(simpleButton12);
        }

        private void simpleButton17_MouseMove(object sender, MouseEventArgs e)
        {
            Control.ButtonStyle1(simpleButton17);
        }

        private void simpleButton17_MouseLeave(object sender, EventArgs e)
        {
            Control.ButtonStyle(simpleButton17);
        }

        private void simpleButton15_MouseMove(object sender, MouseEventArgs e)
        {
            Control.ButtonStyle1(simpleButton15);
        }

        private void simpleButton15_MouseLeave(object sender, EventArgs e)
        {
            Control.ButtonStyle(simpleButton15);
        }

        private void simpleButton31_MouseMove(object sender, MouseEventArgs e)
        {
            Control.ButtonStyle1(simpleButton31);
        }

        private void simpleButton31_MouseLeave(object sender, EventArgs e)
        {
            Control.ButtonStyle(simpleButton31);
        }

        private void simpleButton32_MouseMove(object sender, MouseEventArgs e)
        {
            Control.ButtonStyle1(simpleButton32);
        }

        private void simpleButton32_MouseLeave(object sender, EventArgs e)
        {
            Control.ButtonStyle(simpleButton32);
        }

        private void simpleButton22_MouseMove(object sender, MouseEventArgs e)
        {
            Control.ButtonStyle1(simpleButton22);
        }

        private void simpleButton22_MouseLeave(object sender, EventArgs e)
        {
            Control.ButtonStyle(simpleButton22);
        }
    }
}