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
    class D_currencysetting
    {
        DataTable dt = new DataTable();
        currencysetting currencysetting = new currencysetting();
        public int InsertSetting(int SelfStart,int AutomaticUpgrade,int PushNotice,int SuspensionWindow,int ScanningCallUp,decimal SweepTimeout, int VoiceAnnouncements,int JiangXiaoHe_VoiceAnnouncements,int JiangXiaoHe,string UserId)
        {
           return my_sql.updateSql("INSERT INTO `currencysetting` (`SelfStart`, `AutomaticUpgrade`, `PushNotice`, `SuspensionWindow`, `ScanningCallUp`, `SweepTimeout`, `VoiceAnnouncements`, `JiangXiaoHe_VoiceAnnouncements`, `JiangXiaoHe`,`UserId`) VALUES ('"+SelfStart+"', '"+AutomaticUpgrade+"', '"+PushNotice+"', '"+SuspensionWindow+"', '"+ScanningCallUp+"', '"+SweepTimeout+"', '"+VoiceAnnouncements+"', '"+JiangXiaoHe_VoiceAnnouncements+"', '"+JiangXiaoHe+"','"+UserId+"')");
        }

        public currencysetting SelectSetting(string UserId)
        {
            dt= my_sql.listVar("SELECT SelfStart,AutomaticUpgrade,PushNotice,SuspensionWindow,ScanningCallUp,SweepTimeout,VoiceAnnouncements,JiangXiaoHe_VoiceAnnouncements,JiangXiaoHe FROM currencysetting Where UserId='"+UserId+"';").Tables[0];
            currencysetting.SelfStart = int.Parse(dt.Rows[0][0].ToString());
            currencysetting.AutomaticUpgrade = int.Parse(dt.Rows[0][1].ToString());
            currencysetting.PushNotice= int.Parse(dt.Rows[0][2].ToString());
            currencysetting.SuspensionWindow= int.Parse(dt.Rows[0][3].ToString());
            currencysetting.ScanningCallUp= int.Parse(dt.Rows[0][4].ToString());
            currencysetting.SweepTimeout = decimal.Parse(dt.Rows[0][5].ToString());
            currencysetting.VoiceAnnouncements= int.Parse(dt.Rows[0][6].ToString());
            currencysetting.JiangXiaoHe_VoiceAnnouncements= int.Parse(dt.Rows[0][7].ToString());
            currencysetting.JiangXiaoHe = int.Parse(dt.Rows[0][8].ToString());
            return currencysetting;
        }

        public int UpdSetting(int SelfStart, int AutomaticUpgrade, int PushNotice, int SuspensionWindow, int ScanningCallUp, decimal SweepTimeout, int VoiceAnnouncements, int JiangXiaoHe_VoiceAnnouncements, int JiangXiaoHe,string UserId)
        {
           return my_sql.updateSql("UPDATE `currencysetting` SET `SelfStart`='"+SelfStart+"', `AutomaticUpgrade`='"+AutomaticUpgrade+"', `PushNotice`='"+PushNotice+"', `SuspensionWindow`='"+SuspensionWindow+"', `ScanningCallUp`='"+ScanningCallUp+"', `SweepTimeout`='"+SweepTimeout+"', `VoiceAnnouncements`='"+VoiceAnnouncements+"', `JiangXiaoHe_VoiceAnnouncements`='"+JiangXiaoHe_VoiceAnnouncements+"', `JiangXiaoHe`='"+JiangXiaoHe+"' WHERE (`UserId`='"+UserId+"');");
        }
    }
}
