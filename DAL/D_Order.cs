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
            return my_sql.updateSql("INSERT INTO `order` (`OrderBH`, `PaymentAmount`, `PreferentialAmount`, `AmountMoney`, `PaymentMethod`, `State`, `PaymentTime`, `NameStore`, `Cashier`, `PaymentTerminal`, `OrderRemarks`) VALUES ('"+OrderBH+"', '"+PaymentAmount+"', '"+ PreferentialAmount + "', '"+ AmountMoney + "', '"+ PaymentMethod + "', '"+ State + "', '"+ PaymentTime + "', '"+ NameStore + "', '"+ Cashier + "', '"+ PaymentTerminal + "', '"+ PaymentTerminal + "')");
        }

        public DataTable SelectOrder(string Cashier, string StartTime,string EndTime,string PaymentMethod,string OrderBH)
        {
           return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentMethod,State,PaymentTime FROM `OrderLIst` WHERE PaymentTime>='" + StartTime+"' AND PaymentTime<='"+EndTime+ "'AND Cashier='"+Cashier+"' AND PaymentMethod='"+PaymentMethod+"' AND OrderBH='"+OrderBH+ "' GROUP BY OrderBH;;");
        }

        public DataTable SelectOrder(string StartTime, string EndTime, string PaymentMethod, string OrderBH)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentMethod,State,PaymentTime FROM `OrderLIst` WHERE PaymentTime>='" + StartTime + "' AND PaymentTime<='" + EndTime + "' AND PaymentMethod='" + PaymentMethod + "' AND OrderBH='" + OrderBH + "' GROUP BY OrderBH;;");
        }

        public DataTable SelectOrder(string StartTime, string EndTime,string OrderBH)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentMethod,State,PaymentTime FROM `OrderLIst` WHERE PaymentTime>='" + StartTime + "' AND PaymentTime<='" + EndTime+ "' AND OrderBH='" + OrderBH + "' GROUP BY OrderBH;;");
        }

        public DataTable SelectOrder(string StartTime, string EndTime)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentMethod,PaymentTime,State FROM `OrderLIst` WHERE PaymentTime>='"+StartTime+"' AND PaymentTime<='"+EndTime+"' GROUP BY OrderBH;");
        }
        
        public DataTable SelectOrder1(string StartTime)
        {
            return my_sql.listTable("SELECT SUM(AmountMoney) FROM `order` WHERE PaymentTime>='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Monday, 0).ToString() + "' AND PaymentTime<='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Sunday,1).ToString() + "';");
        }

        public DataTable SelectOrder6(string StartTime)
        {
            return my_sql.listTable("SELECT SUM(AmountMoney) FROM `order` WHERE PaymentTime>='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Monday, 0).ToString() + "' AND PaymentTime<='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Sunday, 6).AddDays(1).ToString() + "';");
        }

        public DataTable SelectOrder7(string StartTime)
        {
            return my_sql.listTable("SELECT IFNULL(SUM(AmountMoney),0) FROM `order` WHERE PaymentTime>='" + DateTime.Now.ToString() + "' AND PaymentTime<='" + DateTime.Now.AddDays(1).ToString() + "';");
        }

        public DataTable SelectOrder8(string StartTime)
        {
            return my_sql.listTable("SELECT SUM(1) FROM `order` WHERE PaymentTime>='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Monday, 0).ToString() + "' AND PaymentTime<='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Sunday, 1).AddDays(1).ToString() + "';");
        }

        public DataTable SelectOrder9(string StartTime)
        {
            return my_sql.listTable("SELECT SUM(1) FROM `order` WHERE PaymentTime>='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Monday, 0).ToString() + "' AND PaymentTime<='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Sunday, 6).AddDays(1).ToString() + "';");
        }

        public DataTable SelectOrder10(string StartTime)
        {
            return my_sql.listTable("SELECT IFNULL(SUM(1),0) FROM `order` WHERE PaymentTime>='" + DateTime.Now.ToString() + "' AND PaymentTime<='" + DateTime.Now.AddDays(1).ToString() + "';");
        }

        public DataTable SelectOrder11(string StartTime)
        {
            return my_sql.listTable("SELECT IFNULL(SUM(State),0) FROM `order` WHERE PaymentTime>='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Monday, 0).ToString() + "' AND PaymentTime<='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Sunday, 1).AddDays(1).ToString() + "' AND State=3;");
        }

        public DataTable SelectOrder12(string StartTime)
        {
            return my_sql.listTable("SELECT IFNULL(SUM(State),0) FROM `order` WHERE PaymentTime>='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Monday, 0).ToString() + "' AND PaymentTime<='" + GetWeekUpOfDate(Convert.ToDateTime(StartTime), DayOfWeek.Sunday, 1).AddDays(6).ToString() + "' AND State=3;");
        }

        public DataTable SelectOrder13(string StartTime)
        {
            return my_sql.listTable("SELECT IFNULL(SUM(State),0) FROM `order` WHERE PaymentTime>='" + DateTime.Now.ToString() + "' AND PaymentTime<='" + DateTime.Now.AddDays(1).ToString() + "' AND State=3;");
        }

        public DataTable SelectOrder(string EndTime)
        {
            Console.WriteLine("SELECT OrderBH,AmountMoney,PaymentMethod,PaymentTime,State FROM `OrderLIst` WHERE PaymentTime<='" + EndTime + "' GROUP BY OrderBH;");
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentMethod,PaymentTime,State FROM `OrderLIst` WHERE PaymentTime<='" + EndTime + "' GROUP BY OrderBH;");
        }

        public DataTable SelectOrder2(string StateTime)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentMethod,PaymentTime,State FROM `OrderLIst` WHERE PaymentTime>='" + StateTime + "' GROUP BY OrderBH;");
        }

        public DataTable SelectOrder3(string OrderBH)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentMethod,PaymentTime,State FROM `OrderLIst` WHERE OrderBH='" + OrderBH + "' GROUP BY OrderBH;");
        }

        public DataTable SelectOrder4(string PaymentMethod)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentMethod,PaymentTime,State FROM `OrderLIst` WHERE PaymentMethod='" + PaymentMethod + "' GROUP BY OrderBH;");
        }

        public DataTable SelectOrder5(string Cashier)
        {
            return my_sql.listTable("SELECT OrderBH,AmountMoney,PaymentMethod,PaymentTime,State FROM `OrderLIst` WHERE Cashier='" + Cashier + "' GROUP BY OrderBH;");
        }

        public DateTime GetWeekUpOfDate(DateTime dt, DayOfWeek weekday, int Number)
        {
            int wd1 = (int)weekday;
            int wd2 = (int)dt.DayOfWeek;
            return wd2 == wd1 ? dt.AddDays(7 * Number) : dt.AddDays(7 * Number - wd2 + wd1);
        }
    }
}
