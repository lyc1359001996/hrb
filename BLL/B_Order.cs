using DevExpress.XtraEditors;
using DXApplication2.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DXApplication2.BLL
{
    class B_Order
    {
        D_Order Order = new D_Order();
        public int InsertOrder(string OrderBH,decimal AmountMoney,decimal PreferentialAmount, int PaymentMethod,int State,DateTime PaymentTime,int NameStore,int Cashier,int PaymentTerminal,string OrderRemarks)
        {
            return Order.InsertOrder(OrderBH,AmountMoney,PreferentialAmount,AmountMoney,PaymentMethod,State,PaymentTime.ToString(),NameStore,Cashier,PaymentTerminal, OrderRemarks);
        }
        public DataTable SelectOrder()
        {
            return Order.SelectOrder(DateTime.Now.Date.ToString(), DateTime.Now.ToLocalTime().ToString());
        }

        public DataTable SelectOrder(DateEdit dateedit1,DateEdit dateedit2)
        {
            return Order.SelectOrder(dateedit1.Text, dateedit2.Text);
        }

        public DataTable SelectOrder(string EndTime)
        {
            return Order.SelectOrder(EndTime);
        }

        public DataTable SelectOrder2(string OrderBh)
        {
            return Order.SelectOrder3(OrderBh);
        }

        public DataTable SelectOrder3(string PaymentMethod)
        {
            return Order.SelectOrder4(PaymentMethod);
        }

        public DataTable SelectOrder4(string StateTime, string EndTime,string Cashier)
        {
            return Order.SelectOrder5(StateTime, EndTime,Cashier);
        }

        public DataTable SelectOrder5(string StartTime)
        {
            return Order.SelectOrder2(StartTime);
        }

        public DataTable SelectOrder(string StateTime,string EndTime)
        {
            return Order.SelectOrder(StateTime,EndTime);
        }

        public DataTable SelectOrder15(string StateTime, string EndTime)
        {
            return Order.SelectOrder15(StateTime, EndTime);
        }

        public DataTable SelectOrder(string StateTime, string EndTime,string OrderBH)
        {
            return Order.SelectOrder(StateTime, EndTime,OrderBH);
        }

        public DataTable P_SelectOrder(string StateTime, string EndTime,int pageSize,int curPage)
        {
            return Order.P_SelectOrder(StateTime, EndTime ,pageSize,curPage);
        }

        public DataTable P_SelectOrder(string StateTime, string EndTime, string OrderBH, int pageSize, int curPage)
        {
            return Order.P_SelectOrder(StateTime, EndTime, OrderBH, pageSize, curPage);
        }

        public DataTable SelectOrder7()
        {
            return Order.SelectOrder(DateTime.Now.Date.ToString(), DateTime.Now.ToLocalTime().ToString());
        }

        public DataTable SelectOrder6(string StateTime)
        {
            return Order.SelectOrder1(StateTime);
        }

        public DataTable SelectOrder7(string StateTime)
        {
            return Order.SelectOrder6(StateTime);
        }

        public DataTable SelectOrder8()
        {
            return Order.SelectOrder7();
        }

        public DataTable SelectOrder9(string StateTime)
        {
            return Order.SelectOrder8(StateTime);
        }

        public DataTable SelectOrder10(string StateTime)
        {
            return Order.SelectOrder9(StateTime);
        }

        public DataTable SelectOrder11()
        {
            return Order.SelectOrder10();
        }

        public DataTable SelectOrder12(string StateTime)
        {
            return Order.SelectOrder11(StateTime);
        }

        public DataTable SelectOrder13(string StateTime)
        {
            return Order.SelectOrder12(StateTime);
        }

        public DataTable SelectOrder14()
        {
            return Order.SelectOrder13();
        }

        /// <summary>
                /// 时间转时间戳（精确到秒）
                /// </summary>
                /// <param name="date"></param>
                /// <returns></returns>
        public static long GetTimeStamp(DateTime date)
        {
            var ticks = date.ToUniversalTime().Ticks - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
            var timeSpan = ticks / TimeSpan.TicksPerSecond;
            return timeSpan;
        }
        /// <summary>
        /// 时间戳转时间
        /// </summary>
        /// <param name="timespan"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(long timespan)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            var dt = timespan.ToString().Length == 13 ? startTime.AddMilliseconds(timespan) : startTime.AddSeconds(timespan);
            return dt;
        }
        /// <summary>
        /// 秒
        /// </summary>
        /// <returns></returns>
        public static long Timestamps()
        {
            return (DateTime.UtcNow.Ticks - 621355968000000000L) / 10000000L;
        }
        /// <summary>
        /// 毫秒
        /// </summary>
        /// <returns></returns>
        public static long Timestampms()
        {
            return (DateTime.UtcNow.Ticks - 621355968000000000L) / 10000L;
        }
    }
}
