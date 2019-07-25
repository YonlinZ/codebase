using System;
using Unity;
using YonLin.Interface;

namespace YonLin.Service
{
    public class DellComputer : IComputer

    {
        #region IComputer Members
        public IMonitor iMonitor { get; set ; }
        public IHardDisk iHardDisk { get ; set ; }
        public IMainBoard iMainBoard { get ; set ; }
        public void ShowOperationSystem()
        {
            Console.WriteLine($"os of {GetType().Name} is {_os.Os}");
        }
        #endregion

        private IOperationSystem _os;
        public DellComputer(IOperationSystem os)
        {
            _os = os;
        }
    }
}
