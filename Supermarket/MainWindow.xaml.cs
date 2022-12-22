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
using Supermarket.Pages;

namespace Supermarket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frmMain.NavigationService.Navigate(new ProductsPage());
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            frmMain.NavigationService.Navigate(new ProductsPage());
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            frmMain.NavigationService.Navigate(new ClientsPage());
        }

        private void btnDepartments_Click(object sender, RoutedEventArgs e)
        {
            frmMain.NavigationService.Navigate(new DepartmentsPage());
        }

        private void btnSales_Click(object sender, RoutedEventArgs e)
        {
            frmMain.NavigationService.Navigate(new SalesPage());
        }

        private void btnSuppliers_Click(object sender, RoutedEventArgs e)
        {
            frmMain.NavigationService.Navigate(new SuppliersPage());
        }
    }
}
