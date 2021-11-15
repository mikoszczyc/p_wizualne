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

namespace _15_11_2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string seq;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                seq = File.ReadAllText(openFileDialog.FileName);
                seq = seq.Replace("\n", "").Replace("\r", "");

                seqenceTextBox.Text = seq;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    public partial class Algorithm
    {
        //tutaj będzie algorytm
        /*
        FrequentWords(Text, k)
            FrequentPatterns = pusty łańcuch znaków
            for i = 0 to |Text| - k
            Pattern = Text(i, k)
            Count[i] = PatternCount(Text, Pattern) // Algorytm 1
            maxCount = maksymalna wartość w tablicy Count[]
            for i = 0 to |Text| - k
            if Count[i] = maxCount
            dodaj Text(i,k) do FrequentPatterns
            usuń duplikaty z FrequentPatterns
            return FrequentPatterns
         */

        public Algorithm()
        { 
        }

    }
}
