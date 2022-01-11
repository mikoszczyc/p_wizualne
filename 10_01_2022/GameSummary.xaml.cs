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
    /// Logika interakcji dla klasy GameSummary.xaml
    /// </summary>
    public partial class GameSummary : Window
    {
        public GameSummary(int result, string animal)
        {
            InitializeComponent();
            if (result == 1)
            {
                if (animal == "Crocodile")
                {
                    Random random = new Random();
                    bool isEaten = Convert.ToBoolean(random.Next(0, 2));
                    if (isEaten)
                    {
                        // Croc ate you!
                        result_label.Content = "Croc ate you!";
                    }
                    else
                    {
                        // winner!
                        result_label.Content = "You won!\nYou caught a Crocodile!";
                    }
                }
                else
                {
                    //winner!
                    result_label.Content = $"You won!\nYou caught a {animal}!";
                }
            }
            else
            {
                //time out!
                result_label.Content = "Time is out!\nNo dinner for you today 😥";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChooseAnimal chooseAnimal = new ChooseAnimal();
            chooseAnimal.Show();
            for (int intCounter = App.Current.Windows.Count - 2; intCounter >= 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }
    }
}
