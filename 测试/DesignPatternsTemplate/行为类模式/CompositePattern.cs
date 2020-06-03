using System.Collections.Generic;

namespace DesignPatternsTemplate.行为类模式.CompositePattern
{
    // Compose objects into tree structures to represent part-whole hierarchies.Composite lets clients
    // treat individual objects and compositions of objects uniformly.（将对象组合成树形结构以表
    // 示“部分-整体”的层次结构， 使得用户对单个对象和组合对象的使用具有一致性。 ）

    // 角色：Component抽象构件角色，Leaf叶子构件，Composite树枝构件

    /// <summary>
    /// 抽象构件角色
    /// </summary>
    public abstract class Component
    {
        //个体和整体都具有的共享
        public virtual void DoSomething()
        {
            //编写业务逻辑
        }
    }
    /// <summary>
    /// 树枝构建
    /// </summary>
    public class Composite : Component
    {
        //构件容器
        private readonly List<Component> _componentList = new List<Component>();
        //增加一个叶子构件或树枝构件
        public void Add(Component component)
        {
            this._componentList.Add(component);
        }
        //删除一个叶子构件或树枝构件
        public void Remove(Component component)
        {
            this._componentList.Remove(component);
        }
        //获得分支下的所有叶子构件和树枝构件
        public List<Component> GetChildren()
        {
            return this._componentList;
        }
    }
    /// <summary>
    /// 树叶构建
    /// </summary>
    public class Leaf : Component
    {
        public override void DoSomething()
        {

        }
    }

    public class Client
    {
        public static void main()
        {
            //创建一个根节点
            Composite root = new Composite();
            root.DoSomething();
            //创建一个树枝构件
            Composite branch = new Composite();
            //创建一个叶子节点
            Leaf leaf = new Leaf();
            //建立整体
            root.Add(branch);
            branch.Add(leaf);
        }
        //通过递归遍历树
        public static void Display(Composite root)
        {
            foreach (var component in root.GetChildren())
            {
                if (component is Leaf)
                {
                    component.DoSomething();
                }
                else
                {
                    Display((Composite)component);
                }
            }
        }
    }
}
