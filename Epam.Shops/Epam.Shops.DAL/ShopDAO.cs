using Epam.Shops.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shops.DAL
{
    public class ShopDAO : IShopDAO
    {
        public bool Add(Shops.Entities.Shop newShop)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shops.Entities.Shop> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shops.Entities.Shop> GetByCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shops.Entities.Shop> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Shops.Entities.Shop shop)
        {
            throw new NotImplementedException();
        }
    }
}
