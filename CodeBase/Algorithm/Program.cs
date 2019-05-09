using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            LiteAlgorithm.F2(5682465217);
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine(sw.ElapsedTicks);
            Console.WriteLine();
            sw.Restart();
            LiteAlgorithm.F(5682465217);
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine(sw.ElapsedTicks);
            Console.ReadKey();
        }
    }
}
