using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            //Foo foo = (IFoo)null;
            //foo.Name = "lindexi";
            //Console.WriteLine("X={0},Y={1}", AA.X, BB.Y);
            //new C();

            //var i = new MyIndex("first", "second");
            //Console.WriteLine(i["1"]);
            //Console.WriteLine(i["2"]);
            //try
            //{
            //Console.WriteLine(i["3"]);

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //var count1 = 0;
            //var count2 = 0;
            //foreach (var i in Feige.Fib(10))
            //{
            //    Console.WriteLine($"{++count1} 返回的结果是：{i}");
            //}
            //foreach (var i in Feige.Fib(20))
            //{
            //    Console.WriteLine($"{++count2} 返回的结果是：{i}");
            //}
            Console.ReadKey();
        }
    }

    internal class A
    {
        private int i1 = 1;
        protected int i2 = 2;

        public A()
        {
            Console.WriteLine($"{GetType().Name} CONSTRUCTOR A");
        }
    }

    internal class B : A
    {
        private int i3 = 3;
        protected int i4 = 4;

        public B()
        {
            Console.WriteLine($"{GetType().Name} CONSTRUCTOR B");
        }
    }

    internal class C : B
    {
        private int i5 = 5;
        protected int i6 = 6;

        public C()
        {
            Console.WriteLine($"{GetType().Name} CONSTRUCTOR C");
            Console.WriteLine($"i2:{i2}, i4:{i4}, i5:{i5}, i6: {i6}");
        }
    }

    public enum QuestionType
    {
        Text = 0,
        MultipleChoice = 1
    }

    public interface IQuestion
    {
        string Title { get; set; }
        QuestionType Type { get; }
        string GetResult();
    }

    public abstract class QuestionBase : IQuestion
    {
        public string Title { get; set; }
        public abstract QuestionType Type { get; }
        public virtual string GetResult()
        {
            return "默认答案";
        }
    }

    public class TextQuestion : QuestionBase
    {
        public override string GetResult()
        {
            return "文本答案";
        }
        public override QuestionType Type { get; }
    }

    public class MultipleChoiceQuestion : QuestionBase
    {
        public override string GetResult()
        {
            return "多选答案";
        }
        public override QuestionType Type { get; }
    }

    //interface IFoo
    //{

    //}
    internal class IFoo
    {

    }

    internal class Foo
    {
        public string Name { get; set; }

        public static implicit operator Foo(IFoo foo)//IFoo 不能是接口
        {
            return new Foo();
        }
    }

    internal class AA
    {
        public static int X = 2;
        static AA()
        {
            X = BB.Y + 1;
        }
    }

    internal class BB
    {
        public static int Y = AA.X + 1;
        static BB() { }
    }

    /// <summary>
    /// 索引器
    /// </summary>
    internal class MyIndex
    {
        private string First;
        private string Second;

        public MyIndex(string first, string second)
        {
            First = first;
            Second = second;
        }

        public string this[string index]
        {
            get
            {
                switch (index)
                {
                    case "1":
                        return First;
                    case "2":
                        return Second;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

    }

    internal class Feige
    {
        public static IEnumerable<int> Fei()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return i;
                Thread.Sleep(1000);
                Console.WriteLine($"返回后的结果是:{i}");
            }
        }

        public static IEnumerable<string> Y()
        {
            yield return "one";
            yield return "tow";
            yield return "three";
        }

        public static IEnumerable<int> Fib(int n)
        {
            int current = 1, next = 1;
            int count = 0;
            while (true)
            {
                count++;
                yield return current;
                next = current + (current = next);
                if (count == n)
                {
                    yield break;
                }
            }

        }
    }

}
