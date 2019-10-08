using CustomPrint;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using DXApplication2.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using thsoft_core;
using tools;

namespace DXApplication2.HELP
{
    class ControlHelp
    {
        DataTable dt = new DataTable();
        IniFile ini = new IniFile(@"config\set.ini");
        PrintRow row0;
        PrintRow row1;
        PrintRow row2;
        PrintRow row3;
        PrintRow row4;
        PrintRow row5;
        PrintRow row6;
        PrintRow row7;
        PrintRow row8;
        PrintRow row9;
        PrintRow row10;
        PrintRow row11;
        PrintRow row12;
        PrintRow row13;
        PrintRow row14;
        PrintRow row15;
        PrintRow row16;
                public void ButtonStyle(DevExpress.XtraEditors.SimpleButton simpleButton)
        {
            simpleButton.ButtonStyle = BorderStyles.Default;
        }
        
        public void ButtonStyle1(SimpleButton simpleButton)
        {
            simpleButton.Appearance.BackColor = Color.FromArgb(14, 144, 254);
            simpleButton.Appearance.BackColor = Color.FromArgb(14, 144, 254);
            simpleButton.ButtonStyle = BorderStyles.Simple;
            simpleButton.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
        }

        public void TimeEdit(DateEdit dateEdit)
        {
            dateEdit.Properties.DisplayFormat.FormatString = "d";
            dateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            dateEdit.Properties.EditFormat.FormatString = "d";
            dateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.None;
            dateEdit.Properties.Mask.EditMask = "d";
            dateEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            dateEdit.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.False;
        }

        public void ComboBoxEdit(ComboBoxEdit ComboBoxEdit)
        {
                                    ComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }

        public void GridControl(GridView GridView)
        {
            GridView.OptionsView.ShowGroupPanel = false;
            GridView.OptionsView.ShowFooter = true;

                                                        }

        public void comboBoxEdit1(ComboBoxEdit comboBoxEdit)
        {
            dt = my_sql.listTable("SELECT Cashier FROM `cashier`;");
            comboBoxEdit.Properties.Items.Add("店员");
            comboBoxEdit.SelectedIndex = 0;
            for (int i=0;i< dt.Rows.Count;i++)
            {
               comboBoxEdit.Properties.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        public void comboBoxEdit2(ComboBoxEdit comboBoxEdit)
        {
            dt = my_sql.listTable("SELECT PaymentMethod FROM `paymentmethod`");
            comboBoxEdit.Properties.Items.Add("支付方式");
            comboBoxEdit.SelectedIndex = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBoxEdit.Properties.Items.Add(dt.Rows[i][0].ToString());
            }
        }
        
        public void radioGroup(RadioGroup radioGroup)
        {
            if (radioGroup.Properties.Items.Count<1)
            {
                dt = my_sql.listTable("SELECT GrabMode FROM `grabmode`;");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    radioGroup.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("串口模式", dt.Rows[i][0].ToString()));
                }
            }
        }

        public void xtraTabControl(XtraTabControl xtraTabControl, XtraTabPage XtraTabPage1, XtraTabPage XtraTabPag2, XtraTabPage XtraTabPag3, XtraTabPage XtraTabPage4)
        {
            xtraTabControl.TabPages.Remove(XtraTabPage1);
            xtraTabControl.TabPages.Remove(XtraTabPag2);
            xtraTabControl.TabPages.Remove(XtraTabPag3);
            xtraTabControl.TabPages.Remove(XtraTabPage4);
        }

        public void xtraTabControl1(XtraTabControl xtraTabControl, XtraTabPage XtraTabPage1, XtraTabPage XtraTabPag2, XtraTabPage XtraTabPag3, XtraTabPage XtraTabPage4)
        {
            xtraTabControl.TabPages.Add(XtraTabPage1);
            xtraTabControl.TabPages.Add(XtraTabPag2);
            xtraTabControl.TabPages.Add(XtraTabPag3);
            xtraTabControl.TabPages.Add(XtraTabPage4);
        }
        
