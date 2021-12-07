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
using System.Xml.Serialization;
using System.Configuration;
using System.Collections.Specialized;
using System.Reflection;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;

namespace _06_12_2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class Airport
    {
        [XmlAttribute("mainCity")]
        public string mainCity { get; set; }
        [XmlAttribute("voivodeship")]
        public string voivodeship { get; set; }
        [XmlAttribute("ICAO")]
        public string ICAO { get; set; }
        [XmlAttribute("IATA")]
        public string IATA { get; set; }
        [XmlAttribute("airportName")]
        public string airportName { get; set; }
        [XmlAttribute("numberOfPassengers")]
        public string numberOfPassengers { get; set; }
        [XmlAttribute("change")]
        public string change { get; set; }

        public Airport(string mainCity, string voivodeship, string ICAO, string IATA, string airportName, string numberOfPassengers, string change)
        {
            this.mainCity = mainCity;
            this.voivodeship = voivodeship;
            this.ICAO = ICAO;
            this.IATA = IATA;
            this.airportName = airportName;
            this.numberOfPassengers = numberOfPassengers;
            this.change = change;
        }
    }
        public partial class MainWindow : Window
    {
        public Airport selectedAirport;
        public List<Airport> Airports = new List<Airport>();
        public string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(path + "\\Test_Data.csv"))
            {
                LoadFile("Test_Data.csv");
                airportsList.ItemsSource = Airports;
                airportsList.Items.Refresh();
            }
            else
                Console.WriteLine("Sorry, no input file found!");
            
        }

        void LoadFile(string fileName)
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            //string fileContent = File.ReadAllText(path + "\\" + fileName, Encoding.UTF8);
            
            using (TextFieldParser csvParser = new TextFieldParser(path + "\\" + fileName))
            {
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                csvParser.ReadLine();
                csvParser.ReadLine();


                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    Airport newAirport = new Airport(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], fields[6]);
                    Airports.Add(newAirport);
                }
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Summary window = new Summary();

            if (selectedAirport != null)
            {
                window.Show();
            }
        }

        private void airportsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedAirport = airportsList.SelectedItems[0] as Airport;
            Debug.WriteLine(selectedAirport.airportName);
        }
    }
}
