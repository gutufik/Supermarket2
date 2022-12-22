using Supermarket.DataBase;
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

namespace Supermarket.Pages
{
    /// <summary>
    /// Interaction logic for DepartmentsPage.xaml
    /// </summary>
    public partial class DepartmentsPage : Page
    {
        public List<Department> Departments { get; set; }
        public DepartmentsPage()
        {
            InitializeComponent();
            Departments = DataAccess.GetDepartments();
            DataAccess.RefreshListsEvent += DataAccess_RefreshListsEvent;

            DataContext = this;
        }

        private void DataAccess_RefreshListsEvent()
        {
            Departments = DataAccess.GetDepartments();
            lvDepartments.ItemsSource = Departments;
            lvDepartments.Items.Refresh();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DepartmentPage(new Department()));
        }

        private void lvDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var department = lvDepartments.SelectedItem as Department;
            if (department != null)
                NavigationService.Navigate(new DepartmentPage(department));
        }
    }
}
