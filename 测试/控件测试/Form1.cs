using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = $"button {button1.Visible}";
            SetLinkApp();
            ultraLabel1.UseHotTracking = DefaultableBoolean.True;
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
    }
}
