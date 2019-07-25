﻿using System;
using System.Collections;
using System.Diagnostics;
using Algorithm.LeetCodeSeries;

namespace Algorithm
{
    internal class Program
    {
        private static void Main(string[] args)
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

            //var l = new LeetCode128LongestConsecutiveSequence();
            //int[] arr = {1,3,5,7,9,55,6,8,22,13,4,5,3,8,0,62,2,10};
            //var length = l.LongestConsecutive(arr);





            //Console.WriteLine(LiteAlgorithm.Pow1(2, 60));
            //Console.WriteLine(LiteAlgorithm.Pow3(2, 60));

            //78267
            var arr = new[] { 1, 7, 7, 4, 3, 1, 7, 0, 1, 4, 4, 9, 2, 8, 5, 0, 0, 9, 3, 1, 2, 5, 9, 6, 0, 9, 9, 0, 9, 6, 0, 5, 3, 7, 9, 8, 8, 9, 8, 2, 5, 4, 1, 9, 3, 8, 0, 5, 9, 5, 6, 1, 1, 8, 9, 3, 7, 8, 5, 8, 5, 5, 3, 0, 4, 3, 1, 5, 4, 1, 7, 9, 6, 8, 8, 9, 8, 0, 6, 7, 8, 3, 1, 1, 1, 0, 6, 8, 1, 1, 6, 6, 9, 1, 8, 5, 6, 9, 0, 0, 1, 7, 1, 7, 7, 2, 8, 5, 4, 4, 5, 2, 9, 6, 5, 0, 8, 1, 0, 9, 5, 8, 7, 6, 0, 6, 1, 8, 7, 2, 9, 8, 1, 0, 7, 9, 4, 7, 6, 9, 2, 3, 1, 3, 9, 9, 6, 8, 0, 8, 9, 7, 7, 7, 3, 9, 5, 5, 7, 4, 9, 8, 3, 0, 1, 2, 1, 5, 0, 8, 4, 4, 3, 8, 9, 3, 7, 5, 3, 9, 4, 4, 9, 3, 3, 2, 4, 8, 9, 3, 3, 8, 2, 8, 1, 3, 2, 2, 8, 4, 2, 5, 0, 6, 3, 0, 9, 0, 5, 4, 1, 1, 8, 0, 4, 2, 5, 8, 2, 4, 2, 7, 5, 4, 7, 6, 9, 0, 8, 9, 6, 1, 4, 7, 7, 9, 7, 8, 1, 4, 4, 3, 6, 4, 5, 2, 6, 0, 1, 1, 5, 3, 8, 0, 9, 8, 8, 0, 0, 6, 1, 6, 9, 6, 5, 8, 7, 4, 8, 9, 9, 2, 4, 7, 7, 9, 9, 5, 2, 2, 6, 9, 7, 7, 9, 8, 5, 9, 8, 5, 5, 0, 3, 5, 8, 9, 5, 7, 3, 4, 6, 4, 6, 2, 3, 5, 2, 3, 1, 4, 5, 9, 3, 3, 6, 4, 1, 3, 3, 2, 0, 0, 4, 4, 7, 2, 3, 3, 9, 8, 7, 8, 5, 5, 0, 8, 3, 4, 1, 4, 0, 9, 5, 5, 4, 4, 9, 7, 7, 4, 1, 8, 7, 5, 2, 4, 9, 7, 9, 1, 7, 8, 9, 2, 4, 1, 1, 7, 6, 4, 3, 6, 5, 0, 2, 1, 4, 3, 9, 2, 0, 0, 2, 9, 8, 4, 5, 7, 3, 5, 8, 2, 3, 9, 5, 9, 1, 8, 8, 9, 2, 3, 7, 0, 4, 1, 1, 8, 7, 0, 2, 7, 3, 4, 6, 1, 0, 3, 8, 5, 8, 9, 8, 4, 8, 3, 5, 1, 1, 4, 2, 5, 9, 0, 5, 3, 1, 7, 4, 8, 9, 6, 7, 2, 3, 5, 5, 3, 9, 6, 9, 9, 5, 7, 3, 5, 2, 9, 9, 5, 5, 1, 0, 6, 3, 8, 0, 5, 5, 6, 5, 6, 4, 5, 1, 7, 0, 6, 3, 9, 4, 4, 9, 1, 3, 4, 7, 7, 5, 8, 2, 0, 9, 2, 7, 3, 0, 9, 0, 7, 7, 7, 4, 1, 2, 5, 1, 3, 3, 6, 4, 8, 2, 5, 9, 5, 0, 8, 2, 5, 6, 4, 8, 8, 8, 7, 3, 1, 8, 5, 0, 5, 2, 4, 8, 5, 1, 1, 0, 7, 9, 6, 5, 1, 2, 6, 6, 4, 7, 0, 9, 5, 6, 9, 3, 7, 8, 8, 8, 6, 5, 8, 3, 8, 5, 4, 5, 8, 5, 7, 5, 7, 3, 2, 8, 7, 1, 7, 1, 8, 7, 3, 3, 6, 2, 9, 3, 3, 9, 3, 1, 5, 1, 5, 5, 8, 1, 2, 7, 8, 9, 2, 5, 4, 5, 4, 2, 6, 1, 3, 6, 0, 6, 9, 6, 1, 0, 1, 4, 0, 4, 5, 5, 8, 2, 2, 6, 3, 4, 3, 4, 3, 8, 9, 7, 5, 5, 9, 1, 8, 5, 9, 9, 1, 8, 7, 2, 1, 1, 8, 1, 5, 6, 8, 5, 8, 0, 2, 4, 4, 7, 8, 9, 5, 9, 8, 0, 5, 0, 3, 5, 5, 2, 6, 8, 3, 4, 1, 4, 7, 1, 7, 2, 7, 5, 8, 8, 7, 2, 2, 3, 9, 2, 2, 7, 3, 2, 9, 0, 2, 3, 6, 9, 7, 2, 8, 0, 8, 1, 6, 5, 2, 3, 0, 2, 0, 0, 0, 9, 2, 2, 2, 3, 6, 6, 0, 9, 1, 0, 0, 3, 5, 8, 3, 2, 0, 3, 5, 1, 4, 1, 6, 8, 7, 6, 0, 9, 8, 0, 1, 0, 4, 5, 6, 0, 2, 8, 2, 5, 0, 2, 8, 5, 2, 3, 0, 2, 6, 7, 3, 0, 0, 2, 1, 9, 0, 1, 9, 9, 2, 0, 1, 6, 7, 7, 9, 9, 6, 1, 4, 8, 5, 5, 6, 7, 0, 6, 1, 7, 3, 5, 9, 3, 9, 0, 5, 9, 2, 4, 8, 6, 6, 2, 2, 3, 9, 3, 5, 7, 4, 1, 6, 9, 8, 2, 6, 9, 0, 0, 8, 5, 7, 7, 0, 6, 0, 5, 7, 4, 9, 6, 0, 7, 8, 4, 3, 9, 8, 8, 7, 4, 1, 5, 6, 0, 9, 4, 1, 9, 4, 9, 4, 1, 8, 6, 7, 8, 2, 5, 2, 3, 3, 4, 3, 3, 1, 6, 4, 1, 6, 1, 5, 7, 8, 1, 9, 7, 6, 0, 8, 0, 1, 4, 4, 0, 1, 1, 8, 3, 8, 3, 8, 3, 9, 1, 6, 0, 7, 1, 3, 3, 4, 9, 3, 5, 2, 4, 2, 0, 7, 3, 3, 8, 7, 7, 8, 8, 0, 9, 3, 1, 2, 2, 4, 3, 3, 3, 6, 1, 6, 9, 6, 2, 0, 1, 7, 5, 6, 2, 5, 3, 5, 0, 3, 2, 7, 2, 3, 0, 3, 6, 1, 7, 8, 7, 0, 4, 0, 6, 7, 6, 6, 3, 9, 8, 5, 8, 3, 3, 0, 9, 6, 7, 1, 9, 2, 1, 3, 5, 1, 6, 3, 4, 3, 4, 1, 6, 8, 4, 2, 5 };




