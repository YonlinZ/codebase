using CommonControls;
using System;
using System.Windows.Forms;

namespace CommonMethods
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }




        private void button1_Click(object sender, EventArgs e)
        {
            ControlAlign.SetControlAlign(panel, panel1, ControlAlign.AlignType.TopLeft);
            ControlAlign.SetControlAlign(panel, panel2, ControlAlign.AlignType.TopCentre);
            ControlAlign.SetControlAlign(panel, panel3, ControlAlign.AlignType.TopRight);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ControlAlign.SetControlAlign(panel, panel1, ControlAlign.AlignType.TopLeft + 3);
            ControlAlign.SetControlAlign(panel, panel2, ControlAlign.AlignType.TopCentre + 3);
            ControlAlign.SetControlAlign(panel, panel3, ControlAlign.AlignType.TopRight + 3);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ControlAlign.SetControlAlign(panel, panel1, ControlAlign.AlignType.TopLeft + 6);
            ControlAlign.SetControlAlign(panel, panel2, ControlAlign.AlignType.TopCentre + 6);
            ControlAlign.SetControlAlign(panel, panel3, ControlAlign.AlignType.TopRight + 6);

        }
    }
}
