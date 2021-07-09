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
        public bool Add(Shop newShop)
        {
            throw new NotImplementedException();
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
            using(var db = new ShopsDB())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var param = new SqlParameter("@name", name);
                var queryResult = db.Shops.SqlQuery("GetShopsByName @name", param);

                result = LoadShops(db, queryResult);
            }

            return result;
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Shop shop)
        {
            throw new NotImplementedException();
        }

        private List<Shop> LoadShops(ShopsDB db, DbSqlQuery<Shop> queryResult)
        {
            var result = new List<Shop>();

            foreach (var item in queryResult.ToList())
            {
                db.Entry(item).Reference(s => s.Category).Load();
                result.Add(item);
            }

            return result;
        }
    }
}
