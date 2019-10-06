using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using thsoft_core;

namespace DXApplication2.HELP
{
    class Setting
    {
        IniFile ini = new IniFile(@"config\set.ini");

        public void Fillgraspsetting(ToggleSwitch toggleSwitch1, RadioGroup RadioGroup, ComboBoxEdit comboBoxEdit3,
ComboBoxEdit comboBoxEdit4, ComboBoxEdit comboBoxEdit6, ComboBoxEdit comboBoxEdit5, SpinEdit spinEdit1, ToggleSwitch toggleSwitch2, TextEdit textEdit4, TextEdit textEdit5, ToggleSwitch toggleSwitch3, SpinEdit spinEdit2, TextEdit textEdit6,
ComboBoxEdit comboBoxEdit7, TextEdit textEdit7, ComboBoxEdit comboBoxEdit8, TextEdit textEdit8, ComboBoxEdit comboBoxEdit9, TextEdit textEdit9, ComboBoxEdit comboBoxEdit10, TextEdit textEdit10, ComboBoxEdit comboBoxEdit11,
TextEdit textEdit11, ComboBoxEdit comboBoxEdit12, CheckEdit checkEdit1, ComboBoxEdit comboBoxEdit13,string UserId)
        {
            try
            {
                toggleSwitch1.IsOn = bool.Parse(ini.IniReadValue("graspsetting", "ExtractionMethodState"));
                RadioGroup.SelectedIndex = int.Parse(ini.IniReadValue("graspsetting", "GrabMode"))+1;
                comboBoxEdit3.SelectedIndex = int.Parse(ini.IniReadValue("graspsetting", "GrabSerialPort"));
                comboBoxEdit4.SelectedIndex = int.Parse(ini.IniReadValue("graspsetting", "Grabbing_BaudRate"));
                comboBoxEdit6.SelectedIndex = int.Parse(ini.IniReadValue("graspsetting", "GuestShowPort"));
                comboBoxEdit5.SelectedIndex = int.Parse(ini.IniReadValue("graspsetting", "Grabbing_BaudRate"));
                toggleSwitch2.IsOn = bool.Parse(ini.IniReadValue("graspsetting", "FocusReturnState"));
                toggleSwitch3.IsOn = bool.Parse(ini.IniReadValue("graspsetting", "SelfCheckoutState"));
                spinEdit1.Text = ini.IniReadValue("graspsetting", "PaymentWaitingTime");
                spinEdit2.Text = ini.IniReadValue("graspsetting", "KeyIntervalTime");
                textEdit4.Text = ini.IniReadValue("graspsetting", "Coordinate").Split(',')[0];
                textEdit5.Text = ini.IniReadValue("graspsetting", "Coordinate").Split(',')[1];
                textEdit6.Text = ini.IniReadValue("graspsetting", "Step1Name");
                comboBoxEdit7.SelectedIndex = int.Parse(ini.IniReadValue("graspsetting", "Step1Frequency"));
                textEdit7.Text = ini.IniReadValue("graspsetting", "Step2Name");
                comboBoxEdit8.SelectedIndex = int.Parse(ini.IniReadValue("graspsetting", "Step2Frequency"));
                textEdit8.Text = ini.IniReadValue("graspsetting", "Step3Name");
                comboBoxEdit9.SelectedIndex = int.Parse(ini.IniReadValue("graspsetting", "Step3Frequency"));
                textEdit9.Text = ini.IniReadValue("graspsetting", "Step4Name");
                comboBoxEdit10.SelectedIndex = int.Parse(ini.IniReadValue("graspsetting", "Step4Frequency"));
                textEdit10.Text = ini.IniReadValue("graspsetting", "Step5Name");
                comboBoxEdit11.SelectedIndex = int.Parse(ini.IniReadValue("graspsetting", "Step5Frequency"));
                textEdit11.Text = ini.IniReadValue("graspsetting", "Step6Name");
                comboBoxEdit12.SelectedIndex = int.Parse(ini.IniReadValue("graspsetting", "Step6Frequency"));
                comboBoxEdit13.SelectedIndex = int.Parse(ini.IniReadValue("graspsetting", "FillAmount"));
                checkEdit1.Checked = bool.Parse(ini.IniReadValue("graspsetting", "FillAmountState"));
            }catch (Exception e1)
            {
                Log4NetHelper.WriteErrorLog(e1.Message);
            }
        }

