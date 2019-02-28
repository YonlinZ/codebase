namespace CommonControls
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
            this.组合控件 = new System.Windows.Forms.GroupBox();
            this.ucLabelAndTxt1 = new CommonControls.UcLabelAndTxt();
            this.UcButtonRadiusBorder1 = new CommonControls.UcButtonRadiusBorder();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.组合控件.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 组合控件
            // 
            this.组合控件.Controls.Add(this.ucLabelAndTxt1);
            this.组合控件.Controls.Add(this.UcButtonRadiusBorder1);
            this.组合控件.Dock = System.Windows.Forms.DockStyle.Top;
            this.组合控件.Location = new System.Drawing.Point(0, 0);
            this.组合控件.Name = "组合控件";
            this.组合控件.Size = new System.Drawing.Size(800, 203);
            this.组合控件.TabIndex = 2;
            this.组合控件.TabStop = false;
            this.组合控件.Text = "组合控件";
            // 
            // ucLabelAndTxt1
            // 
            this.ucLabelAndTxt1.Font = new System.Drawing.Font("微软雅黑 Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucLabelAndTxt1.Location = new System.Drawing.Point(12, 20);
            this.ucLabelAndTxt1.Name = "ucLabelAndTxt1";
            this.ucLabelAndTxt1.SetLabelWidth = 112;
            this.ucLabelAndTxt1.SetLbDes = "描述";
            this.ucLabelAndTxt1.SetTxtValue = "";
            this.ucLabelAndTxt1.SetTxtWidth = 128;
            this.ucLabelAndTxt1.Size = new System.Drawing.Size(240, 36);
            this.ucLabelAndTxt1.TabIndex = 0;
            // 
            // UcButtonRadiusBorder1
            // 
            this.UcButtonRadiusBorder1.DisplayName = "button1";
            this.UcButtonRadiusBorder1.Font = new System.Drawing.Font("微软雅黑 Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UcButtonRadiusBorder1.Location = new System.Drawing.Point(258, 20);
            this.UcButtonRadiusBorder1.Name = "UcButtonRadiusBorder1";
            this.UcButtonRadiusBorder1.Size = new System.Drawing.Size(90, 36);
            this.UcButtonRadiusBorder1.TabIndex = 1;
            this.UcButtonRadiusBorder1.UcBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(135)))), ((int)(((byte)(254)))));
            this.UcButtonRadiusBorder1.UcRadius = 15;
            this.UcButtonRadiusBorder1.UcTxtColor = System.Drawing.Color.White;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 203);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "原生控件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "显示默认文字的textbox";
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.textBox1.Location = new System.Drawing.Point(23, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.组合控件);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.组合控件.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UcLabelAndTxt ucLabelAndTxt1;
        private UcButtonRadiusBorder UcButtonRadiusBorder1;
        private System.Windows.Forms.GroupBox 组合控件;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

