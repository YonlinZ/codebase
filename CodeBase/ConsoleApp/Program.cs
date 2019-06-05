using CommonMethods;
using System;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var userName = "admin";
            var password = "123456";
            int i = 1;
            if (i == 1)
            {
                if (FTPreload.Download(@"ftp://192.168.1.142:21/", @"", @"F:\FTPtest\download\", "LaoMaoTao_v9.5_1811.zip", userName, password))
                {
                    Console.WriteLine("success");
                }
            }
            else
            {
                System.IO.FileInfo fileInfo = null;
                try
                {
                    fileInfo = new System.IO.FileInfo(@"F:\FTPtest\download\LaoMaoTao_v9.5_1811.zip");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    // 其他处理异常的代码
                }

                if (FTPreload.RestartDownloadFromServer(@"F:\FTPtest\download\LaoMaoTao_v9.5_1811.zip"
                    , new Uri(@"ftp://192.168.1.142:21/LaoMaoTao_v9.5_1811.zip"), fileInfo.Length, userName, password))
                {
                    Console.WriteLine("success");
                }
            }

            Console.ReadKey();
        }
    }
}
