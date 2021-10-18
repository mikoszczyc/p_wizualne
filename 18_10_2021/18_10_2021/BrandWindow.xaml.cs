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
using System.Windows.Shapes;

namespace _18_10_2021
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class BrandWindow : Window
    {
        public BrandWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void brand_0(object sender, RoutedEventArgs e)
        {
            price.Content = "$" + 126;
        }
        private void brand_1(object sender, RoutedEventArgs e)
        {
            price.Content = "$" + 50000;
        }
        private void brand_2(object sender, RoutedEventArgs e)
        {
            price.Content = "$" + 1000000;
        }
    }
}
