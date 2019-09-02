using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thsoft_core;

namespace DXApplication2.DAL
{
    class D_print
    {
        public DataTable fill(string OrderBH)
        {
           return my_sql.listTable("SELECT NameStore,Cashier,OrderBH,PaymentMethod,State,PaymentTerminal,PaymentTime,AmountMoney,PreferentialAmount FROM `OrderLIst` WHERE OrderBH='"+OrderBH+"' GROUP BY OrderBH;");
        }
    }
}
