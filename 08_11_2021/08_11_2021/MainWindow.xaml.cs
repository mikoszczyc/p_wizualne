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

namespace _08_11_2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        BitmapImage obrazek;
        Bitmap obrazekBmp;

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        private void Button_Click_Choose(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                obrazek = new BitmapImage(fileUri);
                ImgViewer.Source = obrazek;
                obrazekBmp = new Bitmap(obrazek.StreamSource);
                //BitmapImage
            }
            
        }

        private void Button_Click_A(object sender, RoutedEventArgs e)
        {
            // mirror
            obrazekBmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
        }
        private void Button_Click_B(object sender, RoutedEventArgs e)
        {
            // 90 counter clockwise
            obrazekBmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }
        private void Button_Click_C(object sender, RoutedEventArgs e)
        {
            // only green
            // setPixel
        }
        private void Button_Click_D(object sender, RoutedEventArgs e)
        {
            // neg
        }
    }
}
