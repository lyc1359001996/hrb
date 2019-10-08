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
    public sealed class WebUtils
    {
        public static string MakeRequest(string url, string query_string, string method, string protocol)
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