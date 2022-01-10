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
                    break;
                case "Normal":
                    break;
                case "Hard":
                    break;
                case "Hard++":
                    break;
            }

            InitializeComponent();
        }
    }
}
