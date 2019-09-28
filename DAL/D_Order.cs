using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thsoft_core;
using Utilities;

namespace DXApplication2.DAL
{
    class D_Order
    {
        DataTable dt = new DataTable();
        
        public int InsertOrder(string OrderBH,decimal PaymentAmount,decimal PreferentialAmount,decimal AmountMoney,int PaymentMethod,int State, string PaymentTime,int NameStore,int Cashier, int PaymentTerminal,string OrderRemarks)
        {
            return my_sql.updateSql("INSERT INTO `order` (`OrderBH`, `PaymentAmount`, `PreferentialAmount`, `AmountMoney`, `PaymentMethod`, `State`, `PaymentTime`, `NameStore`, `Cashier`, `PaymentTerminal`) VALUES('11', '"+PaymentAmount+"', '"+ PreferentialAmount + "', '" + AmountMoney + "', '"+ PaymentMethod + "', '"+ State + "', '"+ PaymentTime + "', '"+ NameStore + "', '" + Cashier + "', '"+ PaymentTerminal + "')");
        }

        public DataTable SelectOrder(string Cashier, string StartTime,string EndTime,string PaymentMethod,string OrderBH)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentTime,s.State,p.PaymentMethod FROM `order` o left JOIN paymentmethod p ON p.id=o.PaymentMethod  LEFT JOIN state s on s.Id=o.State WHERE PaymentTime>='" + StartTime+"' AND PaymentTime<='"+EndTime+ "'AND Cashier='"+Cashier+"' AND PaymentMethod='"+PaymentMethod+"' AND OrderBH='"+OrderBH+ "' GROUP BY OrderBH;;");
        }

