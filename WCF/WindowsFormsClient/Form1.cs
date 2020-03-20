using System;
using System.Windows.Forms;

namespace WindowsFormsClient
{
    public partial class Form1 : Form
    {
        private WCFServiceDemo.ServiceClient ServiceClient = new WCFServiceDemo.ServiceClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var i = random.Next(1,101);
            ServiceClient.GetData(i);
        }
    }
}
