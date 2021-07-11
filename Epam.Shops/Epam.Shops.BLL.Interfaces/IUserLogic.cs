using Epam.Shops.Entities;
using Epam.Shops.Entities.Enums;
using Epam.Shops.Entities.Issues;
using Epam.Shops.Entities.Issues.Generic;
using System;
using System.Collections.Generic;

namespace Epam.Shops.BLL.Interfaces
{
    public interface IUserLogic
    {
        Response Add(User newUser);
        Response Remove(Guid id);
        Response Update(User user);
        Response<bool> ContainsEmail(string email);
        Response<User> GetByEmail(string email);
        Response<IEnumerable<User>> GetAll();
    }
}
