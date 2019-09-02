using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication2.MODEL
{
    class printsetting
    {
        public int Id { set; get; }
        public int PrintSwitch { set; get; }
        public int CompatibilityMode { set; get; }
        public int DetailSwitch {set;get;}
        public int PrintingDelay { set; get; }
        public int PrintingNumber { set; get; }
        public string PrintingDrive { set; get; }
    }
}
