using DXApplication2.DAL;
using DXApplication2.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication2.BLL
{
    class B_currencysetting
    {
        private D_currencysetting currencysetting = new D_currencysetting();

        public int Insert(int SelfStart, int AutomaticUpgrade, int PushNotice, int SuspensionWindow, int ScanningCallUp, decimal SweepTimeout, int VoiceAnnouncements, int JiangXiaoHe_VoiceAnnouncements, int JiangXiaoHe, string UserId)
        {
           return currencysetting.InsertSetting(SelfStart,AutomaticUpgrade,PushNotice,SuspensionWindow,ScanningCallUp,SweepTimeout,VoiceAnnouncements,JiangXiaoHe_VoiceAnnouncements,JiangXiaoHe,UserId);
        }

        public int Update(int SelfStart, int AutomaticUpgrade, int PushNotice, int SuspensionWindow, int ScanningCallUp, decimal SweepTimeout, int VoiceAnnouncements, int JiangXiaoHe_VoiceAnnouncements, int JiangXiaoHe, string UserId)
        {
            return currencysetting.UpdSetting(SelfStart,AutomaticUpgrade,PushNotice,SuspensionWindow,ScanningCallUp,SweepTimeout,VoiceAnnouncements,JiangXiaoHe_VoiceAnnouncements,JiangXiaoHe,UserId);
        }

        public currencysetting Select(string UserId)
        {
            return currencysetting.SelectSetting(UserId);
        }
    }
}
