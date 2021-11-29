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
        public User selectedUser;
        public Book selectedBook;
        public List<User> listOfUsers = new List<User>();
        public List<Book> listOfBooks = new List<Book>();
        public List<User> tmpUsers = new List<User>();
        public List<Book> tmpBooks = new List<Book>();

        public MainWindow()
        {
            InitializeComponent();
            userList.ItemsSource = listOfUsers;
            booksList.ItemsSource = listOfBooks;
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\users_SaveFile.xml") && File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\books_SaveFile.xml"))
            {
                LoadFile("users_SaveFile.xml", "books_SaveFile.xml");
            }

        }
        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listOfUsers.Count() > 0 || listOfBooks.Count() > 0)
            {
                AreYouSure popupWindow = new AreYouSure();
                popupWindow.ShowDialog();
                e.Cancel = true;
            }
        }
        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SerializeToXml(listOfUsers, AppDomain.CurrentDomain.BaseDirectory + "\\users_SaveFile.xml");
            SerializeToXml(listOfBooks, AppDomain.CurrentDomain.BaseDirectory + "\\books_SaveFile.xml");
        }
        void LoadFile(string users_fileName, string books_fileName)
        {
            listOfUsers.Clear();
            listOfBooks.Clear();
            tmpUsers= DeserializeToObject<List<User>>(AppDomain.CurrentDomain.BaseDirectory + "\\" + users_fileName);
            tmpBooks = DeserializeToObject<List<Book>>(AppDomain.CurrentDomain.BaseDirectory + "\\" + books_fileName);
            foreach (User el in tmpUsers)
            {
                AddUser(el.user_FirstName, el.user_LastName);
            }
            foreach (Book el in tmpBooks)
            {
                AddBook(el.book_title, el.book_author,el.book_status);
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
        public void AddBook(string title, string author, string status = "Nie wypozyczona")
        {
            int index = listOfBooks.Count + 1;
            listOfBooks.Add(new Book() {book_title = title,book_author = author, book_id = index.ToString(),book_status = status });
            booksList.Items.Refresh();
        }

        private void AddUser_Button_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser_window = new AddUser();
            addUser_window.Show();
        }

        private void Borrow_Button_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser != null && selectedBook != null)
            {
                Debug.WriteLine(selectedUser.user_id + " -> " + selectedBook.book_title);
                if(selectedBook.book_status == "Nie wypozyczona")
                {
                    (booksList.SelectedItem as Book).book_status = selectedUser.user_id;
                    booksList.Items.Refresh();
                }
            }
        }
        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser != null && selectedBook != null)
            {
                Debug.WriteLine(selectedUser.user_id + " -> " + selectedBook.book_title);
                if (selectedBook.book_status == selectedUser.user_id)
                {
                    (booksList.SelectedItem as Book).book_status = "Nie wypozyczona";
                    booksList.Items.Refresh();
                }
            }
        }
        private void AddBook_Button_Click(object sender, RoutedEventArgs e)
        {
            AddBook addBook_window = new AddBook();
            addBook_window.Show();
        }

        private void userList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedUser = userList.SelectedItems[0] as User;
        }

        private void booksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBook = booksList.SelectedItems[0] as Book;
        }
    }
}
