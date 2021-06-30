using Epam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shops.BLL.Interfaces
{
    public interface ShopLogic
    {
        bool Add(Shop newShop);
        bool Remove(Guid id);
        bool Update(Shop shop);
        IEnumerable<Shop> GetAll();
        IEnumerable<Shop> GetByCategory(Guid categoryId);
        IEnumerable<Shop> GetByName(string name);
    }
}
