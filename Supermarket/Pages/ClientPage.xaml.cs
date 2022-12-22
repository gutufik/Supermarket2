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
    /// Interaction logic for ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public Client Client { get; set; }
        public List<PaymentType> PaymentTypes { get; set; }
        public ClientPage(Client client)
        {
            InitializeComponent();
            this.Client = client;
            PaymentTypes = DataAccess.GetPaymentTypes();

            DataContext = this;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Выбранный продукт будет удален. Продолжить?", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                DataAccess.DeleteClient(Client);
                NavigationService.GoBack();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataAccess.SaveClient(Client);
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить изменения, допущены ошибки в заполнении", "Предупреждение");
            }
        }
    }
}
