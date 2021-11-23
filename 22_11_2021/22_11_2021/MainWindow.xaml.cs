﻿using System;
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
                foreach(User el in items)
                {
                    SerializeToXml(el, saveFileDialog.FileName.Split('.')[0]+".xml");
                }
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                User test = DeserializeToObject<User>(openFileDialog.FileName);
                AddUser(test.Name, test.Count.ToString());
                Debug.WriteLine("x");
                /*  
                //clear list
                items.Clear();
                foreach (string line in File.ReadLines(openFileDialog.FileName))
                {
                    string[] args = line.Split(',');
                    AddUser(args[0], args[2]);
                }*/
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
    }
}
