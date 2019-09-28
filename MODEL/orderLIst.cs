using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXApplication2.MODEL
{
    class orderLIst
    {
        public int curPage { set; get; }
        public int total { set; get; }
        public int pageCount { set; get; }
        public int beginPos { set; get; }
        public int id { set; get; }
        public string orderNumber { set; get; }
        public decimal orderAmount { set; get; }
        public decimal discountAmount { set; get; }
        public decimal realPayAmount { set; get; }
        public int status { set; get; }
        public string storeName { set; get; }
        public string userName { set; get; }
        public int type { set; get; }
        public int channel { set; get; }
        public DateTime createTime { set; get; }
        public string payTime { set; get; }
        public decimal refundAmount { set; get; }
        public DateTime refundTime { set; get; }
    }
}
