using Epam.Shops.Entities;
using System.Data.Entity;

namespace Epam.Shops.DAL
{
    public class ShopsDB : DbContext
    {
        public ShopsDB() : base(@"Data Source=LAPTOP-BDF48BLN\SQLEXPRESS;Initial Catalog=ShopsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
