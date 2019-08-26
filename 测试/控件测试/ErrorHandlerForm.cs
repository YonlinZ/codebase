using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 控件测试
{
    public partial class ErrorHandlerForm : Form
    {
        public ErrorHandlerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            throw new ArgumentException("The parameter was invalid");
        }

        // Start a new thread, separate from Windows Forms, that will throw an exception.
        private void button2_Click(object sender, System.EventArgs e)
        {
            ThreadStart newThreadStart = new ThreadStart(newThread_Execute);
            var newThread = new Thread(newThreadStart);
            newThread.Start();
        }

        // The thread we start up to demonstrate non-UI exception handling. 
        void newThread_Execute()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void F()
        {
            MessageBox.Show(button1.Text);
        }

    }
}
