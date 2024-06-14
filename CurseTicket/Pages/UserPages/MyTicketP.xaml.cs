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

namespace CurseTicket.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для MyTicketP.xaml
    /// </summary>
    public partial class MyTicketP : Page
    {
        public MyTicketP()
        {
            InitializeComponent();
            TicketsDG.ItemsSource = App.DB.ticket.Where(a => a.idUser == App.LoggedUser.id).ToList();
        }

        private void AboutBT_Click(object sender, RoutedEventArgs e)
        {
            string message = "";
            var selectedFlight = TicketsDG.SelectedItem as ticket;
            if (selectedFlight != null)
            {
                message += "\nЦена: " + selectedFlight.flight.price;
                message += "\nКоманда: " + selectedFlight.flight.party.name;
                message += "\nБорт: " + selectedFlight.flight.party.airplane.name;
                message += "\nДата: " + selectedFlight.flight.dateFlight;
                message += "\nСтрана: " + selectedFlight.flight.airport.country.name;
                message += "\nАэропорт: " + selectedFlight.flight.airport.name;
                MessageBox.Show(message);
            }
            else MessageBox.Show("Выберите рейс");
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientP());
        }
    }
}
