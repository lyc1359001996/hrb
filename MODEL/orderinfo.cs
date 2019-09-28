using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXApplication2.MODEL
{
    class orderinfo
    {
        public decimal orderAmount = 0.0m;
        public decimal discountAmount = 0.0m;
        public decimal realPayAmount = 0.0m;
        public int status = 0;
        public string storeName = "";
        public string userName = "";
        public string orderNumber = "";
        public int type = 0;
        public int terminal = 0;
        public int channel = 0;
        //public DateTime payTime;
        //public DateTime createTime;
        public decimal refundAmount = 0.0m;
        public string note = "";
    }
}
