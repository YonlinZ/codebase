namespace CsHook1 {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.globalEventProvider1 = new Gma.UserActivityMonitor.GlobalEventProvider();
            this.chkBoxMouserMove = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMousePosition = new System.Windows.Forms.Label();
            this.chkBoxMouseClick = new System.Windows.Forms.CheckBox();
            this.chbBoxMouseDown = new System.Windows.Forms.CheckBox();
            this.chkBoxMouseUp = new System.Windows.Forms.CheckBox();
            this.chkBoxMouseDoubleClick = new System.Windows.Forms.CheckBox();
            this.chbBoxMouseWheel = new System.Windows.Forms.CheckBox();
            this.chkBoxKeyDown = new System.Windows.Forms.CheckBox();
            this.chkBoxKeyPress = new System.Windows.Forms.CheckBox();
            this.chkBoxKeyUp = new System.Windows.Forms.CheckBox();
            this.lblWheel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkBoxMouserMove
            // 
            this.chkBoxMouserMove.AutoSize = true;
            this.chkBoxMouserMove.Location = new System.Drawing.Point(21, 20);
            this.chkBoxMouserMove.Name = "chkBoxMouserMove";
            this.chkBoxMouserMove.Size = new System.Drawing.Size(108, 16);
            this.chkBoxMouserMove.TabIndex = 0;
            this.chkBoxMouserMove.Text = "鼠标移动(Move)";
            this.chkBoxMouserMove.UseVisualStyleBackColor = true;
            this.chkBoxMouserMove.CheckedChanged += new System.EventHandler(this.chkBoxMouserMove_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBoxKeyUp);
            this.groupBox1.Controls.Add(this.chkBoxKeyPress);
            this.groupBox1.Controls.Add(this.chkBoxKeyDown);
            this.groupBox1.Controls.Add(this.chbBoxMouseWheel);
            this.groupBox1.Controls.Add(this.chkBoxMouseDoubleClick);
            this.groupBox1.Controls.Add(this.chkBoxMouseUp);
            this.groupBox1.Controls.Add(this.chbBoxMouseDown);
            this.groupBox1.Controls.Add(this.chkBoxMouseClick);
            this.groupBox1.Controls.Add(this.chkBoxMouserMove);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 196);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lblMousePosition
            // 
            this.lblMousePosition.AutoSize = true;
            this.lblMousePosition.Location = new System.Drawing.Point(12, 232);
            this.lblMousePosition.Name = "lblMousePosition";
            this.lblMousePosition.Size = new System.Drawing.Size(95, 12);
            this.lblMousePosition.TabIndex = 2;
            this.lblMousePosition.Text = "鼠标坐标x=:,y=:";
            // 
            // chkBoxMouseClick
            // 
            this.chkBoxMouseClick.AutoSize = true;
            this.chkBoxMouseClick.Location = new System.Drawing.Point(21, 50);
            this.chkBoxMouseClick.Name = "chkBoxMouseClick";
            this.chkBoxMouseClick.Size = new System.Drawing.Size(114, 16);
            this.chkBoxMouseClick.TabIndex = 1;
            this.chkBoxMouseClick.Text = "鼠标单击(Click)";
            this.chkBoxMouseClick.UseVisualStyleBackColor = true;
            this.chkBoxMouseClick.CheckedChanged += new System.EventHandler(this.chkBoxMouseClick_CheckedChanged);
            // 
            // chbBoxMouseDown
            // 
            this.chbBoxMouseDown.AutoSize = true;
            this.chbBoxMouseDown.Location = new System.Drawing.Point(21, 80);
            this.chbBoxMouseDown.Name = "chbBoxMouseDown";
            this.chbBoxMouseDown.Size = new System.Drawing.Size(108, 16);
            this.chbBoxMouseDown.TabIndex = 1;
            this.chbBoxMouseDown.Text = "鼠标按下(Down)";
            this.chbBoxMouseDown.UseVisualStyleBackColor = true;
            this.chbBoxMouseDown.CheckedChanged += new System.EventHandler(this.chbBoxMouseDown_CheckedChanged);
            // 
            // chkBoxMouseUp
            // 
            this.chkBoxMouseUp.AutoSize = true;
            this.chkBoxMouseUp.Location = new System.Drawing.Point(21, 110);
            this.chkBoxMouseUp.Name = "chkBoxMouseUp";
            this.chkBoxMouseUp.Size = new System.Drawing.Size(102, 16);
            this.chkBoxMouseUp.TabIndex = 1;
            this.chkBoxMouseUp.Text = "鼠标释放（UP)";
            this.chkBoxMouseUp.UseVisualStyleBackColor = true;
            this.chkBoxMouseUp.CheckedChanged += new System.EventHandler(this.chkBoxMouseUp_CheckedChanged);
            // 
            // chkBoxMouseDoubleClick
            // 
            this.chkBoxMouseDoubleClick.AutoSize = true;
            this.chkBoxMouseDoubleClick.Location = new System.Drawing.Point(21, 140);
            this.chkBoxMouseDoubleClick.Name = "chkBoxMouseDoubleClick";
            this.chkBoxMouseDoubleClick.Size = new System.Drawing.Size(150, 16);
            this.chkBoxMouseDoubleClick.TabIndex = 1;
            this.chkBoxMouseDoubleClick.Text = "鼠标双击(DoubleClick)";
            this.chkBoxMouseDoubleClick.UseVisualStyleBackColor = true;
            this.chkBoxMouseDoubleClick.CheckedChanged += new System.EventHandler(this.chkBoxMouseDoubleClick_CheckedChanged);
            // 
            // chbBoxMouseWheel
            // 
            this.chbBoxMouseWheel.AutoSize = true;
            this.chbBoxMouseWheel.Location = new System.Drawing.Point(21, 170);
            this.chbBoxMouseWheel.Name = "chbBoxMouseWheel";
            this.chbBoxMouseWheel.Size = new System.Drawing.Size(114, 16);
            this.chbBoxMouseWheel.TabIndex = 1;
            this.chbBoxMouseWheel.Text = "鼠标滚轮(Wheel)";
            this.chbBoxMouseWheel.UseVisualStyleBackColor = true;
            this.chbBoxMouseWheel.CheckedChanged += new System.EventHandler(this.chbBoxMouseWheel_CheckedChanged);
            // 
            // chkBoxKeyDown
            // 
            this.chkBoxKeyDown.AutoSize = true;
            this.chkBoxKeyDown.Location = new System.Drawing.Point(178, 20);
            this.chkBoxKeyDown.Name = "chkBoxKeyDown";
            this.chkBoxKeyDown.Size = new System.Drawing.Size(126, 16);
            this.chkBoxKeyDown.TabIndex = 1;
            this.chkBoxKeyDown.Text = "键盘按下(keyDown)";
            this.chkBoxKeyDown.UseVisualStyleBackColor = true;
            this.chkBoxKeyDown.CheckedChanged += new System.EventHandler(this.chkBoxKeyDown_CheckedChanged);
            // 
            // chkBoxKeyPress
            // 
            this.chkBoxKeyPress.AutoSize = true;
            this.chkBoxKeyPress.Location = new System.Drawing.Point(178, 52);
            this.chkBoxKeyPress.Name = "chkBoxKeyPress";
            this.chkBoxKeyPress.Size = new System.Drawing.Size(132, 16);
            this.chkBoxKeyPress.TabIndex = 1;
            this.chkBoxKeyPress.Text = "键盘事件(KeyPress)";
            this.chkBoxKeyPress.UseVisualStyleBackColor = true;
            this.chkBoxKeyPress.CheckedChanged += new System.EventHandler(this.chkBoxKeyPress_CheckedChanged);
            // 
            // chkBoxKeyUp
            // 
            this.chkBoxKeyUp.AutoSize = true;
            this.chkBoxKeyUp.Location = new System.Drawing.Point(178, 86);
            this.chkBoxKeyUp.Name = "chkBoxKeyUp";
            this.chkBoxKeyUp.Size = new System.Drawing.Size(96, 16);
            this.chkBoxKeyUp.TabIndex = 1;
            this.chkBoxKeyUp.Text = "键盘释放(UP)";
            this.chkBoxKeyUp.UseVisualStyleBackColor = true;
            this.chkBoxKeyUp.CheckedChanged += new System.EventHandler(this.chkBoxKeyUp_CheckedChanged);
            // 
            // lblWheel
            // 
            this.lblWheel.AutoSize = true;
            this.lblWheel.Location = new System.Drawing.Point(185, 232);
            this.lblWheel.Name = "lblWheel";
            this.lblWheel.Size = new System.Drawing.Size(101, 12);
            this.lblWheel.TabIndex = 2;
            this.lblWheel.Text = "鼠标滚轮 Wheel=:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 262);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(351, 189);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 463);
            this.Controls.Add(this.lblWheel);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lblMousePosition);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gma.UserActivityMonitor.GlobalEventProvider globalEventProvider1;
        private System.Windows.Forms.CheckBox chkBoxMouserMove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMousePosition;
        private System.Windows.Forms.CheckBox chkBoxKeyUp;
        private System.Windows.Forms.CheckBox chkBoxKeyPress;
        private System.Windows.Forms.CheckBox chkBoxKeyDown;
        private System.Windows.Forms.CheckBox chbBoxMouseWheel;
        private System.Windows.Forms.CheckBox chkBoxMouseDoubleClick;
        private System.Windows.Forms.CheckBox chkBoxMouseUp;
        private System.Windows.Forms.CheckBox chbBoxMouseDown;
        private System.Windows.Forms.CheckBox chkBoxMouseClick;
        private System.Windows.Forms.Label lblWheel;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

