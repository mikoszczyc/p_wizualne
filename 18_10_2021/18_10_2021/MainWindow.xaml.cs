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

namespace _18_10_2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public float totalPrice = 0;
        public float brandPrice = 0;
        public float enginePrice = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void brand_Click(object sender, RoutedEventArgs e)
        {
            BrandWindow window = new BrandWindow();
            window.Show();
        }

        private void engine_Click(object sender, RoutedEventArgs e)
        {
            EngineWindow window = new EngineWindow();
            window.Show();
        }
    }
}
