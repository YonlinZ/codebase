using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 原生控件测试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            F();
            //F2();
        }
        private ToolStripMenuItem item;
        private void F()
        {
            item = new System.Windows.Forms.ToolStripMenuItem();
            item.Name = "aToolStripMenuItem";
            item.Size = new System.Drawing.Size(84, 22);
            item.Text = "A";
            item.Click += async (a, b) =>
             {
                 await F3();
             };
        }

        private void 菜单ToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { item });

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { item });

        }


        private async Task F3()
        {
            await Task.Delay(2000);
            var frm = new Form1();
            frm.BackColor = Color.Red;
            //Application.Run(frm);
            //frm.ShowDialog();
            frm.Show();
        }
        class MyClass
        {
            public int Level1 { get; set; }
            public int Level2 { get; set; }
            public int Level3 { get; set; }
            public string content { get; set; }
        }
        private void F2()
        {
            var c1 = new MyClass { Level1 = 1, Level2 = 10, Level3 = 101, content = "1,1,1" };
            var c2 = new MyClass { Level1 = 1, Level2 = 11, Level3 = 112, content = "1,1,1" };
            var c3 = new MyClass { Level1 = 1, Level2 = 11, Level3 = 112, content = "1,1,1" };
            var c4 = new MyClass { Level1 = 1, Level2 = 11, Level3 = 113, content = "1,1,1" };
            var c5 = new MyClass { Level1 = 2, Level2 = 20, Level3 = 201, content = "1,1,1" };
            var c6 = new MyClass { Level1 = 2, Level2 = 21, Level3 = 212, content = "1,1,1" };
            var c7 = new MyClass { Level1 = 2, Level2 = 21, Level3 = 212, content = "1,1,1" };
            var c8 = new MyClass { Level1 = 2, Level2 = 21, Level3 = 213, content = "1,1,1" };

            var list = new List<MyClass>
            {
                c1,c2,c3,c4,c5,c6,c7,c8
            };
            var result = list.GroupBy(level1 => level1.Level1)
             .Select(a => new
             {
                 level1 = a.Key,
                 sub = a.Select(item => new { item.Level2, item.Level3, item.content })
                 .GroupBy(level2 => level2.Level2)
                 .Select(b => new
                 {
                     level2 = b.Key,
                     sub = b.Select(item => new { item.Level3, item.content })
                     .GroupBy(level3 => level3.Level3)
                     .Select(c => new
                     {
                         level3 = c.Key,
                         sub = c.Select(item => new { item.content })
                     })
                 })
             }); ;

            var json = JsonConvert.SerializeObject(result);

        }
    }
}
