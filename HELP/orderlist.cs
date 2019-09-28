using Common.Utility;
using DXApplication2.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXApplication2.HELP
{
    class orderlist
    {
        public static DataTable toTatable(string json)
        {
                orderLIst order = new orderLIst();
                DataTable table = new DataTable();
                DataColumn dc1 = new DataColumn("orderNumber", Type.GetType("System.String"));
                DataColumn dc2 = new DataColumn("orderAmount", Type.GetType("System.Decimal"));
                DataColumn dc3 = new DataColumn("discountAmount", Type.GetType("System.Decimal"));
                DataColumn dc4 = new DataColumn("realPayAmount", Type.GetType("System.Decimal"));
                DataColumn dc5 = new DataColumn("status", Type.GetType("System.String"));
                DataColumn dc6 = new DataColumn("storeName", Type.GetType("System.String"));
                DataColumn dc7 = new DataColumn("userName", Type.GetType("System.String"));
                DataColumn dc8 = new DataColumn("type", Type.GetType("System.String"));
                DataColumn dc9 = new DataColumn("channel", Type.GetType("System.Int32"));
                DataColumn dc10 = new DataColumn("createTime", Type.GetType("System.String"));
                DataColumn dc11 = new DataColumn("refundAmount", Type.GetType("System.Decimal"));
                DataColumn dc12 = new DataColumn("refundTime", Type.GetType("System.String"));
                DataColumn dc13 = new DataColumn("payTime", Type.GetType("System.String"));
                DataColumn dc14 = new DataColumn("terminal", Type.GetType("System.String"));
                table.Columns.Add(dc1);
                table.Columns.Add(dc2);
                table.Columns.Add(dc3);
                table.Columns.Add(dc4);
                table.Columns.Add(dc5);
                table.Columns.Add(dc6);
                table.Columns.Add(dc7);
                table.Columns.Add(dc8);
                table.Columns.Add(dc9);
                table.Columns.Add(dc10);
                table.Columns.Add(dc11);
                table.Columns.Add(dc12);
                table.Columns.Add(dc13);
                table.Columns.Add(dc14);
                string[] condition = { "}," };
                for (int i = 0; i < json.Split(condition, StringSplitOptions.RemoveEmptyEntries).Length; i++)
                {
                    DataRow dr = table.NewRow();
                    var order1 = json.Split(condition, StringSplitOptions.RemoveEmptyEntries)[i];
                    dr["orderNumber"] = order1.Split(',')[1].Split(':')[1];
                    dr["orderAmount"] = order1.Split(',')[2].Split(':')[1];
                    if (!order1.Split(',')[4].Split(':')[1].Replace("}", "").Equals("null"))
                    {
                        dr["discountAmount"] = order1.Split(',')[4].Split(':')[1];
                    }else
                    {
                        dr["discountAmount"] = 0.0m;
                    }
                    if (!order1.Split(',')[3].Split(':')[1].Replace("}", "").Equals("null"))
                    {
                     dr["realPayAmount"] = dr["realPayAmount"] = order1.Split(',')[3].Split(':')[1];
                    }else
                    {
                     dr["realPayAmount"] = 0.0m;
                    }
                    
                    if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 1) { dr["status"] = "支付成功"; } else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 2) { dr["status"] = "待支付"; }else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 3) { dr["status"] = "已退款"; }else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 4) { dr["status"] = "支付失败"; }else if (int.Parse(order1.Split(',')[6].Split(':')[1]) ==5) { dr["status"] = "部分退款"; }else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 6) { dr["status"] = "已关闭"; }else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 7) { dr["status"] = "未支付"; }else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 8) { dr["status"] = "退款失败"; }else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 9) { dr["status"] = "订单取消"; }
                    if (int.Parse(order1.Split(',')[7].Split(':')[1])==1) { dr["terminal"] = "PC"; }else if (int.Parse(order1.Split(',')[7].Split(':')[1]) == 2) { dr["terminal"] = "安卓"; }else if (int.Parse(order1.Split(',')[7].Split(':')[1]) == 3) { dr["terminal"] = "IOS"; }else if (int.Parse(order1.Split(',')[7].Split(':')[1]) == 4) { dr["terminal"] = "收银API"; }else if (int.Parse(order1.Split(',')[7].Split(':')[1]) == 5) { dr["terminal"] = "二维码"; }
                    dr["storeName"] = order1.Split(',')[10].Split(':')[1];
                    dr["userName"] = order1.Split(',')[9].Split(':')[1];
                    if (int.Parse(order1.Split(',')[5].Split(':')[1]) == 1) { dr["type"] = "微信"; } else { dr["type"] = "支付宝"; }
                    dr["channel"] = order1.Split(',')[8].Split(':')[1];
                    dr["createTime"] = order1.Split(',')[11].Split(':')[1]+ order1.Split(',')[11].Split(':')[2]+ order1.Split(',')[11].Split(':')[3];
                    if (!order1.Split(',')[13].Split(':')[1].Replace("}", "").Equals("null"))
                    {
                        dr["refundAmount"] = order1.Split(',')[13].Split(':')[1];
                    }else
                    {
                        dr["refundAmount"] = 0.0m;
                    }
                    if (!order1.Split(',')[14].Split(':')[1].Replace("}", "").Equals("null"))
                    {
                        dr["refundTime"] = order1.Split(',')[14].Split(':')[1]+":"+ order1.Split(',')[14].Split(':')[2]+":"+ order1.Split(',')[14].Split(':')[3];
                    }else
                    {
                        dr["refundTime"] = "";
                    }
                if (!order1.Split(',')[12].Split(':')[1].Equals("null"))
                {
                    dr["payTime"] = order1.Split(',')[12].Split(':')[1] + ":" + order1.Split(',')[12].Split(':')[2] + ":" + order1.Split(',')[12].Split(':')[3];
                }else
                {
                    dr["payTime"] = "";
                }
                    
                    table.Rows.Add(dr);
                }
            return table;
        }

        public static DataTable toTatable1(string json)
        {
            orderLIst order = new orderLIst();
            DataTable table = new DataTable();
            DataColumn dc1 = new DataColumn("orderNumber", Type.GetType("System.String"));//
            DataColumn dc4 = new DataColumn("orderAmount", Type.GetType("System.Decimal"));//
            DataColumn dc5 = new DataColumn("status", Type.GetType("System.String"));//
            DataColumn dc8 = new DataColumn("type", Type.GetType("System.String"));//
            DataColumn dc10 = new DataColumn("createTime", Type.GetType("System.String"));//
            table.Columns.Add(dc1);
            table.Columns.Add(dc4);
            table.Columns.Add(dc5);
            table.Columns.Add(dc8);
            table.Columns.Add(dc10);
            string[] condition = { "}," };
            if (json.Split(condition, StringSplitOptions.RemoveEmptyEntries).Length==5)
            {
                for (int i = 0; i < 5; i++)
                {
                    DataRow dr = table.NewRow();
                    var order1 = json.Split(condition, StringSplitOptions.RemoveEmptyEntries)[i];
                    dr["orderNumber"] = order1.Split(',')[1].Split(':')[1];
                    if (!order1.Split(',')[2].Split(':')[1].Replace("}", "").Equals("null"))
                    {
                        dr["orderAmount"] = dr["orderAmount"] = order1.Split(',')[2].Split(':')[1];
                    }
                    else
                    {
                        dr["orderAmount"] = 0.0m;
                    }
                    dr["type"] = order1.Split(',')[5].Split(':')[1];
                    if (int.Parse(order1.Split(',')[5].Split(':')[1]) == 1) { dr["type"] = "微信"; } else { dr["type"] = "支付宝"; }
                    if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 1) { dr["status"] = "支付成功"; } else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 2) { dr["status"] = "待支付"; } else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 3) { dr["status"] = "已退款"; } else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 4) { dr["status"] = "支付失败"; } else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 5) { dr["status"] = "部分退款"; } else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 6) { dr["status"] = "已关闭"; } else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 7) { dr["status"] = "未支付"; } else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 8) { dr["status"] = "退款失败"; } else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 9) { dr["status"] = "订单取消"; }
                    dr["createTime"] = order1.Split(',')[11].Split(':')[1] + ":" + order1.Split(',')[11].Split(':')[2] + ":" + order1.Split(',')[11].Split(':')[3];
                    table.Rows.Add(dr);
                }
            }else
            {
                for (int i = 0; i < json.Split(condition, StringSplitOptions.RemoveEmptyEntries).Length; i++)
                {
                    DataRow dr = table.NewRow();
                    var order1 = json.Split(condition, StringSplitOptions.RemoveEmptyEntries)[i];
                    dr["orderNumber"] = order1.Split(',')[1].Split(':')[1];
                    if (!order1.Split(',')[2].Split(':')[1].Replace("}", "").Equals("null"))
                    {
                        dr["orderAmount"] = dr["orderAmount"] = order1.Split(',')[2].Split(':')[1];
                    }
                    else
                    {
                        dr["orderAmount"] = 0.0m;
                    }
                    dr["type"] = order1.Split(',')[5].Split(':')[1];
                    if (int.Parse(order1.Split(',')[5].Split(':')[1]) == 1) { dr["type"] = "微信"; } else { dr["type"] = "支付宝"; }
                    if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 1) { dr["status"] = "支付成功"; } else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 2) { dr["status"] = "待支付"; } else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 3) { dr["status"] = "已退款"; } else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 4) { dr["status"] = "支付失败"; } else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 5) { dr["status"] = "部分退款"; } else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 6) { dr["status"] = "已关闭"; } else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 7) { dr["status"] = "未支付"; } else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 8) { dr["status"] = "退款失败"; } else if (int.Parse(order1.Split(',')[6].Split(':')[1]) == 9) { dr["status"] = "订单取消"; }
                    dr["createTime"] = order1.Split(',')[11].Split(':')[1] + ":" + order1.Split(',')[11].Split(':')[2] + ":" + order1.Split(',')[11].Split(':')[3];
                    table.Rows.Add(dr);
                }
            }
            
            return table;
        }
    }
}
