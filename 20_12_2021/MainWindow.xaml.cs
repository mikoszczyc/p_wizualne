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
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Win32;
using System.Diagnostics;

namespace _20_12_2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool isPlaying;
        public OpenFileDialog openFileDialog = new OpenFileDialog();
        public ListBoxItem selectedItm;
        public string directory = "";
        public MainWindow()
        {
            InitializeComponent();
            isPlaying = false;
			
            openFileDialog.Multiselect = true;
			openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
			if (openFileDialog.ShowDialog() == true)
            {
                directory = openFileDialog.FileNames[0];
                directory = directory.Substring(0, directory.LastIndexOf('\\')) + '\\';
                Debug.WriteLine(directory);
                addSongs(openFileDialog.FileNames);
                
            }
				
		}
		private MediaPlayer mediaPlayer = new MediaPlayer();

        private void addSongs(string[] songs)
        {
            foreach (var song in songs)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = song.Split('\\').Last();
                //itm.Name = song;

                piosenki.Items.Add(itm);
            }
        }
		private void Button_Play_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                mediaPlayer.Pause();
                isPlaying = false;
            }
            else if (!isPlaying)
            {
                ListBoxItem first = piosenki.Items[0] as ListBoxItem;
                Debug.WriteLine(first.Content.ToString());
                if(selectedItm == null)
                    mediaPlayer.Open(new Uri($"{directory}{first.Content.ToString()}"));
                
                else
                    mediaPlayer.Open(new Uri($"{directory}{selectedItm.Content.ToString()}"));

                mediaPlayer.Play();
                isPlaying = true;
            }
                
        }

        private void Button_Stop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            isPlaying = false;
        }

        private void piosenki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mediaPlayer.Stop();
            isPlaying = false;

            selectedItm = piosenki.SelectedItems[0] as ListBoxItem;
            Debug.WriteLine(selectedItm.Content);
            
        }
    }
}
