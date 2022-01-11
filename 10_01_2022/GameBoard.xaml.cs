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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _10_01_2022
{
    /// <summary>
    /// Logika interakcji dla klasy GameBoard.xaml
    /// </summary>
    public partial class GameBoard : Window
    {
        public int hide_i = 0;
        public int hide_j = 0;
        public string myanimal = "";
        DispatcherTimer _timer;
        TimeSpan _time;
        public GameBoard(string animal, string difficulty)
        {
            InitializeComponent();
            //timer
            _time = TimeSpan.FromSeconds(3);
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTime.Content = _time.ToString("c");
                if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();
                    GameSummary window = new GameSummary(0, myanimal);
                    window.Show();
                } 
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            _timer.Stop();

            int boardSize = 3;
            myanimal = animal;
            Image hunted = new Image();
            hunted.Width = 90;
            hunted.Height = 90;
            
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
                switch (animal)
                {
                    case "Mouse":
                        bitmapImage.UriSource = new Uri(@"images/mouse.jpg",UriKind.Relative);
                    break;
                    case "Fish":
                        bitmapImage.UriSource = new Uri(@"/images/fish.jpg", UriKind.Relative);
                        break;
                    case "Cat":
                        bitmapImage.UriSource = new Uri(@"/images/cat.jpg", UriKind.Relative);
                    break;
                    case "Crocodile":
                        bitmapImage.UriSource = new Uri(@"/images/croc.jpg", UriKind.Relative);
                    break;
                }
            bitmapImage.EndInit();
            hunted.Source = bitmapImage;
            switch (difficulty)
            {
                case "Easy":
                    boardSize = 3;
                    break;
                case "Normal":
                    boardSize = 4;
                    break;
                case "Hard":
                    boardSize = 5;
                    break;
                case "Hard++":
                    boardSize = 5;
                    break;
            }
            // roll for animal's hiding place
            Random r = new Random();
            hide_i = r.Next(0, boardSize);
            hide_j = r.Next(0, boardSize);
            GameGrid.Children.Add(hunted);
            Grid.SetRow(hunted, hide_i);
            Grid.SetColumn(hunted, hide_j);

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Rectangle myRect = new Rectangle();
                    switch (difficulty)
                    {
                        case "Easy":
                            myRect.Stroke = Brushes.ForestGreen;
                            myRect.Fill = Brushes.SpringGreen;
                            break;
                        case "Normal":
                            myRect.Stroke = Brushes.DeepSkyBlue;
                            myRect.Fill = Brushes.BlueViolet;
                            break;
                        case "Hard":
                            myRect.Stroke = Brushes.DarkRed;
                            myRect.Fill = Brushes.MediumPurple;
                            break;
                        case "Hard++":
                            myRect.Stroke = Brushes.LightGoldenrodYellow;
                            myRect.Fill = Brushes.MediumVioletRed;
                            break;
                    }
                    myRect.HorizontalAlignment = HorizontalAlignment.Center;
                    myRect.VerticalAlignment = VerticalAlignment.Center;
                    myRect.Height = 90;
                    myRect.Width = 90;
                    myRect.MouseLeftButtonDown += hideRect;

                    GameGrid.Children.Add(myRect);
                    Grid.SetRow(myRect, i);
                    Grid.SetColumn(myRect, j);
                }
            }

        }
        private void hideRect(object sender, MouseButtonEventArgs e)
        {
            Rectangle clickedRect = e.Source as Rectangle;
            if (clickedRect != null && clickedRect.IsVisible)
            {
                if (_time > TimeSpan.Zero && _timer.IsEnabled == false)
                {
                    _timer.Start();
                }
                if (_timer.IsEnabled)
                {
                    clickedRect.Visibility = Visibility.Hidden;
                    if (Grid.GetRow(clickedRect) == hide_i && Grid.GetColumn(clickedRect) == hide_j)
                    {
                        _timer.Stop();
                        GameSummary window = new GameSummary(1, myanimal);
                        window.Show();
                    }
                }
            }
        }
    }
}
