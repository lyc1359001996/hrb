using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace tools
{
    /// <summary>
    /// 网络工具类。
    /// </summary>
    public sealed class WebUtils
    {
        /*
*  url:POST请求地址
*  postData:json格式的请求报文,例如：{"key1":"value1","key2":"value2"}
*/
        public static string MakeRequest(string url, string query_string, string method, string protocol)
        {
            //cookie
            //string cookie_string = null;
            //if (cookie != null && cookie.Count > 0)
            //{
            //    string[] arr_cookies = new string[cookie.Count];
            //    int i = 0;
            //    foreach (string key in cookie.Keys)
            //    {
            //        arr_cookies[i] = key + "=" + cookie[key];
            //        i++;
            //    }
            //    cookie_string = string.Join("; ", arr_cookies);
            //}
            //结果
            string result = "";
            //请求类
            HttpWebRequest request = null;
            //请求响应类
            HttpWebResponse response = null;
            //响应结果读取类
            StreamReader reader = null;
            //http连接数限制默认为2，多线程情况下可以增加该连接数，非多线程情况下可以注释掉此行代码
            ServicePointManager.DefaultConnectionLimit = 500;
            try
            {
                if (method.Equals("get", StringComparison.OrdinalIgnoreCase))
                {


                    if (url.IndexOf("?") > 0)
                    {
                        url = url + "&" + query_string;
                    }
                    else
                    {
                        url = url + "?" + query_string;
                    }
                    //如果是发送HTTPS请求   
                    if (protocol.Equals("https", StringComparison.OrdinalIgnoreCase))
                    {
                        //request = WebRequest.Create(url) as HttpWebRequest;
                        //request.ProtocolVersion = HttpVersion.Version10;
                    }
                    else
                    {
                        request = WebRequest.Create(url) as HttpWebRequest;
                    }
                    request.Method = "GET";
                    request.Timeout = 30000;
                    request.KeepAlive = false;
                }
                else
                {
                    //如果是发送HTTPS请求   
                    if (protocol.Equals("https", StringComparison.OrdinalIgnoreCase))
                    {
                        //request = WebRequest.Create(url) as HttpWebRequest;
                        //request.ProtocolVersion = HttpVersion.Version10;
                    }
                    else
                    {
                        request = WebRequest.Create(url) as HttpWebRequest;
                    }
                    //去掉“Expect: 100-Continue”请求头，不然会引起post（417） expectation failed
                    ServicePointManager.Expect100Continue = false;


                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.Timeout = 30000;
                    request.KeepAlive = false;
                    //POST数据   
                    byte[] data = Encoding.UTF8.GetBytes(query_string);
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
                //cookie
                //if (!string.IsNullOrEmpty(cookie_string))
                //{
                //    request.Headers.Add("Cookie", cookie_string);
                //}
                //response
                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                //return
                result = reader.ReadToEnd();
            }
            finally
            {
                if (request != null)
                {
                    request.Abort();
                }
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
            return result;
        }

        public static string MakeRequest1(string url, string query_string, string method, string protocol, string token = null)
        {

            string result = "";
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            ServicePointManager.DefaultConnectionLimit = 500;
            try
            {
                if (method.Equals("get", StringComparison.OrdinalIgnoreCase))
                {


                    if (url.IndexOf("?") > 0)
                    {
                        url = url + "&" + query_string;
                    }
                    else
                    {
                        url = url + "?" + query_string;
                    }
                    if (protocol.Equals("https", StringComparison.OrdinalIgnoreCase))
                    {
                    }
                    else
                    {
                        request = WebRequest.Create(url) as HttpWebRequest;
                    }
                    request.Method = "GET";
                    request.Timeout = 30000;
                    request.KeepAlive = false;
                }
                else
                {
                    if (protocol.Equals("https", StringComparison.OrdinalIgnoreCase))
                    {
                    }
                    else
                    {
                        request = WebRequest.Create(url) as HttpWebRequest;
                    }
                    ServicePointManager.Expect100Continue = false;

                    if (token != null)
                    {
                        request.Headers.Add("Authorization", token);
                    }
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.Timeout = 30000;
                    request.KeepAlive = false;
                    byte[] data = Encoding.UTF8.GetBytes(query_string);
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                //return
                result = reader.ReadToEnd();
            }
            finally
            {
                if (request != null)
                {
                    request.Abort();
                }
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
            return result;
        }

        public static string HttpGet(string Url, string token = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            if (token != null)
            {
                request.Headers.Add("Authorization", token);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;

        }


        public static string MakeRequest2(string url, string query_string, string method, string protocol, string token = null)
        {

            string result = "";
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            ServicePointManager.DefaultConnectionLimit = 500;
            try
            {
                if (method.Equals("get", StringComparison.OrdinalIgnoreCase))
                {


                    if (url.IndexOf("?") > 0)
                    {
                        url = url + "&" + query_string;
                    }
                    else
                    {
                        url = url + "?" + query_string;
                    }
                    if (protocol.Equals("https", StringComparison.OrdinalIgnoreCase))
                    {
                    }
                    else
                    {
                        request = WebRequest.Create(url) as HttpWebRequest;
                    }
                    request.Method = "GET";
                    request.Timeout = 30000;
                    request.KeepAlive = false;
                }
                else
                {
                    if (protocol.Equals("https", StringComparison.OrdinalIgnoreCase))
                    {
                    }
                    else
                    {
                        request = WebRequest.Create(url) as HttpWebRequest;
                    }
                    ServicePointManager.Expect100Continue = false;

                    if (token != null)
                    {
                        request.Headers.Add("Authorization", token);
                    }
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Timeout = 30000;
                    request.KeepAlive = false;
                    byte[] data = Encoding.UTF8.GetBytes(query_string);
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                //return
                result = reader.ReadToEnd();
            }
            finally
            {
                if (request != null)
                {
                    request.Abort();
                }
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
            return result;
        }

    }
}