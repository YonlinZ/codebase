using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyFirstWPF
{
    public class MyButton : Button
    {
        public Type UserWindowType { get; set; }

        protected override void OnClick()
        {
            base.OnClick();
            var win = Activator.CreateInstance(UserWindowType) as Window;
            if (win != null)
            {
                win.ShowDialog();
            }

        }
    }
}
