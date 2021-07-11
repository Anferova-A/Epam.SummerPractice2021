using Epam.Shops.Entities;
using System.Configuration;
using System.Data.Entity;

namespace Epam.Shops.DAL
{
    public class ShopsDB : DbContext
    {
        public ShopsDB() : base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
