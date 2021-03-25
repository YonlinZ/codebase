using CommonMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            //MemoryCacheUtil.GetOrAddCacheItem("key1", () => new A { Name = "z z", Age = 18 }, new TimeSpan(0, 0, 4), null);
            //MemoryCacheUtil.GetOrAddCacheItem("key1", () => new A { Name = "z z", Age = 18 }, null, DateTime.Now.AddSeconds(5));

            //while (true)
            //{
            //    var res = MemoryCacheUtil.GetCacheItem<A>("key1");
            //    if (res == null)
            //    {
            //        Console.WriteLine("移除缓存");
            //        break;
            //    }
            //    Console.WriteLine($"dt: {DateTime.Now}, name: {res.Name}, age: {res.Age}");
            //    res.Age = res.Age + 1;
            //    Thread.Sleep(1000);
            //}

            var key = new KeyboardHookTest();
            key.startListen();







            Console.ReadLine();


        }
        
        class A
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
