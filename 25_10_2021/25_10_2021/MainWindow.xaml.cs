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
using System.Diagnostics;

namespace _25_10_2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> items = new List<User>();
        public MainWindow()
        {
            InitializeComponent();
            //items.Add(new User() { Name = "John Doe", Id = "1", Count = 15});
            AddUser("Steve", "10");
            //items.Add(new User() { Name = "John Doe", Id = "1", Count = 15});
            //GridList.ItemsSource = items;
        }

        public class User
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public int Count { get; set; }
        }

        public void AddUser(string name, string cnt)
        {
            int index = items.Count + 1;
            items.Add(new User() { Name = name, Id = index.ToString(), Count = Int32.Parse(cnt)});
            GridList.ItemsSource = items;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
