using Epam.Shops.Entities;
using Epam.Shops.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Epam.Shops.DAL.Interfaces
{
    public interface IUserDAO
    {
        bool Add(User newUser);
        bool Remove(Guid id);
        bool Update(User user);
        IEnumerable<User> GetAll();
        IEnumerable<User> GetByAge(int age);
        IEnumerable<User> GetByGenger(Gender gender);
    }
}
