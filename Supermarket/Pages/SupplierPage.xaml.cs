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
    /// Interaction logic for SupplierPage.xaml
    /// </summary>
    public partial class SupplierPage : Page
    {
        public Supplier Supplier { get; set; }
        public List<TransportType> TransportTypes { get; set; }
        public List<PaymentType> PaymentTypes { get; set; }
        public SupplierPage(Supplier supplier)
        {
            InitializeComponent();
            Supplier = supplier;
            TransportTypes = DataAccess.GetTransportTypes();
            PaymentTypes = DataAccess.GetPaymentTypes();

            DataContext = this;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Выбранный продукт будет удален. Продолжить?", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                DataAccess.DeleteSupplier(Supplier);
                NavigationService.GoBack();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataAccess.SaveSupplier(Supplier);
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить изменения, допущены ошибки в заполнении", "Предупреждение");
            }
        }
    }
}
