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
    /// Логика взаимодействия для PartyP.xaml
    /// </summary>
    public partial class PartyP : Page
    {
        public PartyP()
        {
            InitializeComponent();
            PartyDG.ItemsSource = App.DB.party.ToList();
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminP());
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            party p = new party();
            NavigationService.Navigate(new AddPartyName(p));
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedParty = PartyDG.SelectedItem as party;
            if (selectedParty != null)
            {
                NavigationService.Navigate(new AddPartyName(selectedParty));
            }
            else MessageBox.Show("Выберите команду");
        }

        private void DropBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedParty = PartyDG.SelectedItem as party;
            if (selectedParty != null)
            {
                App.DB.party.Remove(selectedParty);
                App.DB.SaveChanges();
                PartyDG.ItemsSource = App.DB.party.ToList();
            }
            else MessageBox.Show("Выберите команду");
        }
    }
}
