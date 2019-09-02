using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DXApplication2.HELP
{
    class jubing
    {
        [DllImport("user32.dll")]
        public static extern int GetCursorPos(ref Point lpPoint);  //获取鼠标坐标，该坐标是光标所在的屏幕坐标位置
        [DllImport("user32.dll")]
        public static extern int WindowFromPoint(int xPoint, int yPoint);  //指定坐标处窗体句柄
        [DllImport("user32.dll")]
        public static extern int GetWindowText(int hwnd, StringBuilder lpString, int nMaxCount);//获取窗体标题名称
        [DllImport("user32.dll")]
        public static extern int GetClassName(int hwnd, StringBuilder lpstring, int nMaxCount); //获取窗体类名称           
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, string lParam);
        bool isMouseUp = false;
        Point pi = new Point();
        Point p = new Point();
        int hwnd;
        StringBuilder name = new StringBuilder(256);
        string WM_SETTEXT = "&HC";
        string Name = "";
        public string timer()
        {
            if (isMouseUp)//左键是否被按下
            {
                GetCursorPos(ref pi); //获取鼠标坐标值
                //label1.Text = "坐标：X=" + pi.X + "  |  Y=" + pi.Y; //label1显示鼠标坐标值的x值与y值
                hwnd = WindowFromPoint(pi.X, pi.Y);//获取坐标值下的窗体句柄

                //label2.Text = "句柄：" + hwnd.ToString();//lable2显示句柄，貌似SPY++是十六进制的，这个是十进制的
                GetWindowText(hwnd, name, 256);//name得到窗体的标题
                Name = name.ToString();//label3显示标题
                GetClassName(hwnd, name, 256);//name得到class的名称（这个我也不知道叫什么）
                //label4.Text = "名称：" + name.ToString();//显示class的名称
            }
            else
            {
                if (pi.X != 0)
                {
                    //label1.Text = "坐标：X=" + pi.X + "  |  Y=" + pi.Y; //label1显示鼠标坐标值的x值与y值
                    hwnd = WindowFromPoint(pi.X, pi.Y);//获取坐标值下的窗体句柄
                    //label2.Text = "句柄：" + hwnd.ToString();//lable2显示句柄，貌似SPY++是十六进制的，这个是十进制的
                    GetWindowText(hwnd, name, 256);//name得到窗体的标题
                    Name = name.ToString();//label3显示标题
                    GetClassName(hwnd, name, 256);//name得到class的名称（这个我也不知道叫什么）
                    //label4.Text = "名称：" + name.ToString();//显示class的名称
                }
            }
            return Name;

        }
    }
}
