namespace DesignPatternsTemplate.行为类模式.FacadePattern
{
    // Provide a unified interface to a set of interfaces in a subsystem.Facade defines a higher-levelinterface that makes the subsystem easier to use.（要求一个子系统的外部与其内部的通信必须通过一个统一的对象进行。 门面模式提供一个高层次的接口， 使得子系统更易于使用。 ）
    // 角色：Facade 门面角色，subsystem 子系统角色

    /// <summary>
    /// 门面对象
    /// </summary>
    public class Facade
    {
        //被委托的对象
        private ClassA a = new ClassA();
        private ClassB b = new ClassB();
        private ClassC c = new ClassC();
        //提供给外部访问的方法
        public void MethodA()
        {
            this.a.DoSomethingA();
        }
        public void MethodB()
        {
            this.b.DoSomethingB();
        }
        public void MethodC()
        {
            this.c.DoSomethingC();
        }
    }
    /// <summary>
    /// 子系统A
    /// </summary>
    public class ClassA
    {
        public void DoSomethingA()
        {
            //业务逻辑
        }
    }
    public class ClassB
    {
        public void DoSomethingB()
        {
            //业务逻辑
        }
    }
    public class ClassC
    {
        public void DoSomethingC()
        {
            //业务逻辑
        }
    }
}
