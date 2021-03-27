using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommonMethods
{
    /// <summary>
    /// 文件浏览器
    /// </summary>
    public class FolderBrowserHelper
    {
        /// <summary>
        /// 通过文件浏览器获取文件夹路径
        /// </summary>
        /// <returns></returns>
        public static string GetFolderPath()
        {
            try
            {
                string path = string.Empty;
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    path = fbd.SelectedPath;
                }
                return path;
            }
            catch (Exception e)
            {
                throw new Exception("通过文件浏览器获取文件夹路径失败", e);
            }
        }
        /// <summary>
        /// 获取文件路径（单选文件）
        /// </summary>
        /// <returns></returns>
        public static string GetFilePath(string filter = null)
        {
            try
            {
                string path = string.Empty;
                OpenFileDialog fdlg = new OpenFileDialog();
                fdlg.Title = "请选择文件";
                fdlg.Filter = string.IsNullOrWhiteSpace(filter) ? "All files（*.*）|*.*" : filter;
                /*
                 *如果值为false，那么下一次选择文件的初始目录是上一次你选择的那个目录，
                 *不固定；如果值为true，每次打开这个对话框初始目录不随你的选择而改变，是固定的  
                 */
                fdlg.RestoreDirectory = false;
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    path = fdlg.FileName;
                }
                return path;
            }
            catch (Exception e)
            {
                throw new Exception("获取文件路径", e);
            }
        }
        /// <summary>
        /// 获取文件路径（多选文件）
        /// </summary>
        /// <returns></returns>
        public static string[] GetFilesPath(string filter = null)
        {
            try
            {
                string[] path = null;
                OpenFileDialog fdlg = new OpenFileDialog();
                fdlg.Title = "请选择文件";
                fdlg.Filter = string.IsNullOrWhiteSpace(filter) ? "All files（*.*）|*.*" : filter;
                fdlg.Multiselect = true;
                /*
                 *如果值为false，那么下一次选择文件的初始目录是上一次你选择的那个目录，
                 *不固定；如果值为true，每次打开这个对话框初始目录不随你的选择而改变，是固定的  
                 */
                fdlg.RestoreDirectory = false;
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    path = fdlg.FileNames;
                }
                return path;
            }
            catch (Exception e)
            {
                throw new Exception("获取文件路径", e);
            }
        }
    }
}
