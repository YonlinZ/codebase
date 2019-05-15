using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Algorithm.LeetCodeSeries;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //LiteAlgorithm.F2(5682465217);
            //sw.Stop();
            //Console.WriteLine();
            //Console.WriteLine(sw.ElapsedTicks);
            //Console.WriteLine();
            //sw.Restart();
            //LiteAlgorithm.F(5682465217);
            //sw.Stop();
            //Console.WriteLine();
            //Console.WriteLine(LiteAlgorithm.C(1, 9));

            //Console.WriteLine($"递归：{LiteAlgorithm.FrogJump(1)}");
            //Console.WriteLine();
            //Console.WriteLine($"常规：{LiteAlgorithm.FrogJump2(1)}");

            var l = new LeetCode128LongestConsecutiveSequence();
            int[] arr = {1,3,5,7,9,55,6,8,22,13,4,5,3,8,0,62,2,10};
            var length = l.LongestConsecutive(arr);


            Console.WriteLine(length);




            Console.ReadKey();
        }
    }
}
