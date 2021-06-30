using Epam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shops.BLL.Interfaces
{
    public interface CategoryLogic
    {
        bool Add(Category newCategory);
        bool Remove(Guid id);
        bool Update(Category category);
        IEnumerable<Category> GetAll();
    }
}
