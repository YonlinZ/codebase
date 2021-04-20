using SevenZip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Zip
{
    class Program
    {
        static void Main(string[] args)
        {
            if (IntPtr.Size == 4)    //32位操作系统
            {
                SevenZipCompressor.SetLibraryPath(AppDomain.CurrentDomain.BaseDirectory + @"zip\7z.dll"); //路径指向dll文件，此处dll放在与程序相同目录，以下相同。

            }
            else    //64位操作系统
            {
                SevenZipCompressor.SetLibraryPath(AppDomain.CurrentDomain.BaseDirectory + @"zip\7z64.dll");
            }
            using (var tmp = new SevenZipExtractor("Z_RADA_I_Z0001_20200925000000_O_YCCR_HTKAA_RAW_M.BIN.zip"))    //这里的全名称包含路径
            {
                tmp.ExtractArchive("temp");
            }


            Console.ReadLine();
        }
    }
}
