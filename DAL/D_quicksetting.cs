using DevExpress.XtraEditors;
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
    class D_quicksettingClass
    {
        quicksetting quicksetting = new quicksetting();
        DataTable dt = new DataTable();
        public int InsertSetting(int FastSwitchState,int GraspShortcutKeys1,int GraspShortcutKeys2,int ReceivablesShortcutKeys1,int ReceivablesShortcutKeys2,int OrderShortcutKeys1,int OrderShortcutKeys2,int RefundShortcutKeys1,int RefundShortcutKeys2,int PipelinePrinting1,int PipelinePrinting2,int ViewShortcuts1,int ViewShortcuts2,int ArouseConcealment1,int ArouseConcealment2,int ClosingProcess1,int ClosingProcess2,int SwitchingAccounts1,int SwitchingAccounts2,string UserId)
        {
           return my_sql.updateSql("INSERT INTO `quicksetting` (`FastSwitchState`, `GraspShortcutKeys1`, `GraspShortcutKeys2`, `ReceivablesShortcutKeys1`, `ReceivablesShortcutKeys2`, `OrderShortcutKeys1`, `OrderShortcutKeys2`, `RefundShortcutKeys1`, `RefundShortcutKeys2`, `PipelinePrinting1`, `PipelinePrinting2`, `ViewShortcuts1`, `ViewShortcuts2`, `ArouseConcealment1`, `ArouseConcealment2`, `ClosingProcess1`, `ClosingProcess2`, `SwitchingAccounts1`, `SwitchingAccounts2`, `UserId`) VALUES ('"+FastSwitchState+"', '"+GraspShortcutKeys1+"', '"+GraspShortcutKeys2+"', '"+ReceivablesShortcutKeys1+"', '"+ReceivablesShortcutKeys2+"', '"+OrderShortcutKeys1+"', '"+OrderShortcutKeys2+"', '"+RefundShortcutKeys1+"', '"+RefundShortcutKeys2+"', '"+PipelinePrinting1+"', '"+PipelinePrinting2+"', '"+ViewShortcuts1+"', '"+ViewShortcuts2+"', '"+ArouseConcealment1+"', '"+ArouseConcealment2+"', '"+ClosingProcess1+"', '"+ClosingProcess2+"', '"+SwitchingAccounts1+"', '"+SwitchingAccounts2+"', '"+UserId+"')");
        }

        public int UpdSetting(int FastSwitchState, int GraspShortcutKeys1, int GraspShortcutKeys2, int ReceivablesShortcutKeys1, int ReceivablesShortcutKeys2, int OrderShortcutKeys1, int OrderShortcutKeys2, int RefundShortcutKeys1, int RefundShortcutKeys2, int PipelinePrinting1, int PipelinePrinting2, int ViewShortcuts1, int ViewShortcuts2, int ArouseConcealment1, int ArouseConcealment2, int ClosingProcess1, int ClosingProcess2, int SwitchingAccounts1, int SwitchingAccounts2, string UserId)
        {
            return my_sql.updateSql("UPDATE `quicksetting` SET `FastSwitchState`='"+FastSwitchState+"', `GraspShortcutKeys1`='"+GraspShortcutKeys1+"', `GraspShortcutKeys2`='"+GraspShortcutKeys2+"', `ReceivablesShortcutKeys1`='"+ReceivablesShortcutKeys1+"', `ReceivablesShortcutKeys2`='"+ReceivablesShortcutKeys2+"', `OrderShortcutKeys1`='"+OrderShortcutKeys2+"', `OrderShortcutKeys2`='"+OrderShortcutKeys2+"', `RefundShortcutKeys1`='6', `RefundShortcutKeys2`='"+ReceivablesShortcutKeys1+"', `PipelinePrinting1`='"+PipelinePrinting1+"', `PipelinePrinting2`='"+PipelinePrinting2+"', `ViewShortcuts1`='"+ViewShortcuts1+"', `ViewShortcuts2`='"+ViewShortcuts2+"', `ArouseConcealment1`='"+ArouseConcealment1+"', `ArouseConcealment2`='"+ArouseConcealment2+"', `ClosingProcess1`='"+ClosingProcess1+"', `ClosingProcess2`='"+ClosingProcess1+"', `SwitchingAccounts1`='"+SwitchingAccounts1+"', `SwitchingAccounts2`='"+SwitchingAccounts1+"' WHERE (`UserId`='"+UserId+"');");
        }

        public quicksetting SelectSetting(string UserId)
        {
            dt= my_sql.listTable("SELECT FastSwitchState,GraspShortcutKeys1,GraspShortcutKeys2,ReceivablesShortcutKeys1,ReceivablesShortcutKeys2,OrderShortcutKeys1,OrderShortcutKeys2,RefundShortcutKeys1,RefundShortcutKeys2,PipelinePrinting1,PipelinePrinting2,ViewShortcuts1,ViewShortcuts2,ArouseConcealment1,ArouseConcealment2,ClosingProcess1,ClosingProcess2,SwitchingAccounts1,SwitchingAccounts2 FROM quicksetting WHERE UserId='"+UserId+"';");
            quicksetting.FastSwitchState=int.Parse(dt.Rows[0][0].ToString());
            quicksetting.GraspShortcutKeys1= int.Parse(dt.Rows[0][1].ToString());
            quicksetting.GraspShortcutKeys2= dt.Rows[0][2].ToString();
            quicksetting.ReceivablesShortcutKeys1= int.Parse(dt.Rows[0][3].ToString());
            quicksetting.ReceivablesShortcutKeys2 = dt.Rows[0][4].ToString();
            quicksetting.OrderShortcutKeys1= int.Parse(dt.Rows[0][5].ToString());
            quicksetting.OrderShortcutKeys2= dt.Rows[0][6].ToString();
            quicksetting.RefundShortcutKeys1= int.Parse(dt.Rows[0][7].ToString());
            quicksetting.RefundShortcutKeys2= dt.Rows[0][8].ToString();
            quicksetting.PipelinePrinting1= int.Parse(dt.Rows[0][9].ToString());
            quicksetting.PipelinePrinting2= dt.Rows[0][10].ToString();
            quicksetting.ViewShortcuts1= int.Parse(dt.Rows[0][11].ToString());
            quicksetting.ViewShortcuts2= dt.Rows[0][12].ToString();
            quicksetting.ArouseConcealment1= int.Parse(dt.Rows[0][13].ToString());
            quicksetting.ArouseConcealment2 = dt.Rows[0][14].ToString();
            quicksetting.ClosingProcess1= int.Parse(dt.Rows[0][15].ToString());
            quicksetting.ClosingProcess2= dt.Rows[0][16].ToString();
            quicksetting.SwitchingAccounts1= int.Parse(dt.Rows[0][17].ToString());
            quicksetting.SwitchingAccounts2= dt.Rows[0][18].ToString();
            return quicksetting;
        }

        public void Selectsetting1(ComboBoxEdit comboBoxEdit14, ComboBoxEdit comboBoxEdit15, ComboBoxEdit comboBoxEdit16, ComboBoxEdit comboBoxEdit17, ComboBoxEdit comboBoxEdit18, ComboBoxEdit comboBoxEdit19, ComboBoxEdit comboBoxEdit20, ComboBoxEdit comboBoxEdit21, ComboBoxEdit comboBoxEdit22,string UserId)
        {
            dt = my_sql.listTable("SELECT(SELECT GROUP_CONCAT(s.ShortcutKeys) FROM shortcutkeys s WHERE FIND_IN_SET(s.Id,q.ArouseConcealment1)),(SELECT GROUP_CONCAT(s.ShortcutKeys) FROM shortcutkeys s WHERE FIND_IN_SET(s.Id,q.ClosingProcess1)),(SELECT GROUP_CONCAT(s.ShortcutKeys) FROM shortcutkeys s WHERE FIND_IN_SET(s.Id,q.GraspShortcutKeys1)),(SELECT GROUP_CONCAT(s.ShortcutKeys) FROM shortcutkeys s WHERE FIND_IN_SET(s.Id,q.OrderShortcutKeys1)),(SELECT GROUP_CONCAT(s.ShortcutKeys) FROM shortcutkeys s WHERE FIND_IN_SET(s.Id,q.PipelinePrinting1)),(SELECT GROUP_CONCAT(s.ShortcutKeys) FROM shortcutkeys s WHERE FIND_IN_SET(s.Id,q.ReceivablesShortcutKeys1)),(SELECT GROUP_CONCAT(s.ShortcutKeys) FROM shortcutkeys s WHERE FIND_IN_SET(s.Id,q.RefundShortcutKeys1)),(SELECT GROUP_CONCAT(s.ShortcutKeys) FROM shortcutkeys s WHERE FIND_IN_SET(s.Id,q.SwitchingAccounts1)),(SELECT GROUP_CONCAT(s.ShortcutKeys) FROM shortcutkeys s WHERE FIND_IN_SET(s.Id,q.ViewShortcuts1)) FROM quicksetting `q`");
            comboBoxEdit18.Text = dt.Rows[0][0].ToString();
            comboBoxEdit21.Text =dt.Rows[0][1].ToString();
            comboBoxEdit14.Text= dt.Rows[0][2].ToString();
            comboBoxEdit17.Text= dt.Rows[0][3].ToString();
            comboBoxEdit19.Text= dt.Rows[0][4].ToString();
            comboBoxEdit15.Text= dt.Rows[0][5].ToString();
            comboBoxEdit16.Text = dt.Rows[0][6].ToString();
            comboBoxEdit20.Text = dt.Rows[0][7].ToString();
            comboBoxEdit22.Text = dt.Rows[0][8].ToString();
        }

        public DataTable Fill()
        {
            return my_sql.listTable("Select id,ShortcutKeys from shortcutkeys");
        }
    }
}
