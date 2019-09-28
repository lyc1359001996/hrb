using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using SISS_thsoft;

namespace thsoft_core
{
    class my_sql
    {
        public static String getconstr()
        {
            String constr = "";
           constr = "SERVER=192.168.0.119;DATABASE=hrb;PWD=abcd-1234;UID=root;Charset=utf8";
            return constr;
        }
        public static String getconstr2()
        {
            String constr = "";
            string cfgINI = @"config\set.ini";
            if (File.Exists(cfgINI))
            {
                IniFile ini = new IniFile(cfgINI);
                constr = "SERVER=" + ini.IniReadValue("mySqlCon", "ip") + ";DATABASE=sys_data;PWD=" + jiami.Decrypt(ini.IniReadValue("mySqlCon", "pwd")) + ";UID=" + ini.IniReadValue("mySqlCon", "username") + ";Charset=utf8";
            }
            return constr;
        }
        public static DataSet listVar( string sqlStr)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(getconstr());
            MySqlDataAdapter da = new MySqlDataAdapter(sqlStr, conn);
            da.Fill(ds, "tb");
            return ds;
        }
        public static DataTable listTable(string sqlStr)
        {
            DataSet ds = new DataSet();
            DataTable Dt = new DataTable();
            MySqlConnection conn = new MySqlConnection(getconstr());
            MySqlDataAdapter da = new MySqlDataAdapter(sqlStr, conn);
            da.Fill(ds, "tb");
            Dt = ds.Tables[0];
            return Dt;
        }
        public static DataTable listTable2(string sqlStr)
        {
            DataSet ds = new DataSet();
            DataTable Dt = new DataTable();
            MySqlConnection conn = new MySqlConnection(getconstr2());
            MySqlDataAdapter da = new MySqlDataAdapter(sqlStr, conn);
            da.Fill(ds, "tb");
            Dt = ds.Tables[0];
            return Dt;
        }
        public static int updateSql(string sqlStr)
        {
            int b = 0;
            MySqlConnection conn = new MySqlConnection(getconstr());
            MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
            conn.Open();
            b = cmd.ExecuteNonQuery();
            conn.Close();
            return b;
        }
        public static int updateSql2(string sqlStr)
        {
            int b = 0;
            MySqlConnection conn = new MySqlConnection(getconstr2());
            MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
            conn.Open();
            b = cmd.ExecuteNonQuery();
            conn.Close();
            return b;
        }
       
    }
}
