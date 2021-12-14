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

namespace _13_12_2021
{
    /// <summary>
    /// Logika interakcji dla klasy AreYouSure.xaml
    /// </summary>
    public partial class AreYouSure : Window
    {
        public AreYouSure()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e) //zapisz
        {
            ((MainWindow)Application.Current.MainWindow).Button_Click(sender, e);
            Environment.Exit(0);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e) //bez zapisywania
        {
            Environment.Exit(0);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //cofnij
        {
            Close();
        }
    }
}