        public void quicksetting(ToggleSwitch toggleSwitch5, ComboBoxEdit comboBoxEdit14, TextEdit textEdit12, ComboBoxEdit comBoxEdit15,TextEdit textEdit13, ComboBoxEdit comboBoxEdit17, TextEdit textEdit15, ComboBoxEdit comboBoxEdit16, TextEdit textEdit14, ComboBoxEdit comboBoxEdit19, TextEdit textEdit17, ComboBoxEdit comboBoxEdit18, TextEdit textEdit16, ComboBoxEdit comboBoxEdit21, TextEdit textEdit19, ComboBoxEdit comboBoxEdit20, TextEdit textEdit18, ComboBoxEdit comboBoxEdit22, TextEdit textEdit20, string UserId)
        {
            toggleSwitch5.IsOn = bool.Parse(ini.IniReadValue("quicksetting", "FastSwitchState"));
            comboBoxEdit14.SelectedIndex = int.Parse(ini.IniReadValue("quicksetting", "GraspShortcutKeys1"));
            textEdit12.Text = ini.IniReadValue("quicksetting", "GraspShortcutKeys2");
            comBoxEdit15.SelectedIndex = int.Parse(ini.IniReadValue("quicksetting", "ReceivablesShortcutKeys1"));
            textEdit13.Text = ini.IniReadValue("quicksetting", "ReceivablesShortcutKeys2");
            comboBoxEdit17.SelectedIndex = int.Parse(ini.IniReadValue("quicksetting", "OrderShortcutKeys1"));
            textEdit15.Text = ini.IniReadValue("quicksetting", "OrderShortcutKeys2");
            comboBoxEdit16.SelectedIndex = int.Parse(ini.IniReadValue("quicksetting", "RefundShortcutKeys1"));
            textEdit14.Text = ini.IniReadValue("quicksetting", "RefundShortcutKeys2");
            comboBoxEdit19.SelectedIndex = int.Parse(ini.IniReadValue("quicksetting", "PipelinePrinting1"));
            textEdit17.Text = ini.IniReadValue("quicksetting", "PipelinePrinting2");
            comboBoxEdit18.SelectedIndex = int.Parse(ini.IniReadValue("quicksetting", "ArouseConcealment1"));
            textEdit16.Text = ini.IniReadValue("quicksetting", "ArouseConcealment2");
            comboBoxEdit21.SelectedIndex = int.Parse(ini.IniReadValue("quicksetting", "ClosingProcess1"));
            textEdit19.Text = ini.IniReadValue("quicksetting", "ClosingProcess2");
            comboBoxEdit20.SelectedIndex = int.Parse(ini.IniReadValue("quicksetting", "SwitchingAccounts1"));
            textEdit18.Text = ini.IniReadValue("quicksetting", "SwitchingAccounts2");
            comboBoxEdit22.SelectedIndex = int.Parse(ini.IniReadValue("quicksetting", "ViewShortcuts1"));
            textEdit20.Text = ini.IniReadValue("quicksetting", "ViewShortcuts2");
        }

