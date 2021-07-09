using Epam.Shops.Dependency.Registrations;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shops.Dependency
{
    public class DependencyKernel
    {
        private static IKernel _kernel;

        public static IKernel GetKernel()
        {
            if (_kernel is null)
            {
                var dal = new DALRegistrations();
                var bll = new BLLRegistrations();

                _kernel = new StandardKernel(dal, bll);
            }

            return _kernel;
        }
    }
}
