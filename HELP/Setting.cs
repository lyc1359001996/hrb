using DevExpress.XtraEditors;
using DXApplication2.BLL;
using DXApplication2.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using thsoft_core;

namespace DXApplication2.HELP
{
    class Setting
    {
        B_currencysetting currencysetting = new B_currencysetting();
        B_graspsettingClass graspsetting = new B_graspsettingClass();
        graspsetting grasp = new graspsetting();

        public void Fillgraspsetting(ToggleSwitch toggleSwitch1, RadioGroup RadioGroup, ComboBoxEdit comboBoxEdit3,
ComboBoxEdit comboBoxEdit4, ComboBoxEdit comboBoxEdit6, ComboBoxEdit comboBoxEdit5, SpinEdit spinEdit1, ToggleSwitch toggleSwitch2, TextEdit textEdit4, TextEdit textEdit5, ToggleSwitch toggleSwitch3, SpinEdit spinEdit2, TextEdit textEdit6,
ComboBoxEdit comboBoxEdit7, TextEdit textEdit7, ComboBoxEdit comboBoxEdit8, TextEdit textEdit8, ComboBoxEdit comboBoxEdit9, TextEdit textEdit9, ComboBoxEdit comboBoxEdit10, TextEdit textEdit10, ComboBoxEdit comboBoxEdit11,
TextEdit textEdit11, ComboBoxEdit comboBoxEdit12, CheckEdit checkEdit1, ComboBoxEdit comboBoxEdit13,string UserId)
        {
            grasp=graspsetting.Select(UserId);
            try
            {
                if (grasp.ExtractionMethodState != 1)
                {
                    toggleSwitch1.IsOn = false;
                }

                if (grasp.GrabMode == 1)
                {
                    RadioGroup.SelectedIndex = 1;
                }
                else if (grasp.GrabMode == 2)
                {
                    RadioGroup.SelectedIndex = 2;
                }
                else if (grasp.GrabMode == 3)
                {
                    RadioGroup.SelectedIndex = 3;
                }
                else if (grasp.GrabMode == 4)
                {
                    RadioGroup.SelectedIndex = 4;
                }

                if (grasp.GrabSerialPort == 1)
                {
                    comboBoxEdit3.SelectedIndex = 1;
                }
                else if (grasp.GrabSerialPort == 2)
                {
                    comboBoxEdit3.SelectedIndex = 2;
                }
                else if (grasp.GrabSerialPort == 3)
                {
                    comboBoxEdit3.SelectedIndex = 3;
                }
                else if (grasp.GrabSerialPort == 4)
                {
                    comboBoxEdit3.SelectedIndex = 4;
                }
                else if (grasp.GrabSerialPort == 5)
                {
                    comboBoxEdit3.SelectedIndex = 5;
                }
                else if (grasp.GrabSerialPort == 6)
                {
                    comboBoxEdit3.SelectedIndex = 6;
                }
                else if (grasp.GrabSerialPort == 7)
                {
                    comboBoxEdit3.SelectedIndex = 7;
                }
                else if (grasp.GrabSerialPort == 8)
                {
                    comboBoxEdit3.SelectedIndex = 8;
                }
                else if (grasp.GrabSerialPort == 9)
                {
                    comboBoxEdit3.SelectedIndex = 9;
                }
                else if (grasp.GrabSerialPort == 10)
                {
                    comboBoxEdit3.SelectedIndex = 10;
                }
                else if (grasp.GrabSerialPort == 11)
                {
                    comboBoxEdit3.SelectedIndex = 11;
                }
                else if (grasp.GrabSerialPort == 12)
                {
                    comboBoxEdit3.SelectedIndex = 12;
                }
                else if (grasp.GrabSerialPort == 13)
                {
                    comboBoxEdit3.SelectedIndex = 13;
                }
                else if (grasp.GrabSerialPort == 14)
                {
                    comboBoxEdit3.SelectedIndex = 14;
                }
                else if (grasp.GrabSerialPort == 15)
                {
                    comboBoxEdit3.SelectedIndex = 15;
                }

                if (grasp.Grabbing_BaudRate == 1)
                {
                    comboBoxEdit4.SelectedIndex = 1;
                }
                else if (grasp.Grabbing_BaudRate == 2)
                {
                    comboBoxEdit4.SelectedIndex = 2;
                }
                else if (grasp.Grabbing_BaudRate == 3)
                {
                    comboBoxEdit4.SelectedIndex = 3;
                }

                if (grasp.GuestShow_BaudRate == 1)
                {
                    comboBoxEdit6.SelectedIndex = 1;
                }
                else if (grasp.GuestShow_BaudRate == 2)
                {
                    comboBoxEdit6.SelectedIndex = 2;
                }
                else if (grasp.GuestShow_BaudRate == 3)
                {
                    comboBoxEdit6.SelectedIndex = 3;
                }
                else if (grasp.GuestShow_BaudRate == 4)
                {
                    comboBoxEdit6.SelectedIndex = 4;
                }
                else if (grasp.GuestShow_BaudRate == 5)
                {
                    comboBoxEdit6.SelectedIndex = 5;
                }
                else if (grasp.GuestShow_BaudRate == 6)
                {
                    comboBoxEdit6.SelectedIndex = 6;
                }
                else if (grasp.GuestShow_BaudRate == 7)
                {
                    comboBoxEdit6.SelectedIndex = 7;
                }
                else if (grasp.GuestShow_BaudRate == 8)
                {
                    comboBoxEdit6.SelectedIndex = 8;
                }
                else if (grasp.GuestShow_BaudRate == 9)
                {
                    comboBoxEdit6.SelectedIndex = 9;
                }
                else if (grasp.GuestShow_BaudRate == 10)
                {
                    comboBoxEdit6.SelectedIndex = 10;
                }
                else if (grasp.GuestShow_BaudRate == 11)
                {
                    comboBoxEdit6.SelectedIndex = 11;
                }
                else if (grasp.GuestShow_BaudRate == 12)
                {
                    comboBoxEdit6.SelectedIndex = 12;
                }
                else if (grasp.GuestShow_BaudRate == 13)
                {
                    comboBoxEdit6.SelectedIndex = 13;
                }
                else if (grasp.GuestShow_BaudRate == 14)
                {
                    comboBoxEdit6.SelectedIndex = 14;
                }
                else if (grasp.GuestShow_BaudRate == 15)
                {
                    comboBoxEdit6.SelectedIndex = 15;
                }

                if (grasp.Grabbing_BaudRate == 1)
                {
                    comboBoxEdit5.SelectedIndex = 1;
                }
                else if (grasp.Grabbing_BaudRate == 2)
                {
                    comboBoxEdit5.SelectedIndex = 2;
                }
                else if (grasp.Grabbing_BaudRate == 3)
                {
                    comboBoxEdit5.SelectedIndex = 3;
                }

                if (grasp.FocusReturnState != 1)
                {
                    toggleSwitch2.IsOn = false;
                }

                if (grasp.SelfCheckoutState != 1)
                {
                    toggleSwitch3.IsOn = false;
                }
                spinEdit1.Text = grasp.PaymentWaitingTime.ToString();
                spinEdit2.Text = grasp.KeyIntervalTime.ToString();
                Console.WriteLine(grasp.PaymentWaitingTime.ToString());
                textEdit4.Text = grasp.Coordinate.Split(',')[0];
                textEdit5.Text = grasp.Coordinate.Split(',')[1];
                textEdit6.Text = grasp.Step1Name;
                comboBoxEdit7.SelectedIndex = grasp.Step1Frequency;
                textEdit7.Text = grasp.Step2Name;
                comboBoxEdit8.SelectedIndex = grasp.Step2Frequency;
                textEdit8.Text = grasp.Step3Name;
                comboBoxEdit9.SelectedIndex = grasp.Step3Frequency;
                textEdit9.Text = grasp.Step4Name;
                comboBoxEdit10.SelectedIndex = grasp.Step4Frequency;
                textEdit10.Text = grasp.Step5Name;
                comboBoxEdit11.SelectedIndex = grasp.Step5Frequency;
                textEdit11.Text = grasp.Step6Name;
                comboBoxEdit12.SelectedIndex = grasp.Step6Frequency;
                comboBoxEdit13.SelectedIndex = grasp.FillAmount;

                if (grasp.FillAmountState == 1)
                {
                    checkEdit1.Checked = true;
                }
            }catch
            {

            }
        }

