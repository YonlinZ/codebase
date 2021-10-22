using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using DImage = System.Drawing.Image;

namespace WpfControlLibrary
{
    /// <summary>
    /// UserPicBox.xaml 的交互逻辑
    /// </summary>
    public partial class UserPicBox : UserControl
    {


        /// <summary>
        /// 默认图片
        /// </summary>
        private DImage _defaultImage;
        private List<DImage> _dimgs = new List<DImage>();
        private List<Image> _imgs = new List<Image>();
        private Image _currentImg;
        public UserPicBox(DImage defaultImage)
        {
            _defaultImage = defaultImage;
            InitializeComponent();
            InitControl();
        }
        private void InitControl()
        {
            if (_defaultImage != null)
            {
                MainImg.Source = Util.ChangeBitmapToImageSource(new System.Drawing.Bitmap(_defaultImage));
            }
        }
        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Height = Width / 3 * 2;
            BtnClear.Margin = new Thickness(BgGrid.ColumnDefinitions[0].ActualWidth - BtnClear.Width, 0, 0, BgGrid.RowDefinitions[0].ActualHeight - BtnClear.Height);
            //PanelImgList.Width = Scroll.ActualWidth;
            PanelImgList.Height = Scroll.ActualHeight;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            if (_dimgs.Any())
            {
                var index = _imgs.IndexOf(_currentImg);
                _dimgs.RemoveAt(index);
                PanelImgList.Children.Remove(_currentImg);
                _imgs.Remove(_currentImg);
                ShowLast();
            }
        }
        /// <summary>
        /// 添加img
        /// </summary>
        /// <param name="img"></param>
        public void AddImage(DImage img)
        {
            if (img is null)
            {
                throw new System.ArgumentNullException(nameof(img));
            }
            _dimgs.Add(img);
            AddImageControl(img);
            ShowLast();

        }
        /// <summary>
        /// 添加img
        /// </summary>
        /// <param name="img"></param>
        public void AddImage(IEnumerable<DImage> img)
        {
            if (img is null)
            {
                throw new System.ArgumentNullException(nameof(img));
            }
            if (!img.Any())
            {
                throw new System.ArgumentException($"{img} 不包含任何元素");
            }
            _dimgs.AddRange(img);
            foreach (var item in img)
            {
                AddImageControl(item);
            }
                ShowLast();
        }

        public IEnumerable<DImage> GetImg()
        {
            return _dimgs;
        }

        private void AddImageControl(DImage img)
        {
            var imgTemp = new Image();
            imgTemp.Stretch = System.Windows.Media.Stretch.Fill;
            if (_imgs.Any())
            {
                imgTemp.Margin = new Thickness(5, 0, 0, 0);
            }
            imgTemp.Source = Util.ChangeBitmapToImageSource(new System.Drawing.Bitmap(img));
            imgTemp.MouseLeftButtonUp += Img_Click;
            PanelImgList.Children.Add(imgTemp);
            _imgs.Add(imgTemp);
        }

        private void Img_Click(object sender, MouseButtonEventArgs e)
        {
            var temp = sender as Image;
            MainImg.Source = temp.Source;
            _currentImg = temp;
        }

        public void ShowLast()
        {
            if (_imgs.Any())
            {
                MainImg.Source = _imgs.Last().Source;
                _currentImg = _imgs.Last();
            }
            else if (_defaultImage != null)
            {
                MainImg.Source = Util.ChangeBitmapToImageSource(new System.Drawing.Bitmap(_defaultImage));
            }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer sv = sender as ScrollViewer;
            //move twice make it flexible
            if (e.Delta > 0)
            {
                sv.LineLeft();
                sv.LineLeft();
            }
            else
            {
                sv.LineRight();
                sv.LineRight();
            }
            e.Handled = true;
        }
    }
}
