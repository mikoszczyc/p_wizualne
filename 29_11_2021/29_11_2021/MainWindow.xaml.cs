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
using Microsoft.Win32;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;
using System.Collections.Specialized;
using System.Reflection;
using System.Diagnostics;

namespace _29_11_2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> listOfUsers = new List<User>();
        public List<Book> listOfBooks = new List<Book>();

        public MainWindow()
        {
            InitializeComponent();
            userList.ItemsSource = listOfUsers;
            booksList.ItemsSource = listOfBooks;
        }
        public class User
        {
            [XmlAttribute("user_FirstName")]
            public string user_FirstName { get; set; }
            [XmlAttribute("user_LastName")]
            public string user_LastName { get; set; }
            [XmlAttribute("user_id")]
            public string user_id { get; set; }
        }
        public class Book
        {
            [XmlAttribute("book_title")]
            public string book_title { get; set; }
            [XmlAttribute("book_author")]
            public string book_author { get; set; }
            [XmlAttribute("book_id")]
            public string book_id { get; set; }
            [XmlAttribute("book_status")]
            public string book_status { get; set; }
        }

        public void AddUser(string firstName, string lastName)
        {
            int index = listOfUsers.Count + 1;
            listOfUsers.Add(new User() { user_FirstName = firstName, user_LastName = lastName, user_id = index.ToString() });
            userList.Items.Refresh();
        }
        public void AddBook(string title, string author)
        {
            int index = listOfUsers.Count + 1;
            listOfBooks.Add(new Book() {book_title = title,book_author = author, book_id = index.ToString(),book_status = "Nie wypozyczona" });
            booksList.Items.Refresh();
        }

        private void AddUser_Button_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser_window = new AddUser();
            addUser_window.Show();
        }

        private void Borrow_Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(userList.SelectedItem.ToString());
            
        }

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBook_Button_Click(object sender, RoutedEventArgs e)
        {
            AddBook addBook_window = new AddBook();
            addBook_window.Show();
        }

        private void userList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User selectedUser = userList.SelectedItems[0] as User;
        }

        private void booksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book selectedBook = booksList.SelectedItems[0] as Book;
        }
    }
}
