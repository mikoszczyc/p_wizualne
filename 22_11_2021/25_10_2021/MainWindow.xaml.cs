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
using Microsoft.Win32;
using System.IO;

namespace _22_11_2021
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
            GridList.ItemsSource = items;
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
            //GridList.ItemsSource = items;
            GridList.Items.Refresh();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string saveText = "";
            foreach(User el in items)
            {
                saveText += $"{el.Name},{el.Id},{el.Count}\n";
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, saveText);
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                //clear list
                items.Clear();
                foreach (string line in File.ReadLines(openFileDialog.FileName))
                {
                    string[] args = line.Split(',');
                    AddUser(args[0], args[2]);
                }
            }
        }
    }
}
