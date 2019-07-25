using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace YonLin.Interface
{
    public interface IComputer
    {
        IMonitor iMonitor { get; set; }
        IHardDisk iHardDisk { get; set; }
        IMainBoard iMainBoard { get; set; }
        /// <summary>
        /// 输出系统
        /// </summary>
        void ShowOperationSystem();

    }
}
