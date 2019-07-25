using System;
using Unity;
using Unity.Injection;
using YonLin.Interface;
using YonLin.Service;

namespace YonLin.Project
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IMonitor, Monitor>();
            container.RegisterType<IHardDisk, HardDisk>();
            //container.RegisterType<IMainBoard, MainBoard>();
            container.RegisterType<IOperationSystem, OperationSystem>("WINDOWS", new InjectionConstructor("WINDOWS"));
            container.RegisterType<IOperationSystem, OperationSystem>("IOS", new InjectionConstructor("IOS"));
            container.RegisterType<IOperationSystem, OperationSystem>(new InjectionConstructor("OTHER"));//被OTHER2覆盖掉，实际上实例化的是OTHER2
            container.RegisterType<IOperationSystem, OperationSystem>(new InjectionConstructor("OTHER2"));
            container.RegisterType<IComputer, DellComputer>("DELL", new InjectionConstructor(container.Resolve<IOperationSystem>("WINDOWS")));
            container.RegisterType<IComputer, AppleMac>("MAC", new InjectionConstructor(container.Resolve<IOperationSystem>("IOS")));
            container.RegisterType<IComputer, OtComputer>(new InjectionProperty("iHardDisk"), new InjectionProperty("iMainBoard", new MainBoard()));//属性注入方式2

            var dell = container.Resolve<IComputer>("DELL");
            dell.ShowOperationSystem();
            var mac = container.Resolve<IComputer>("MAC");
            mac.ShowOperationSystem();
            var other = container.Resolve<IComputer>();//默认执行了构造函数注入，注入的是OTHER2实例
            other.ShowOperationSystem();
            Console.ReadKey();
        }
    }
}
