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
using Supermarket.DataBase;

namespace Supermarket.Pages
{
    /// <summary>
    /// Interaction logic for SuppliersPage.xaml
    /// </summary>
    public partial class SuppliersPage : Page
    {
        public List<Supplier> Suppliers { get; set; }
        public SuppliersPage()
        {
            InitializeComponent();
            Suppliers = DataAccess.GetSuppliers();
            DataAccess.RefreshListsEvent += DataAccess_RefreshListsEvent;

            DataContext = this;
        }

        private void DataAccess_RefreshListsEvent()
        {
            Suppliers = DataAccess.GetSuppliers();
            lvSuppliers.ItemsSource = Suppliers;
            lvSuppliers.Items.Refresh();
        }

        private void lvSuppliers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var supplier = lvSuppliers.SelectedItem as Supplier;
            if (supplier != null)
                NavigationService.Navigate(new SupplierPage(supplier));

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SupplierPage(new DataBase.Supplier()));
        }
    }
}
