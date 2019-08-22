using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.FormattedLinkLabel;

namespace 控件测试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.printDialog1.Document = this.printDocument1;//必要的 
            this.printPreviewDialog1.Document = this.printDocument1;
            this.pageSetupDialog1.Document = this.printDocument1;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = $"button {button1.Visible}";
            SetLinkApp();
            ultraLabel1.UseHotTracking = DefaultableBoolean.True;
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

        private void AddForm()
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
                var frm = new Form
                {
                    BackColor = Color.AntiqueWhite,
                    TopLevel = false
                };
                BeginInvoke((Action)(() =>
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    panel1.Controls.Add(frm);
                    frm.Show();
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                }));
            });
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLines(new Point[] { new Point(50, 2), new Point(65, 18), new Point(50, 34), new Point(50, 27), new Point(30, 27), new Point(30, 10), new Point(50, 10), new Point(50, 2), });
            this.button1.Region = new Region(path);

        }

        private void SetLinkApp()
        {
            ultraFormattedLinkLabel1.ResetHotTrackLinkAppearance();
            // Treat the Value as a URL
            this.ultraFormattedLinkLabel1.TreatValueAs = TreatValueAs.FormattedText;

            // Set the value to a URL
            this.ultraFormattedLinkLabel1.Value = "http://www.Infragistics.com";

            // Apply a solid border
            this.ultraFormattedLinkLabel1.BorderStyle = UIElementBorderStyle.Solid;

            // Set the colors to black on White. 
            //this.ultraFormattedLinkLabel1.Appearance.BackColor = Color.White;
            this.ultraFormattedLinkLabel1.Appearance.ForeColor = Color.Black;

            // Make links display in Blue.
            this.ultraFormattedLinkLabel1.LinkAppearance.ForeColor = Color.Blue;

            // Make links purple when you mouse over them. 
            this.ultraFormattedLinkLabel1.HotTrackLinkAppearance.ForeColor = Color.Purple;
            ultraFormattedLinkLabel1.HotTrackLinkAppearance.BackColor = Color.PaleVioletRed;
            // Only underling links when the mouse is over them. 
            this.ultraFormattedLinkLabel1.UnderlineLinks = UnderlineLink.WhenHovered;

            // When the link is active, display it in green.
            this.ultraFormattedLinkLabel1.ActiveLinkAppearance.ForeColor = Color.Green;

            // Visited links display in Red
            this.ultraFormattedLinkLabel1.VisitedLinkAppearance.ForeColor = Color.Red;

            // Put some padding around the inside of the control
            this.ultraFormattedLinkLabel1.Padding = new Size(5, 5);

            // Do not autosize. 
            this.ultraFormattedLinkLabel1.AutoSize = false;

            // Do not wrap text. 
            this.ultraFormattedLinkLabel1.WrapText = false;
        }

        private void print1_Click(object sender, EventArgs e)
        {
            if (this.printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }

        private void print2_Click(object sender, EventArgs e)
        {
            this.printPreviewDialog1.ShowDialog();
        }

        private void print3_Click(object sender, EventArgs e)
        {
            this.pageSetupDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Tahoma", 12, FontStyle.Underline);//设置画笔 
            Brush bru = Brushes.Blue;
            Pen pen = new Pen(bru);
            pen.Width = 5;
            //设置各边距 
            int nLeft = this.pageSetupDialog1.PageSettings.Margins.Left;
            int nTop = this.pageSetupDialog1.PageSettings.Margins.Top;
            int nRight = this.pageSetupDialog1.PageSettings.Margins.Right;
            int nBottom = this.pageSetupDialog1.PageSettings.Margins.Bottom;
            int nWidth = this.pageSetupDialog1.PageSettings.PaperSize.Width - nRight - nLeft;
            int nHeight = this.pageSetupDialog1.PageSettings.PaperSize.Height - nTop - nBottom;
            //打印各边距 
            e.Graphics.DrawLine(pen, nLeft, nTop, nLeft, nTop + nHeight);
            e.Graphics.DrawLine(pen, nLeft + nWidth, nTop, nLeft + nWidth, nTop + nHeight);
            e.Graphics.DrawLine(pen, nLeft, nTop, nLeft + nWidth, nTop);
            e.Graphics.DrawLine(pen, nLeft, nTop + nHeight, nLeft + nWidth, nTop + nHeight);
            //在离左边距20,右边距20的位置打印

            e.Graphics.DrawString($"haha{Environment.NewLine}xixi0000000000000000", font, bru, nLeft + 20, nTop + 20);//如果要打印datagridView在这里遍历便可 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddForm();
        }
    }
}
