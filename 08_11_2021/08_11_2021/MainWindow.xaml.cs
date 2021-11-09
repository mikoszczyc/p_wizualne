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
using System.Windows.Interop;

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

        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                Bitmap bitmap = new Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        private BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
        {
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }
            return bitmapImage;
        }

        private void Button_Click_Choose(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                obrazek = new BitmapImage(fileUri);

                ScaleTransform flipTransform = new ScaleTransform();
                FlipX = 1;
                flipTransform.ScaleX = FlipX;
                ImgViewer.RenderTransform = flipTransform;
                RotateTransform rotateTransform = new RotateTransform(0, 0, 0);
                rotateTransform.Angle = 0;
                ImgViewer.VerticalAlignment = VerticalAlignment.Top;
                ImgViewer.HorizontalAlignment = HorizontalAlignment.Left;
                ImgViewer.LayoutTransform = rotateTransform;

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
            // only green RGB(50,150,50)
            if (obrazek != null)
            {
                Bitmap obrazekBmp;
                obrazekBmp = BitmapImage2Bitmap(obrazek);

                for (int y = 0; y < obrazekBmp.Height; y++)
                {
                    for (int x = 0; x < obrazekBmp.Width; x++)
                    {
                        System.Drawing.Color pixelColor = obrazekBmp.GetPixel(x, y);
                        if(pixelColor.R < 50 & pixelColor.G < 150 & pixelColor.B < 50)
                        {
                            pixelColor = System.Drawing.Color.White;
                            obrazekBmp.SetPixel(x, y, pixelColor);
                        }
                        
                    }
                }

                obrazek = Bitmap2BitmapImage(obrazekBmp);
                ImgViewer.Source = obrazek;
            }
        }
        private void Button_Click_D(object sender, RoutedEventArgs e)
        {
            // neg
            if (obrazek != null)
            {
                Bitmap obrazekBmp;
                obrazekBmp = BitmapImage2Bitmap(obrazek);
                for (int y = 0; y < obrazekBmp.Height; y++)
                {
                    for (int x = 0; x < obrazekBmp.Width; x++)
                    {
                        System.Drawing.Color pixelColor = obrazekBmp.GetPixel(x, y);
                        pixelColor = System.Drawing.Color.FromArgb(255, 255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B);
                        obrazekBmp.SetPixel(x, y, pixelColor);
                    }
                }
                obrazek = Bitmap2BitmapImage(obrazekBmp);
                ImgViewer.Source = obrazek;
            }
        }
    }

}

