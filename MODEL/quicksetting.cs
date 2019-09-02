using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication2.MODEL
{
    class quicksetting
    {
        public int Id { set; get; }
        public int FastSwitchState { set; get; }
        public int GraspShortcutKeys1 { set; get; }
        public string GraspShortcutKeys2 { set; get; }
        public int ReceivablesShortcutKeys1 { set; get; }
        public string ReceivablesShortcutKeys2 { set; get; }
        public int OrderShortcutKeys1 { set; get; }
        public string OrderShortcutKeys2 { set; get; }
        public int RefundShortcutKeys1 { set; get; }
        public string RefundShortcutKeys2 { set; get; }
        public int PipelinePrinting1 { set; get; }
        public string PipelinePrinting2 { set; get; }
        public int ViewShortcuts1 { set; get; }
        public string ViewShortcuts2 { set; get; }
        public int ArouseConcealment1 { set; get; }
        public string ArouseConcealment2 { set; get; }
        public int ClosingProcess1 { set; get; }
        public string ClosingProcess2 { set; get; }
        public int SwitchingAccounts1 { set; get; }
        public string SwitchingAccounts2 { set; get; }
    }
}
