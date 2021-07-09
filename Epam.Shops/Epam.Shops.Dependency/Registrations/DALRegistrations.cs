using Epam.Shops.DAL;
using Epam.Shops.DAL.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shops.Dependency.Registrations
{
    public class DALRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryDAO>().To<CategoryDAO>();
            Bind<IFeedbackDAO>().To<FeedbackDAO>();
            Bind<IShopDAO>().To<ShopDAO>();
            Bind<IUserDAO>().To<UserDAO>();
        }
    }
}
