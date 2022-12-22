using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.DataBase;

namespace Supermarket
{
    public static class DataAccess
    {
        public delegate void RefreshListsDelegate();
        public static event RefreshListsDelegate RefreshListsEvent;

        public static List<Product> GetProducts() => SupermarketEntities.GetContext().Products.Where(x => !x.IsDeleted).ToList();
        public static List<Client> GetClients() => SupermarketEntities.GetContext().Clients.ToList();
        public static List<Department> GetDepartments() => SupermarketEntities.GetContext().Departments.ToList();
        public static List<PaymentType> GetPaymentTypes() => SupermarketEntities.GetContext().PaymentTypes.ToList();
        public static List<Sale> GetSales() => SupermarketEntities.GetContext().Sales.ToList();
        public static List<Supplier> GetSuppliers() => SupermarketEntities.GetContext().Suppliers.ToList();
        public static List<TransportType> GetTransportTypes() => SupermarketEntities.GetContext().TransportTypes.ToList();

        internal static void DeleteProduct(Product product)
        {
            product.IsDeleted = true;

            SupermarketEntities.GetContext().SaveChanges();
            RefreshListsEvent?.Invoke();
        }

        internal static void SaveProduct(Product product)
        {
            if (product.Id == 0)
                SupermarketEntities.GetContext().Products.Add(product);

            SupermarketEntities.GetContext().SaveChanges();
            RefreshListsEvent?.Invoke();
        }

        internal static void DeleteClient(Client client)
        {
            SupermarketEntities.GetContext().Clients.Remove(client);
            SupermarketEntities.GetContext().SaveChanges();
            RefreshListsEvent?.Invoke();
        }

        internal static void SaveClient(Client client)
        {
            if (client.Id == 0)
                SupermarketEntities.GetContext().Clients.Add(client);

            SupermarketEntities.GetContext().SaveChanges();
            RefreshListsEvent?.Invoke();
        }

        internal static void DeleteSupplier(Supplier supplier)
        {
            SupermarketEntities.GetContext().Suppliers.Remove(supplier);
            SupermarketEntities.GetContext().SaveChanges();
            RefreshListsEvent?.Invoke();
        }

        internal static void SaveSupplier(Supplier supplier)
        {
            if (supplier.Id == 0)
                SupermarketEntities.GetContext().Suppliers.Add(supplier);

            SupermarketEntities.GetContext().SaveChanges();
            RefreshListsEvent?.Invoke();
        }
    }
}
