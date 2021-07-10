using Epam.Shops.DAL.Interfaces;
using Epam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace Epam.Shops.DAL
{
    public class ShopDAO : IShopDAO
    {
        //rowcounts?????
        public bool Add(Shop newShop)
        {
            int result;

            using (var db = new ShopsDB())
            {
                var id = new SqlParameter("@id", Guid.NewGuid());
                var name = new SqlParameter("@name", newShop.Name);
                var site = new SqlParameter("@site", newShop.Site);
                var address = new SqlParameter("@address", newShop.Address);
                var categoryId = new SqlParameter("@category_id", newShop.Category);

                result = db.Database.ExecuteSqlCommand("AddShop @id, @name, @site, @address, @category_id", id, name, site, address, categoryId);
            }
            return result == -1;
        }

        public IEnumerable<Shop> GetAll()
        {
            List<Shop> result;
            using (var db = new ShopsDB())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var queryResult = db.Shops.SqlQuery("GetAllShops");
                result = LoadShops(db, queryResult);
            }

            return result;
        }

        

        public IEnumerable<Shop> GetByCategory(Guid categoryId)
        {
            List<Shop> result;
            using (var db = new ShopsDB())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var param = new SqlParameter("@categoryId", categoryId);
                var queryResult = db.Shops.SqlQuery("GetShopsByCategory @categoryId", categoryId);

                result = LoadShops(db, queryResult);
            }

            return result;
        }

        public IEnumerable<Shop> GetByName(string name)
        {
            List<Shop> result;
            using (var db = new ShopsDB())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var param = new SqlParameter("@name", name);
                var queryResult = db.Shops.SqlQuery("GetShopsByName @name", param);

                result = LoadShops(db, queryResult);
            }

            return result;
        }

        //rowcount 
        public bool Remove(Guid id)
        {
            int result;

            using (var db = new ShopsDB())
            {
                var param = new SqlParameter("@id", id);

                result = db.Database.ExecuteSqlCommand("RemoveShop @id", param);
            }

            return result != 0;
        }

        public bool Update(Shop shop)
        {
            int result;

            using (var db = new ShopsDB())
            {
                var id = new SqlParameter("@id", shop.Id);
                var name = new SqlParameter("@name", shop.Name);
                var site = new SqlParameter("@site", shop.Site);
                var address = new SqlParameter("@address", shop.Address);
                var categoryId = new SqlParameter("@category_id", shop.Category);

                result = db.Database.ExecuteSqlCommand("UpdateShop @id, @name, @site, @address, @category_id", id, name, site, address, categoryId);
            }

            return result != 0;
        }

        private List<Shop> LoadShops(ShopsDB db, DbSqlQuery<Shop> queryResult)
        {
            var result = new List<Shop>();

            foreach (var item in queryResult.ToArray())
            {
                db.Entry(item).Reference(s => s.Category).Load();
                result.Add(item);
            }

            return result;
        }
    }
}
