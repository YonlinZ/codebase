using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformCallWpf
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            picContainer1.DefaultImage= ReadImageFile($@"C:\Users\AXB\Pictures\4.jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            picContainer1.Remove();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ran = new Random(DateTime.Now.Millisecond);
            var img = ReadImageFile($@"C:\Users\AXB\Pictures\{ran.Next(1,4)}.jpg");
            picContainer1.CurrentSelectedPicBox.AddImage(img);
        }
        /// <summary>
        /// 读取图片文件
        /// </summary>
        /// <param name="path">图片文件路径</param>
        /// <returns>图片文件</returns>
        private Bitmap ReadImageFile(string path)
        {
            Bitmap bitmap = null;
            try
            {
                FileStream fileStream = File.OpenRead(path);
                Int32 filelength = 0;
                filelength = (int)fileStream.Length;
                Byte[] image = new Byte[filelength];
                fileStream.Read(image, 0, filelength);
                System.Drawing.Image result = System.Drawing.Image.FromStream(fileStream);
                fileStream.Close();
                bitmap = new Bitmap(result);
            }
            catch (Exception ex)
            {
                //  异常输出
            }
            return bitmap;
        }
    }
}
