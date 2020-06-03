namespace DesignPatternsTemplate.行为类模式
{
    // 适配器模式：Convert the interface of a class into another interface clients expect.Adapter lets classes work
    // together that couldn't otherwise because of incompatible interfaces.（将一个类的接口变换成客户
    // 端所期待的另一种接口， 从而使原本因接口不匹配而无法在一起工作的两个类能够在一起工
    // 作。 ）
    // 也叫变压器模式，包装模式，装饰模式也是包装模式
    // 三个角色：Target 目标角色；Adaptee 源角色；Adapter 适配器角色
    public interface ITarget
    {
        //目标角色有自己的方法
        void Request();
    }
    public class ConcreteTarget : ITarget
    {
        public void Request()
        {

        }
    }
    public class Adaptee
    {
        //原有的业务逻辑
        public void DoSomething()
        {
        }
    }

    public class Adapter : Adaptee, ITarget
    {
        public void Request()
        {
            base.DoSomething();
        }
    }
}
