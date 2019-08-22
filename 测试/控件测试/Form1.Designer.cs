namespace 控件测试
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ultraFormattedLinkLabel1 = new Infragistics.Win.FormattedLinkLabel.UltraFormattedLinkLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.print1 = new System.Windows.Forms.Button();
            this.print2 = new System.Windows.Forms.Button();
            this.print3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(29, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 136);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(509, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 120);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Paint += new System.Windows.Forms.PaintEventHandler(this.button1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(672, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(29, 154);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 166);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkSalmon;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(177, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(222, 166);
            this.panel4.TabIndex = 4;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(174, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 166);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkRed;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(174, 166);
            this.panel3.TabIndex = 3;
            // 
            // ultraFormattedLinkLabel1
            // 
            appearance3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ultraFormattedLinkLabel1.HotTrackLinkAppearance = appearance3;
            this.ultraFormattedLinkLabel1.Location = new System.Drawing.Point(347, 12);
            this.ultraFormattedLinkLabel1.Name = "ultraFormattedLinkLabel1";
            this.ultraFormattedLinkLabel1.Size = new System.Drawing.Size(130, 23);
            this.ultraFormattedLinkLabel1.TabIndex = 3;
            this.ultraFormattedLinkLabel1.TabStop = true;
            this.ultraFormattedLinkLabel1.Value = "ultraFormattedLinkLabel1";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance4.BackColor = System.Drawing.Color.Blue;
            this.ultraLabel1.HotTrackAppearance = appearance4;
            this.ultraLabel1.Location = new System.Drawing.Point(347, 41);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 4;
            this.ultraLabel1.Text = "ultraLabel1";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // print1
            // 
            this.print1.Location = new System.Drawing.Point(39, 359);
            this.print1.Name = "print1";
            this.print1.Size = new System.Drawing.Size(75, 23);
            this.print1.TabIndex = 5;
            this.print1.Text = "打印";
            this.print1.UseVisualStyleBackColor = true;
            this.print1.Click += new System.EventHandler(this.print1_Click);
            // 
            // print2
            // 
            this.print2.Location = new System.Drawing.Point(131, 359);
            this.print2.Name = "print2";
            this.print2.Size = new System.Drawing.Size(75, 23);
            this.print2.TabIndex = 5;
            this.print2.Text = "打印预览";
            this.print2.UseVisualStyleBackColor = true;
            this.print2.Click += new System.EventHandler(this.print2_Click);
            // 
            // print3
            // 
            this.print3.Location = new System.Drawing.Point(227, 359);
            this.print3.Name = "print3";
            this.print3.Size = new System.Drawing.Size(75, 23);
            this.print3.TabIndex = 5;
            this.print3.Text = "打印设置";
            this.print3.UseVisualStyleBackColor = true;
            this.print3.Click += new System.EventHandler(this.print3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(347, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "show";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.print3);
            this.Controls.Add(this.print2);
            this.Controls.Add(this.print1);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.ultraFormattedLinkLabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter1;
        private Infragistics.Win.FormattedLinkLabel.UltraFormattedLinkLabel ultraFormattedLinkLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Button print1;
        private System.Windows.Forms.Button print2;
        private System.Windows.Forms.Button print3;
        private System.Windows.Forms.Button button2;
    }
}

