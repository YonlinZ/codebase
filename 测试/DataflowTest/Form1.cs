using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;

namespace DataflowTest
{
    public partial class Form1 : Form
    {
        ActionBlock<int> b = new ActionBlock<int>(x =>
        {
            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(x * x);
        });
        public Form1()
        {
            InitializeComponent();
            F();
        }

        void F()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
            b.Post(10);
        }
    }
}
