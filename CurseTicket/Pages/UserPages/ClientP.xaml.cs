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
    /// Логика взаимодействия для ClientP.xaml
    /// </summary>
    public partial class ClientP : Page
    {
        public ClientP()
        {
            InitializeComponent();
        }

        private void BackBT_Click(object sender, object e)
        {
            NavigationService.Navigate(new LoginP());
        }
        private void FlightBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MyTicketP());

        }

        private void BuyTicketBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BuyTicketP());

        }

        private void BalanceBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddBalaneP());


        }
    }
}
