using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _29_11_2021
{
    /// <summary>
    /// Logika interakcji dla klasy AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public string firstNameInput = "";
        public string lastNameInput = "";

        public AddUser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).AddUser(firstNameInput, lastNameInput);
            Close();
        }

        private void FirstName_input_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = e.Source as TextBox;
            firstNameInput = textBox.Text;
        }

        private void LastName_input_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = e.Source as TextBox;
            lastNameInput = textBox.Text;
        }
    }
}
