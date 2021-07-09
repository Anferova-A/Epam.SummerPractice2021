using Epam.Shops.BLL;
using Epam.Shops.BLL.Interfaces;
using Ninject.Modules;

namespace Epam.Shops.Dependency.Registrations
{
    public class BLLRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryLogic>().To<CategoryLogic>();
            Bind<IFeedbackLogic>().To<FeedbackLogic>();
            Bind<IShopLogic>().To<ShopLogic>();
            Bind<IUserLogic>().To<UserLogic>();
        }
    }
}
