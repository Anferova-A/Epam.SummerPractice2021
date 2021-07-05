using Epam.Shops.Entities;
using Epam.Shops.Entities.Issues;
using Epam.Shops.Entities.Issues.Generic;
using System;
using System.Collections.Generic;

namespace Epam.Shops.BLL.Interfaces
{
    public interface IShopLogic
    {
        Response Add(Shop newShop);
        Response Remove(Guid id);
        Response Update(Shop shop);
        Response<IEnumerable<Shop>> GetAll();
        Response<IEnumerable<Shop>> GetByCategory(Guid categoryId);
        Response<IEnumerable<Shop>> GetByName(string name);
    }
}
