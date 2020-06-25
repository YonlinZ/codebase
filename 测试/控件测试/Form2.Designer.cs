using System.Windows.Forms;

namespace SuNing
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.登录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.快捷键ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.小工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开程序目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_GoodsId = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_StoreId = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPassWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Model = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.操作ToolStripMenuItem,
            this.快捷键ToolStripMenuItem,
            this.导入导出ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.小工具ToolStripMenuItem,
            this.说明ToolStripMenuItem,
            this.打开程序目录ToolStripMenuItem,
            this.登录ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(821, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 登录ToolStripMenuItem
            // 
            this.登录ToolStripMenuItem.Name = "登录ToolStripMenuItem";
            this.登录ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.登录ToolStripMenuItem.Text = "登录";
            this.登录ToolStripMenuItem.Click += new System.EventHandler(this.登录ToolStripMenuItem_Click);
            // 
            // 快捷键ToolStripMenuItem
            // 
            this.快捷键ToolStripMenuItem.Name = "快捷键ToolStripMenuItem";
            this.快捷键ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.快捷键ToolStripMenuItem.Text = "快捷键";
            // 
            // 导入导出ToolStripMenuItem
            // 
            this.导入导出ToolStripMenuItem.Name = "导入导出ToolStripMenuItem";
            this.导入导出ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.导入导出ToolStripMenuItem.Text = "导入导出";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 小工具ToolStripMenuItem
            // 
            this.小工具ToolStripMenuItem.Name = "小工具ToolStripMenuItem";
            this.小工具ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.小工具ToolStripMenuItem.Text = "小工具";
            // 
            // 说明ToolStripMenuItem
            // 
            this.说明ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem,
            this.bToolStripMenuItem});
            this.说明ToolStripMenuItem.Name = "说明ToolStripMenuItem";
            this.说明ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.说明ToolStripMenuItem.Text = "说明";
            // 
            // 打开程序目录ToolStripMenuItem
            // 
            this.打开程序目录ToolStripMenuItem.Name = "打开程序目录ToolStripMenuItem";
            this.打开程序目录ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.打开程序目录ToolStripMenuItem.Text = "打开程序目录";
            // 
            // textBox_Log
            // 
            this.textBox_Log.Location = new System.Drawing.Point(2, 440);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.ReadOnly = true;
            this.textBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Log.Size = new System.Drawing.Size(819, 187);
            this.textBox_Log.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(389, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "商品ID";
            // 
            // textBox_GoodsId
            // 
            this.textBox_GoodsId.Location = new System.Drawing.Point(436, 22);
            this.textBox_GoodsId.Name = "textBox_GoodsId";
            this.textBox_GoodsId.Size = new System.Drawing.Size(162, 21);
            this.textBox_GoodsId.TabIndex = 3;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 64);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "直接购买";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(108, 64);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "抢购";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(240, 62);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "店铺Id";
            // 
            // textBox_StoreId
            // 
            this.textBox_StoreId.Location = new System.Drawing.Point(235, 22);
            this.textBox_StoreId.Name = "textBox_StoreId";
            this.textBox_StoreId.Size = new System.Drawing.Size(100, 21);
            this.textBox_StoreId.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAccount,
            this.ColumnPassWord,
            this.ColumnState});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(821, 299);
            this.dataGridView1.TabIndex = 10;
            // 
            // ColumnAccount
            // 
            this.ColumnAccount.HeaderText = "账号";
            this.ColumnAccount.Name = "ColumnAccount";
            this.ColumnAccount.ReadOnly = true;
            // 
            // ColumnPassWord
            // 
            this.ColumnPassWord.HeaderText = "密码";
            this.ColumnPassWord.Name = "ColumnPassWord";
            this.ColumnPassWord.ReadOnly = true;
            // 
            // ColumnState
            // 
            this.ColumnState.HeaderText = "状态";
            this.ColumnState.Name = "ColumnState";
            this.ColumnState.ReadOnly = true;
            this.ColumnState.Width = 300;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "功能";
            // 
            // comboBox_Model
            // 
            this.comboBox_Model.FormattingEnabled = true;
            this.comboBox_Model.Location = new System.Drawing.Point(58, 23);
            this.comboBox_Model.Name = "comboBox_Model";
            this.comboBox_Model.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Model.TabIndex = 12;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.ssToolStripMenuItem,
            this.ddToolStripMenuItem});
            开始ToolStripMenuItem11=new ToolStripMenuItem();
            this.开始ToolStripMenuItem11.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem11.Size = new System.Drawing.Size(180, 22);
            this.开始ToolStripMenuItem11.Text = "开始";
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                开始ToolStripMenuItem11
            });
            //this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            //{
            //    this.开始ToolStripMenuItem,
            //    this.ssToolStripMenuItem,
            //    this.ddToolStripMenuItem
            //});

            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.操作ToolStripMenuItem.Text = "操作";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox_Model);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.textBox_StoreId);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_GoodsId);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(5, 329);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(809, 104);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.开始ToolStripMenuItem.Text = "开始";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aToolStripMenuItem.Text = "a";
            // 
            // bToolStripMenuItem
            // 
            this.bToolStripMenuItem.Name = "bToolStripMenuItem";
            this.bToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bToolStripMenuItem.Text = "b";
            // 
            // ssToolStripMenuItem
            // 
            this.ssToolStripMenuItem.Name = "ssToolStripMenuItem";
            this.ssToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ssToolStripMenuItem.Text = "ss";
            // 
            // ddToolStripMenuItem
            // 
            this.ddToolStripMenuItem.Name = "ddToolStripMenuItem";
            this.ddToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ddToolStripMenuItem.Text = "dd";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 639);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox_Log);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "网购[自用]";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 登录ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_Log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_GoodsId;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_StoreId;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPassWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnState;
        private System.Windows.Forms.ToolStripMenuItem 导入导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 小工具ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 快捷键ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 说明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开程序目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ssToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem11;
    }
}

