using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("starting program...");
            //Thread t = new Thread(PrintNumberWithStatus);
            //Thread t2 = new Thread(DoNothing);
            //t2.Start();
            //t.Start();
            //for (int i = 0; i < 30; i++)
            //{
            //    Console.WriteLine(t.ThreadState.ToString());
            //}
            //Thread.Sleep(TimeSpan.FromSeconds(6));
            //t.Abort();
            //Console.WriteLine("a thread has been aborted");
            //Console.WriteLine(t.ThreadState.ToString());
            //Console.WriteLine(t2.ThreadState.ToString());

            // 第一种方法 通过构造函数传值
            //var sample = new ThreadSample(10);

            //var threadOne = new Thread(sample.CountNumbers);
            //threadOne.Name = "ThreadOne";
            //threadOne.Start();
            //threadOne.Join();

            //Console.WriteLine("--------------------------");

            // 第二种方法 使用Start方法传值 
            // Count方法 接收一个Object类型参数
            var threadTwo = new Thread(Count);
            threadTwo.Name = "ThreadTwo";
            // Start方法中传入的值 会传递到 Count方法 Object参数上
            threadTwo.Start(8);
            threadTwo.Join();

            Console.WriteLine("--------------------------");

            // 第三种方法 Lambda表达式传值
            // 实际上是构建了一个匿名函数 通过函数闭包来传值
            var threadThree = new Thread(() => CountNumbers(12));
            threadThree.Name = "ThreadThree";
            threadThree.Start();
            threadThree.Join();
            Console.WriteLine("--------------------------");

            // Lambda表达式传值 会共享变量值
            int i = 10;
            var threadFour = new Thread(() => PrintNumber(i));
            i = 20;
            var threadFive = new Thread(() => PrintNumber(i));
            threadFour.Start();
            threadFive.Start();



            Console.ReadKey();
        }

        static void DoNothing()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        static void PrintNumberWithStatus()
        {
            Console.WriteLine("starting....");
            Console.WriteLine(Thread.CurrentThread.ThreadState.ToString());
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
        }

        static void Count(object iterations)
        {
            CountNumbers((int)iterations);
        }

        static void CountNumbers(int iterations)
        {
            for (int i = 1; i <= iterations; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.WriteLine($"{Thread.CurrentThread.Name} prints {i}");
            }
        }

        static void PrintNumber(int number)
        {
            Console.WriteLine(number);
        }

        class ThreadSample
        {
            private readonly int _iterations;

            public ThreadSample(int iterations)
            {
                _iterations = iterations;
            }
            public void CountNumbers()
            {
                for (int i = 1; i <= _iterations; i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                    Console.WriteLine($"{Thread.CurrentThread.Name} prints {i}");
                }
            }
        }
    }
}
