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
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public Product Product { get; set; }
        public List<Department> Departments { get; set; }
        public ProductPage(Product product)
        {
            InitializeComponent();
            Product = product;
            Departments = DataAccess.GetDepartments();
            DataContext = this;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataAccess.SaveProduct(Product);
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
                DataAccess.DeleteProduct(Product);
                NavigationService.GoBack();
            }

        }
    }
}
