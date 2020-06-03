using System;

namespace DesignPatternsTemplate.创建类模式
{
    /// <summary>
    /// 抽象产品类
    /// </summary>
    public abstract class Product
    {
        //产品类的公共方法
        public void method1()
        {
            //业务逻辑处理
        }
        //抽象方法
        public abstract void method2();
    }
    /// <summary>
    /// 具体产品类
    /// </summary>
    public class ConcreteProduct1 : Product
    {
        public override void method2()
        {
            //业务逻辑处理
        }
    }
    public class ConcreteProduct2 : Product
    {
        public override void method2()
        {
            //业务逻辑处理
        }
    }
    /// <summary>
    /// 抽象工厂类
    /// </summary>
    public abstract class Creator
    {
        /*
* 创建一个产品对象， 其输入参数类型可以自行设置
* 通常为String、 Enum、 Class等， 当然也可以为空
*/
        public abstract Product CreateProduct(Object product);
    }

    public class ConcreteCreator:Creator
    {
        public override Product CreateProduct(Object product)
        {
            Product p = null;
            try
            {
                // 构建具体商品
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return p;
        }
    }
}
