using System;
using Unity;
using YonLin.Interface;

namespace YonLin.Service
{
    public class OtComputer : IComputer

    {
        #region IComputer Members
        [Dependency]//属性注入方式1
        public IMonitor iMonitor { get; set ; }
        public IHardDisk iHardDisk { get ; set ; }
        public IMainBoard iMainBoard { get ; set ; }
        public void ShowOperationSystem()
        {
            Console.WriteLine($"os of {GetType().Name} is {_os.Os}");
        }
        #endregion

        private IOperationSystem _os;
        public OtComputer(IOperationSystem os)
        {
            _os = os;
        }
    }
}
