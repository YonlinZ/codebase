using Aspose.Slides;
using Aspose.Slides.Export;
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

namespace AsposeTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string licenseKey = "PExpY2Vuc2U+CiAgPERhdGE+CiAgICA8TGljZW5zZWRUbz5TdXpob3UgQXVuYm94IFNvZnR3YXJlIENvLiwgTHRkLjwvTGljZW5zZWRUbz4KICAgIDxFbWFpbFRvPnNhbGVzQGF1bnRlYy5jb208L0VtYWlsVG8+CiAgICA8TGljZW5zZVR5cGU+RGV2ZWxvcGVyIE9FTTwvTGljZW5zZVR5cGU+CiAgICA8TGljZW5zZU5vdGU+TGltaXRlZCB0byAxIGRldmVsb3BlciwgdW5saW1pdGVkIHBoeXNpY2FsIGxvY2F0aW9uczwvTGljZW5zZU5vdGU+CiAgICA8T3JkZXJJRD4xOTA4MjYwODA3NTM8L09yZGVySUQ+CiAgICA8VXNlcklEPjEzNDk3NjAwNjwvVXNlcklEPgogICAgPE9FTT5UaGlzIGlzIGEgcmVkaXN0cmlidXRhYmxlIGxpY2Vuc2U8L09FTT4KICAgIDxQcm9kdWN0cz4KICAgICAgPFByb2R1Y3Q+QXNwb3NlLlRvdGFsIGZvciAuTkVUPC9Qcm9kdWN0PgogICAgPC9Qcm9kdWN0cz4KICAgIDxFZGl0aW9uVHlwZT5FbnRlcnByaXNlPC9FZGl0aW9uVHlwZT4KICAgIDxTZXJpYWxOdW1iZXI+M2U0NGRlMzAtZmNkMi00MTA2LWIzNWQtNDZjNmEzNzE1ZmMyPC9TZXJpYWxOdW1iZXI+CiAgICA8U3Vic2NyaXB0aW9uRXhwaXJ5PjIwMjAwODI3PC9TdWJzY3JpcHRpb25FeHBpcnk+CiAgICA8TGljZW5zZVZlcnNpb24+My4wPC9MaWNlbnNlVmVyc2lvbj4KICAgIDxMaWNlbnNlSW5zdHJ1Y3Rpb25zPmh0dHBzOi8vcHVyY2hhc2UuYXNwb3NlLmNvbS9wb2xpY2llcy91c2UtbGljZW5zZTwvTGljZW5zZUluc3RydWN0aW9ucz4KICA8L0RhdGE+CiAgPFNpZ25hdHVyZT53UGJtNUt3ZTYvRFZXWFNIY1o4d2FiVEFQQXlSR0pEOGI3L00zVkV4YWZpQnd5U2h3YWtrNGI5N2c2eGtnTjhtbUFGY3J0c0cwd1ZDcnp6MytVYk9iQjRYUndTZWxsTFdXeXNDL0haTDNpN01SMC9jZUFxaVZFOU0rWndOQkR4RnlRbE9uYTFQajhQMzhzR1grQ3ZsemJLZFZPZXk1S3A2dDN5c0dqYWtaL1E9PC9TaWduYXR1cmU+CjwvTGljZW5zZT4=";
            new Aspose.Slides.License().SetLicense(new MemoryStream(Convert.FromBase64String(licenseKey)));
        }

        private void button1_Click(object sender, EventArgs e)
        {



            using (Presentation pres = new Presentation())
            {

                // Get the first slide
                pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
                pres.Slides.AddEmptySlide(pres.LayoutSlides[1]);
                ISlide sld1 = pres.Slides[0];
                ISlide sld2 = pres.Slides[1];
                ISlide sld3 = pres.Slides[2];

                // Instantiate the ImageEx class
                System.Drawing.Image img1 = (System.Drawing.Image)new Bitmap("1.jpg");
                System.Drawing.Image img2 = (System.Drawing.Image)new Bitmap("2.jpg");
                System.Drawing.Image img3 = (System.Drawing.Image)new Bitmap("3.jpg");
                IPPImage imgx1 = pres.Images.AddImage(img1);
                IPPImage imgx2 = pres.Images.AddImage(img2);
                IPPImage imgx3 = pres.Images.AddImage(img3);

                // Add Picture Frame with height and width equivalent of Picture
                sld1.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, imgx1);
                sld2.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, imgx2.Width, imgx2.Height, imgx2);
                sld3.Shapes.AddPictureFrame(ShapeType.Rectangle, 100, 100, imgx3.Width, imgx3.Height, imgx3);

                // Apply some formatting to PictureFrameEx
                //pf.LineFormat.FillFormat.FillType = FillType.Solid;
                //pf.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                //pf.LineFormat.Width = 20;
                //pf.Rotation = 45;

                //Write the PPTX file to disk
                pres.Save("1.pptx", SaveFormat.Pptx);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                var img = Clipboard.GetImage();
                using (var pres = new Presentation())
                {
                    var sld = pres.Slides[0];
                    var imgx = pres.Images.AddImage(Clipboard.GetImage());
                    sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, imgx);
                    pres.Save("ClopboardPicture.pptx", SaveFormat.Pptx);
                }
            }
        }
    }
}
