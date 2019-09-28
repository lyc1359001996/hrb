using DXApplication2.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thsoft_core;

namespace DXApplication2.DAL
{
    class D_graspsettingClass
    {
        DataTable dt = new DataTable();
        graspsetting graspsetting = new graspsetting();
        public int InsertSetting(int ExtractionMethodState,int GrabMode,int GrabSerialPort,int Grabbing_BaudRate,int GuestShowPort,int GuestShow_BaudRate,int PaymentWaitingTime,int FocusReturnState,int Coordinate,int SelfCheckoutState,int KeyIntervalTime,string Step1Name,int Step1Frequency,string Step2Name,int Step2Frequency,string Step3Name,int Step3Frequency, string Step4Name, int Step4Frequency, string Step5Name, int Step5Frequency, string Step6Name, int Step6Frequency,int FillAmount,int FillAmountState,string UserId)
        {
           return my_sql.updateSql("INSERT INTO `graspsetting` (`ExtractionMethodState`, `GrabMode`, `GrabSerialPort`, `Grabbing_BaudRate`, `GuestShowPort`, `GuestShow_BaudRate`, `PaymentWaitingTime`, `FocusReturnState`, `Coordinate`, `SelfCheckoutState`, `KeyIntervalTime`, `Step1Name`, `Step1Frequency`, `Step2Name`, `Step2Frequency`, `Step3Name`, `Step3Frequency`, `Step4Name`, `Step4Frequency`, `Step5Name`, `Step5Frequency`, `Step6Name`, `Step6Frequency`, `FillAmount`, `FillAmountState`, `UserId`) VALUES ('"+ExtractionMethodState+"', '"+ GrabMode + "', '"+ GrabSerialPort + "', '"+ Grabbing_BaudRate + "', '"+ GuestShowPort + "', '"+ GuestShow_BaudRate + "', '"+ PaymentWaitingTime + "', '"+ FocusReturnState + "', '"+ Coordinate + "', '"+ SelfCheckoutState + "', '"+ KeyIntervalTime + "', '"+ KeyIntervalTime + "', '"+ Step1Name + "', '"+ Step1Frequency + "', '"+ Step2Name + "', '"+ Step2Frequency + "', '"+ Step2Frequency + "', '"+ Step3Name + "', '"+ Step3Frequency + "', '"+ Step4Name + "', '"+ Step4Name + "', '"+ Step4Frequency + "', '"+ Step5Name + "', '"+ Step5Frequency + "', '"+Step6Name+ "', '"+Step6Frequency+ "', '"+FillAmount+ "', '"+FillAmountState+"', '"+UserId+"')");
        }
        
        public int UpdSetting(int ExtractionMethodState, int GrabMode, int GrabSerialPort, int Grabbing_BaudRate, int GuestShowPort, int GuestShow_BaudRate, int PaymentWaitingTime, int FocusReturnState, string Coordinate, int SelfCheckoutState, int KeyIntervalTime, string Step1Name, int Step1Frequency, string Step2Name, int Step2Frequency, string Step3Name, int Step3Frequency, string Step4Name, int Step4Frequency, string Step5Name, int Step5Frequency, string Step6Name, int Step6Frequency, int FillAmount, int FillAmountState, string UserId)
        {
            return my_sql.updateSql("UPDATE `graspsetting` SET `ExtractionMethodState`='"+ExtractionMethodState+"', `GrabMode`='"+GrabMode+"', `GrabSerialPort`='"+GrabSerialPort+"', `Grabbing_BaudRate`='"+Grabbing_BaudRate+"', `GuestShowPort`='"+GuestShowPort+"', `GuestShow_BaudRate`='"+GuestShow_BaudRate+"', `PaymentWaitingTime`='"+PaymentWaitingTime+"', `FocusReturnState`='"+FocusReturnState+"', `Coordinate`='"+Coordinate+"', `SelfCheckoutState`='"+SelfCheckoutState+"', `KeyIntervalTime`='"+KeyIntervalTime+"', `Step1Name`='"+Step1Name+"', `Step1Frequency`='"+Step1Frequency+"', `Step2Name`='"+Step2Name+"', `Step2Frequency`='"+Step2Frequency+"', `Step3Name`='"+Step3Name+"', `Step3Frequency`='"+Step3Frequency+"', `Step4Name`='"+Step4Name+"', `Step4Frequency`='"+Step4Frequency+"', `Step5Name`='"+Step5Name+"', `Step5Frequency`='"+Step5Frequency+"', `Step6Name`='"+Step6Name+"', `Step6Frequency`='"+Step6Frequency+"', `FillAmount`='"+FillAmount+"', `FillAmountState`='"+FillAmountState+ "'  WHERE (`UserId`='"+UserId+"')");
        }

        public graspsetting SelectSetting(string UserId)
        {
                dt = my_sql.listTable("SELECT ExtractionMethodState,GrabMode,GrabSerialPort,Grabbing_BaudRate,GuestShowPort,GuestShow_BaudRate,PaymentWaitingTime,FocusReturnState,Coordinate,SelfCheckoutState,KeyIntervalTime,Step1Name,Step1Frequency,Step2Name,Step2Frequency,Step3Name,Step3Frequency,Step4Name,Step4Frequency,Step5Name,Step5Frequency,Step6Name,Step6Frequency FROM graspsetting Where UserId='"+UserId+"';");
            try
            {
                graspsetting.ExtractionMethodState = int.Parse(dt.Rows[0][0].ToString());
                graspsetting.GrabMode = int.Parse(dt.Rows[0][1].ToString());
                graspsetting.GrabSerialPort = int.Parse(dt.Rows[0][2].ToString());
                graspsetting.Grabbing_BaudRate = int.Parse(dt.Rows[0][3].ToString());
                graspsetting.GuestShowPort = int.Parse(dt.Rows[0][4].ToString());
                graspsetting.GuestShow_BaudRate = int.Parse(dt.Rows[0][5].ToString());
                graspsetting.PaymentWaitingTime = int.Parse(dt.Rows[0][6].ToString());
                graspsetting.FocusReturnState = int.Parse(dt.Rows[0][7].ToString());
                graspsetting.Coordinate = dt.Rows[0][8].ToString();
                graspsetting.SelfCheckoutState = int.Parse(dt.Rows[0][9].ToString());
                graspsetting.KeyIntervalTime = decimal.Parse(dt.Rows[0][10].ToString());
                graspsetting.Step1Name = dt.Rows[0][11].ToString();
                graspsetting.Step1Frequency = int.Parse(dt.Rows[0][12].ToString());
                graspsetting.Step2Name = dt.Rows[0][13].ToString();
                graspsetting.Step3Frequency = int.Parse(dt.Rows[0][14].ToString());
                graspsetting.Step4Name = dt.Rows[0][15].ToString();
                graspsetting.Step4Frequency = int.Parse(dt.Rows[0][16].ToString());
                graspsetting.Step5Name = dt.Rows[0][17].ToString();
                graspsetting.Step5Frequency = int.Parse(dt.Rows[0][18].ToString());
                graspsetting.Step6Name = dt.Rows[0][19].ToString();
                graspsetting.Step6Frequency = int.Parse(dt.Rows[0][20].ToString());
                graspsetting.FillAmount = int.Parse(dt.Rows[0][21].ToString());
                graspsetting.FillAmountState = int.Parse(dt.Rows[0][22].ToString());
            }
            catch { }
            return graspsetting;
        }
    }
}