        public void Updquicksetting(ToggleSwitch toggleSwitch5, ComboBoxEdit comboBoxEdit14, TextEdit textEdit12, ComboBoxEdit comBoxEdit15, TextEdit textEdit13, ComboBoxEdit comboBoxEdit17, TextEdit textEdit15, ComboBoxEdit comboBoxEdit16, TextEdit textEdit14, ComboBoxEdit comboBoxEdit19, TextEdit textEdit17, ComboBoxEdit comboBoxEdit18, TextEdit textEdit16, ComboBoxEdit comboBoxEdit21, TextEdit textEdit19, ComboBoxEdit comboBoxEdit20, TextEdit textEdit18, ComboBoxEdit comboBoxEdit22, TextEdit textEdit20, string UserId)
        {
            ini.IniWriteValue("quicksetting", "FastSwitchState", toggleSwitch5.IsOn.ToString());
            ini.IniWriteValue("quicksetting", "GraspShortcutKeys1", comboBoxEdit14.SelectedIndex.ToString());
            ini.IniWriteValue("quicksetting", "GraspShortcutKeys2", textEdit12.Text);
            ini.IniWriteValue("quicksetting", "ReceivablesShortcutKeys1", comBoxEdit15.SelectedIndex.ToString());
            ini.IniWriteValue("quicksetting", "ReceivablesShortcutKeys2", textEdit13.Text);
            ini.IniWriteValue("quicksetting", "OrderShortcutKeys1", comboBoxEdit17.SelectedIndex.ToString());
            ini.IniWriteValue("quicksetting", "OrderShortcutKeys2", textEdit15.Text);
            ini.IniWriteValue("quicksetting", "RefundShortcutKeys1", comboBoxEdit16.SelectedIndex.ToString());
            ini.IniWriteValue("quicksetting", "RefundShortcutKeys2", textEdit14.Text);
            ini.IniWriteValue("quicksetting", "PipelinePrinting1", comboBoxEdit19.SelectedIndex.ToString());
            ini.IniWriteValue("quicksetting", "PipelinePrinting2", textEdit17.Text);
            ini.IniWriteValue("quicksetting", "ArouseConcealment1", comboBoxEdit18.SelectedIndex.ToString());
            ini.IniWriteValue("quicksetting", "ArouseConcealment2", textEdit16.Text);
            ini.IniWriteValue("quicksetting", "ClosingProcess1", comboBoxEdit21.SelectedIndex.ToString());
            ini.IniWriteValue("quicksetting", "ClosingProcess2", textEdit19.Text);
            ini.IniWriteValue("quicksetting", "SwitchingAccounts1", comboBoxEdit20.SelectedIndex.ToString());
            ini.IniWriteValue("quicksetting", "SwitchingAccounts2", textEdit18.Text);
            ini.IniWriteValue("quicksetting", "ViewShortcuts1", comboBoxEdit22.SelectedIndex.ToString());
            ini.IniWriteValue("quicksetting", "ViewShortcuts2", textEdit20.Text);
        }

        public void baudrate(ComboBoxEdit comboBoxEdit4)
        {
            dt= my_sql.listTable("SELECT BaudRate FROM baudrate;");
            for (int i=0;i<dt.Rows.Count;i++)
            {
                comboBoxEdit4.Properties.Items.Add(dt.Rows[i][0]);
            }
        }

        public void fillprint(ToggleSwitch toggleSwitch6, ToggleSwitch toggleSwitch7, ToggleSwitch toggleSwitch8, SpinEdit spinEdit3, SpinEdit spinEdit4, ComboBoxEdit comboBoxEdit23,string UserId)
        {
            toggleSwitch6.IsOn=bool.Parse(ini.IniReadValue("printsetting", "PrintSwitch"));
            toggleSwitch7.IsOn=bool.Parse(ini.IniReadValue("printsetting", "CompatibilityMode"));
            toggleSwitch8.IsOn = bool.Parse(ini.IniReadValue("printsetting", "DetailSwitch"));
            spinEdit3.Text = ini.IniReadValue("printsetting", "PrintingDelay");
            spinEdit4.Text=ini.IniReadValue("printsetting", "PrintingNumber");
            comboBoxEdit23.Text=ini.IniReadValue("printsetting", "PrintingDrive");
        }

        public void UPdprint(ToggleSwitch toggleSwitch6, ToggleSwitch toggleSwitch7, ToggleSwitch toggleSwitch8, SpinEdit spinEdit3, SpinEdit spinEdit4, ComboBoxEdit comboBoxEdit23, string UserId)
        {
            ini.IniWriteValue("printsetting", "PrintSwitch", toggleSwitch6.IsOn.ToString());
            ini.IniWriteValue("printsetting", "CompatibilityMode", toggleSwitch7.IsOn.ToString());
            ini.IniWriteValue("printsetting", "DetailSwitch", toggleSwitch8.IsOn.ToString());
            ini.IniWriteValue("printsetting", "PrintingDelay", spinEdit3.Text);
            ini.IniWriteValue("printsetting", "PrintingNumber", spinEdit4.Text);
            ini.IniWriteValue("printsetting", "PrintingDrive", comboBoxEdit23.Text);
        }

