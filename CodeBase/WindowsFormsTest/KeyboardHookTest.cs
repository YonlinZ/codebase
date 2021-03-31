using CommonMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTest
{
    public class KeyboardHookTest
    {
        private KeyboardHook k_hook = new KeyboardHook();
        private KeyBordHook2 k_hook2 ;
        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            //  这里写具体实现
            Console.WriteLine("按下按键" + e.KeyValue);
        }
        private void hook_KeyDown2(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyValue);
            Console.WriteLine(Control.ModifierKeys);
            //判断按下的键（Alt + A）   
            if (e.KeyValue == (int)Keys.A && (int)Control.ModifierKeys == (int)Keys.Control)
            {
                System.Windows.Forms.MessageBox.Show("按下了指定快捷键组");
            }
        }
        private void hook_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  这里写具体实现
            Console.WriteLine("按下按键:" + e.KeyChar);
        }
        //public void startListen()
        //{
        //    myKeyEventHandeler += hook_KeyDown;
        //}
        public void startListen()
        {
            k_hook.KeyDownEvent += hook_KeyDown2;//钩住键按下
            k_hook.Start();//安装键盘钩子
        }
        /// <summary>
        /// 无效
        /// </summary>
        public void startListen2()
        {
            k_hook2 = new KeyBordHook2();
            k_hook2.OnKeyDownEvent += hook_KeyDown2;
            k_hook2.Start();
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
