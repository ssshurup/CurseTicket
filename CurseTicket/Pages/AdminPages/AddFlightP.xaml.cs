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
    /// Логика взаимодействия для AddFlightP.xaml
    /// </summary>
    public partial class AddFlightP : Page
    {
        flight context;
        public AddFlightP(flight fl)
        {
            InitializeComponent();
            AirportCB.ItemsSource = App.DB.airport.ToList();
            PartyCB.ItemsSource = App.DB.party.ToList();
            context = fl;
            DataContext = fl;
        }

        private void AddBT_Click(object sender, object e)
        {
            try
            {
                if (context.id == 0)
                    App.DB.flight.Add(context);
                App.DB.SaveChanges();
                NavigationService.Navigate(new FlightP());
            }
            catch
            {
                MessageBox.Show("Что-то не так");
            }
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FlightP());
        }
    }
}