        public void Updgraspsetting(ToggleSwitch toggleSwitch1, RadioGroup radioGroup1, ComboBoxEdit comboBoxEdit3,
ComboBoxEdit comboBoxEdit4, ComboBoxEdit comboBoxEdit6, ComboBoxEdit comboBoxEdit5, SpinEdit spinEdit1, ToggleSwitch toggleSwitch2, TextEdit textEdit4, TextEdit textEdit5, ToggleSwitch toggleSwitch3, SpinEdit spinEdit2, TextEdit textEdit6,
ComboBoxEdit comboBoxEdit7, TextEdit textEdit7, ComboBoxEdit comboBoxEdit8, TextEdit textEdit8, ComboBoxEdit comboBoxEdit9, TextEdit textEdit9, ComboBoxEdit comboBoxEdit10, TextEdit textEdit10, ComboBoxEdit comboBoxEdit11,
TextEdit textEdit11, ComboBoxEdit comboBoxEdit12, CheckEdit checkEdit1, ComboBoxEdit comboBoxEdit13,string UserId)
        {

            if (toggleSwitch1.IsOn == true)
            {
                grasp.ExtractionMethodState = 1;
            }
            else { grasp.ExtractionMethodState = 2; }

            grasp.GrabMode = radioGroup1.SelectedIndex;
            grasp.GrabSerialPort = comboBoxEdit3.SelectedIndex;
            grasp.Grabbing_BaudRate = comboBoxEdit4.SelectedIndex;
            grasp.GuestShowPort = comboBoxEdit5.SelectedIndex;
            grasp.GuestShow_BaudRate = comboBoxEdit6.SelectedIndex;
            grasp.PaymentWaitingTime =int.Parse(spinEdit1.Text);
            if (toggleSwitch2.IsOn == true)
            {
                grasp.FocusReturnState = 1;
            }else
            {
                grasp.FocusReturnState = 2;
            }

            grasp.Coordinate = textEdit4.Text +","+ textEdit5.Text;
            if (toggleSwitch3.IsOn)
            {
                grasp.SelfCheckoutState = 1;
            }else
            {
                grasp.SelfCheckoutState = 2;
            }

            grasp.KeyIntervalTime = decimal.Parse(spinEdit2.Text);
            grasp.Step1Name = textEdit6.Text;
            grasp.Step1Frequency = comboBoxEdit7.SelectedIndex;
            grasp.Step2Name = textEdit7.Text;
            grasp.Step2Frequency = comboBoxEdit8.SelectedIndex;
            grasp.Step3Name = textEdit8.Text;
            grasp.Step3Frequency = comboBoxEdit9.SelectedIndex;
            grasp.Step4Name = textEdit9.Text;
            grasp.Step4Frequency = comboBoxEdit10.SelectedIndex;
            grasp.Step5Name = textEdit10.Text;
            grasp.Step5Frequency = comboBoxEdit11.SelectedIndex;
            grasp.Step6Name = textEdit11.Text;
            grasp.Step6Frequency = comboBoxEdit12.SelectedIndex;
            if (checkEdit1.Checked==true)
            {
                grasp.FillAmountState = 1;
            }else
            {
                grasp.FillAmountState = 2;
            }
            grasp.FillAmount = comboBoxEdit13.SelectedIndex;
            graspsetting.Update(grasp.ExtractionMethodState,grasp.GrabMode,grasp.GrabSerialPort,grasp.Grabbing_BaudRate,grasp.GuestShowPort,grasp.GuestShow_BaudRate,grasp.PaymentWaitingTime,grasp.FocusReturnState,grasp.Coordinate,grasp.SelfCheckoutState,int.Parse(grasp.KeyIntervalTime.ToString()),grasp.Step1Name,grasp.Step1Frequency,grasp.Step2Name,grasp.Step2Frequency,grasp.Step3Name,grasp.Step3Frequency,grasp.Step4Name,grasp.Step4Frequency,grasp.Step5Name,grasp.Step5Frequency,grasp.Step6Name,grasp.Step6Frequency,grasp.FillAmount,grasp.FillAmountState,UserId);
            //graspsetting.Update( ExtractionMethodState,  GrabMode,  GrabSerialPort,  Grabbing_BaudRate,  GuestShowPort,  GuestShow_BaudRate,  PaymentWaitingTime,  FocusReturnState,  Coordinate,  SelfCheckoutState,  KeyervalTime,  Step1Name,  Step1Frequency,  Step2Name,  Step2Frequency,  Step3Name,  Step3Frequency,  Step4Name,  Step4Frequency,  Step5Name,  Step5Frequency,  Step6Name,  Step6Frequency,  FillAmount,  FillAmountState,  UserId);
        }

