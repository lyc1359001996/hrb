using CustomPrint;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication2.HELP
{
    class PrintOrder
    {
        private static PrintDocument printDocument;


        private static Order printOrder;


        private static object lockObj;
        /// <summary>
        /// 设置打印纸高 
        /// </summary>
        public static int pageHeight = 800;


        /// <summary>
        /// 设置打印纸宽
        /// </summary>
        public static int pageWidth = 300;


        public static StringFormat sf;

        static PrintOrder()
        {
            sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.FormatFlags= StringFormatFlags.LineLimit;
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
                e.Graphics.PageUnit = GraphicsUnit.Millimeter;
                Image image = Image.FromFile("E:/hrb/1.jpg");
                e.Graphics.DrawImage(image, new Rectangle(7,70, 30, 30));
                image.Dispose();
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
                    printOrder = order;
                    printDocument.DefaultPageSettings.PaperSize = new PaperSize("Custom", pageWidth, pageHeight);
                    printDocument.PrinterSettings.PrinterName = printName;
                    printDocument.Print();
            }
        }
    }
}
