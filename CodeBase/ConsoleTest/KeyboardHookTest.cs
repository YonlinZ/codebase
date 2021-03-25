using CommonMethods;
using Gma.UserActivityMonitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleTest
{
    public class KeyboardHookTest
    {
        //private KeyEventHandler myKeyEventHandeler = null;//按键钩子
        //private KeyBordHook2 k_hook = new KeyBordHook2();
        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            //  这里写具体实现
            Console.WriteLine("按下按键" + e.KeyValue);
        }
        public void startListen()
        {
            HookManager.KeyDown += hook_KeyDown;
        }
        //public void stopListen()
        //{
        //    if (myKeyEventHandeler != null)
        //    {
        //        k_hook.KeyDownEvent -= myKeyEventHandeler;//取消按键事件
        //        myKeyEventHandeler = null;
        //        k_hook.Stop();//关闭键盘钩子
        //    }
        //}
    }
}
