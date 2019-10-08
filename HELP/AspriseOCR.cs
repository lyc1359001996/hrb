using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OCR.ImageRecognition
{
        public class AspriseOCR:ImageRecognitionInterface
    {
        [DllImport("AspriseOCR.dll", EntryPoint = "OCR", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr OCR(string file, int type);

        [DllImport("AspriseOCR.dll", EntryPoint = "OCRpart", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr OCRpart(string file, int type, int startX, int startY, int width, int height);

        [DllImport("AspriseOCR.dll", EntryPoint = "OCRBarCodes", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr OCRBarCodes(string file, int type);

        [DllImport("AspriseOCR.dll", EntryPoint = "OCRpartBarCodes", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr OCRpartBarCodes(string file, int type, int startX, int startY, int width, int height);

        
        public string Recognize(string imgPath)
        {
            try
            {
                int startX = 0, startY = 0;
                Image image = Image.FromFile(imgPath);
                return Marshal.PtrToStringAnsi(OCRpart(imgPath, -1, startX, startY, image.Width, image.Height));
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex.Message);
            }
            return "";
        }
    }
}
