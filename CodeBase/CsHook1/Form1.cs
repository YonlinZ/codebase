using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gma.UserActivityMonitor;

namespace CsHook1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
          
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
           
        }

        private void chkBoxMouserMove_CheckedChanged(object sender, EventArgs e) {
            if (chkBoxMouserMove.Checked)
                HookManager.MouseMove += HookManager_MouseMove;
            else
                HookManager.MouseMove -=HookManager_MouseMove;
        }

        private void chkBoxMouseClick_CheckedChanged(object sender, EventArgs e) {
            if(chkBoxMouseClick.Checked)
                HookManager.MouseClick += HookManager_MouseClick;
            else
                HookManager.MouseClick -= HookManager_MouseClick;
        }
    

        private void chbBoxMouseDown_CheckedChanged(object sender, EventArgs e) {
             if(chbBoxMouseDown.Checked)
                 HookManager.MouseDown += HookManager_MouseDown;
             else
                 HookManager.MouseDown -= HookManager_MouseDown;
        }

      

        private void chkBoxMouseUp_CheckedChanged(object sender, EventArgs e) {
             if(chkBoxMouseUp.Checked)
                 HookManager.MouseUp += HookManager_MouseUp;
             else
                 HookManager.MouseUp -= HookManager_MouseUp;
        }

    

        private void chkBoxMouseDoubleClick_CheckedChanged(object sender, EventArgs e) {
             if(chkBoxMouseClick.Checked)
                 HookManager.MouseDoubleClick += HookManager_MouseDoubleClick;
             else
                 HookManager.MouseDoubleClick -= HookManager_MouseDoubleClick;
        }

   
        private void chbBoxMouseWheel_CheckedChanged(object sender, EventArgs e) {
             if(chbBoxMouseWheel.Checked)
                 HookManager.MouseWheel += HookManager_MouseWheel;
             else
                 HookManager.MouseWheel -=HookManager_MouseWheel;
        }

      
        private void chkBoxKeyDown_CheckedChanged(object sender, EventArgs e) {
             if(chkBoxKeyDown.Checked)
                 HookManager.KeyDown += HookManager_KeyDown;
             else
                 HookManager.KeyDown -= HookManager_KeyDown;
        }

    

        private void chkBoxKeyPress_CheckedChanged(object sender, EventArgs e) {
             if(chkBoxKeyPress.Checked)
                 HookManager.KeyPress += HookManager_KeyPress;
             else
                 HookManager.KeyPress -= HookManager_KeyPress;
        }

     
        private void chkBoxKeyUp_CheckedChanged(object sender, EventArgs e) {
             if(chkBoxKeyUp.Checked)
                 HookManager.KeyUp += HookManager_KeyUp;
             else
                 HookManager.KeyUp -= HookManager_KeyUp;
        }

       


        //=====================================Event============================
        void HookManager_MouseMove(object sender, MouseEventArgs e) {
            lblMousePosition.Text = string.Format("x={0:0000}; y={1:0000}", e.X, e.Y);
        }

        void HookManager_MouseClick(object sender, MouseEventArgs e) {
             richTextBox1.AppendText(string.Format("鼠标单击(MouseClick) - {0}\n", e.Button));
             richTextBox1.ScrollToCaret();
        }
        void HookManager_MouseUp(object sender, MouseEventArgs e) {
            richTextBox1.AppendText(string.Format("鼠标事件(MouseUp) - {0}\n", e.Button));
            richTextBox1.ScrollToCaret();
        }
        void HookManager_MouseDown(object sender, MouseEventArgs e) {
            richTextBox1.AppendText(string.Format("鼠标事件(MouseDown) - {0}\n", e.Button));
            richTextBox1.ScrollToCaret();
        }
        

        void HookManager_MouseDoubleClick(object sender, MouseEventArgs e) {
            richTextBox1.AppendText(string.Format("鼠标事件(MouseDoubleClick) - {0}\n", e.Button));
            richTextBox1.ScrollToCaret();
        }

        void HookManager_MouseWheel(object sender, MouseEventArgs e) {
            lblWheel.Text = string.Format("Wheel={0:000}", e.Delta);
        }

        void HookManager_KeyDown(object sender, KeyEventArgs e) {
            richTextBox1.AppendText(string.Format("键盘事件(KeyDown) - {0}\n", e.KeyCode));
            richTextBox1.ScrollToCaret();
        }
        void HookManager_KeyPress(object sender, KeyPressEventArgs e) {
            richTextBox1.AppendText(string.Format("键盘事件(KeyPress) - {0}\n", e.KeyChar));
            richTextBox1.ScrollToCaret();
        }

        void HookManager_KeyUp(object sender, KeyEventArgs e) {
            richTextBox1.AppendText(string.Format("键盘事件(KeyUp) - {0}\n", e.KeyCode));
            richTextBox1.ScrollToCaret(); 
        }
    }
}
