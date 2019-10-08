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
        private WaitFormService()
        {

        }
        private static WaitFormService _instance;
        private static readonly Object syncLock = new Object();
        private static WaitForm waitForm;
        public delegate void ShowWaitFormEventHandler();
        public delegate bool CancleEventHandler();
        public static event CancleEventHandler Cancle;
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
        public static void Close()
        {
            try
            {
                if (waitForm.InvokeRequired)
                {
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

        
        public static void CreateForm()
        {
            waitForm = new WaitForm();
            waitForm.Show();
            for (int i = 0; i < 10000; i++)
            {
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
        public void SetWaiteText(string text)
        {

        }
    }
}
