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
    /// Логика взаимодействия для AdminP.xaml
    /// </summary>
    public partial class AdminP : Page
    {
        public AdminP()
        {
            InitializeComponent();
        }

        private void BackBT_Click(object sender, object e)
        {
            NavigationService.Navigate(new LoginP());
        }

        private void EmployeeBT_Click(object sender, object e)
        {
            NavigationService.Navigate(new EmployeeP());
        }

        private void PartyBT_Click(object sender, object e)
        {
            NavigationService.Navigate(new PartyP());
        }

        private void FlightBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FlightP());
        }
    }
}
