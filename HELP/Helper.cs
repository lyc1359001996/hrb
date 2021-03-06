﻿using KellComUtility;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using USBControlUtility;

namespace USBControlUtility
{
    class Helper
    {
        public string HexString2BinString(string hexString)
        {
            string result = string.Empty;
            foreach (char c in hexString)
            {
                int v = Convert.ToInt32(c.ToString(), 16);
                int v2 = int.Parse(Convert.ToString(v, 2));
                result += string.Format("{0:d4} ", v2);
            }
            return result;
        }

        public string HexStringToString(string hs, Encoding encode)
        {
            string strTemp = "";
            byte[] b = new byte[hs.Length / 2];
            for (int i = 0; i < hs.Length / 2; i++)
            {
                strTemp = hs.Substring(i * 2, 2);
                b[i] = Convert.ToByte(strTemp, 16);
            }
            return encode.GetString(b);
        }
        
        private string sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            SerialPort sp = sender as SerialPort;
            byte[] buf = new byte[sp.BytesToRead];
            sp.Read(buf, 0, buf.Length);
            builder.Append(ComUtility.GetHex(buf).ToUpper());
            string content = builder.ToString();
            return HexStringToString(content.Replace(" ", ""), Encoding.UTF8);
        }
    }
}
