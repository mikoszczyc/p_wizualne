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

namespace _10_01_2022
{
    /// <summary>
    /// Logika interakcji dla klasy GameBoard.xaml
    /// </summary>
    public partial class GameBoard : Window
    {
        public GameBoard(string animal, string difficulty)
        {
            InitializeComponent();
            int boardSize = 3;
            
            switch (animal)
            {
                case "Mouse":
                    break;
                case "Fish":
                    break;
                case "Cat":
                    break;
                case "Crocodile":
                    break;
            }
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
            if (clickedRect.IsVisible)
            {
                clickedRect.Visibility = Visibility.Hidden;
            }
        }
    }
}
