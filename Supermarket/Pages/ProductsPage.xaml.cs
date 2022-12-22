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
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public List<Product> Products { get; set; }
        public ProductsPage()
        {
            InitializeComponent();
            Products = DataAccess.GetProducts();
            DataAccess.RefreshListsEvent += DataAccess_RefreshListsEvent;
            DataContext = this;
        }

        private void DataAccess_RefreshListsEvent()
        {
            Products = DataAccess.GetProducts();
            lvProducts.ItemsSource = Products;
            lvProducts.Items.Refresh();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductPage(new Product()));
        }

        private void lvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = lvProducts.SelectedItem as Product;
            if (product != null)
                NavigationService.Navigate(new ProductPage(product));
        }
    }
}
