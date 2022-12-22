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
    /// Interaction logic for SalePage.xaml
    /// </summary>
    public partial class SalePage : Page
    {
        public List<Client> Clients { get; set; }
        public List<Product> Products { get; set; }
        public Sale Sale { get; set; }
        public SalePage(Sale sale)
        {
            InitializeComponent();
            Clients = DataAccess.GetClients();
            Products = DataAccess.GetProducts();
            Sale= sale;
            Sale.Date = DateTime.Now;

            DataContext = this;
        }

        private void cbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = cbProduct.SelectedItem as Product;

            Sale.SaleProducts.Add(new SaleProduct { Product = product, Count = 1 });

            lvProducts.ItemsSource = Sale.SaleProducts;
            lvProducts.Items.Refresh();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataAccess.SaveSale(Sale);
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить изменения, допущены ошибки в заполнении", "Предупреждение");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Выбранный продукт будет удален. Продолжить?", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                DataAccess.DeleteSale(Sale);
                NavigationService.GoBack();
            }
        }
    }
}
