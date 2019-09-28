using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thsoft_core;

namespace DXApplication2.DAL
{
    class D_paymentmethod
    {
        public DataTable Fill()
        {
            return my_sql.listTable("SELECT PaymentMethod,scope FROM paymentmethod;");
        }
    }
}
