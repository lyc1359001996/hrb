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
        public int Upd_Pwd(string Old, string New, string UserId)
        {
            return my_sql.updateSql("UPDATE `user` SET `PassWord`='" + New + "' WHERE (`UserId`='" + UserId + "' and PassWord='" + Old + "');");
        }
        public int Upd_NameStore(int NameStore, string UserId)
        {
            return my_sql.updateSql("UPDATE `user` SET `NameStore`='" + NameStore + "' WHERE (`UserId`='" + UserId + "');");
        }
        public int Login(string UserId, string PassWord)
        {
            if (PassWord.Length!=32)
            {
                Console.WriteLine("SELECT COUNT(1) FROM `user` WHERE `UserID`='" + UserId + "' AND `PassWord`='" + PassWord + "';");
                return int.Parse(my_sql.listTable("SELECT COUNT(1) FROM `user` WHERE `UserID`='" + UserId + "' AND `PassWord`='" + PassWord + "';").Rows[0][0].ToString());
            }else
            {
                Console.WriteLine("SELECT COUNT(1) FROM `user` WHERE `UserID`='" + UserId + "' AND `PassWord`='" + EncryptionMD5.EncryptString(PassWord) + "';");
                return int.Parse(my_sql.listTable("SELECT COUNT(1) FROM `user` WHERE `UserID`='" + UserId + "' AND `PassWord`='" + EncryptionMD5.EncryptString(PassWord) + "';").Rows[0][0].ToString());
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
