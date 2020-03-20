using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using WCFServiceDemo;

namespace WindowsFormsServer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ServiceHost aa = new ServiceHost(new Service());
            aa.Open();
            Application.Run(new Form1());
        }
    }
}
