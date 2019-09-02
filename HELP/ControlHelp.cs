using Common.Utilities;
using CustomPrint;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using DXApplication2.BLL;
using DXApplication2.DAL;
using DXApplication2.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thsoft_core;

namespace DXApplication2.HELP
{
    class ControlHelp
    {
        DataTable dt = new DataTable();
        B_Order Order = new B_Order();
        quicksetting q = new MODEL.quicksetting();
        B_quicksetting quick = new B_quicksetting();
        B_PrintSetting print = new B_PrintSetting();
        B_currencysetting currency = new B_currencysetting();
        currencysetting curr = new MODEL.currencysetting();
        printsetting printsetting = new printsetting();
        B_User user = new B_User();
        D_print print4 = new D_print();
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
        PrintRow row17;
        public void ButtonStyle(DevExpress.XtraEditors.SimpleButton simpleButton)
        {
            simpleButton.Appearance.BackColor = Color.FromArgb(224, 224, 224);
            simpleButton.Appearance.BackColor2 = Color.FromArgb(224, 224, 224);
            simpleButton.Appearance.BorderColor = Color.FromArgb(224, 224, 224);
            simpleButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
        }
        
        public void ButtonStyle1(SimpleButton simpleButton1, SimpleButton simpleButton2, SimpleButton simpleButton3,SimpleButton simpleButton4)
        {
            simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            simpleButton3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            simpleButton4.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
        }

        public void TimeEdit(DateEdit dateEdit)
        {
            dateEdit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            dateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEdit.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            dateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEdit.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            dateEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            dateEdit.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
        }

        public void ComboBoxEdit(ComboBoxEdit ComboBoxEdit)
        {
            //ComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            //ComboBoxEdit.Properties.ReadOnly = true;
            ComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }

