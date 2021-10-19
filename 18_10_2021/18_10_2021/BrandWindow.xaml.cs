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
    /// Logika interakcji dla klasy BrandWindow.xaml
    /// </summary>
    public partial class BrandWindow : Window
    {
        public float carprice = 0;
        public float addons = 0;
        public float policy = 0;
        public float total = 0;

        public BrandWindow()
        {
            InitializeComponent();
            update_price();
        }

        private void brand_0(object sender, RoutedEventArgs e)
        {
            carprice = 126;
            update_price();
        }
        private void brand_1(object sender, RoutedEventArgs e)
        {
            carprice = 50000;
            update_price();
        }
        private void brand_2(object sender, RoutedEventArgs e)
        {
            carprice = 1000000;
            update_price();
        }

        private void addons_check(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = e.Source as CheckBox;
            Debug.WriteLine(checkBox.Name);
            switch (checkBox.Name)
            {
                case "sunroof":
                    addons += 1000;
                    break;
                case "ac":
                    addons += 2000;
                    break;
                case "neons":
                    addons += 2020;
                    break;
                case "spoiler":
                    addons += 322;
                    break;
                case "n2o":
                    addons += 1499;
                    break;
                case "i_am_speed":
                    addons += 10000;
                    break;
            }
            update_price();
        }

        private void addons_uncheck(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = e.Source as CheckBox;
            Debug.WriteLine(checkBox.Name);
            switch (checkBox.Name)
            {
                case "sunroof":
                    addons -= 1000;
                    break;
                case "ac":
                    addons -= 2000;
                    break;
                case "neons":
                    addons -= 2020;
                    break;
                case "spoiler":
                    addons -= 322;
                    break;
                case "n2o":
                    addons -= 1499;
                    break;
                case "i_am_speed":
                    addons -= 10000;
                    break;
            }
            update_price();
        }

        private void update_policy(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = e.Source as TextBox;
            Debug.WriteLine(textBox.Text);
            bool test = float.TryParse(textBox.Text, out policy);
            if (test)
                policy = float.Parse(textBox.Text);
        }

        private void update_price()
        {
            price.Content = $"${carprice+addons+policy:F2}";
            total = carprice+addons+policy;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("click");
            update_price();
        }

        public void Submit_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).brandPrice = total;
            ((MainWindow)Application.Current.MainWindow).price.Content = $"${((MainWindow)Application.Current.MainWindow).brandPrice + ((MainWindow)Application.Current.MainWindow).enginePrice:F2}";
            this.Close();
        }
    }
}
