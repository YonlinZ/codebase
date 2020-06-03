namespace DesignPatternsTemplate.创建类模式
{
    internal class BuilderPattern
    {
        // 将一个复杂对象的构建与它的表示分离， 使得同样的构建过程可以创建不同的表示
        // 包含4个角色：Product 产品类，Builder 抽象建造者，ConcreteBuilder 具体建造真，Director 导演类

        /// <summary>
        /// 产品类
        /// </summary>
        public class Product
        {
            // 产品类通用方法
            public void DoSomething()
            {

            }
        }
        /// <summary>
        /// 抽象建造者
        /// </summary>
        public abstract class Builder
        {
            // 设置产品的不同部分， 以获得不同的产品
            public abstract void SetPart();
            // 建造产品
            public abstract Product BuildProduct();
        }
        /// <summary>
        /// 具体建造者
        /// 如果有多个产品类就有几个具体的建造者
        /// </summary>
        public class ConcreteBuilder : Builder
        {
            private Product p = new Product();
            /// <summary>
            /// 关键的地方，可以有多个组建产品的方式，视具体情况而定
            /// </summary>
            public override void SetPart()
            {
                throw new System.NotImplementedException();
            }

            public override Product BuildProduct()
            {
                return p;
            }
        }
        /// <summary>
        /// 导演类
        /// </summary>
        public class Director
        {
            private Builder builder = new ConcreteBuilder();
            //构建不同的产品
            public Product GetAProduct()
            {
                builder.SetPart();
                /*
                * 设置不同的零件， 产生不同的产品
                */
                return builder.BuildProduct();
            }
        }

    }
}
