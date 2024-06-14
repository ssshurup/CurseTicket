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
    /// Логика взаимодействия для AddEmployeeP.xaml
    /// </summary>
    public partial class AddEmployeeP : Page
    {
        employee context;
        public AddEmployeeP(employee emp)
        {
            InitializeComponent();
            context = emp;
            DataContext = context;
            PostCB.ItemsSource = App.DB.post.ToList();
        }

        private void AddBT_Click(object sender, object e)
        {
            try
            {
                if (context.id == 0)
                    App.DB.employee.Add(context);
                App.DB.SaveChanges();
                NavigationService.Navigate(new EmployeeP());
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void BackBT_Click(object sender, object e)
        {
            NavigationService.Navigate(new EmployeeP());
        }
    }
}
