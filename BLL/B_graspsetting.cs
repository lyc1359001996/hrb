using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DXApplication2.DAL;
using DXApplication2.MODEL;

namespace DXApplication2.BLL
{
    class B_graspsettingClass
    {
        D_graspsettingClass graspsetting = new D_graspsettingClass();

        public graspsetting Select(string UserId)
        {
            return graspsetting.SelectSetting(UserId);
        }

        public int Insert(int ExtractionMethodState, int GrabMode, int GrabSerialPort, int Grabbing_BaudRate, int GuestShowPort, int GuestShow_BaudRate, int PaymentWaitingTime, int FocusReturnState, int Coordinate, int SelfCheckoutState, int KeyIntervalTime, string Step1Name, int Step1Frequency, string Step2Name, int Step2Frequency, string Step3Name, int Step3Frequency, string Step4Name, int Step4Frequency, string Step5Name, int Step5Frequency, string Step6Name, int Step6Frequency, int FillAmount, int FillAmountState, string UserId)
        {
            return graspsetting.InsertSetting(ExtractionMethodState,GrabMode,GrabSerialPort,Grabbing_BaudRate,GuestShowPort,GuestShow_BaudRate,PaymentWaitingTime,FocusReturnState,Coordinate,SelfCheckoutState,KeyIntervalTime,Step1Name,Step1Frequency,Step2Name,Step2Frequency,Step3Name,Step3Frequency,Step4Name,Step4Frequency,Step5Name,Step5Frequency,Step6Name,Step6Frequency,FillAmount,FillAmountState,UserId);
        }

        public int Update(int ExtractionMethodState, int GrabMode, int GrabSerialPort, int Grabbing_BaudRate, int GuestShowPort, int GuestShow_BaudRate, int PaymentWaitingTime, int FocusReturnState, string Coordinate, int SelfCheckoutState, int KeyIntervalTime, string Step1Name, int Step1Frequency, string Step2Name, int Step2Frequency, string Step3Name, int Step3Frequency, string Step4Name, int Step4Frequency, string Step5Name, int Step5Frequency, string Step6Name, int Step6Frequency, int FillAmount, int FillAmountState, string UserId)
        {
            return graspsetting.UpdSetting(ExtractionMethodState, GrabMode, GrabSerialPort, Grabbing_BaudRate, GuestShowPort, GuestShow_BaudRate, PaymentWaitingTime, FocusReturnState, Coordinate, SelfCheckoutState, KeyIntervalTime, Step1Name, Step1Frequency, Step2Name, Step2Frequency, Step3Name, Step3Frequency, Step4Name, Step4Frequency, Step5Name, Step5Frequency, Step6Name, Step6Frequency, FillAmount, FillAmountState, UserId);
        }
    }
}
