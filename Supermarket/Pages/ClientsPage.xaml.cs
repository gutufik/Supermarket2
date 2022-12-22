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
    /// Interaction logic for ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public List<Client> Clients { get; set; }
        public ClientsPage()
        {
            InitializeComponent();
            Clients = DataAccess.GetClients();
            DataAccess.RefreshListsEvent += DataAccess_RefreshListsEvent;
            DataContext = this;
        }
        private void DataAccess_RefreshListsEvent()
        {
            Clients = DataAccess.GetClients();
            lvClients.ItemsSource = Clients;
            lvClients.Items.Refresh();
        }

        private void lvClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var client = lvClients.SelectedItem as Client;
            if (client != null)
                NavigationService.Navigate(new ClientPage(client));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientPage(new Client()));
        }
    }
}
