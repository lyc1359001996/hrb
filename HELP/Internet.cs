using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DXApplication2.HELP
{
    class Internet
    {
        [DllImport(@"wininet", SetLastError = true, CharSet = CharSet.Auto, EntryPoint = "InternetSetOption", CallingConvention = CallingConvention.StdCall)]
        public static extern bool InternetSetOption
       (
       int hInternet,
       int dmOption,
       IntPtr lpBuffer,
       int dwBufferLength
       );
        public struct Struct_INTERNET_PROXY_INFO
        {
            public int dwAccessType;
            public IntPtr proxy;
            public IntPtr proxyBypass;
        };

        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);

        public static void SetIEProxy(string strProxy)
        {
            const int INTERNET_OPTION_PROXY = 38;
            const int INTERNET_OPEN_TYPE_PROXY = 3;
            Struct_INTERNET_PROXY_INFO struct_IPI;
            struct_IPI.dwAccessType = INTERNET_OPEN_TYPE_PROXY;
            struct_IPI.proxy = Marshal.StringToHGlobalAnsi(strProxy);
            struct_IPI.proxyBypass = Marshal.StringToHGlobalAnsi("local");
            IntPtr intptrStruct = Marshal.AllocCoTaskMem(Marshal.SizeOf(struct_IPI));
            Marshal.StructureToPtr(struct_IPI, intptrStruct, true);
            bool iReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_PROXY, intptrStruct, Marshal.SizeOf(struct_IPI));
        }
        public static bool yanzhen(string str, int port)
        {
            WebProxy proxyObject = new WebProxy(str, port);//str为IP地址 port为端口号
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create("http://www.ip138.com/");
            Req.Proxy = proxyObject;
            Req.Timeout = 30000;
            HttpWebResponse Resp = (HttpWebResponse)Req.GetResponse();
            Encoding code = Encoding.GetEncoding("UTF-8");
            using (StreamReader sr = new StreamReader(Resp.GetResponseStream(), code))
            {
                if (sr != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
