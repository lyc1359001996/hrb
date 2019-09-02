using DevExpress.XtraEditors;
using DXApplication2.DAL;
using DXApplication2.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thsoft_core;

namespace DXApplication2.BLL
{
    class B_quicksetting
    {
        D_quicksettingClass quicksetting = new D_quicksettingClass();

        public int InsertSetting(int FastSwitchState, int GraspShortcutKeys1, int GraspShortcutKeys2, int ReceivablesShortcutKeys1, int ReceivablesShortcutKeys2, int OrderShortcutKeys1, int OrderShortcutKeys2, int RefundShortcutKeys1, int RefundShortcutKeys2, int PipelinePrinting1, int PipelinePrinting2, int ViewShortcuts1, int ViewShortcuts2, int ArouseConcealment1, int ArouseConcealment2, int ClosingProcess1, int ClosingProcess2, int SwitchingAccounts1, int SwitchingAccounts2, string UserId)
        {
            return quicksetting.InsertSetting( FastSwitchState,  GraspShortcutKeys1,  GraspShortcutKeys2,  ReceivablesShortcutKeys1,  ReceivablesShortcutKeys2,  OrderShortcutKeys1,  OrderShortcutKeys2,  RefundShortcutKeys1,  RefundShortcutKeys2, PipelinePrinting1, PipelinePrinting2,  ViewShortcuts1,  ViewShortcuts2,  ArouseConcealment1,  ArouseConcealment2,  ClosingProcess1,  ClosingProcess2,  SwitchingAccounts1,  SwitchingAccounts2,  UserId);
        }

        public int UpdSetting(int FastSwitchState, int GraspShortcutKeys1, int GraspShortcutKeys2, int ReceivablesShortcutKeys1, int ReceivablesShortcutKeys2, int OrderShortcutKeys1, int OrderShortcutKeys2, int RefundShortcutKeys1, int RefundShortcutKeys2, int PipelinePrinting1, int PipelinePrinting2, int ViewShortcuts1, int ViewShortcuts2, int ArouseConcealment1, int ArouseConcealment2, int ClosingProcess1, int ClosingProcess2, int SwitchingAccounts1, int SwitchingAccounts2, string UserId)
        {
            return quicksetting.UpdSetting(FastSwitchState, GraspShortcutKeys1, GraspShortcutKeys2, ReceivablesShortcutKeys1, ReceivablesShortcutKeys2, OrderShortcutKeys1, OrderShortcutKeys2, RefundShortcutKeys1, RefundShortcutKeys2, PipelinePrinting1, PipelinePrinting2, ViewShortcuts1, ViewShortcuts2, ArouseConcealment1, ArouseConcealment2, ClosingProcess1, ClosingProcess2, SwitchingAccounts1, SwitchingAccounts2, UserId);
        }

        public quicksetting SelectSetting(string UserId)
        {
            return quicksetting.SelectSetting(UserId);
        }

        public void SelectSetting1(ComboBoxEdit comboBoxEdit14, ComboBoxEdit comboBoxEdit15, ComboBoxEdit comboBoxEdit16, ComboBoxEdit comboBoxEdit17, ComboBoxEdit comboBoxEdit18, ComboBoxEdit comboBoxEdit19, ComboBoxEdit comboBoxEdit20, ComboBoxEdit comboBoxEdit21, ComboBoxEdit comboBoxEdit22, string UserId)
        {
            quicksetting.Selectsetting1(comboBoxEdit14, comboBoxEdit15, comboBoxEdit16, comboBoxEdit17, comboBoxEdit18, comboBoxEdit19, comboBoxEdit20, comboBoxEdit21, comboBoxEdit22,UserId);
        }

        public DataTable FillQuick()
        {
           return quicksetting.Fill();
        }
    }
}
