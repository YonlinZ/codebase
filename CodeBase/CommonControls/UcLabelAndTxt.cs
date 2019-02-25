using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CommonControls
{
    public partial class UcLabelAndTxt : UserControl
    {
        public UcLabelAndTxt()
        {
            InitializeComponent();
        }

        private void ucLabelAndTxt_Load(object sender, EventArgs e)
        {
            ResetControlSize();
        }
        #region 自定义属性

        [Description("Label宽度"), Category("自定义属性")]
        public int SetLabelWidth
        {
            get => panel1.Width;
            set
            {
                panel1.Width = value;
                ResetControlSize();
                this.Invalidate();
            }
        }
        [Description("文本框宽度"), Category("自定义属性")]
        public int SetTxtWidth
        {
            get => panel3.Width;
            set
            {
                panel3.Width = value;
                ResetControlSize();
                this.Invalidate();
            }
        }

        [Description("Label文字描述"), Category("自定义属性")]
        public string SetLbDes
        {
            get => lbDes.Text;
            set => lbDes.Text = value;
        }

        [Description("文本框内容"), Category("自定义属性")]
        public string SetTxtValue
        {
            get => txtValue.Text;
            set => txtValue.Text = value;
        }

        #endregion
        /// <summary>
        /// 运行时可以有效改变控件大小，设计器无效
        /// 可以通过改变label或textbox宽度使在设计器中生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucLabelAndTxt_FontChanged(object sender, EventArgs e)
        {
            ResetControlSize();
        }


        #region 公共方法
        /// <summary>
        /// 获取Label实例
        /// </summary>
        /// <returns></returns>
        public Label GetLabelInstance()
        {
            return lbDes;
        }
        /// <summary>
        /// 获取TextBox实例
        /// </summary>
        /// <returns></returns>
        public TextBox GetTextBoxInstance()
        {
            return txtValue;
        }

        #endregion 
        #region 私有方法

        /// <summary>
        /// 调整控件大小
        /// </summary>
        private void ResetControlSize()
        {
            Size = new Size(panel1.Width + panel3.Width, txtValue.Height);
        }

        #endregion
    }
}
