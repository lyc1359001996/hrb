using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomPrint
{
    public static class PrintOrder
    {
        private static PrintDocument printDocument;


        private static Order printOrder;


        private static object lockObj;
        public static int pageHeight = 450;
        public static int pageWidth = 420;


        public static StringFormat sf;


        static PrintOrder()
        {
            sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            lockObj = new object();
            printDocument = new System.Drawing.Printing.PrintDocument();
            printDocument.BeginPrint += PrintDocument_BeginPrint;
            printDocument.EndPrint += PrintDocument_EndPrint;
            printDocument.PrintPage += PrintDocument_PrintPage;
        }


        private static void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                if (!System.IO.File.Exists(@"F:\桌面\hrb0917\hrb\bin\Debug\11111.jpg"))
                {
                    Draw1(e.Graphics, printOrder);
                }
                else
                {
                    Draw(e.Graphics, printOrder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(ex.Message);
            }
        }


        private static void PrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {


        }


        private static void PrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {


        }


        private static void Draw1(Graphics g, Order order)
        {
            List<PrintRow> tempList = order.PrintRows.OrderBy(p => p.PrintIndex).ToList();
            for (int i = 0; i < tempList.Count; i++)
            {
                //Rectangle drawRect = new Rectangle(0, tempList[i].DrawHeight, pageWidth, tempList[i].DrawFont.Height);
                //g.DrawString(tempList[i].Context, tempList[i].DrawFont, tempList[i].DrawBrush, drawRect, sf);
                Rectangle drawRect = new Rectangle(0, tempList[i].DrawHeight, pageWidth, pageHeight);
                g.DrawString(tempList[i].Context, tempList[i].DrawFont, tempList[i].DrawBrush, drawRect, sf);
                //g.DrawImage(Image.FromFile(Application.StartupPath + @"\11111.jpg"), 15, 260, 200, 200);
            }
        }

        /// <summary>
        /// 绘制打印的过程
        /// </summary>
        /// <param name="g">打印机g</param>
        /// <param name="order">订单</param>
        private static void Draw(Graphics g, Order order)
        {
            List<PrintRow> tempList = order.PrintRows.OrderBy(p => p.PrintIndex).ToList();
            for (int i = 0; i < tempList.Count; i++)
            {
                Rectangle drawRect = new Rectangle(0, tempList[i].DrawHeight, 340, pageHeight);
                g.DrawString(tempList[i].Context, tempList[i].DrawFont, tempList[i].DrawBrush, drawRect, sf);
                g.DrawImage(Image.FromFile(Application.StartupPath + @"\11111.jpg"), 15, 260,170,170);
                System.IO.File.Delete(Application.StartupPath + @"\11111.jpg");
            }
        }

        public static void Print(string printName, Order order)
        {
            lock (lockObj)
            {
                try
                {
                    printOrder = order;
                    printDocument.DefaultPageSettings.PaperSize = new PaperSize("Custom", pageWidth, pageHeight);
                    printDocument.PrinterSettings.PrinterName = printName;
                    printDocument.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(ex.Message);
                }
            }
        }




        public static void Print(Order order)
        {
            lock (lockObj)
            {
                try
                {
                    printOrder = order;
                    //printDocument.DocumentName = order.HeardInfo.OrderNum;
                    printDocument.DefaultPageSettings.PaperSize = new PaperSize("Custom", pageWidth, pageHeight);
                    printDocument.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("当前网络状态不佳，请检查网络。"); Log4NetHelper.WriteErrorLog(ex.Message);
                }
            }
        }


        /// <summary>
        /// 将CM转换成打印像素
        /// </summary>
        /// <param name="cmValue"></param>
        /// <returns></returns>
        public static int ConvertCmToPrintPixel(float cmValue)
        {
            return PrinterUnitConvert.Convert((int)(cmValue * 100), PrinterUnit.TenthsOfAMillimeter, PrinterUnit.Display);
        }
    }
}