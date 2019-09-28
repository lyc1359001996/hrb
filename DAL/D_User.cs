using Common.Utilities;
using SISS_thsoft;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thsoft_core;

namespace DXApplication2.DAL
{
    class D_User
    {
        EncryptionSHA1 e = new EncryptionSHA1();
        public int Upd_Pwd(string Old, string New, string UserId)
        {
            return my_sql.updateSql("UPDATE `user` SET `PassWord`='" + e.MD5E(New) + "' WHERE (`UserId`='" + UserId + "' and PassWord='" + e.MD5E(Old) + "');");
        }
        public int Upd_NameStore(int NameStore, string UserId)
        {
            return my_sql.updateSql("UPDATE `user` SET `NameStore`='" + NameStore + "' WHERE (`UserId`='" + UserId + "');");
        }
        public int Login(string UserId, string PassWord)
        {
            if (PassWord.Length!=32)
            {
                return int.Parse(my_sql.listTable("SELECT COUNT(1) FROM `user` WHERE BINARY `UserID`='" + UserId + "' AND `PassWord`='" +e.MD5E( PassWord )+ "';").Rows[0][0].ToString());
            }else
            {
                return int.Parse(my_sql.listTable("SELECT COUNT(1) FROM `user` WHERE BINARY `UserID`='" + UserId + "' AND `PassWord`='" +e.MD5E(PassWord) + "';").Rows[0][0].ToString());
            }
        }

        public DataTable Select(string name)
        {
            return my_sql.listTable("SELECT NameStore,UserId,PassWord,UserName FROM user where UserId='"+name+"';");
        }

        public DataTable Select1(string NameStore)
        {
            return my_sql.listTable("SELECT NameStore FROM `namestore` WHERE id='" + NameStore + "';");
        }
    }
}
