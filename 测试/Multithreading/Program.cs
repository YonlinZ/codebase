using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var url = "https://www.google.com/";

            Console.WriteLine(url);
            Task task = WriteWebRequestSizeAsync(url);

            try
            {
                while (!task.Wait(100))
                {
                    Console.Write(".");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.ReadKey();
        }

        private static Task WriteWebRequestSizeAsync(string url)
        {
            StreamReader reader = null;
            WebRequest webRequest = WebRequest.Create(url);

            Task task = webRequest.GetResponseAsync()
                .ContinueWith(antecedent =>
                {
                    WebResponse response = antecedent.Result;
                    reader = new StreamReader(response.GetResponseStream());
                    return reader.ReadToEndAsync();
                })
                .Unwrap()
                .ContinueWith(antecedent =>
                {
                    reader?.Dispose();
                    string text = antecedent.Result;
                    Console.WriteLine();
                    Console.WriteLine(FormatBytes(text.Length));
                });

            return task;
        }

        public static string FormatBytes(long bytes)
        {
            string[] arr = { "GB", "MB", "KB", "Bytes" };
            long max = (long)Math.Pow(1024, arr.Length);
            return string.Format("{1:##.##} {0}", arr.FirstOrDefault(t => bytes > (max /= 1024)) ?? "0 Bytes", (decimal)bytes / (decimal)max);
        }
    }
}
