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
    }
}