        public void print3(string orderNumber, string realPayAmount,string discountAmount,string orderAmount ,string type ,string status ,string terminal ,string userName ,string storeName ,string payTime ,string print)
        {
            row0 = new PrintRow(150, "      "+ storeName, new Font("宋体", 14, FontStyle.Bold), Brushes.Blue, 0);
            row1 = new PrintRow(150, "********付款凭证********", new Font("宋体", 10), Brushes.Blue, 40);
            row2 = new PrintRow(150, "门店名称：" + storeName, new Font("宋体", 10), Brushes.Black, 70);
            row3 = new PrintRow(150, "收银员："+ userName, new Font("宋体", 10), Brushes.Black, 100);
            row4 = new PrintRow(150, "订单编号："+ orderNumber.Substring(0,17), new Font("宋体", 10), Brushes.Black,130);
            row5 = new PrintRow(150, "          "+orderNumber.Substring(17,7), new Font("宋体", 10), Brushes.Black, 150);
            row6 = new PrintRow(150, "支付方式："+type, new Font("宋体", 10), Brushes.Black, 170);
            row7 = new PrintRow(150, "支付状态：" + status, new Font("宋体", 10), Brushes.Black, 200);
            row8 = new PrintRow(150, "支付终端：" + terminal, new Font("宋体", 10), Brushes.Black, 230);
            row9 = new PrintRow(150, "支付时间：" + payTime, new Font("宋体", 10), Brushes.Black, 260);
            row10 = new PrintRow(150, "订单金额：" + orderAmount, new Font("宋体", 10), Brushes.Black, 290);
            row11 = new PrintRow(150, "优惠金额：" + discountAmount, new Font("宋体", 10), Brushes.Black, 320);
            row12 = new PrintRow(150, "顾客实付：", new Font("宋体", 10,FontStyle.Bold), Brushes.Black, 350);
            row13 = new PrintRow(150, "RMB:"+ realPayAmount, new Font("宋体", 20, FontStyle.Bold), Brushes.Black, 390);
            row14 = new PrintRow(150, "签    名：___________", new Font("宋体", 10), Brushes.Blue, 420);
            row15 = new PrintRow(150, "备    注：", new Font("宋体", 10), Brushes.Blue, 450);
                                    Order tempOrder = new Order(new List<PrintRow>() { row0, row1, row2, row3, row4,row5,row6,row7,row8,row9,row10,row11,row12,row13,row14,row15});
            PrintOrder.Print(print, tempOrder);
        }

        public void print5(string print, string storeName, string userName,string  terminal, string realPayAmount)
        {
                                                            
            row0 = new PrintRow(150, "      " +storeName, new Font("宋体", 14, FontStyle.Bold), Brushes.Blue, 0);
            row1 = new PrintRow(150, "********付款凭证********", new Font("宋体", 10), Brushes.Blue, 40);
            row2 = new PrintRow(150, "门店名称：" +storeName, new Font("宋体", 10), Brushes.Black, 70);
            row3 = new PrintRow(150, "收银员：" + userName, new Font("宋体", 10), Brushes.Black, 100);
            row8 = new PrintRow(150, "支付终端：" + terminal, new Font("宋体", 10), Brushes.Black, 130);
            row12 = new PrintRow(150, "顾客实付：", new Font("宋体", 10, FontStyle.Bold), Brushes.Black, 160);
            row13 = new PrintRow(150, "RMB:" +realPayAmount, new Font("宋体", 20, FontStyle.Bold), Brushes.Black, 190);
            row16 = new PrintRow(150, "*********付款码*********", new Font("宋体", 10), Brushes.Blue, 230);
            Order tempOrder = new Order(new List<PrintRow>() { row0, row1, row2, row3, row8, row12, row13,row16 });
            PrintOrder.Print(print, tempOrder);
        }

        public void print6(string OrderBH, string print)
        {
                                                            
            row0 = new PrintRow(150, "      " + dt.Rows[0][0].ToString(), new Font("宋体", 14, FontStyle.Bold), Brushes.Blue, 0);
            row1 = new PrintRow(150, "********付款凭证********", new Font("宋体", 10), Brushes.Blue, 40);
            row2 = new PrintRow(150, "门店名称：" + dt.Rows[0][0].ToString(), new Font("宋体", 10), Brushes.Black, 70);
            row3 = new PrintRow(150, "收银员：" + dt.Rows[0][1].ToString(), new Font("宋体", 10), Brushes.Black, 100);
            row8 = new PrintRow(150, "支付终端：" + dt.Rows[0][5].ToString(), new Font("宋体", 10), Brushes.Black, 130);
            row12 = new PrintRow(150, "顾客实付：", new Font("宋体", 10, FontStyle.Bold), Brushes.Black, 160);
            row13 = new PrintRow(150, "RMB:" + (decimal.Parse(dt.Rows[0][7].ToString()) - decimal.Parse(dt.Rows[0][8].ToString())).ToString(), new Font("宋体", 20, FontStyle.Bold), Brushes.Black, 190);
            Order tempOrder = new Order(new List<PrintRow>() { row1,row0,row2,row3,row8,row12,row13});
            PrintOrder.Print(print, tempOrder);
        }

