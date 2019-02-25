using System;
using System.Drawing;
using System.Windows.Forms;

namespace CommonControls
{
    public partial class Form1 : Form
    {
        private string defaultText = "默认文字";
        private string lastText = string.Empty;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = defaultText;
            textBox1.ForeColor = SystemColors.ControlLight;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lastText) && textBox1.Text != defaultText)//突出显示
            {
                textBox1.Text = textBox1.Text.Replace(defaultText, string.Empty);
                textBox1.ForeColor = Color.Black;
                textBox1.SelectionStart = textBox1.TextLength;
                lastText = defaultText;
            }

            if (lastText == defaultText && string.IsNullOrWhiteSpace(textBox1.Text))//恢复默认
            {
                textBox1.Text = defaultText;
                textBox1.ForeColor = SystemColors.ControlLight;
                lastText = string.Empty;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }
    }
}
