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
using System.Diagnostics;

namespace _06_12_2021
{
    /// <summary>
    /// Logika interakcji dla klasy Summary.xaml
    /// </summary>
    public partial class Summary : Window
    {
        public Summary()
        {
            InitializeComponent();
            var origin = ((MainWindow)Application.Current.MainWindow);
            if (origin.checkbox_ICAO.IsChecked ?? true)
            {
                Debug.WriteLine("ICAO = TRUE");

                label1.Content = "Kod ICAO: " + origin.selectedAirport.ICAO;
            }
            if (origin.checkbox_IATA.IsChecked ?? true)
            {
                Debug.WriteLine("IATA = TRUE");

                label2.Content = "Kod IATA: " + origin.selectedAirport.IATA;

            }
            if (origin.checkbox_Passengers.IsChecked ?? true)
            {
                Debug.WriteLine("Passengers = TRUE");

                label3.Content = "Liczba pasażerów: " + origin.selectedAirport.numberOfPassengers;
            }
            if (origin.checkbox_Voivodeship.IsChecked ?? true)
            {
                Debug.WriteLine("Voivodeship = TRUE");

                label4.Content = "Województwo: " + origin.selectedAirport.voivodeship;
            }
            if (origin.checkbox_City.IsChecked ?? true)
            {
                Debug.WriteLine("City = TRUE");

                label5.Content = "Miasto: " + origin.selectedAirport.mainCity;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
