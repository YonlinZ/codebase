using System.Collections.Generic;

namespace DesignPatternsTemplate.行为类模式
{
    // 享元模式（Flyweight Pattern） 是池技术的重要实现方式， 其定义如下： Use sharing tosupport large numbers of fine-grained objects efficiently.（使用共享对象可有效地支持大量的细粒度的对象。 
    // 角色：Flyweight——抽象享元角色，ConcreteFlyweight——具体享元角色，unsharedConcreteFlyweight——不可共享的享元角色，FlyweightFactory——享元工厂
    /// <summary>
    /// 抽象享元角色
    /// </summary>
    public abstract class Flyweight
    {
        //内部状态
        public string Intrinsic { get; set; }

        //外部状态
        protected string Extrinsic;
        //要求享元角色必须接受外部状态
        public Flyweight(string extrinsic)
        {
            this.Extrinsic = extrinsic;
        }
        /// <summary>
        /// 定义业务操作
        /// </summary>
        public abstract void Operate();

    }
    /// <summary>
    /// 具体享元角色
    /// </summary>
    public class ConcreteFlyweight1 : Flyweight
    {
        //接受外部状态
        public ConcreteFlyweight1(string extrinsic) : base(extrinsic)
        {
        }
        //根据外部状态进行逻辑处理
        public override void Operate()
        {
            //业务逻辑
        }
    }
    public class ConcreteFlyweight2 : Flyweight
    {
        //接受外部状态
        public ConcreteFlyweight2(string extrinsic) : base(extrinsic)
        {
        }
        //根据外部状态进行逻辑处理
        public override void Operate()
        {
            //业务逻辑
        }
    }
    /// <summary>
    /// 享元工厂
    /// </summary>
    public class FlyweightFactory
    {
        //定义一个池容器
        private static Dictionary<string, Flyweight> pool = new Dictionary<string, Flyweight>();
        //享元工厂
        public static Flyweight GetFlyweight(string extrinsic)
        {
            //需要返回的对象
            Flyweight flyweight = null;
            //在池中没有该对象
            if (pool.ContainsKey(extrinsic))
            {
                flyweight = pool[extrinsic];
            }
            else
            {
                //根据外部状态创建享元对象
                flyweight = new ConcreteFlyweight1(extrinsic);
                //放置到池中
                pool.Add(extrinsic, flyweight);
            }
            return flyweight;
        }
    }
}
