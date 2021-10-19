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
using System.Diagnostics;

namespace _18_10_2021
{
    /// <summary>
    /// Logika interakcji dla klasy EngineWindow.xaml
    /// </summary>
    public partial class EngineWindow : Window
    {

        public int engine_price = 0;
        public int power_price = 0;
        public float total = 0;
        

        public EngineWindow()
        {
            InitializeComponent();
            
        }

        private void engine_0(object sender, RoutedEventArgs e)
        {
            engine_price = 2350;
            update_price();
        }
        private void engine_1(object sender, RoutedEventArgs e)
        {
            engine_price = 2500;
            update_price();
        }
        private void engine_2(object sender, RoutedEventArgs e)
        {
            engine_price = 4030;
            update_price();
        }
        private void engine_3(object sender, RoutedEventArgs e)
        {
            engine_price = 10000;
            update_price();
        }

        private void update_price()
        {
            price.Content = $"${engine_price+power_price:F2}";
            total = engine_price + power_price;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(total);
            ((MainWindow)Application.Current.MainWindow).enginePrice = total;
            ((MainWindow)Application.Current.MainWindow).price.Content = $"${((MainWindow)Application.Current.MainWindow).brandPrice + ((MainWindow)Application.Current.MainWindow).enginePrice:F2}";
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cBox = e.Source as ComboBox;
            int power_out = cBox.SelectedIndex;

            switch (power_out)
            {
                case 0:
                    power_price = 1000;
                    break;
                case 1:
                    power_price = 2000;
                    break;
                case 2:
                    power_price = 3000;
                    break;
                case 3:
                    power_price = 4000;
                    break;
            }
            update_price();
        }
    }
}
