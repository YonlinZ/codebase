using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CommonControls
{
    /// <summary>
    /// 未实现自定义字体
    /// </summary>
    [DefaultEvent("ButtonClick")]
    public partial class UcButtonRadiusBorder : UserControl
    {

        private Brush fontBrushColor = Brushes.White;
        private int radius = 15; //默认圆角半径

        public UcButtonRadiusBorder()
        {
            InitializeComponent();
        }

        #region 自定义属性

        [Description("显示文字"), Category("自定义属性")]
        public string DisplayName
        {
            get => button1.Text;
            set => button1.Text = value;
        }
        [Description("半径"), Category("自定义属性")]
        public int UcRadius
        {
            get => radius;
            set => radius = value > 0 ? value : 1;
        }
        [Description("背景色"), Category("自定义属性")]
        public Color UcBackColor { get; set; } = Color.FromArgb(19, 135, 254);

        private Color txtColor = Color.White;

        [Description("文字颜色"), Category("自定义属性")]
        public Color UcTxtColor
        {
            get => txtColor;
            set
            {
                txtColor = value;
                fontBrushColor = new SolidBrush(txtColor);
            }
        }
        #endregion

        #region 自定义事件

        [Browsable(true)]
        public event EventHandler ButtonClick;
        private void button1_Click(object sender, EventArgs e)
        {
            ButtonClick?.Invoke(sender, e);
        }

        #endregion

        #region 共有方法



        #endregion

        #region 私有方法



        #endregion


    

         private void button1_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            int span = 2;
            //抗锯齿
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //渐变填充
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush(e.ClipRectangle, UcBackColor, UcBackColor, LinearGradientMode.Vertical);
            //填充
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(e.ClipRectangle.X, e.ClipRectangle.Y, radius, radius, 180, 90);
            gp.AddArc(e.ClipRectangle.Width - span - radius, e.ClipRectangle.Y, radius, radius, 270, 90);
            gp.AddArc(e.ClipRectangle.Width - span - radius, e.ClipRectangle.Height - 1 - radius, radius, radius, 0, 90);
            gp.AddArc(e.ClipRectangle.X, e.ClipRectangle.Height - 1 - radius, radius, radius, 90, 90);
            gp.CloseAllFigures();
            e.Graphics.FillPath(myLinearGradientBrush, gp);
            base.OnPaint(e);
            Graphics g = e.Graphics;
            StringFormat 格式 = new StringFormat();
            格式.Alignment = StringAlignment.Center; //居中
            格式.LineAlignment = StringAlignment.Center; //右对齐
            Rectangle 矩形 = new Rectangle(0, 0, btn.Width, btn.Height + 2);
            g.DrawString(btn.Text, btn.Font, fontBrushColor, 矩形, 格式);
        }

        private void ButtonRadiusBorder_Load(object sender, EventArgs e)
        {
            button1.Size = this.Size;
        }

        private void UcButtonRadiusBorder_FontChanged(object sender, EventArgs e)
        {
            button1.Font = Font;
        }
    }
}
