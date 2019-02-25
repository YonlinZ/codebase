using CommonControls;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CommonMethods
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
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

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor = Cursors.Hand;//改变鼠标样式
                ReleaseCapture(); //释放鼠标捕捉
                //发送左键点击的消息至该窗体(标题栏)
                SendMessage(Handle, 0xA1, 0x02, 0);
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        # region 支持改变窗体大小，需要露出窗体
        private const int Guying_HTLEFT = 10;
        private const int Guying_HTRIGHT = 11;
        private const int Guying_HTTOP = 12;
        private const int Guying_HTTOPLEFT = 13;
        private const int Guying_HTTOPRIGHT = 14;
        private const int Guying_HTBOTTOM = 15;
        private const int Guying_HTBOTTOMLEFT = 0x10;
        private const int Guying_HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF, (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMLEFT;
                        else
                            m.Result = (IntPtr)Guying_HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMRIGHT;
                        else
                            m.Result = (IntPtr)Guying_HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)Guying_HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)Guying_HTBOTTOM;
                    break;
                case 0x0201://鼠标左键按下的消息
                    m.Msg = 0x00A1; //更改消息为非客户区按下鼠标
                    m.LParam = IntPtr.Zero; //默认值
                    m.WParam = new IntPtr(2); //鼠标放在标题栏内
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion
    }
}