        public void print7(DateEdit dateEdit1,DateEdit dateEdit2,string UserId,string refundWxNum,string refundWxAmount,string NameStore,string totalPaidInOrder,string refundAliAmount,string refundAliNum,string wxTotalOrder,string refundTotalOrder,string refundTotalAmount,string wxTotalAmount,string aliTotalOrder,string aliTotalAmount,string totalOrder,string totalAmount,string totalPaidInAmount, string print)
        {
            
            DataTable dt2 = my_sql.listTable("SELECT SUM(PaymentAmount),COUNT(PaymentAmount) FROM `order` o WHERE o.State=4 AND PaymentTime>='"+dateEdit1.Text+"' AND PaymentTime<='"+dateEdit2.Text+"';");
            DataTable d1 = my_sql.listTable("SELECT COUNT(PaymentAmount),SUM(PaymentAmount) FROM `order` o WHERE o.State=2 AND PaymentTime>='" + dateEdit1.Text+"' AND PaymentTime<='"+dateEdit2.Text+"';");
            
            row0 = new PrintRow(150, "        "+NameStore+ "        ", new Font("宋体", 10, FontStyle.Bold), Brushes.Blue, 0);
            row1 = new PrintRow(150, "********流水凭证********", new Font("宋体", 10), Brushes.Blue, 40);
            row2 = new PrintRow(150, "打印人：" + UserId, new Font("宋体", 10), Brushes.Black, 70);
            row3 = new PrintRow(150, "起始时间：" + dateEdit1.Text, new Font("宋体", 10), Brushes.Black, 100);
            row4 = new PrintRow(150, "截止时间：" + dateEdit2.Text, new Font("宋体", 10), Brushes.Black, 130);
            row5 = new PrintRow(150, "-----------------------", new Font("宋体", 10, FontStyle.Bold), Brushes.Black, 160);
            row6 = new PrintRow(150, "订单统计:" + totalOrder + "笔   " + totalAmount + "元", new Font("宋体", 10), Brushes.Black, 190);
            row7 = new PrintRow(150, "商户实收:"+ totalPaidInOrder + "笔   "+ totalPaidInAmount + "元", new Font("宋体", 10), Brushes.Black, 220);
            row8 = new PrintRow(150, "支 付 宝:" + aliTotalOrder + "笔   " + aliTotalAmount + "元", new Font("宋体", 10), Brushes.Black, 220);
            row9 = new PrintRow(150, "微    信:" + wxTotalOrder + "笔   " + wxTotalAmount + "元", new Font("宋体", 10), Brushes.Black, 220);

            row10 = new PrintRow(150, "-----------------------", new Font("宋体", 10), Brushes.Black, 250);
            row11 = new PrintRow(150, "退款统计"+ refundTotalOrder + "笔   " + refundTotalAmount + "元", new Font("宋体", 10), Brushes.Black, 280);
            row12 = new PrintRow(150, "支 付 宝" + refundAliNum + "笔   " + refundAliAmount + "元", new Font("宋体", 10), Brushes.Black, 310);
            row13 = new PrintRow(150, "微    信" + refundWxNum + "笔   " + refundWxAmount + "元", new Font("宋体", 10), Brushes.Black, 340);
            Order tempOrder = new Order(new List<PrintRow>() { row0, row1, row2, row3, row4, row5,row6,row7,row10,row11, row12, row13 });
            PrintOrder.Print(print, tempOrder);
        }

        public void print5(ComboBoxEdit comboBoxEdit23) {
            PrinterSettings.StringCollection printers = PrinterSettings.InstalledPrinters;
            foreach (var item in printers)
            {
                comboBoxEdit23.Properties.Items.Add(item);
            }
        }

