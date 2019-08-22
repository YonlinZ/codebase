using System;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            Foo foo = (IFoo)null;
            foo.Name = "lindexi";

            Console.ReadKey();
        }
    }

    internal class A
    {
        private int i1 = 1;
        private int i2 = 2;

        public A()
        {
            Console.WriteLine($"{GetType().Name} CONSTRUCTOR A");
        }
    }

    internal class B : A
    {
        private int i3 = 3;
        private int i4 = 4;

        public B()
        {
            Console.WriteLine($"{GetType().Name} CONSTRUCTOR B");
        }
    }

    internal class C : B
    {
        private int i5 = 5;
        private int i6 = 6;

        public C()
        {
            Console.WriteLine($"{GetType().Name} CONSTRUCTOR C");
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









}