        public void GridControl(GridView GridView)
        {
            GridView.OptionsView.ShowGroupPanel = false;
            GridView.OptionsView.ShowFooter = true;
            //GridView.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //GridView.Columns[1].SummaryItem.DisplayFormat = "{0:0.##}";
            //GridView.Columns[1].SummaryItem.FieldName = "TotalMoney";
            //gridView2.GetFocusedRowCellValue("OrderBH").ToString()
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

        public void OrderSetting(DateEdit dateEdit1,LabelControl labelControl16, LabelControl labelControl15, LabelControl labelControl17, LabelControl labelControl13, LabelControl labelControl14, LabelControl labelControl12, LabelControl labelControl11, LabelControl labelControl23, LabelControl labelControl22, LabelControl labelControl24)
        {
            if (dateEdit1.ToString().Equals("DevExpress.XtraEditors.DateEdit"))
            {
                labelControl16.Text = "周:" + Order.SelectOrder6(DateTime.Now.Date.ToString()).Rows[0][0].ToString() + "元";
                labelControl15.Text = "月:" + Order.SelectOrder7(DateTime.Now.Date.ToString()).Rows[0][0].ToString() + "元";
                labelControl17.Text = Order.SelectOrder8(DateTime.Now.Date.ToString()).Rows[0][0].ToString();
                labelControl13.Text = "周:" + Order.SelectOrder9(DateTime.Now.Date.ToString()).Rows[0][0].ToString() + "元";
                labelControl14.Text = "月:" + Order.SelectOrder10(DateTime.Now.Date.ToString()).Rows[0][0].ToString() + "元";
                labelControl12.Text = Order.SelectOrder11(DateTime.Now.Date.ToString()).Rows[0][0].ToString();
                labelControl23.Text = "周:" + Order.SelectOrder12(DateTime.Now.Date.ToString()).Rows[0][0].ToString() + "元";
                labelControl22.Text = "月:" + Order.SelectOrder13(DateTime.Now.Date.ToString()).Rows[0][0].ToString() + "元";
                labelControl24.Text = Order.SelectOrder14(DateTime.Now.Date.ToString()).Rows[0][0].ToString();

            }
            else
            {
                labelControl16.Text = "周:" + Order.SelectOrder6(dateEdit1.ToString()).Rows[0][0].ToString() + "元";
                labelControl15.Text = "月:" + Order.SelectOrder7(dateEdit1.ToString()).Rows[0][0].ToString() + "元";
                labelControl17.Text = Order.SelectOrder8(dateEdit1.ToString()).Rows[0][0].ToString();
                labelControl13.Text = "周:" + Order.SelectOrder9(dateEdit1.ToString()).Rows[0][0].ToString() + "元";
                labelControl14.Text = "月:" + Order.SelectOrder10(dateEdit1.ToString()).Rows[0][0].ToString() + "元";
                labelControl12.Text = Order.SelectOrder11(dateEdit1.ToString()).Rows[0][0].ToString();
                labelControl23.Text = "周:" + Order.SelectOrder12(dateEdit1.ToString()).Rows[0][0].ToString() + "元";
                labelControl22.Text = "月:" + Order.SelectOrder13(dateEdit1.ToString()).Rows[0][0].ToString() + "元";
                labelControl24.Text = Order.SelectOrder14(dateEdit1.ToString()).Rows[0][0].ToString();
            }
        }

        public void OrderSetting2(DateEdit dateEdit2,DateEdit dateEdit1,GridControl gridControl2, ComboBoxEdit comboBoxEdit1, ComboBoxEdit comboBoxEdit2, ComboBoxEdit comboBoxEdit3,SearchControl searchControl1)
        {
            if (!dateEdit2.Text.Equals(""))
            {
                if (!dateEdit1.Text.Equals(""))
                {
                    gridControl2.DataSource = Order.SelectOrder(dateEdit1.Text, dateEdit2.Text);
                }
                else
                {
                    gridControl2.DataSource = Order.SelectOrder(dateEdit2.Text);
                }
            }
            else
            {
                if (!dateEdit1.Text.Equals(""))
                {
                    gridControl2.DataSource = Order.SelectOrder5(dateEdit1.Text);
                }
                else
                {
                    if (comboBoxEdit1.SelectedText.Equals("员工"))
                    {
                        if (comboBoxEdit2.SelectedText.Equals("支付方式"))
                        {
                            if (searchControl1.Text.Equals(""))
                            {
                                gridControl2.DataSource = Order.SelectOrder();
                            }
                            else
                            {
                                gridControl2.DataSource = Order.SelectOrder2(searchControl1.Text);
                            }
                        }
                        else
                        {
                            gridControl2.DataSource = Order.SelectOrder3(comboBoxEdit2.SelectedText);
                        }
                    }
                    else
                    {
                        gridControl2.DataSource = Order.SelectOrder4(comboBoxEdit1.SelectedText);
                    }
                }
            }
        }

        public void quicksetting(ToggleSwitch toggleSwitch5, ComboBoxEdit comboBoxEdit14, TextEdit textEdit12, ComboBoxEdit comBoxEdit15,TextEdit textEdit13, ComboBoxEdit comboBoxEdit17, TextEdit textEdit15, ComboBoxEdit comboBoxEdit16, TextEdit textEdit14, ComboBoxEdit comboBoxEdit19, TextEdit textEdit17, ComboBoxEdit comboBoxEdit18, TextEdit textEdit16, ComboBoxEdit comboBoxEdit21, TextEdit textEdit19, ComboBoxEdit comboBoxEdit20, TextEdit textEdit18, ComboBoxEdit comboBoxEdit22, TextEdit textEdit20, string UserId)
        {
            q= quick.SelectSetting(UserId);
            if (toggleSwitch5.IsOn)
            {
                q.FastSwitchState = 1;
            }
            else { q.FastSwitchState = 2; }
            comboBoxEdit14.SelectedIndex = q.GraspShortcutKeys1;
            textEdit12.Text = q.GraspShortcutKeys2;
            comBoxEdit15.SelectedIndex = q.ReceivablesShortcutKeys1;
            textEdit13.Text = q.ReceivablesShortcutKeys2;
            comboBoxEdit17.SelectedIndex = q.OrderShortcutKeys1;
            textEdit15.Text = q.OrderShortcutKeys2;
            comboBoxEdit16.SelectedIndex = q.RefundShortcutKeys1;
            textEdit14.Text = q.RefundShortcutKeys2;
            comboBoxEdit19.SelectedIndex = q.PipelinePrinting1;
            textEdit17.Text = q.PipelinePrinting2;
            comboBoxEdit18.SelectedIndex = q.ArouseConcealment1;
            textEdit16.Text = q.ArouseConcealment2;
            comboBoxEdit21.SelectedIndex = q.ClosingProcess1;
            textEdit19.Text = q.ClosingProcess2;
            comboBoxEdit20.SelectedIndex = q.SwitchingAccounts1;
            textEdit18.Text = q.SwitchingAccounts2;
            comboBoxEdit22.SelectedIndex = q.ViewShortcuts1;
            textEdit20.Text = q.ViewShortcuts2;
        }

        public void baudrate(ComboBoxEdit comboBoxEdit4)
        {
            dt= my_sql.listTable("SELECT BaudRate FROM baudrate;");
            Console.WriteLine(11);
            for (int i=0;i< dt.Rows.Count;i++)
            {
                comboBoxEdit4.Properties.Items.Add(dt.Rows[i][0]);
            }
        }

        public void fillprint(ToggleSwitch toggleSwitch6, ToggleSwitch toggleSwitch7, ToggleSwitch toggleSwitch8, SpinEdit spinEdit3, SpinEdit spinEdit4, ComboBoxEdit comboBoxEdit23,string UserId)
        {
            printsetting= print.fill(UserId);
            if (printsetting.PrintSwitch == 1)
            {
                toggleSwitch6.IsOn = true;
            }
            else { toggleSwitch6.IsOn = false; }

            if (printsetting.CompatibilityMode == 1){toggleSwitch7.IsOn = true;}else { toggleSwitch7.IsOn = false; }
            if (printsetting.DetailSwitch == 1) { toggleSwitch8.IsOn = true; } else { toggleSwitch8.IsOn = false; }
            spinEdit3.Text = printsetting.PrintingDelay.ToString();
            spinEdit4.Text = printsetting.PrintingNumber.ToString();
            comboBoxEdit23.Text = printsetting.PrintingDrive;
        }

        public void UPdprint(ToggleSwitch toggleSwitch6, ToggleSwitch toggleSwitch7, ToggleSwitch toggleSwitch8, SpinEdit spinEdit3, SpinEdit spinEdit4, ComboBoxEdit comboBoxEdit23, string UserId)
        {
            if (toggleSwitch6.IsOn==true) { printsetting.PrintSwitch = 1; } else { printsetting.PrintSwitch = 2; }
            if (toggleSwitch7.IsOn == true) { printsetting.CompatibilityMode = 1; } else { printsetting.CompatibilityMode= 2; }
            if (toggleSwitch8.IsOn == true) { printsetting.DetailSwitch= 1; } else { printsetting.DetailSwitch = 2; }
            printsetting.PrintingDelay = int.Parse(spinEdit3.Text);
            printsetting.PrintingNumber = int.Parse(spinEdit4.Text);
            printsetting.PrintingDrive = comboBoxEdit23.Text;
        }

        public void print3(string OrderBH,string print)
        {
            //string OrderBH = gridView2.GetFocusedRowCellValue("OrderBH").ToString();
            //string AmountMoney = gridView2.GetFocusedRowCellValue("AmountMoney").ToString();//PaymentMethod
            //string PaymentMethod = gridView2.GetFocusedRowCellValue("PaymentMethod").ToString();
            //string State = gridView2.GetFocusedRowCellValue("State").ToString();
            //string PaymentTime = gridView2.GetFocusedRowCellValue("PaymentTime").ToString();
            DataTable dt = print4.fill(OrderBH);
            
            row0 = new PrintRow(150, "      "+dt.Rows[0][0].ToString(), new Font("宋体", 14, FontStyle.Bold), Brushes.Blue, 0);
            row1 = new PrintRow(150, "********付款凭证********", new Font("宋体", 10), Brushes.Blue, 40);
            row2 = new PrintRow(150, "门店名称：" + dt.Rows[0][0].ToString(), new Font("宋体", 10), Brushes.Black, 70);
            row3 = new PrintRow(150, "收银员："+ dt.Rows[0][1].ToString(), new Font("宋体", 10), Brushes.Black, 100);
            row4 = new PrintRow(150, "订单编号："+ dt.Rows[0][2].ToString().Substring(0,17), new Font("宋体", 10), Brushes.Black,130);
            row5 = new PrintRow(150, "          "+dt.Rows[0][2].ToString().Substring(17,7), new Font("宋体", 10), Brushes.Black, 150);
            row6 = new PrintRow(150, "支付方式："+dt.Rows[0][3].ToString(), new Font("宋体", 10), Brushes.Black, 170);
            row7 = new PrintRow(150, "支付状态：" + dt.Rows[0][4].ToString(), new Font("宋体", 10), Brushes.Black, 200);
            row8 = new PrintRow(150, "支付终端：" + dt.Rows[0][5].ToString(), new Font("宋体", 10), Brushes.Black, 230);
            row9 = new PrintRow(150, "支付时间：" + dt.Rows[0][6].ToString(), new Font("宋体", 10), Brushes.Black, 260);
            row10 = new PrintRow(150, "订单金额：" + dt.Rows[0][7].ToString(), new Font("宋体", 10), Brushes.Black, 290);
            row11 = new PrintRow(150, "优惠金额：" + dt.Rows[0][8].ToString(), new Font("宋体", 10), Brushes.Black, 320);
            row12 = new PrintRow(150, "顾客实付：", new Font("宋体", 10,FontStyle.Bold), Brushes.Black, 350);
            row13 = new PrintRow(150, "RMB:"+(decimal.Parse(dt.Rows[0][7].ToString()) - decimal.Parse(dt.Rows[0][8].ToString())).ToString(), new Font("宋体", 20, FontStyle.Bold), Brushes.Black, 390);
            row14 = new PrintRow(150, "签    名：___________", new Font("宋体", 10), Brushes.Blue, 420);
            row15 = new PrintRow(150, "备    注：", new Font("宋体", 10), Brushes.Blue, 450);
            row16 = new PrintRow(150, "*********退款码*********", new Font("宋体", 10), Brushes.Blue, 480);
            row17 = new PrintRow(150, Image.FromFile("E:/hrb/1.jpg"), new Font("宋体", 10), Brushes.Blue, 540);
            Order tempOrder = new Order(new List<PrintRow>() { row0, row1, row2, row3, row4,row5,row6,row7,row8,row9,row10,row11,row12,row13,row14,row15,row16});
            PrintOrder.Print(print, tempOrder);
        }

        public void print5(string OrderBH, string print)
        {
            //string OrderBH = gridView2.GetFocusedRowCellValue("OrderBH").ToString();
            //string AmountMoney = gridView2.GetFocusedRowCellValue("AmountMoney").ToString();//PaymentMethod
            //string PaymentMethod = gridView2.GetFocusedRowCellValue("PaymentMethod").ToString();
            //string State = gridView2.GetFocusedRowCellValue("State").ToString();
            //string PaymentTime = gridView2.GetFocusedRowCellValue("PaymentTime").ToString();
            DataTable dt = print4.fill(OrderBH);

            row0 = new PrintRow(150, "      " + dt.Rows[0][0].ToString(), new Font("宋体", 14, FontStyle.Bold), Brushes.Blue, 0);
            row1 = new PrintRow(150, "********付款凭证********", new Font("宋体", 10), Brushes.Blue, 40);
            row2 = new PrintRow(150, "门店名称：" + dt.Rows[0][0].ToString(), new Font("宋体", 10), Brushes.Black, 70);
            row3 = new PrintRow(150, "收银员：" + dt.Rows[0][1].ToString(), new Font("宋体", 10), Brushes.Black, 100);
            row8 = new PrintRow(150, "支付终端：" + dt.Rows[0][5].ToString(), new Font("宋体", 10), Brushes.Black, 130);
            row12 = new PrintRow(150, "顾客实付：", new Font("宋体", 10, FontStyle.Bold), Brushes.Black, 160);
            row13 = new PrintRow(150, "RMB:" + (decimal.Parse(dt.Rows[0][7].ToString()) - decimal.Parse(dt.Rows[0][8].ToString())).ToString(), new Font("宋体", 20, FontStyle.Bold), Brushes.Black, 190);
            row16 = new PrintRow(150, "*********付款码*********", new Font("宋体", 10), Brushes.Blue, 230);
            row17 = new PrintRow(150, Image.FromFile("E:/hrb/1.jpg"), new Font("宋体", 10), Brushes.Blue, 280);
            Order tempOrder = new Order(new List<PrintRow>() { row0, row1, row2, row3, row8, row12, row13,row16, row17 });
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
            if (toggleSwitch9.IsOn == true) { curr.SelfStart = 1; } else { curr.SelfStart = 2; }
            if (toggleSwitch10.IsOn == true) { curr.AutomaticUpgrade = 1; } else { curr.AutomaticUpgrade = 2; }
            if (toggleSwitch11.IsOn == true) { curr.PushNotice = 1; } else { curr.PushNotice = 2; }
            if (toggleSwitch12.IsOn == true) { curr.SuspensionWindow = 1; } else { curr.SuspensionWindow = 2; }
            if (toggleSwitch16.IsOn == true) { curr.ScanningCallUp = 1; } else { curr.ScanningCallUp = 2; }
            curr.SweepTimeout=int.Parse( spinEdit5.Text);
            if (toggleSwitch14.IsOn == true) { curr.VoiceAnnouncements = 1; } else { curr.VoiceAnnouncements = 2; }
            if (toggleSwitch13.IsOn == true) { curr.JiangXiaoHe_VoiceAnnouncements = 1; } else { curr.JiangXiaoHe_VoiceAnnouncements = 2; }
            if (toggleSwitch17.IsOn == true) { curr.JiangXiaoHe = 1; } else { curr.JiangXiaoHe = 2; }
            currency.Update(curr.SelfStart,curr.AutomaticUpgrade,curr.PushNotice,curr.SuspensionWindow,curr.ScanningCallUp,curr.SweepTimeout,curr.VoiceAnnouncements,curr.JiangXiaoHe_VoiceAnnouncements,curr.JiangXiaoHe,UserId);
        }

        public void currencysetting1(ToggleSwitch toggleSwitch9, ToggleSwitch toggleSwitch10, ToggleSwitch toggleSwitch11, ToggleSwitch toggleSwitch12, ToggleSwitch toggleSwitch16, SpinEdit spinEdit5, ToggleSwitch toggleSwitch14, ToggleSwitch toggleSwitch13, ToggleSwitch toggleSwitch17, string UserId)
        {
            curr = currency.Select(UserId);
            if (curr.SelfStart == 1) { toggleSwitch9.IsOn = true; } else { toggleSwitch9.IsOn = false; }
            if (curr.AutomaticUpgrade == 1) { toggleSwitch10.IsOn = true; } else { toggleSwitch10.IsOn = false; }
            if (curr.PushNotice == 1) { toggleSwitch11.IsOn = true; } else { toggleSwitch11.IsOn = false; }
            if (curr.SuspensionWindow == 1) { toggleSwitch12.IsOn = true; } else { toggleSwitch12.IsOn = false; }
            if (curr.ScanningCallUp== 1) { toggleSwitch16.IsOn = true; } else { toggleSwitch16.IsOn = false; }
            spinEdit5.Text = curr.SweepTimeout.ToString();
            if (curr.VoiceAnnouncements== 1) { toggleSwitch14.IsOn = true; } else { toggleSwitch14.IsOn = false; }
            if (curr.JiangXiaoHe_VoiceAnnouncements == 1) { toggleSwitch13.IsOn = true; } else { toggleSwitch13.IsOn = false; }
            if (curr.JiangXiaoHe == 1) { toggleSwitch17.IsOn = true; } else { toggleSwitch17.IsOn = false; }
        }

        public void AccountInformation (ComboBoxEdit comboBoxEdit24, string UserId, LabelControl labelControl109)
        {
            dt= my_sql.listTable("SELECT NameStore FROM namestore;");
            for (int i=0;i<dt.Rows.Count;i++)
            {
                comboBoxEdit24.Properties.Items.Add(dt.Rows[i][0].ToString());
            }
            DataTable dt1 = my_sql.listTable("SELECT UserName FROM `user` WHERE UserID='"+UserId+"';");
            labelControl109.Text = dt1.Rows[0][0].ToString();
            DataTable dt2 = my_sql.listTable("SELECT NameStore FROM namestore WHERE Id=(SELECT NameStore FROM `user` WHERE UserID='"+UserId+"');");
            comboBoxEdit24.Text=dt2.Rows[0][0].ToString();
        }

        public void checkpwd(TextEdit textEdit1, TextEdit textEdit2, TextEdit textEdit3,string UserId)
        {
            if (!textEdit1.Text.Equals(""))
            {
                if (!textEdit2.Text.Equals(""))
                {
                    if (!textEdit3.Text.Equals(""))
                    {
                        if (user.login(UserId, EncryptionMD5.EncryptString(textEdit1.Text)))
                        {
                            if (textEdit2.Text.Equals(textEdit3.Text))
                            {
                                if (user.Upd_Pwd(EncryptionMD5.EncryptString(textEdit1.Text), EncryptionMD5.EncryptString(textEdit2.Text), UserId))
                                {
                                    DevExpress.XtraEditors.XtraMessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    DevExpress.XtraEditors.XtraMessageBox.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }else
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("新密码不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            
                        }else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("原密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("请再次输入新密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("新密码不许为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("原密码不许为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