        public void Updgraspsetting1(ToggleSwitch toggleSwitch1, RadioGroup radioGroup1, ToggleSwitch toggleSwitch4, SpinEdit spinEdit1, ToggleSwitch toggleSwitch2, TextEdit textEdit4, TextEdit textEdit5, ToggleSwitch toggleSwitch3, SpinEdit spinEdit2, TextEdit textEdit6,
ComboBoxEdit comboBoxEdit7, TextEdit textEdit7, ComboBoxEdit comboBoxEdit8, TextEdit textEdit8, ComboBoxEdit comboBoxEdit9, TextEdit textEdit9, ComboBoxEdit comboBoxEdit10, TextEdit textEdit10, ComboBoxEdit comboBoxEdit11,
TextEdit textEdit11, ComboBoxEdit comboBoxEdit12, CheckEdit checkEdit1, ComboBoxEdit comboBoxEdit13, ComboBoxEdit comboBoxEdit3, ComboBoxEdit comboBoxEdit4,ComboBoxEdit comboBoxEdit5, ComboBoxEdit comboBoxEdit6)
        {
            ini.IniWriteValue("graspsetting", "ExtractionMethodState", toggleSwitch1.IsOn.ToString());
            ini.IniWriteValue("graspsetting", "GrabMode", (radioGroup1.SelectedIndex-1).ToString());
            ini.IniWriteValue("graspsetting", "GrabSerialPort", comboBoxEdit3.SelectedIndex.ToString());
            ini.IniWriteValue("graspsetting", "Grabbing_BaudRate", comboBoxEdit4.SelectedIndex.ToString());
            ini.IniWriteValue("graspsetting", "GuestShowPort", comboBoxEdit6.SelectedIndex.ToString());
            ini.IniWriteValue("graspsetting", "GuestShow_BaudRate", comboBoxEdit5.SelectedIndex.ToString());
            ini.IniWriteValue("graspsetting", "PaymentWaitingTime", spinEdit1.Text);
            ini.IniWriteValue("graspsetting", "FocusReturnState", toggleSwitch2.IsOn.ToString());
            ini.IniWriteValue("graspsetting", "Coordinate", textEdit4.Text + "," + textEdit5.Text);
            ini.IniWriteValue("graspsetting", "SelfCheckoutState", toggleSwitch3.IsOn.ToString());
            ini.IniWriteValue("graspsetting", "KeyIntervalTime", spinEdit2.Text);
            ini.IniWriteValue("graspsetting", "Step1Name", textEdit6.Text);
            ini.IniWriteValue("graspsetting", "Step1Frequency", comboBoxEdit7.SelectedIndex.ToString());
            ini.IniWriteValue("graspsetting", "Step2Name", textEdit7.Text);
            ini.IniWriteValue("graspsetting", "Step2Frequency", comboBoxEdit8.SelectedIndex.ToString());
            ini.IniWriteValue("graspsetting", "Step3Name", textEdit8.Text);
            ini.IniWriteValue("graspsetting", "Step3Frequency", comboBoxEdit9.SelectedIndex.ToString());
            ini.IniWriteValue("graspsetting", "Step4Name", textEdit9.Text);
            ini.IniWriteValue("graspsetting", "Step4Frequency", comboBoxEdit10.SelectedIndex.ToString());
            ini.IniWriteValue("graspsetting", "Step5Name", textEdit10.Text);
            ini.IniWriteValue("graspsetting", "Step5Frequency", comboBoxEdit11.SelectedIndex.ToString());
            ini.IniWriteValue("graspsetting", "Step6Name", textEdit11.Text);
            ini.IniWriteValue("graspsetting", "Step6Frequency", comboBoxEdit12.SelectedIndex.ToString());
            ini.IniWriteValue("graspsetting", "FillAmountState", checkEdit1.Checked.ToString());
            ini.IniWriteValue("graspsetting", "FillAmount", comboBoxEdit13.SelectedIndex.ToString());
        }
    }
}
