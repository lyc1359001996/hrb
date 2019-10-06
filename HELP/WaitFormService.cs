using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication16
{
    public class WaitFormService
    {

        /// <summary>    
        /// 单例模式    
        /// </summary>    
        public static WaitFormService Instance
        {
            get
            {
                if (WaitFormService._instance == null)
                {
                    lock (syncLock)
                    {
                        if (WaitFormService._instance == null)
                        {
                            WaitFormService._instance = new WaitFormService();
                        }
                    }
                }
                return WaitFormService._instance;
            }
        }

        /// <summary>    
        /// 为了单例模式防止new 实例化..    
        /// </summary>    
        private WaitFormService()
        {

        }
        private static WaitFormService _instance;
        private static readonly Object syncLock = new Object();
        //private static Thread waitThread;
        private static WaitForm waitForm;
        public delegate void ShowWaitFormEventHandler();
        public delegate bool CancleEventHandler();
        public static event CancleEventHandler Cancle;
        /// <summary>    
        /// 显示等待窗体    
        /// </summary>    
        public static void Show()
        {
            ShowWaitFormEventHandler showWaitFormEventHandler = new ShowWaitFormEventHandler(CreateForm);
            IAsyncResult result = showWaitFormEventHandler.BeginInvoke(new AsyncCallback(Completed), null);
        }
        private static void Completed(IAsyncResult result)
        {
            AsyncResult _result = (AsyncResult)result;
            ShowWaitFormEventHandler showHandler = (ShowWaitFormEventHandler)_result.AsyncDelegate;
            try { showHandler.EndInvoke(result); } catch { }
            WaitFormService.Close();
        }
        /// <summary>    
        /// 关闭等待窗体    
        /// </summary>    
        public static void Close()
        {
            try
            {
                if (waitForm.InvokeRequired)
                {
                    //子线程将调用方法 Marshal成消息，调用Win 32 API的RegisterWindowsMessage()向UI窗体发送消息。
                    //UI线程需要处理完正在做的事，做完之后再去执行Invoke封送过来的消息。Control.Invoke和BeginInvoke,这两个方法所执行的
                    //委托是在UI线程中执行的
                    waitForm.Invoke((Action)(delegate
                    {
                        waitForm.Close();
                        waitForm.Dispose();
                    }));
                }
                else
                {
                    waitForm.Close();
                }
            }
            catch
            {

            }
        }

        /// <summary>    
        /// 设置等待窗体标题    
        /// </summary>    
        /// <param name="text"></param>    
        public static void SetText(string text)
        {
            try
            {
                WaitFormService.Instance.SetWaiteText(text);
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex.Message);
            }
        }


        /// <summary>    
        /// 创建等待窗体    
        /// </summary>    
        public static void CreateForm()
        {
            waitForm = new WaitForm();
            waitForm.Show();
            for (int i = 0; i < 10000; i++)
            {
                //waitForm.IsHandleCreated
                // if (waitForm.IsHandleCreated)
                //  {
                if (!Cancle())
                {
                    waitForm.Invoke((Action)(delegate
                    {
                        WaitFormService.SetText("正在执行 ，请耐心等待...." + i.ToString());
                    }));
                    Application.DoEvents();
                }
                else
                {
                    break;
                }
            }
        }
        private static void Create()
        {

        }

        /// <summary>    
        /// 设置窗体标题    
        /// </summary>    
        /// <param name="text"></param>    
        public void SetWaiteText(string text)
        {

        }
    }
}
