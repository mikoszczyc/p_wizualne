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
using Microsoft.Win32;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace _08_11_2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage obrazek;
        int FlipX = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Choose(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                obrazek = new BitmapImage(fileUri);
                ImgViewer.Source = obrazek;
            }
        }

        private void Button_Click_A(object sender, RoutedEventArgs e)
        {
            // mirror
            if (obrazek != null)
            {
                ScaleTransform flipTransform = new ScaleTransform();
                FlipX *= -1;
                flipTransform.ScaleX = FlipX;
                ImgViewer.RenderTransform = flipTransform;
            }
        }
        private void Button_Click_B(object sender, RoutedEventArgs e)
        {
            // 90deg counter clockwise (always)
            if(obrazek != null)
            {
                RotateTransform rotateTransform = ImgViewer.LayoutTransform as RotateTransform;
                if (rotateTransform == null)
                {
                    if (FlipX > 0) rotateTransform = new RotateTransform(-90, 0, 0);
                    else if (FlipX < 0) rotateTransform = new RotateTransform(90, 0, 0);
                }
                else
                {
                    if (FlipX > 0) rotateTransform.Angle -= 90;
                    else if (FlipX < 0) rotateTransform.Angle += 90;
                }
                ImgViewer.VerticalAlignment = VerticalAlignment.Top;
                ImgViewer.HorizontalAlignment = HorizontalAlignment.Left;
                ImgViewer.LayoutTransform = rotateTransform;
            }
        }
        private void Button_Click_C(object sender, RoutedEventArgs e)
        {
            // only green
            // setPixel
            if (obrazek != null)
            {

            }
        }
        private void Button_Click_D(object sender, RoutedEventArgs e)
        {
            // neg
            if (obrazek != null)
            {

            }
        }
    }

}

