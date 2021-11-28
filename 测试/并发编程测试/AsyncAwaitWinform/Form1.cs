using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitWinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //await Task1();
                //Console.WriteLine("After Task1");
                //Console.WriteLine("==========");
                //await Task2();
                //Console.WriteLine("Event over");

                for (int i = 0; i < 10; i++)
                {
                    Task3();
                }

            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Finally");
            }

        }

        private Task Task1()
        {
            //label1.Text = "Task1, " + "Thread id: " + System.Threading.Thread.CurrentThread.ManagedThreadId;
            ////Console.WriteLine("Thread id: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            //await Task.Delay(TimeSpan.FromSeconds(3));

            //Console.WriteLine("Thread id: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            //label1.Text = "Task1 After delay " + "Thread id: " + System.Threading.Thread.CurrentThread.ManagedThreadId;

            return Task.Run(() =>
            {
                //Console.WriteLine(" Task1 Thread id: " + System.Threading.Thread.CurrentThread.ManagedThreadId);

                for (int i = 0; i < 50000; i++)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine(" Task1 Thread id: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            });

        }
        private async Task Task2()
        {
            label1.Text = "Task2, " + "Thread id: " + System.Threading.Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Thread id: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(TimeSpan.FromSeconds(3));

            label1.Text = "Task2 After delay " + "Thread id: " + System.Threading.Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Thread id: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }


        private async Task Task3()
        {
            Console.WriteLine("____+++++_____");
            await Task.Delay(TimeSpan.FromSeconds(3));
        }
    }
}
