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
using System.Xml.Serialization;
using System.Configuration;
using System.Collections.Specialized;

namespace _22_11_2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> items = new List<User>();
        public List<User> tmpitems = new List<User>();
        public List<User> searchedItems = new List<User>();
        public MainWindow()
        {
            InitializeComponent();
            GridList.ItemsSource = items;
        }

        public class User
        {
            [XmlAttribute("name")]
            public string Name { get; set; }
            [XmlAttribute("id")]
            public string Id { get; set; }
            [XmlAttribute("count")]
            public int Count { get; set; }
        }

        public void AddUser(string name, string cnt)
        {
            int index = items.Count + 1;
            items.Add(new User() { Name = name, Id = index.ToString(), Count = Int32.Parse(cnt)});
            GridList.Items.Refresh();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
        }

        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //XmlSerializer x = new XmlSerializer(typeof(User));

            if (saveFileDialog.ShowDialog() == true)
            {
                /*foreach(User el in items)
                {
                    SerializeToXml(el, saveFileDialog.FileName.Split('.')[0] + ".xml");
                }*/
                SerializeToXml(items, saveFileDialog.FileName.Split('.')[0] + ".xml");
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                items.Clear();
                tmpitems = DeserializeToObject<List<User>>(openFileDialog.FileName);
                foreach(User el in tmpitems){
                    AddUser(el.Name, el.Count.ToString());
                }
            }
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (items.Count() > 0)
            {
                AreYouSure popupWindow = new AreYouSure();
                popupWindow.ShowDialog();
                e.Cancel = true;
            }
        }
        public static void SerializeToXml<T>(T anyobject, string xmlFilePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(anyobject.GetType());

            using (StreamWriter writer = new StreamWriter(xmlFilePath))
            {
                xmlSerializer.Serialize(writer, anyobject);
            }
        }

        public T DeserializeToObject<T>(string filepath) where T : class
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (StreamReader sr = new StreamReader(filepath))
            {
                return (T)serializer.Deserialize(sr);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text != "")
            {
                if (isNumeric(SearchBox.Text)) //number
                {
                    string searchPhrase = SearchBox.Text.ToString();
                    int index = 0;
                    searchedItems.Clear();
                    GridList.ItemsSource = searchedItems;

                    foreach (User el in items)
                    {
                        if (el.Count.ToString() == searchPhrase)
                        {
                            index++;
                            searchedItems.Add(new User() { Name = el.Name, Id = index.ToString(), Count = el.Count });
                        }
                    }
                    GridList.Items.Refresh();
                }
                else if (!isNumeric(SearchBox.Text)) //string
                {
                string searchPhrase = SearchBox.Text.ToString().ToLower();
                int index = 0;
                searchedItems.Clear();
                GridList.ItemsSource = searchedItems;

                foreach (User el in items)
                {
                    if (el.Name.ToString().ToLower() == searchPhrase)
                    {
                        index++;
                        searchedItems.Add(new User() { Name = el.Name, Id = index.ToString(), Count = el.Count });
                    }
                }
                GridList.Items.Refresh();
                }
            }
            else
            {
                GridList.ItemsSource = items;
                GridList.Items.Refresh();
            }
        }
        bool isNumeric(string input)
        {
            int result;
            return int.TryParse(input, out result);
        }
    }
}
