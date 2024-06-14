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

namespace CurseTicket.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для FlightP.xaml
    /// </summary>
    public partial class FlightP : Page
    {
        public FlightP()
        {
            InitializeComponent();
                FlightDG.ItemsSource = App.DB.flight.ToList();
        }

        private void AddBT_Click(object sender, object e)
        {
            flight fl = new flight();
            NavigationService.Navigate(new AddFlightP(fl));
        }

        private void EditBT_Click(object sender, object e)
        {
            var selectedFlight = FlightDG.SelectedItem as flight;
            if (selectedFlight != null)
            {
                NavigationService.Navigate(new AddFlightP(selectedFlight));
            }
            else MessageBox.Show("Выберите рейс");
        }

        private void DropBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedFlight = FlightDG.SelectedItem as flight;
            if (selectedFlight != null)
            {
                App.DB.flight.Remove(selectedFlight);
                App.DB.SaveChanges();
                FlightDG.ItemsSource = App.DB.flight.ToList();
            }
            else MessageBox.Show("Выберите рейс");
        }
        private void AboutBT_Click(object sender, object e)
        {
            string message = "";
            var selectedFlight = FlightDG.SelectedItem as flight;
            if (selectedFlight != null)
            {
                message += "\nЦена: " + selectedFlight.price;
                message += "\nКоманда: " + selectedFlight.party.name ;
                message += "\nБорт: " + selectedFlight.party.airplane.name;
                message += "\nДата: " + selectedFlight.dateFlight;
                message += "\nСтрана: " + selectedFlight.airport.country.name;
                message += "\nАэропорт: " + selectedFlight.airport.name;
                MessageBox.Show(message);
            }
            else MessageBox.Show("Выберите рейс");
        }
        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminP());
        }

        
    }
}
