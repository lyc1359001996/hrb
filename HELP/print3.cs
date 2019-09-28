using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;


namespace CustomPrint
{
    public static class PrintOrder
    {
        private static PrintDocument printDocument;


        private static Order printOrder;


        private static object lockObj;
        /// <summary>
        /// 设置打印纸高 
        /// </summary>
        public static int pageHeight = 350;


        /// <summary>
        /// 设置打印纸宽
        /// </summary>
        public static int pageWidth = 320;


        public static StringFormat sf;


        static PrintOrder()
        {
            sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
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
                Draw(e.Graphics, printOrder);
            }
            catch (Exception ex)
            {


            }
        }


        private static void PrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {


        }


        private static void PrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {


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
                Rectangle drawRect = new Rectangle(0, tempList[i].DrawHeight, pageWidth, tempList[i].DrawFont.Height);
                g.DrawString(tempList[i].Context, tempList[i].DrawFont, tempList[i].DrawBrush, drawRect, sf);
            }
        }


        public static Bitmap GetBmp(Order order)
        {
            Bitmap bmp = new Bitmap(pageWidth, pageHeight);
            Graphics g = Graphics.FromImage(bmp);
            Draw(g, order);
            g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
            return bmp;
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
                    //MessageBox.Show(ex.Message);
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