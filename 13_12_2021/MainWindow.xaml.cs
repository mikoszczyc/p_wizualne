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
using System.Xml.Serialization;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;


namespace _13_12_2021
{

    public partial class MainWindow : Window
    {
// ----------------------------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
            MainWindow_Opening();
        }
        void MainWindow_Opening()
        {
            AreYouSureLoad popupWindow = new AreYouSureLoad();
            popupWindow.ShowDialog();
        }
        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AreYouSure popupWindow = new AreYouSure();
            popupWindow.ShowDialog();
            e.Cancel = true;
        }
        string[] elements = {"typ_pracy", "uczelnia", "kierunek", "zakres", "profil", "forma", "poziom", "student1_imienazwisko", "student1_nralbumu", "student1_data", "student2_imienazwisko", "student2_nralbumu", "student2_data", "student3_imienazwisko", "student3_nralbumu", "student3_data", "student4_imienazwisko", "student4_nralbumu", "student4_data", "praca_tytul", "praca_ang_tytul", "praca_wejscie", "praca_zakres", "praca_termin", "praca_promotor", "praca_jednostka"};
        public void Button_Click(object sender, RoutedEventArgs e) //zapisz
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
                File.Delete(saveFileDialog.FileName);
                string saveContent = 
                typ_pracy.SelectedIndex + ", "+
                uczelnia.Text + ", "+
                kierunek.Text + ", "+
                zakres.Text + ", "+
                profil.Text + ", "+
                forma.Text + ", "+
                poziom.Text + ", "+
                student1_imienazwisko.Text + ", "+
                student1_nralbumu.Text + ", "+
                student1_data.Text + ", "+
                student2_imienazwisko.Text + ", "+
                student2_nralbumu.Text + ", "+
                student2_data.Text + ", "+
                student3_imienazwisko.Text + ", "+
                student3_nralbumu.Text + ", "+
                student3_data.Text + ", "+
                student4_imienazwisko.Text + ", "+
                student4_nralbumu.Text + ", "+
                student4_data.Text + ", "+
                praca_tytul.Text + ", "+
                praca_ang_tytul.Text + ", "+
                praca_wejscie.Text + ", "+
                praca_zakres.Text + ", "+
                praca_termin.Text + ", "+
                praca_promotor.Text + ", "+
                praca_jednostka.Text;
                File.WriteAllText(saveFileDialog.FileName, saveContent);
        }

        public void LoadFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            string loaded = "";
            if (openFileDialog.ShowDialog() == true)
                loaded = File.ReadAllText(openFileDialog.FileName);

            if (loaded != "")
            {
                string[] words = loaded.Split(", ");
                typ_pracy.SelectedIndex = Int32.Parse(words[0]);
                for (int i = 1; i < words.Length; i++)
                {
                    var myTextBox = (TextBox)this.FindName(elements[i]);
                    myTextBox.Text = words[i];
                }
            }
        }

        public void Button_Click_1(object sender, RoutedEventArgs e) //wczytaj
        {
            LoadFile();
        }
    }
}