            var arr2 = new[] { 5, 7, 0, 6, 0, 2, 6, 7, 6, 1, 0, 8, 1, 3, 6, 6, 7, 7, 7, 0, 1, 4, 0, 1, 1, 0, 7, 9, 8, 9, 9, 8, 6, 1, 4, 6, 3, 0, 3, 2, 4, 5, 0, 5, 8, 8, 3, 7, 5, 3, 8, 8, 7, 8, 9, 0, 1, 6, 1, 9, 7, 3, 9, 5, 4, 4, 3, 8, 6, 6, 2, 2, 3, 2, 9, 4, 2, 3, 1, 7, 6, 9, 7, 5, 0, 6, 8, 1, 4, 9, 2, 4, 4, 1, 9, 9, 5, 3, 9, 4, 1, 1, 6, 5, 5, 6, 9, 7, 1, 2, 6, 9, 4, 3, 6, 4, 1, 4, 7, 7, 6, 9, 1, 0, 0, 1, 1, 6, 6, 0, 2, 7, 3, 8, 2, 8, 4, 3, 7, 7, 8, 5, 6, 2, 0, 3, 6, 1, 9, 3, 1, 7, 2, 2, 0, 4, 5, 1, 2, 1, 4, 4, 1, 7, 3, 3, 8, 9, 9, 5, 7, 7, 3, 3, 9, 3, 8, 7, 7, 8, 2, 8, 5, 4, 2, 5, 8, 8, 9, 3, 1, 3, 7, 2, 0, 0, 8, 8, 0, 9, 6, 9, 8, 9, 4, 7, 4, 3, 6, 1, 3, 8, 9, 8, 4, 4, 6, 4, 2, 5, 7, 5, 0, 5, 0, 0, 7, 8, 1, 9, 9, 9, 8, 7, 0, 3, 6, 6, 8, 2, 8, 1, 2, 9, 1, 6, 3, 7, 0, 7, 4, 0, 3, 4, 5, 3, 7, 4, 3, 0, 4, 2, 1, 2, 1, 3, 7, 7, 9, 5, 9, 7, 8, 3, 7, 0, 9, 2, 9, 1, 0, 4, 1, 5, 0, 8, 8, 9, 3, 3, 1, 7, 7, 2, 1, 8, 7, 1, 5, 7, 8, 6, 6, 7, 9, 5, 7, 0, 8, 6, 1, 8, 2, 5, 3, 5, 3, 3, 6, 6, 8, 8, 5, 5, 2, 9, 5, 0, 0, 2, 9, 0, 8, 5, 7, 9, 1, 6, 9, 9, 5, 2, 9, 9, 7, 4, 4, 1, 9, 1, 9, 7, 1, 7, 4, 3, 8, 9, 5, 8, 1, 4, 8, 1, 0, 8, 2, 3, 6, 1, 2, 1, 5, 3, 1, 3, 7, 5, 6, 6, 8, 5, 5, 9, 4, 9, 5, 2, 0, 2, 2, 1, 7, 3, 4, 9, 1, 6, 4, 7, 9, 6, 1, 4, 1, 2, 7, 8, 9, 3, 6, 0, 1, 1, 9, 7, 0, 6, 0, 0, 9, 4, 3, 8, 7, 9, 9, 0, 5, 3, 0, 6, 1, 1, 0, 2, 5, 0, 0, 4, 5, 6, 4, 8, 7, 6, 6, 9, 4, 8, 1, 3, 2, 6, 3, 2, 5, 2, 2, 2, 5, 4, 8, 6, 5, 8, 8, 2, 0, 0, 7, 6, 6, 3, 4, 5, 1, 2, 6, 8, 0, 7, 3, 5, 5, 7, 9, 0, 9, 1, 2, 5, 8, 2, 3, 5, 3, 4, 8, 3, 4, 7, 9, 3, 2, 6, 0, 6, 8, 7, 4, 1, 6, 7, 6, 2, 4, 7, 2, 4, 8, 7, 1, 8, 9, 6, 4, 2, 0, 2, 8, 5, 1, 7, 0, 3, 5, 0, 9, 4, 7, 3, 7, 6, 1, 3, 8, 7, 0, 2, 3, 0, 9, 6, 1, 1, 3, 5, 5, 5, 9, 3, 2, 0, 3, 2, 3, 8, 3, 5, 2, 2, 8, 9, 8, 1, 4, 6, 9, 6, 1, 4, 9, 0, 1, 0, 3, 6, 7, 9, 1, 6, 2, 4, 8, 5, 6, 3, 6, 1, 8, 0, 4, 7, 2, 2, 0, 6, 1, 1, 5, 2, 6, 6, 4, 9, 8, 8, 5, 7, 9, 6, 5, 1, 0, 3, 9, 9, 6, 7, 0, 5, 7, 4, 4, 9, 9, 4, 8, 2, 6, 5, 4, 4, 1, 0, 3, 1, 8, 8, 8, 7, 4, 3, 1, 7, 8, 2, 6, 4, 9, 6, 1, 6, 3, 5, 6, 2, 2, 6, 6, 8, 1, 0, 2, 2, 0, 7, 5, 1, 5, 3, 8, 1, 8, 1, 8, 6, 3, 6, 2, 4, 5, 4, 1, 8, 1, 9, 2, 3, 5, 8, 1, 8, 0, 5, 2, 2, 2, 7, 3, 9, 2, 4, 1, 0, 5, 1, 8, 1, 8, 0, 5, 3, 6, 8, 3, 8, 9, 7, 1, 6, 7, 5, 4, 9, 2, 6, 1, 7, 3, 7, 8, 5, 1, 9, 7, 8, 1, 5, 1, 1, 8, 9, 6, 6, 7, 1, 4, 9, 8, 8, 5, 7, 5, 0, 6, 9, 6, 9, 8, 2, 6, 7, 9, 7, 6, 7, 8, 9, 4, 9, 2, 4, 8, 8, 1, 8, 9, 7, 7, 9, 7, 2, 8, 4, 4, 6, 4, 3, 6, 4, 5, 4, 1, 4, 4, 0, 3, 2, 9, 0, 1, 2, 4, 2, 2, 7, 0, 2, 7, 7, 3, 4, 1, 2, 9, 6, 8, 5, 9, 6, 9, 6, 1, 3, 0, 5, 3, 6, 7, 4, 6, 0, 8, 2, 2, 1, 2, 4, 5, 9, 3, 8, 3, 5, 0, 4, 3, 1, 1, 2, 7, 3, 8, 8, 6, 0, 5, 9, 8, 2, 5, 6, 5, 4, 9, 9, 5, 1, 4, 0, 2, 9, 0, 7, 4, 3, 4, 7, 4, 5, 1, 3, 8, 1, 2, 6, 2, 7, 7, 0, 2, 3, 9, 9, 7, 8, 0, 4, 1, 4, 6, 5, 4, 6, 2, 0, 1, 6, 0, 5, 4, 1, 9, 2, 3, 3, 1, 7, 2, 8, 9, 6, 1, 8, 7, 0, 6, 8, 6, 9, 4, 2, 4, 0, 1, 9, 1, 2, 5, 1, 0, 9, 4, 1, 4, 7, 6, 5, 4, 8, 5, 4, 7, 9, 2, 4, 1, 1, 2, 8, 2, 9, 2, 9, 9, 3, 8, 0, 8, 5, 3, 0, 5, 8, 1, 1, 7, 9, 8, 2, 9, 3, 8, 6, 4, 2, 3, 6, 5 };
            var arr3 = new[] {1};
            var arr4 = new[] { 1,0 };

