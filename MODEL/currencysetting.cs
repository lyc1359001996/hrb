using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication2.MODEL
{
    class currencysetting
    {
        public int Id { set; get; }
        public int SelfStart { set; get; }
        public int AutomaticUpgrade { set; get; }
        public int PushNotice { set; get; }
        public int SuspensionWindow { set; get; }
        public int ScanningCallUp { set; get; }
        public decimal SweepTimeout { set; get; }
        public int VoiceAnnouncements { set; get; }
        public int JiangXiaoHe_VoiceAnnouncements { set; get; }
        public int JiangXiaoHe { set; get; }
    }
}
