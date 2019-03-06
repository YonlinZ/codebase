using System;
using System.Drawing;
using System.Windows.Forms;
using NLog;

namespace CommonControls
{
    public partial class Form1 : Form
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
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
                textBox1.ForeColor = Color.Black;
                lastText = defaultText;
                textBox1.Text = textBox1.Text.Replace(defaultText, string.Empty);
                textBox1.SelectionStart = textBox1.TextLength;
            }

            if (lastText == defaultText && string.IsNullOrWhiteSpace(textBox1.Text))//恢复默认
            {
                textBox1.Text = defaultText;
                textBox1.ForeColor = SystemColors.ControlLight;
                lastText = string.Empty;
            }
        }
        private int flag = 0;
        /// <summary>
        /// 全选 插入光标 切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == defaultText)
            {
                textBox1.SelectAll();
            }
            else if (flag++ % 2 == 0)
            {
                textBox1.SelectAll();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logger.Info("控制台日志");
            logger.Debug("Debug日志");
        }
    }
}