        public DataTable SelectOrder(string StartTime, string EndTime, string PaymentMethod, string OrderBH)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentTime,s.State,p.PaymentMethod FROM `order` o left JOIN paymentmethod p ON p.id=o.PaymentMethod  LEFT JOIN state s on s.Id=o.State WHERE PaymentTime>='" + StartTime + "' AND PaymentTime<='" + EndTime + "' AND PaymentMethod='" + PaymentMethod + "' AND OrderBH='" + OrderBH + "' GROUP BY OrderBH;;");
        }

        public DataTable SelectOrder(string StartTime, string EndTime,string OrderBH)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentTime,PaymentAmount,PreferentialAmount,s.State,p.PaymentMethod,pa.PaymentTerminal,c.Cashier,n.NameStore FROM `order` o left JOIN paymentmethod p ON p.id=o.PaymentMethod  LEFT JOIN state s on s.Id=o.State LEFT JOIN paymentterminal pa ON pa.Id=o.PaymentTerminal LEFT JOIN Cashier c ON c.Id=o.Cashier LEFT JOIN namestore n ON n.Id=o.NameStore WHERE PaymentTime>='" + StartTime + "' AND PaymentTime<='" + EndTime+ "' AND OrderBH like'%" + OrderBH + "' GROUP BY OrderBH;");
        }

        public DataTable P_SelectOrder(string StartTime, string EndTime, string OrderBH, int pageSize, int curPage)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentTime,s.State,p.PaymentMethod FROM `order` o left JOIN paymentmethod p ON p.id=o.PaymentMethod  LEFT JOIN state s on s.Id=o.State WHERE PaymentTime>='" + StartTime + "' AND PaymentTime<='" + EndTime + "' AND OrderBH like'%" + OrderBH + "' GROUP BY OrderBH Limit " + curPage * pageSize + "," + curPage + ";");
        }

        public DataTable SelectOrder(string StartTime, string EndTime)
        {
            Console.WriteLine("SELECT OrderBH,AmountMoney,PaymentTime,PaymentAmount,PreferentialAmount,s.State,p.PaymentMethod,pa.PaymentTerminal,c.Cashier,n.NameStore FROM `order` o left JOIN paymentmethod p ON p.id=o.PaymentMethod  LEFT JOIN state s on s.Id=o.State LEFT JOIN paymentterminal pa ON pa.Id=o.PaymentTerminal LEFT JOIN Cashier c ON c.Id=o.Cashier LEFT JOIN namestore n ON n.Id=o.NameStore WHERE PaymentTime>='" + StartTime + "' AND PaymentTime<='" + EndTime + "' AND(o.State=2 OR o.State=4) GROUP BY OrderBH ;");
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentTime,PaymentAmount,PreferentialAmount,s.State,p.PaymentMethod,pa.PaymentTerminal,c.Cashier,n.NameStore FROM `order` o left JOIN paymentmethod p ON p.id=o.PaymentMethod  LEFT JOIN state s on s.Id=o.State LEFT JOIN paymentterminal pa ON pa.Id=o.PaymentTerminal LEFT JOIN Cashier c ON c.Id=o.Cashier LEFT JOIN namestore n ON n.Id=o.NameStore WHERE PaymentTime>='" + StartTime+"' AND PaymentTime<='"+EndTime+ "' AND(o.State=2 OR o.State=4) GROUP BY OrderBH ;");
        }

        public DataTable SelectOrder15(string StartTime, string EndTime)
        {
            return my_sql.listTable("SELECT COUNT(0),SUM(PaymentAmount),p.PaymentMethod FROM `order` o LEFT JOIN paymentmethod p ON p.Id=o.PaymentMethod WHERE PaymentTime>='" + StartTime+"' AND PaymentTime<='"+EndTime+"' GROUP BY PaymentMethod");
        }

        public DataTable P_SelectOrder(string StartTime, string EndTime, int pageSize, int curPage)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentTime,s.State,p.PaymentMethod FROM `order` o left JOIN paymentmethod p ON p.id=o.PaymentMethod  LEFT JOIN state s on s.Id=o.State WHERE PaymentTime>='" + StartTime + "' AND PaymentTime<='" + EndTime + "' GROUP BY OrderBH Limit " + curPage * pageSize + "," + curPage + " ;");
        }

        public DataTable SelectOrder8(string StartTime, string EndTime)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentTime,s.State,p.PaymentMethod FROM `order` o left JOIN paymentmethod p ON p.id=o.PaymentMethod  LEFT JOIN state s on s.Id=o.State WHERE PaymentTime>='" + StartTime + "' AND PaymentTime<='" + EndTime + "' AND (s.Id=4 OR s.Id=2) GROUP BY OrderBH;");
        }

        public DataTable SelectOrder1(string StartTime)
        {
            return my_sql.listTable("SELECT SUM(AmountMoney) FROM `order` WHERE PaymentTime>='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Monday, 0).ToString() + "' AND PaymentTime<='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Sunday,1).ToString() + "';");
        }

        public DataTable SelectOrder6(string StartTime)
        {
            return my_sql.listTable("SELECT SUM(AmountMoney) FROM `order` WHERE PaymentTime>='" + DateTime.Parse(StartTime).AddDays(1 - DateTime.Parse(StartTime).Day) + "' AND PaymentTime<='" + DateTime.Parse(StartTime).AddMonths(1).AddDays(-DateTime.Parse(StartTime).Day) + "';");
        }

        public DataTable SelectOrder7()
        {
            return my_sql.listTable("SELECT IFNULL(SUM(PaymentAmount),0) FROM `order` WHERE PaymentTime>='" + DateTime.Now.Date.ToString() + "' AND PaymentTime<='" + DateTime.Now.Date.AddDays(1).ToString() + "' AND(State=2 OR State=4);");
        }

        public DataTable SelectOrder8(string StartTime)
        {
            return my_sql.listTable("SELECT SUM(1) FROM `order` WHERE PaymentTime>='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Monday, 0).ToString() + "' AND PaymentTime<='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Sunday, 1).AddDays(1).ToString() + "';");
        }

        public DataTable SelectOrder9(string StartTime)
        {
            return my_sql.listTable("SELECT SUM(1) FROM `order` WHERE PaymentTime>='" +DateTime.Parse(StartTime).AddDays(1- DateTime.Parse(StartTime).Day) + "' AND PaymentTime<='" + DateTime.Parse(StartTime).AddMonths(1).AddDays(-DateTime.Parse(StartTime).Day) + "';");
        }

        public DataTable SelectOrder10()
        {
            return my_sql.listTable("SELECT IFNULL(SUM(1),0) FROM `order` WHERE PaymentTime>='" + DateTime.Now.Date.ToString() + "' AND PaymentTime<='" + DateTime.Now.Date.AddDays(1).ToString() + "' AND(State=2 OR State=4);");
        }

        public DataTable SelectOrder11(string StartTime)
        {
            return my_sql.listTable("SELECT IFNULL(SUM(PaymentAmount),0) FROM `order` WHERE PaymentTime>='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Monday, 0).ToString() + "' AND PaymentTime<='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Sunday, 1).AddDays(1).ToString() + "' AND State=4;");
        }

        public DataTable SelectOrder12(string StartTime)
        {
            return my_sql.listTable("SELECT IFNULL(SUM(PaymentAmount),0) FROM `order` WHERE PaymentTime>='" + DateTime.Parse(StartTime).AddDays(1 - DateTime.Parse(StartTime).Day) + "' AND PaymentTime<='" + DateTime.Parse(StartTime).AddMonths(1).AddDays(- DateTime.Parse(StartTime).Day) + "' AND State=4;");
        }

        public DataTable SelectOrder13()
        {
            return my_sql.listTable("SELECT IFNULL(SUM(PaymentAmount),0) FROM `order` WHERE PaymentTime>='" + DateTime.Now.Date.ToString() + "' AND PaymentTime<='" + DateTime.Now.Date.AddDays(1).ToString() + "'  AND State=4;;");
        }

        public DataTable SelectOrder(string EndTime)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentTime,PaymentAmount,PreferentialAmount,s.State,p.PaymentMethod,pa.PaymentTerminal,c.Cashier,n.NameStore FROM `order` o left JOIN paymentmethod p ON p.id=o.PaymentMethod  LEFT JOIN state s on s.Id=o.State LEFT JOIN paymentterminal pa ON pa.Id=o.PaymentTerminal LEFT JOIN Cashier c ON c.Id=o.Cashier LEFT JOIN namestore n ON n.Id=o.NameStore WHERE PaymentTime<='" + EndTime + "' GROUP BY OrderBH;");
        }

        public DataTable SelectOrder2(string StateTime)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentTime,PaymentAmount,PreferentialAmount,s.State,p.PaymentMethod,pa.PaymentTerminal,c.Cashier,n.NameStore FROM `order` o left JOIN paymentmethod p ON p.id=o.PaymentMethod  LEFT JOIN state s on s.Id=o.State LEFT JOIN paymentterminal pa ON pa.Id=o.PaymentTerminal LEFT JOIN Cashier c ON c.Id=o.Cashier LEFT JOIN namestore n ON n.Id=o.NameStore WHERE PaymentTime>='" + StateTime + "' GROUP BY OrderBH;");
        }

        public DataTable SelectOrder3(string OrderBH)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentMethod,PaymentTime,State FROM `OrderLIst` WHERE OrderBH='" + OrderBH + "' GROUP BY OrderBH;");
        }

        public DataTable SelectOrder4(string PaymentMethod)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentMethod,PaymentTime,State FROM `OrderLIst` WHERE PaymentMethod='" + PaymentMethod + "' GROUP BY OrderBH;");
        }

        public DataTable SelectOrder5(string StateTime, string EndTime, string Cashier)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentMethod,PaymentTime,State FROM `OrderLIst` WHERE  PaymentTime>='" + StateTime + "' AND PaymentTime<='" + EndTime + "'AND  Cashier='" + Cashier + "' GROUP BY OrderBH;");
        }



        public DateTime GetWeekUpOfDate(DateTime dt, DayOfWeek weekday, int Number)
        {
            int wd1 = (int)weekday;
            int wd2 = (int)dt.DayOfWeek;
            return wd2 == wd1 ? dt.AddDays(7 * Number) : dt.AddDays(7 * Number - wd2 + wd1);
        }
    }
}
