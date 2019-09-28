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
    class D_printsetting
    {
        DataTable dt = new DataTable();
        printsetting printsetting = new printsetting();
        public printsetting SelectSetting(string UserId)
        {
            dt= my_sql.listTable("SELECT PrintSwitch,CompatibilityMode,DetailSwitch,PrintingDelay,PrintingNumber,PrintingDrive FROM printsetting Where UserId='"+UserId+"';");
            printsetting.PrintSwitch= int.Parse(dt.Rows[0][0].ToString());
            printsetting.CompatibilityMode = int.Parse(dt.Rows[0][1].ToString());
            printsetting .DetailSwitch= int.Parse(dt.Rows[0][2].ToString());
            printsetting.PrintingDelay= int.Parse(dt.Rows[0][3].ToString());
            printsetting.PrintingNumber=int.Parse(dt.Rows[0][4].ToString());
            printsetting.PrintingDrive= dt.Rows[0][5].ToString();
            return printsetting;
        }

        public int UpdSetting(int PrintSwitch,int CompatibilityMode,int DetailSwitch,int PrintingDelay,int PrintingNumber,string PrintingDrive,string UserId)
        {
           return my_sql.updateSql("UPDATE `printsetting` SET `PrintSwitch`='"+PrintSwitch+"', `CompatibilityMode`='"+CompatibilityMode+"', `DetailSwitch`='"+DetailSwitch+"', `PrintingDelay`='"+PrintingDelay+"', `PrintingNumber`='"+PrintingNumber+"', `PrintingDrive`='"+PrintingDrive+"' WHERE (`UserId`='"+UserId+"') ");
        }

        public int InsertSetting(int PrintSwitch, int CompatibilityMode, int DetailSwitch, int PrintingDelay, int PrintingNumber, string PrintingDrive,string UserId)
        {
            return my_sql.updateSql("INSERT INTO `printsetting` (`PrintSwitch`, `CompatibilityMode`, `DetailSwitch`, `PrintingDelay`, `PrintingNumber`, `PrintingDrive`, `UserId`) VALUES ('"+PrintSwitch+"', '"+CompatibilityMode+"', '"+DetailSwitch+"', '"+PrintingDelay+"', '"+PrintingNumber+"', '"+PrintingDrive+"', '"+UserId+"')");
        }
    }
}
