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
using System.Windows.Shapes;

namespace _25_10_2021
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).AddUser("Test", "10");
            //((MainWindow)Application.Current.MainWindow).AddUser("Test", "10");
        }
    }
}
