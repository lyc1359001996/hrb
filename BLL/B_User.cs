using DXApplication2.DAL;
using DXApplication2.MODEL;
using SISS_thsoft;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thsoft_core;

namespace DXApplication2.BLL
{
    class B_User
    {
        DataTable dt = new DataTable();
        D_User D_User = new D_User();
        public bool login(string UserId,string PassWord)
        {
            if(D_User.Login(UserId, PassWord).Equals(0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Upd_Pwd(string Old, string New, string UserId)
        {
            if (D_User.Upd_Pwd(Old, New, UserId).Equals(0))
            {
                return false;
            }else
            {
                return true;
            }
        }

        public bool Upd_NameStore(int NameStore, string UserId)
        {
            if (D_User.Upd_NameStore(NameStore,UserId).Equals(0))
            {
                return false;
            }else
            {
                return true;
            }
        }

        public DataTable Select(string name)
        {
            return D_User.Select(name);
        }

        public DataTable Select1(string NameStore)
        {
            return D_User.Select1(NameStore);
        }
    }
}
