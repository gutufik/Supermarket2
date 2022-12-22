using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.DataBase
{
    public partial class SupermarketEntities
    {
        private static SupermarketEntities context;
        public static SupermarketEntities GetContext()
        {
            if (context == null)
                context = new SupermarketEntities();
            return context;
        }
    }
}
