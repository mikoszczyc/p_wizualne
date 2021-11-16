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
using System.Diagnostics;

namespace _15_11_2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string seq = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                patternsTextBox.Clear();
                patternsCombo.SelectedItem = null;
                patternsCombo.Items.Clear();
                seq = File.ReadAllText(openFileDialog.FileName);
                seq = seq.Replace("\n", "").Replace("\r", "");

                TextRange textRange = new TextRange(seqenceTextBox.Document.ContentStart, seqenceTextBox.Document.ContentEnd);
                textRange.Text = seq;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count > 0){
            string pattern = e.AddedItems[0].ToString();
            Debug.WriteLine(pattern);
            TextPointer start = seqenceTextBox.Document.ContentStart;
            TextPointer end = seqenceTextBox.Document.ContentEnd;
            TextRange textRange = new TextRange(start, end);

            textRange.ClearAllProperties();
            if(textRange.Text != "")
            {

                string textBoxText = textRange.Text;
                string searchText = pattern;

                //Debug.WriteLine(textBoxText);

                for (TextPointer startPointer = seqenceTextBox.Document.ContentStart; 
                    startPointer.CompareTo(seqenceTextBox.Document.ContentEnd) <= 0; 
                        startPointer = startPointer.GetNextContextPosition(LogicalDirection.Forward))
                {
                    if (startPointer.CompareTo(end) == 0) // koniec tekstu
                        break;

                    string parsedString = startPointer.GetTextInRun(LogicalDirection.Forward);

                    int i = parsedString.IndexOf(searchText);

                    if (i >= 0)
                    {
                        startPointer = startPointer.GetPositionAtOffset(i);
                        if (startPointer != null)
                        {
                            TextPointer nextPointer = startPointer.GetPositionAtOffset(searchText.Length);
                            TextRange searchRange = new TextRange(startPointer, nextPointer);
                            searchRange.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.Red));
                        }
                    }
                }
            }
            }
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            if (seq != "")
            {
                Algorithm al = new Algorithm();
                for (int k = 2; k < 5; k++) // TODO: zmienić przedziały
                {
                    al.findPatterns(seq, k);
                }
            }
        }
    }
    public class Algorithm
    {
        public void findPatterns(string seq, int k)
        {
            List<(string, int)> foundPatterns = new List<(string, int)>();
            List<string> kmers = new List<string>();
            string pattern = "";
            int[] Count = new int[seq.Length - k];
            string patternString = "";

            for (int i = 0; i < seq.Length - k; i++)
            {
                pattern = seq.Substring(i, k);
                Count[i] = patternCount(seq, pattern);
                if (Count[i] > 1 && foundPatterns.Contains((pattern, Count[i])) == false)
                {
                    foundPatterns.Add((pattern, Count[i]));
                }
            }
            
            //foundPatterns.Sort(); //sortowanie alfabetyczne
            foundPatterns = foundPatterns.OrderByDescending(x=>x.Item2).ToList(); //sortowanie po 2 przedmiocie z krotki
            foreach (var item in foundPatterns)
            {
                patternString = patternString + item.Item1+" - "+item.Item2 +"\n";
                ((MainWindow)Application.Current.MainWindow).patternsCombo.Items.Add(item.Item1);
            }

            
            ((MainWindow)Application.Current.MainWindow).patternsTextBox.Text = patternString;
        }

        public int patternCount(string seq, string pattern)
        {
            int count = 0;
            for (int i = 0; i < seq.Length-pattern.Length; i++)
                if (seq.Substring(i, pattern.Length) == pattern)
                    count++;
            return count;
        }
    }
}
