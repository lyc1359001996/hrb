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
                //打开串口
                if (sp.IsOpen)
                {
                    sp.Close();
                }
                Console.WriteLine(comboBoxEdit4.Text);
                sp.Encoding = System.Text.Encoding.ASCII;
                sp.BaudRate = int.Parse(comboBoxEdit4.Text);
                sp.Open();
                //btnOpen.Text = "关闭串口";//按钮打开
                //txtGet.AppendText("串口打开成功！" + Environment.NewLine);//状态栏
                return true;
            }
            else
            {
                //sp.Encoding = System.Text.Encoding.UTF8;
                sp.Close();
                //btnOpen.Text = "打开串口";//按钮关闭
                //txtGet.AppendText("串口关闭成功！" + Environment.NewLine);//状态栏
                //return true;
                return false;
            }
        }
    }
}

