using Epam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shops.DAL
{
    public class ShopsDB : DbContext
    {
        public ShopsDB() : base(@"Data Source=LAPTOP-BDF48BLN\SQLEXPRESS;Initial Catalog=ShopsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }

        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Feedback> Feedbacks { get; set; }
        public IDbSet<Shop> Shops { get; set; }
        public IDbSet<User> Users { get; set; }


    }
}