        public void Updgraspsetting1(ToggleSwitch toggleSwitch1, RadioGroup radioGroup1, ToggleSwitch toggleSwitch4, SpinEdit spinEdit1, ToggleSwitch toggleSwitch2, TextEdit textEdit4, TextEdit textEdit5, ToggleSwitch toggleSwitch3, SpinEdit spinEdit2, TextEdit textEdit6,
ComboBoxEdit comboBoxEdit7, TextEdit textEdit7, ComboBoxEdit comboBoxEdit8, TextEdit textEdit8, ComboBoxEdit comboBoxEdit9, TextEdit textEdit9, ComboBoxEdit comboBoxEdit10, TextEdit textEdit10, ComboBoxEdit comboBoxEdit11,
TextEdit textEdit11, ComboBoxEdit comboBoxEdit12, CheckEdit checkEdit1, ComboBoxEdit comboBoxEdit13, string UserId)
        {
            if (toggleSwitch1.IsOn == true)
            {
                grasp.ExtractionMethodState = 1;
            }

            grasp.GrabMode = radioGroup1.SelectedIndex;
            grasp.PaymentWaitingTime = int.Parse(spinEdit1.Text);
            if (toggleSwitch2.IsOn == true)
            {
                grasp.FocusReturnState = 1;
            }
            else
            {
                grasp.FocusReturnState = 2;
            }

            grasp.Coordinate = textEdit4.Text + ","+textEdit5.Text;
            if (toggleSwitch3.IsOn)
            {
                grasp.SelfCheckoutState = 1;
            }
            else
            {
                grasp.SelfCheckoutState = 2;
            }

            grasp.KeyIntervalTime = int.Parse(spinEdit2.Text);
            grasp.Step1Name = textEdit6.Text;
            grasp.Step1Frequency = comboBoxEdit7.SelectedIndex;
            grasp.Step2Name = textEdit7.Text;
            grasp.Step2Frequency = comboBoxEdit8.SelectedIndex;
            grasp.Step3Name = textEdit8.Text;
            grasp.Step3Frequency = comboBoxEdit9.SelectedIndex;
            grasp.Step4Name = textEdit9.Text;
            grasp.Step4Frequency = comboBoxEdit10.SelectedIndex;
            grasp.Step5Name = textEdit10.Text;
            grasp.Step5Frequency = comboBoxEdit11.SelectedIndex;
            grasp.Step6Name = textEdit11.Text;
            grasp.Step6Frequency = comboBoxEdit12.SelectedIndex;
            if (checkEdit1.Checked == true)
            {
                grasp.FillAmountState = 1;
            }
            else
            {
                grasp.FillAmountState = 2;
            }
            grasp.FillAmount = comboBoxEdit13.SelectedIndex;

            graspsetting.Update(grasp.ExtractionMethodState, grasp.GrabMode, grasp.GrabSerialPort, grasp.Grabbing_BaudRate, grasp.GuestShowPort, grasp.GuestShow_BaudRate, grasp.PaymentWaitingTime, grasp.FocusReturnState, grasp.Coordinate, grasp.SelfCheckoutState, int.Parse(grasp.KeyIntervalTime.ToString()), grasp.Step1Name, grasp.Step1Frequency, grasp.Step2Name, grasp.Step2Frequency, grasp.Step3Name, grasp.Step3Frequency, grasp.Step4Name, grasp.Step4Frequency, grasp.Step5Name, grasp.Step5Frequency, grasp.Step6Name, grasp.Step6Frequency, grasp.FillAmount, grasp.FillAmountState, UserId);
        }
    }
}
