using CommonControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Management;

namespace CommonMethods
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]//窗体拖动
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]//窗体拖动
        private static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]// 点击任务栏最小化
        public static extern int GetWindowLong(HandleRef hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]// 点击任务栏最小化
        public static extern IntPtr SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong);
        public Form1()
        {
            InitializeComponent();
            SetForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        #region  窗体布局

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
        #endregion 

        /// <summary>
        /// 窗体拖动功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    {
                        if (vPoint.Y <= 5)
                        {
                            m.Result = (IntPtr)Guying_HTTOPLEFT;
                        }
                        else if (vPoint.Y >= ClientSize.Height - 5)
                        {
                            m.Result = (IntPtr)Guying_HTBOTTOMLEFT;
                        }
                        else
                        {
                            m.Result = (IntPtr)Guying_HTLEFT;
                        }
                    }
                    else if (vPoint.X >= ClientSize.Width - 5)
                    {
                        if (vPoint.Y <= 5)
                        {
                            m.Result = (IntPtr)Guying_HTTOPRIGHT;
                        }
                        else if (vPoint.Y >= ClientSize.Height - 5)
                        {
                            m.Result = (IntPtr)Guying_HTBOTTOMRIGHT;
                        }
                        else
                        {
                            m.Result = (IntPtr)Guying_HTRIGHT;
                        }
                    }
                    else if (vPoint.Y <= 5)
                    {
                        m.Result = (IntPtr)Guying_HTTOP;
                    }
                    else if (vPoint.Y >= ClientSize.Height - 5)
                    {
                        m.Result = (IntPtr)Guying_HTBOTTOM;
                    }

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

        #region 按键自动输入至指定textBox1

        /// <summary>
        /// 按键自动输入至指定textBox1
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (textBox2.Focused)//当光标聚焦到该控件时，不自动输入到指定的 textBox1
                return base.ProcessCmdKey(ref msg, keyData);
            if (keyData == Keys.NumPad0 || keyData == Keys.NumPad1 || keyData == Keys.NumPad2 ||
                keyData == Keys.NumPad3 || keyData == Keys.NumPad4 ||
                keyData == Keys.NumPad5 || keyData == Keys.NumPad6 || keyData == Keys.NumPad7 ||
                keyData == Keys.NumPad8 || keyData == Keys.NumPad9 ||
                keyData == Keys.D0 || keyData == Keys.D1 || keyData == Keys.D2 || keyData == Keys.D3 ||
                keyData == Keys.D4 ||
                keyData == Keys.D5 || keyData == Keys.D6 || keyData == Keys.D7 || keyData == Keys.D8 ||
                keyData == Keys.D9 ||
                keyData == Keys.A || keyData == Keys.B ||
                keyData == Keys.C || keyData == Keys.D || keyData == Keys.E || keyData == Keys.F || keyData == Keys.G ||
                keyData == Keys.H || keyData == Keys.I ||
                keyData == Keys.J || keyData == Keys.K || keyData == Keys.L || keyData == Keys.M || keyData == Keys.N ||
                keyData == Keys.O || keyData == Keys.P ||
                keyData == Keys.Q || keyData == Keys.R || keyData == Keys.S || keyData == Keys.T || keyData == Keys.U ||
                keyData == Keys.V || keyData == Keys.W ||
                keyData == Keys.X || keyData == Keys.Y || keyData == Keys.Z || keyData == Keys.Subtract ||
                keyData == Keys.OemMinus)
            {
                textBox1.Text += KeyCodeToString(keyData);
                textBox1.Focus();
                textBox1.SelectionStart = textBox1.Text.Trim().Length;
                return true;
            }
            if (keyData == Keys.Enter)
            {
                MessageBox.Show("Enter");
                //TODO 
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private string KeyCodeToString(Keys KeyCode)
        {
            if (KeyCode >= Keys.D0 && KeyCode <= Keys.D9 || KeyCode >= Keys.NumPad0 && KeyCode <= Keys.NumPad9)
                return KeyCode.ToString().Substring(KeyCode.ToString().Length - 1, 1);
            if (KeyCode == Keys.Subtract || KeyCode == Keys.OemMinus)
                return "-";
            if (KeyCode >= Keys.A && KeyCode <= Keys.Z)
                return KeyCode.ToString();
            return "";
        }

        #endregion
        

        #region // 点击任务栏最小化

        public void SetForm()
        {
            int WS_SYSMENU = 0x00080000; // 系统菜单
            int WS_MINIMIZEBOX = 0x20000; // 最大最小化按钮
            int windowLong = (GetWindowLong(new HandleRef(this, this.Handle), -16));
            SetWindowLong(new HandleRef(this, this.Handle), -16, windowLong | WS_SYSMENU | WS_MINIMIZEBOX);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;  // Winuser.h中定义   
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;   // 允许最小化操作   
                return cp;
            }
        }

        #endregion
        
        /// <summary>
        /// 获取MAC地址
        /// </summary>
        /// <returns></returns>
        private static string[] GetMacAddress()
        {
            var strMac = new List<string>();
            try
            {

                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        strMac.Add(mo["MacAddress"].ToString());
                    }
                }
                return strMac.ToArray();
            }
            catch
            {
                return strMac.ToArray();
            }
        }
    }
}
