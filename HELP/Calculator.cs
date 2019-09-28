using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication2.HELP
{
    class Calculator
    {
        public string add(string num,TextEdit TextEdit)
        {
           return TextEdit.Text += num;
        }

        public string empty(TextEdit TextEdit)
        {
            return TextEdit.Text ="";
        }

        public string Del(TextEdit TextEdit)
        {
            return TextEdit.Text.Remove(TextEdit.Text.Length-1,1);
        }
    }
}
