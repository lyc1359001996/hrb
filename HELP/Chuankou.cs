using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication2.HELP
{
    class Chuankou
    {
        public static bool OpenOrClosePort(bool open, SerialPort sp, ComboBoxEdit comboBoxEdit4)
        {
            if (open)
            {
                if (sp.IsOpen)
                {
                    sp.Close();
                }
                sp.Encoding = System.Text.Encoding.ASCII;
                sp.BaudRate = int.Parse(comboBoxEdit4.Text);
                sp.Open();
                return true;
            }
            else
            {
                sp.Close();
                return false;
            }
        }
    }
}

