using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsTemplate.创建类模式
{
    /// <summary>
    /// 定义：用原型实例指定创建对象的种类， 并且通过拷贝这些原型创建新的对象
    /// </summary>
    public abstract class Prototype
    {
        private string _id;

        /// <summary>
        /// Constructor
        /// </summary>
        public Prototype(string id)
        {
            this._id = id;
        }

        /// <summary>
        /// Gets id
        /// </summary> 
        public string Id
        {
            get { return _id; }
        }

        public abstract Prototype Clone();
    }

    public class ConcretePrototype1 : Prototype
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ConcretePrototype1(string id)
            : base(id)
        {
        }

        /// <summary>
        /// 浅拷贝或者深拷贝，视情况而定
        /// </summary>
        /// <returns></returns>
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }
}
