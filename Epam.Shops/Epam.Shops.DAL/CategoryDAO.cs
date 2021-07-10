using Epam.Shops.DAL.Interfaces;
using Epam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shops.DAL
{
    public class CategoryDAO : ICategoryDAO
    {
        public bool Add(Category newCategory)
        {
            int result;

            using (var db = new ShopsDB())
            {
                var id = new SqlParameter("@id", Guid.NewGuid());
                var name = new SqlParameter("@name", newCategory.Name);


                result = db.Database.ExecuteSqlCommand("AddCategory @id, @name", id, name);
            }
            return result == -1;
        }

        public IEnumerable<Category> GetAll()
        {
            List<Category> result;
            using (var db = new ShopsDB())
            {
                result = db.Categories.SqlQuery("GetAllCategories").ToList();
            }

            return result;
        }

        public bool Remove(Guid id)
        {
            int result;

            using (var db = new ShopsDB())
            {
                var param = new SqlParameter("@id", id);

                result = db.Database.ExecuteSqlCommand("RemoveCategory @id", param);
            }

            return result != 0;
        }

        public bool Update(Category category)
        {
            int result;

            using (var db = new ShopsDB())
            {
                var id = new SqlParameter("@id", category.Id);
                var name = new SqlParameter("@name", category.Name);


                result = db.Database.ExecuteSqlCommand("UpdateCategory @id, @name", id, name);
            }
            return result != 0;
        }
    }
}
