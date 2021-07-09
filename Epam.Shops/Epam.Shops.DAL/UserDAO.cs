using Epam.Shops.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shops.DAL
{
    public class UserDAO : IUserDAO
    {
        public bool Add(Shops.Entities.User newUser)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shops.Entities.User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shops.Entities.User> GetByAge(int age)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shops.Entities.User> GetByGenger(Shops.Entities.Enums.Gender gender)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Shops.Entities.User user)
        {
            throw new NotImplementedException();
        }
    }
}
