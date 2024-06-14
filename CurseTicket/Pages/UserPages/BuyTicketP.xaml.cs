using CurseTicket.Pages.AdminPages;
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
    /// Логика взаимодействия для BuyTicketP.xaml
    /// </summary>
    public partial class BuyTicketP : Page
    {
        public BuyTicketP()
        {
            InitializeComponent();
            BalanceTB.Text += App.LoggedUser.balance;
            TicketsDG.ItemsSource = App.DB.flight.ToList();
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientP());
        }

        private void AddBT_Click(object sender, object e)
        {
            var selectedFlight = TicketsDG.SelectedItem as flight;
            if (selectedFlight != null)
            {
                if(App.LoggedUser.balance >= selectedFlight.price)
                {
                    ticket tick = new ticket();
                    tick.idUser = App.LoggedUser.id;
                    tick.idFlight = selectedFlight.id;
                    App.DB.ticket.Add(tick);
                    App.DB.SaveChanges();
                    MessageBox.Show("Билет куплен");
                    App.LoggedUser.balance -= selectedFlight.price - selectedFlight.price/100 * App.LoggedUser.discount.count;
                    BalanceTB.Text += App.LoggedUser.balance;
                }
            }
            else MessageBox.Show("Выберите рейс");
        }

        private void AboutBT_Click(object sender, RoutedEventArgs e)
        {
            string message = "";
            var selectedFlight = TicketsDG.SelectedItem as flight;
            if (selectedFlight != null)
            {
                message += "\nЦена: " + selectedFlight.price;
                message += "\nКоманда: " + selectedFlight.party.name;
                message += "\nБорт: " + selectedFlight.party.airplane.name;
                message += "\nДата: " + selectedFlight.dateFlight;
                message += "\nСтрана: " + selectedFlight.airport.country.name;
                message += "\nАэропорт: " + selectedFlight.airport.name;
                MessageBox.Show(message);
            }
            else MessageBox.Show("Выберите рейс");
        }
    }
}
