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
    /// Логика взаимодействия для AddPartyName.xaml
    /// </summary>
    public partial class AddPartyName : Page
    {
        party context;
        public AddPartyName(party party)
        {
            InitializeComponent();
           AirPlaneCB.ItemsSource = App.DB.airplane.ToList();
            context = party;
            DataContext = party;
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (context.id == 0)
                    App.DB.party.Add(context);
                App.DB.SaveChanges();
                NavigationService.Navigate(new AddPartyP(context));
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так ");
            }
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PartyP());
        }

        private void AddBT_Click(object sender, object e)
        {

        }
    }
}
