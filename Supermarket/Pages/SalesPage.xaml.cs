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
    /// Interaction logic for SalesPage.xaml
    /// </summary>
    public partial class SalesPage : Page
    {
        public List<Sale> Sales { get; set; }
        public SalesPage()
        {
            InitializeComponent();
            Sales = DataAccess.GetSales();
            DataAccess.RefreshListsEvent += DataAccess_RefreshListsEvent;

            DataContext = this;
        }

        private void DataAccess_RefreshListsEvent()
        {
            Sales = DataAccess.GetSales();
            lvSales.ItemsSource = Sales;
            lvSales.Items.Refresh();
        }

        private void lvSales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sale = lvSales.SelectedItem as Sale;
            if (sale != null)
                NavigationService.Navigate(new SalePage(sale));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SalePage(new Sale()));
        }
    }
}
