using System;

namespace DesignPatternsTemplate.行为类模式
{
    // 装饰模式：Attach additional responsibilities to an object dynamically keeping the same interface.Decorators provide a flexible
    //alternative to subclassing for extending functionality.（动态地给一个对象添加一些额外的职责。就增加功能来说， 装饰模式相比生成子类更为灵活。）
    // 四个角色：Component抽象构件   ConcreteComponent 具体构件  Decorator装饰角色 具体装饰角色
    /// <summary>
    /// 抽象构件
    /// </summary>
    public abstract class Component
    {
        //抽象的方法
        public abstract void Operate();
    }
    /// <summary>
    /// 具体构件
    /// </summary>
    public class ConcreteComponent : Component
    {
        //具体实现
        public override void Operate()
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// 抽象装饰者1
    /// </summary>
    public abstract class Decorator : Component
    {
        private Component _component = null;
        //通过构造函数传递被修饰者
        public Decorator(Component component)
        {
            _component = component;
        }
        // 委托给被修饰者执行
        public override void Operate()
        {
            _component.Operate();
        }
    }

    public class ConcreteDecorator1 : Decorator
    {
        /// <summary>
        /// 定义被修饰者
        /// </summary>
        /// <param name="component"></param>
        public ConcreteDecorator1(Component component) : base(component)
        {
        }
        /// <summary>
        /// 定义自己的修饰方法
        /// </summary>
        private void method1()
        {
        }
        /// <summary>
        /// 重写父类的Operation方法
        /// </summary>
        public override void Operate()
        {
            method1();
            base.Operate();
        }
    }

    public class ConcreteDecorator2 : Decorator
    {
        /// <summary>
        /// 定义被修饰者
        /// </summary>
        /// <param name="component"></param>
        public ConcreteDecorator2(Component component) : base(component)
        {
        }
        /// <summary>
        /// 定义自己的修饰方法
        /// </summary>
        private void method1()
        {
        }
        /// <summary>
        /// 重写父类的Operation方法
        /// </summary>
        public override void Operate()
        {
            method1();
            base.Operate();
        }
    }

    /// <summary>
    /// 场景类
    /// </summary>
    public class Client
    {
        public static void main(String[] args)
        {
            Component component = new ConcreteComponent();
            //第一次修饰
            component = new ConcreteDecorator1(component);
            //第二次修饰
            component = new ConcreteDecorator2(component);
            //修饰后运行
            component.Operate();
        }
    }
}
