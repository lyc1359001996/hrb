using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR
{
    interface ImageRecognitionInterface
    {

        /// <summary>
        /// 识别图像
        /// </summary>
        /// <param name="imgPath"></param>
        /// <returns></returns>
        string Recognize(string imgPath);
    }
}
