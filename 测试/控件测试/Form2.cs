using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataUploadTools;
using SuNing.Views;
using YinLong.Utils.Core.IO;
using YinLong.Utils.Core.Ui;

namespace SuNing
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmWebBrowser frm = new FrmWebBrowser();
            frm.Url = "https://passport.suning.com/ids/login?service=https%3A%2F%2Floginst.suning.com%2F%2Fauth%3FtargetUrl%3Dhttps%253A%252F%252Fwww.suning.com%252F%253Futm_source%253Dbaidu%2526utm_medium%253Dbrand%2526utm_campaign%253Dtitle%2526utm_term%253Dbrand&method=GET&loginTheme=b2c";
            frm.ShowDialog();
        }
        private TaskManagerBuy taskManagerBuy;
        private TaskManagerRob taskManagerRob;
        //private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    BackgroundWorker bk = new BackgroundWorker();
        //    if (radioButton1.Checked)
        //    {
        //        bk.DoWork += delegate
        //        {
        //            taskManagerBuy = new TaskManagerBuy();
        //            taskManagerBuy.Run();
        //        };
        //    }
        //    else
        //    {
        //        bk.DoWork += delegate
        //        {
        //            taskManagerRob = new TaskManagerRob();
        //            taskManagerRob.Run();
        //        };
        //    }
           
        //    bk.RunWorkerCompleted += delegate
        //    {
        //        开始ToolStripMenuItem.Enabled = true;
        //        停止ToolStripMenuItem.Enabled = false;
        //    };
        //    bk.RunWorkerAsync();
        //    停止ToolStripMenuItem.Enabled = true;
        //    开始ToolStripMenuItem.Enabled = false;
        //}

    
        FileHelper file=new FileHelper(AppDomain.CurrentDomain.BaseDirectory+"hh.txt");
        private void Form1_Load(object sender, EventArgs e)
        {
            AppReportManager.Instance.AddListener<LogInfo>(ShowLog);
            AppReportManager.Instance.Send(new LogInfo() { Log = "初始化成功." });
            file.WriteLog(new Exception("测试"));
        }
        void ShowLog(LogInfo logInfo)
        {
            this.Invoke(new Action(delegate
            {
                textBox_Log.AppendText(
                    $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo)}] | {logInfo.Log}\r\n");
            }));
        }
    }
}
