using SevenZip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Zip
{
    class Program
    {
        static void Main(string[] args)
        {

            F2();
            Console.ReadLine();
        }

        static void F1()
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

        }
        static void F2()
        {
            //if (IntPtr.Size == 4)    //32位操作系统
            //{
            //    SevenZipCompressor.SetLibraryPath(AppDomain.CurrentDomain.BaseDirectory + @"zip\7z.dll"); //路径指向dll文件，此处dll放在与程序相同目录，以下相同。

            //}
            //else    //64位操作系统
            //{
            //    SevenZipCompressor.SetLibraryPath(AppDomain.CurrentDomain.BaseDirectory + @"zip\7z64.dll");
            //}
            //var path = @"F:\六盘山地地形云野外科学试验特种观测仪器数据格式说明及示例\西安华腾云雷达\示例\20200925\RAW_M";
            //DirectoryInfo folder = new DirectoryInfo(path);
            //var files = folder.GetFiles("*.zip").Select(file=>file.FullName).ToArray();
            //using (var tmp = new SevenZipExtractor(path))    //这里的全名称包含路径
            //{
            //    tmp.ExtractFiles("temp2", files);
            //}

        }
    }
}
