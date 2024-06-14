using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Логика взаимодействия для AddBalaneP.xaml
    /// </summary>
    public partial class AddBalaneP : Page
    {
        
        public AddBalaneP()
        {
            InitializeComponent();
        }

        private void AddBT_Click(object sender, object e)
        {
            try
            {
                int sumBal = Convert.ToInt32(SumTB.Text);
                if (sumBal > 0)
                {
                    App.LoggedUser.balance += sumBal;
                    App.DB.SaveChanges();
                    NavigationService.Navigate(new ClientP());
                }
                else MessageBox.Show("Введена неверная сумма");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так ");
            }
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientP());

        }
    }
}
