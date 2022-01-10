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
    /// Logika interakcji dla klasy ChooseAnimal.xaml
    /// </summary>
    public partial class ChooseAnimal : Window
    {
        public ChooseAnimal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string gameAnimal = animal.Text;
            string gameDifficulty = difficulty.Text;

            GameBoard window = new GameBoard(gameAnimal,gameDifficulty);
            window.Show();
            this.Close();
        }

        private void animal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
