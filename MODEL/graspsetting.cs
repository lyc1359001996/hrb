using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication2.MODEL
{
    class graspsetting
    {
        public int id { set; get; }
        public int ExtractionMethodState { set; get; }
        public int GrabMode { set; get; }
        public int GrabSerialPort { set; get; }
        public int Grabbing_BaudRate { set; get; }
        public int GuestShowPort { set; get; }
        public int GuestShow_BaudRate { set; get; }
        public int PaymentWaitingTime { set; get; }
        public int FocusReturnState { set; get; }
        public string Coordinate { set; get; }
        public int SelfCheckoutState { set; get; }
        public decimal KeyIntervalTime { set; get; }
        public string Step1Name { set; get; }
        public int Step1Frequency { set; get; }
        public string Step2Name { set; get; }
        public int Step2Frequency { set; get; }
        public string Step3Name { set; get; }
        public int Step3Frequency { set; get; }
        public string Step4Name { set; get; }
        public int Step4Frequency { set; get; }
        public string Step5Name { set; get; }
        public int Step5Frequency { set; get; }
        public string Step6Name { set; get; }
        public int Step6Frequency { set; get; }
        public int FillAmount { set; get; }
        public int FillAmountState { set; get; }
    }
}