            var arr5 = new[] { 1 ,2,3};

            //Console.WriteLine(LeetCode372SuperPow.MySuperPow(200000, arr));

            //Console.WriteLine(LeetCode372SuperPow.SuperPow (200000, arr));
            //Console.WriteLine(LeetCode372SuperPow.SuperPow2(200000, arr));

            //Console.WriteLine(LeetCode372SuperPow.SuperPow3(2, arr3));
            //Console.WriteLine(LeetCode372SuperPow.SuperPow3(2, arr4));

            //Console.WriteLine(LeetCode372SuperPow.SuperPow3(2, arr5));



            ////Console.WriteLine(LiteAlgorithm.PowMod(2000, 9999999, 1337));
            ////int i = 1000000000;
            //long i2 = 1000000000000000000L;

            //LiteAlgorithm.PrimeFactorization(1337);

            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //for (int i = 0; i < 10000; i++)
            //{
            //   var k = 1000000000000000000L % 1140;
            //}
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedTicks);
            //sw.Restart();

            //for (int i = 0; i < 10000; i++)
            //{
            //    var k = LiteAlgorithm.PowMod(10, 18, 1140);
            //}
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedTicks);

            int[] input = {};
            SortAlgorithm.QuickSort(input, 0, input.Length-1);

            foreach (var i in input)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}