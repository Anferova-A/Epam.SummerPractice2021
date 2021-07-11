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
        User GetByEmail(string email);
        bool ContainsEmail(string email);
        IEnumerable<User> GetAll();
    }
}
