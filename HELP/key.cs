using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication2.HELP
{
    class key
    {
        public string getKey(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals("ControlKey:ControlKey:17:None"))
            {
                return "CTRL";
            }else if (e.KeyChar.Equals(""))
            {

            }
            return "";
        }
        
        public float[] GetPathPoint(string value, string regx)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            bool isMatch = System.Text.RegularExpressions.Regex.IsMatch(value, regx);
            if (!isMatch)
                return null;
            System.Text.RegularExpressions.MatchCollection matchCol = System.Text.RegularExpressions.Regex.Matches(value, regx);
            float[] result = new float[matchCol.Count];
            if (matchCol.Count > 0)
            {
                for (int i = 0; i < matchCol.Count; i++)
                {
                    result[i] = float.Parse(matchCol[i].Value);
                }
            }
            return result;
        }
    }
}
