using DXApplication2.DAL;
using DXApplication2.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication2.BLL
{
    class B_PrintSetting
    {
        D_printsetting print = new D_printsetting();

        public printsetting fill(string UserId)
        {
            return print.SelectSetting(UserId);
        }

        public int Updsetting(int PrintSwitch, int CompatibilityMode, int DetailSwitch, int PrintingDelay, int PrintingNumber, string PrintingDrive, string UserId)
        {
            return print.UpdSetting(PrintSwitch,CompatibilityMode,DetailSwitch,PrintingDelay,PrintingNumber,PrintingDrive,UserId);
        }
    }
}
