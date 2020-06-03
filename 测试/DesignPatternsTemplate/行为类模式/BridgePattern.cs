namespace DesignPatternsTemplate.行为类模式
{
    // 定义：Decouple an abstraction from its implementation so that the two can vary independently.（将抽象和实现解耦， 使得两者可以独立地变化。 ）
    // 四个角色：Abstraction——抽象化角色，Implementor——实现化角色， RefinedAbstraction——修正抽象化角色，ConcreteImplementor——具体实现化角色

    /// <summary>
    /// 实现化角色
    /// </summary>
    public interface IImplementor
    {
        //基本方法
        void DoSomething();
        void DoAnything();
    }
    /// <summary>
    /// 具体的实现化角色
    /// </summary>
    public class ConcreteImplementor1 : IImplementor
    {
        public void DoSomething()
        {
            //业务逻辑处理
        }

        public void DoAnything()
        {
            //业务逻辑处理
        }
    }

    public class ConcreteImplementor2 : IImplementor
    {
        public void DoSomething()
        {
            //业务逻辑处理
        }
        public void DoAnything()
        {
            //业务逻辑处理
        }
    }
    /// <summary>
    /// 抽象化角色
    /// </summary>
    public abstract class Abstraction
    {
        //定义对实现化角色的引用
        private IImplementor imp;
        //约束子类必须实现该构造函数
        public Abstraction(IImplementor imp)
        {
            this.imp = imp;
        }//自身的行为和属性
        public virtual void Request()
        {
            this.imp.DoSomething();
        }//获得实现化角色
        public IImplementor GetImp()
        {
            return imp;
        }
    }
    /// <summary>
    /// 具体的抽象化角色
    /// </summary>
    public class RefinedAbstraction : Abstraction
    {
        //覆写构造函数
        public RefinedAbstraction(IImplementor imp) : base(imp)
        {
        }
        //修正父类的行为
        public override void Request()
        {
            /*
            * 业务处理...
            */
            base.Request();
            base.GetImp().DoAnything();
        }
    }
    /// <summary>
    /// 场景
    /// </summary>
    public class BridgeClient
    {
        public static void main()
        {
            //定义一个实现化角色
            IImplementor imp = new ConcreteImplementor1();
            //定义一个抽象化角色
            Abstraction abs = new RefinedAbstraction(imp);
            //执行行文
            abs.Request();
        }
    }
}
