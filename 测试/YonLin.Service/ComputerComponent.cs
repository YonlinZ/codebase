using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Unity;
using YonLin.Interface;

namespace YonLin.Service
{
    public class Monitor: IMonitor
    {
        public Monitor()
        {
            Console.WriteLine("Monitor is built");
        }
    }

    public class HardDisk : IHardDisk
    {
        public HardDisk()
        {
            Console.WriteLine("HardDisk is built");
        }
    }

    public class MainBoard : IMainBoard
    {
        public MainBoard()
        {
            Console.WriteLine("MainBoard is built");
        }
    }

    public class OperationSystem : IOperationSystem
    {
        public string Os { get; set; }
        /// <summary>
        /// 默认注入参数最多的构造函数
        /// </summary>
        /// <param name="osName"></param>
        public OperationSystem(string osName)
        {
            Console.WriteLine($"{Os = osName} is built");
        }
        // ReSharper disable once InvalidXmlDocComment
        /// <summary>
        /// 如需注入指定的构造函数需用特性修饰
        /// </summary>
        //[InjectionConstructor]
        //public OperationSystem()
        //{
        //    Console.WriteLine($"default os is built");
        //}
    }
}
