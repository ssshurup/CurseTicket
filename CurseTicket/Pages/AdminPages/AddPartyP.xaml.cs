using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
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
    /// Логика взаимодействия для AddPartyP.xaml
    /// </summary>
    public partial class AddPartyP : Page
    {
        party context;
        public AddPartyP(party party)
        {
            InitializeComponent();
            context = party;

            AddedEmployeeDG.ItemsSource = App.DB.employee.Where(a => a.idParty == context.id).ToList();
            EmployeeListDG.ItemsSource = App.DB.employee.Where(a => a.idParty == null).ToList();
        }
        public static MessageBoxResult MBWindow(string message)
        {
            
            string caption = "Продолжить действие?";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            var result = MessageBox.Show(message, caption, buttons, MessageBoxImage.Question);
            return result;
        }
        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            string message = "Команда состоит меньше, чем из 4-х сотрудников, закончить формирование?";
            int countPartyEmp = 0;
            foreach (var c in App.DB.employee.Where(a => a.idParty == context.id).ToList())
            {
                countPartyEmp++;
            }
            if (countPartyEmp <= 3)
            {
                if (MBWindow(message) == MessageBoxResult.Yes)
                {
                    NavigationService.Navigate(new PartyP());
                }
            }else NavigationService.Navigate(new PartyP());
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmp = EmployeeListDG.SelectedItem as employee;
            if (selectedEmp != null)
            {
                string message = "Вы уверены, что хотите добавить сотрудника в команду?";
                if (MBWindow(message) == MessageBoxResult.Yes)
                {
                    selectedEmp.idParty = context.id;
                    App.DB.SaveChanges();
                    AddedEmployeeDG.ItemsSource = App.DB.employee.Where(a => a.idParty == context.id).ToList();
                    EmployeeListDG.ItemsSource = App.DB.employee.Where(a => a.idParty == null).ToList();
                }
            }
            else MessageBox.Show("Выберите работника");
        }

        private void DropBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmp = AddedEmployeeDG.SelectedItem as employee;
            if (selectedEmp != null)
            {
                string message = "Вы уверены, что хотите убрать сотрудника из команды?";
                
                if (MBWindow(message) == MessageBoxResult.Yes)
                {

                    selectedEmp.idParty = null;
                    App.DB.SaveChanges();
                    AddedEmployeeDG.ItemsSource = App.DB.employee.Where(a => a.idParty == context.id).ToList();
                    EmployeeListDG.ItemsSource = App.DB.employee.Where(a => a.idParty == null).ToList();
                }
            }
            else MessageBox.Show("Выберите работника");
        }

        private void ClearBT_Click(object sender, object e)
        {
            string message = "Вы уверены, что хотите очистить список?";
            if (MBWindow(message) == MessageBoxResult.Yes)
            {
                foreach (var c in App.DB.employee.Where(a => a.idParty == context.id).ToList())
                {
                    c.idParty = null;

                }
                App.DB.SaveChanges();
                AddedEmployeeDG.ItemsSource = App.DB.employee.Where(a => a.idParty == context.id).ToList();
                EmployeeListDG.ItemsSource = App.DB.employee.Where(a => a.idParty == null).ToList();
            }
        }

        private void CompleteBT_Click(object sender, RoutedEventArgs e)
        {
            string message = "Команда состоит меньше, чем из 4-х сотрудников, закончить формирование?";
            int countPartyEmp = 0;
            foreach (var c in App.DB.employee.Where(a => a.idParty == context.id).ToList())
            {
                countPartyEmp++;
            }
            if(countPartyEmp <= 3)
            {
                if (MBWindow(message) == MessageBoxResult.Yes)
                {
                    NavigationService.Navigate(new PartyP());
                }
            }
            else NavigationService.Navigate(new PartyP());
        }
    }
}
