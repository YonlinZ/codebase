namespace DesignPatternsTemplate.创建类模式
{
    //定义：为创建一组相关或相互依赖的对象提供一个接口， 而且无须指定它们的具体类。

    /// <summary>
    /// 抽象产品类
    /// </summary>
    public abstract class AbstractProductA
    {
        //每个产品共有的方法
        public void shareMethod()
        {
        }//每个产品相同方法， 不同实现
        public abstract void doSomething();
    }
    /// <summary>
    /// 抽象产品类
    /// </summary>
    public abstract class AbstractProductB
    {
        //每个产品共有的方法
        public void shareMethod()
        {
        }//每个产品相同方法， 不同实现
        public abstract void doSomething();
    }
    /// <summary>
    /// 产品A1的实现类
    /// </summary>
    public class ProductA1 : AbstractProductA
    {
        public override void doSomething()
        {
            //产品A1的实现方法
        }
    }
    /// <summary>
    /// 产品A2的实现类
    /// </summary>
    public class ProductA2 : AbstractProductA
    {
        public override void doSomething()
        {
            //产品A2的实现方法
        }
    }

    /// <summary>
    /// 产品B1的实现类
    /// </summary>
    public class ProductB1 : AbstractProductB
    {
        public override void doSomething()
        {
            //产品A1的实现方法
        }
    }
    /// <summary>
    /// 产品B2的实现类
    /// </summary>
    public class ProductB2 : AbstractProductB
    {
        public override void doSomething()
        {
            //产品A2的实现方法
        }
    }
    /// <summary>
    /// 抽象工厂类
    /// 注意：有N个产品族， 在抽象工厂类中就应该有N个创建方法。
    /// </summary>
    public abstract class AbstractCreator
    {
        //创建A产品家族
        public abstract AbstractProductA createProductA();
        //创建B产品家族
        public abstract AbstractProductB createProductB();
    }

    #region 具体工厂类 有M个产品等级就应该有M个实现工厂类， 在每个实现工厂中， 实现不同产品族的生产任务。

    public class Creator1 : AbstractCreator
    {
        //只生产产品等级为1的A产品
        public override AbstractProductA createProductA()
        {
            return new ProductA1();
        }
        //只生产产品等级为1的B产品
        public override AbstractProductB createProductB()
        {
            return new ProductB1();
        }
    }

    public class Creator2 : AbstractCreator
    {
        //只生产产品等级为2的A产品
        public override AbstractProductA createProductA()
        {
            return new ProductA2();
        }
        //只生产产品等级为2的B产品
        public override AbstractProductB createProductB()
        {
            return new ProductB2();
        }
    }
    #endregion
}
