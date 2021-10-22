using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DImage = System.Drawing.Image;

namespace WpfControlLibrary
{
    /// <summary>
    /// UserControl2.xaml 的交互逻辑
    /// </summary>
    public partial class PicContainer : UserControl
    {
        private List<UserPicBox> _picBoxList = new List<UserPicBox>();
        public DImage DefaultImage { get; set; }

        public UserPicBox CurrentSelectedPicBox { get; private set; }
        public PicContainer()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPicBox();

        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (var picBox in _picBoxList)
            {
                picBox.Width = StackPicContainer.ActualWidth;
            }
        }
        private void picBox_Click(object sender, MouseButtonEventArgs e)
        {
            CurrentSelectedPicBox = sender as UserPicBox;

            foreach (var child in StackPicContainer.Children)
            {
                if (child is UserPicBox picBox)
                {
                    picBox.Background = Brushes.White;
                }
            }

            CurrentSelectedPicBox.Background = Brushes.Red;
        }

        public void Remove()
        {
            StackPicContainer.Children.Remove(CurrentSelectedPicBox);
        }

        public void AddPicBox()
        {
            var picBox = new UserPicBox(DefaultImage);
            picBox.Width = StackPicContainer.ActualWidth;
            picBox.MouseLeftButtonUp += picBox_Click;
            StackPicContainer.Children.Remove(BtnAdd);
            StackPicContainer.Children.Add(picBox);
            StackPicContainer.Children.Add(BtnAdd);
            _picBoxList.Add(picBox);
            //picBox.ShowLast();
        }
    }
}
