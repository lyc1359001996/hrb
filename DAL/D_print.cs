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
           return my_sql.listTable("SELECT n.NameStore,c.Cashier,o.OrderBH,pm.PaymentMethod,s.State,pl.PaymentTerminal,o.PaymentTime,o.AmountMoney,o.PreferentialAmount FROM `order` o LEFT JOIN namestore n ON o.NameStore=n.Id LEFT JOIN cashier c ON o.Cashier=c.Id LEFT JOIN paymentmethod pm ON o.PaymentMethod=pm.Id LEFT JOIN state s ON o.State=s.Id LEFT JOIN paymentterminal pl ON o.PaymentTerminal=pl.Id WHERE OrderBH='" + OrderBH+"' GROUP BY OrderBH;");
        }
    }
}
