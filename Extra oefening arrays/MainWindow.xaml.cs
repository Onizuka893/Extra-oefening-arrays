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

namespace Extra_oefening_arrays
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Uitvoer();
        }

        string[] medewerkers = new string[] { "Kristof", "Sander", "Koen" };
        string[] medewerkersNummers = new string[] { "M01", "M02", "M03" };
        decimal[] salarissen = new decimal[] { 0, 0, 0 };
        private int indexMedewerker;


        private void Uitvoer()
        {
            //LstMedewerkers.ItemsSource = null;
            for (int i = 0; i < medewerkers.Length; i++)
            {
                string lijstItemMedewerkers = $"{medewerkersNummers[i]} - {medewerkers[i]} - {salarissen[i]:c}";
                LstMedewerkers.Items.Add(lijstItemMedewerkers);
            }
        }



        private void LstMedewerkers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LblError.Content = "Geen Errors";
            BtnUpdate.IsEnabled = true;
            TxtSalaris.IsEnabled = true;
            indexMedewerker = LstMedewerkers.SelectedIndex;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            // op twee manieren je fout op te vangen d.m.v. een try/catch of een TryParse
            //try
            //{
            //    decimal updateSalaris = Convert.ToDecimal(TxtSalaris.Text);
            //    LblError.Content = "Geen Errors";
            //}
            //catch (FormatException)
            //{
            //    LblError.Content = "Kan tekst niet omzetten naar salaris";
            //}

            string updateSalaris = TxtSalaris.Text;

            // op twee manieren je fout op te vangen d.m.v. een try/catch of een TryParse
            if (decimal.TryParse(updateSalaris, out decimal nieuwSalaris))
            {
                salarissen[indexMedewerker] = nieuwSalaris;
                LstMedewerkers.Items.Clear();
                Uitvoer();
                LblError.Content = "Geen Errors";
            }
            else
            {
                LblError.Content = "Kan tekst niet omzetten naar salaris";

            }

            BtnUpdate.IsEnabled = false;
            TxtSalaris.Clear();
            TxtSalaris.IsEnabled = false;
        }

    }
}

