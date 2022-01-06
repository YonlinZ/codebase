using Infragistics.Win.UltraWinTabControl;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormTabBase : Form
    {
        /// <summary>
        /// 缓存需要刷新的tab
        /// 第一个tab是关闭的tab，第二个是要刷新的tab
        /// </summary>
        private static Dictionary<TabControl, TabControl> refreshTabCache = new Dictionary<TabControl, TabControl>();
        public FormTabBase()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var frm = new Form();
            frm.TopLevel = false;
            frm.WindowState = FormWindowState.Maximized;
            ultraTabPageControl1.Controls.Add(frm);
            frm.Show();
        }
        /// <summary>
        /// 添加新tab页，并显示新窗体
        /// </summary>
        /// <param name="frm1">当前窗体</param>
        /// <param name="frm">要显示的新窗体</param>
        /// <param name="refreshPreviousForm">新窗体关闭后是否刷新之前的窗体</param>
        public static void AddFormTab(Form frm1, Form frm, bool refreshPreviousForm)
        {
            try
            {
                var currentForm = (FormTabBase)frm1;
                var tab = currentForm.ultraTabControl1.Tabs.Add();
                if (refreshPreviousForm)
                {
                    refreshTabCache.Add(tab, currentForm.ultraTabControl1.ActiveTab);
                }
                tab.Text = frm.Text;
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                tab.TabPage.Controls.Add(frm);
                frm.FormClosed += (s, e) =>
                {
                    tab.Close();
                };
                frm.Show();
                tab.Selected = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ultraTabControl1_TabClosed(object sender, TabClosedEventArgs e)
        {
            try
            {
                if (!refreshTabCache.ContainsKey(e.Tab))
                {
                    return;
                }

                var tab = refreshTabCache[e.Tab];
                foreach (Control ctrl in tab.TabPage.Controls)
                {
                    if (ctrl is IRefreshTab frm)
                    {
                        frm.RefreshTab();
                    }
                }
                refreshTabCache.Remove(e.Tab);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
