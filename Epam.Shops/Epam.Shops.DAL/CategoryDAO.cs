using Epam.Shops.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shops.DAL
{
    public class CategoryDAO : ICategoryDAO
    {
        public bool Add(Shops.Entities.Category newCategory)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shops.Entities.Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Shops.Entities.Category category)
        {
            throw new NotImplementedException();
        }
    }
}
