using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighPrecisionTimer
{
    class Program
    {
        static HighPrecisionTimer m;
        static int counter;
        static void Main(string[] args)
        {
            counter = 0;
            m = new HighPrecisionTimer(100, 1000, 1, fun);
            m.Open();

            Console.ReadLine();
        }
        private static void fun(object sender, long JumpPeriod, long interval)
        {
            counter++;
            Console.WriteLine(DateTime.Now.Ticks.ToString() +$"   interval: {interval}");
            //Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff")+$"   interval: {interval}");
            if (counter == 1000)
            {
                m.Dispose();
            }
        }
    }
}
