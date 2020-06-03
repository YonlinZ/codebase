using System;

namespace SingletonTemplate
{
    /// <summary>
    /// 测试实例化时成员初始化顺序
    /// </summary>
    public sealed class SingletonTest
    {
        //private static readonly SingletonTest _instance = new SingletonTest();
        private static readonly SingletonTest _instance = null;
        public static string Something = "公开静态字段";
        private string InstanceField = "实例字段";
        static SingletonTest()
        {
            Console.WriteLine("调用静态构造函数");
        }

        private SingletonTest()
        {
            Console.WriteLine("调用私用构造函数");
        }

        public static SingletonTest Instance => _instance;
    }



    /// <summary>
    /// First version - not thread-safe
    /// </summary>
    public sealed class Singleton1
    {
        private static Singleton1 instance = null;

        private Singleton1()
        {
        }

        public static Singleton1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton1();
                }

                return instance;
            }
        }
    }
    /// <summary>
    /// Second version - simple thread-safety
    /// 有性能问题
    /// </summary>
    public sealed class Singleton2
    {
        private static Singleton2 instance = null;
        private static readonly object padlock = new object();

        Singleton2()
        {
        }

        public static Singleton2 Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton2();
                    }
                    return instance;
                }
            }
        }
    }

    /// <summary>
    /// Third version - attempted thread-safety using double-check locking
    /// Bad code! Do not use!
    /// </summary>
    public sealed class Singleton3
    {
        private static Singleton3 instance = null;
        private static readonly object padlock = new object();

        Singleton3()
        {
        }

        public static Singleton3 Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton3();
                        }
                    }
                }
                return instance;
            }
        }
    }

    /// <summary>
    /// Fourth version - not quite as lazy, but thread-safe without using locks
    /// static constructors in C# are specified to execute only when an instance of the class is created or a static member is referenced, and to execute only once per AppDomain
    /// </summary>
    public sealed class Singleton4
    {
        private static readonly Singleton4 instance = new Singleton4();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Singleton4()
        {
        }

        private Singleton4()
        {
        }

        public static Singleton4 Instance => instance;
    }


    /// <summary>
    /// Fifth version - fully lazy instantiation
    /// </summary>
    public sealed class Singleton5
    {
        private Singleton5()
        {
        }

        public static Singleton5 Instance => Nested.instance;

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly Singleton5 instance = new Singleton5();
        }
    }

    /// <summary>
    /// Sixth version - using .NET 4's Lazy<T> type
    /// </summary>
    public sealed class Singleton6
    {
        private static readonly Lazy<Singleton6> lazy = new Lazy<Singleton6>(() => new Singleton6());

        public static Singleton6 Instance => lazy.Value;

        private Singleton6()
        {
        }
    }

    abstract class ABS
    {
        private string str = "";
        public abstract string str2 { get; set; }
        public string str3
        {
            get => string.Empty;
        }
        public abstract void F1();

        public void F2()
        {
        }
    }
}
