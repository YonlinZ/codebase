using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEx
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = TaskExtension.TimeoutCancelTask(F);


            Console.WriteLine(result.Result);

            Console.ReadLine();

        }

        static int F()
        {
            System.Threading.Thread.Sleep(1 * 1000);
            return 100;
        }
    }
}