        public void currencysetting(ToggleSwitch toggleSwitch9, ToggleSwitch toggleSwitch10, ToggleSwitch toggleSwitch11, ToggleSwitch toggleSwitch12, ToggleSwitch toggleSwitch16, SpinEdit spinEdit5, ToggleSwitch toggleSwitch14, ToggleSwitch toggleSwitch13,ToggleSwitch toggleSwitch17,string UserId)
        {
            ini.IniWriteValue("currencysetting", "SelfStart", toggleSwitch9.IsOn.ToString());
            ini.IniWriteValue("currencysetting", "AutomaticUpgrade", toggleSwitch10.IsOn.ToString());
            ini.IniWriteValue("currencysetting", "PushNotice", toggleSwitch11.IsOn.ToString());
            ini.IniWriteValue("currencysetting", "SuspensionWindow", toggleSwitch12.IsOn.ToString());
            ini.IniWriteValue("currencysetting", "ScanningCallUp", toggleSwitch16.IsOn.ToString());
            ini.IniWriteValue("currencysetting", "SweepTimeout", spinEdit5.Text);
            ini.IniWriteValue("currencysetting", "VoiceAnnouncements", toggleSwitch14.IsOn.ToString());
            ini.IniWriteValue("currencysetting", "JiangXiaoHe_VoiceAnnouncements", toggleSwitch13.IsOn.ToString());
            ini.IniWriteValue("currencysetting", "JiangXiaoHe", toggleSwitch17.IsOn.ToString());
        }

        public void currencysetting1(ToggleSwitch toggleSwitch9, ToggleSwitch toggleSwitch10, ToggleSwitch toggleSwitch11, ToggleSwitch toggleSwitch12, ToggleSwitch toggleSwitch16, SpinEdit spinEdit5, ToggleSwitch toggleSwitch14, ToggleSwitch toggleSwitch13, ToggleSwitch toggleSwitch17, string UserId)
        {
            toggleSwitch9.IsOn=bool.Parse(ini.IniReadValue("currencysetting", "SelfStart"));
            toggleSwitch10.IsOn = bool.Parse(ini.IniReadValue("currencysetting", "AutomaticUpgrade"));
            toggleSwitch11.IsOn = bool.Parse(ini.IniReadValue("currencysetting", "PushNotice"));
            toggleSwitch12.IsOn = bool.Parse(ini.IniReadValue("currencysetting", "SuspensionWindow"));
            toggleSwitch16.IsOn = bool.Parse(ini.IniReadValue("currencysetting", "ScanningCallUp"));
            spinEdit5.Text=ini.IniReadValue("currencysetting", "SweepTimeout");
            toggleSwitch14.IsOn=bool.Parse(ini.IniReadValue("currencysetting", "VoiceAnnouncements"));
            toggleSwitch13.IsOn = bool.Parse(ini.IniReadValue("currencysetting", "JiangXiaoHe_VoiceAnnouncements"));
            toggleSwitch17.IsOn = bool.Parse(ini.IniReadValue("currencysetting", "JiangXiaoHe"));
        }

        public void AccountInformation (ComboBoxEdit comboBoxEdit24, string UserId, LabelControl labelControl109)
        {
            dt= my_sql.listTable("SELECT NameStore FROM namestore;");
            for (int i=0;i<dt.Rows.Count;i++)
            {
                comboBoxEdit24.Properties.Items.Add(dt.Rows[i][0].ToString());
            }
            DataTable dt1 = my_sql.listTable("SELECT UserName FROM `user` WHERE UserID='"+UserId+"';");
            labelControl109.Text = ini.IniReadValue("mySqlCon3", "username");
            DataTable dt2 = my_sql.listTable("SELECT NameStore FROM namestore WHERE Id=(SELECT NameStore FROM `user` WHERE UserID='"+UserId+"');");
            comboBoxEdit24.Text = ini.IniReadValue("mySqlCon3", "storeName");
        }

        public bool IsNumber(string s, int precision, int scale)
        {
            if ((precision == 0) && (scale == 0))
            {
                return false;
            }
            string pattern = @"(^\d{1," + precision + "}";
            if (scale > 0)
            {
                pattern += @"\.\d{0," + scale + "}$)|" + pattern;
            }
            pattern += "$)";
            return Regex.IsMatch(s, pattern);
        }
    }
}
