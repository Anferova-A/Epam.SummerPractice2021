using Epam.Shops.Entities;
using Epam.Shops.Entities.Issues;
using Epam.Shops.Entities.Issues.Generic;
using System;
using System.Collections.Generic;

namespace Epam.Shops.BLL.Interfaces
{
    public interface ICategoryLogic
    {
        Response Add(Category newCategory);
        Response Remove(Guid id);
        Response Update(Category category);
        Response<IEnumerable<Category>> GetAll();
    }
}
