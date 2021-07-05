using Epam.Shops.Entities;
using System;
using System.Collections.Generic;

namespace Epam.Shops.DAL.Interfaces
{
    public interface IShopDAO
    {
        bool Add(Shop newShop);
        bool Remove(Guid id);
        bool Update(Shop shop);
        IEnumerable<Shop> GetAll();
        IEnumerable<Shop> GetByCategory(Guid categoryId);
        IEnumerable<Shop> GetByName(string name);
    }
}
