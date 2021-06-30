using Epam.Shops.Entities;
using Epam.Shops.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shops.BLL.Interfaces
{
    public interface UserLogic
    {
        bool Add(User newUser);
        bool Remove(Guid id);
        bool Update(User user);
        IEnumerable<User> GetAll();
        IEnumerable<User> GetByAge(int age);
        IEnumerable<User> GetByGenger(Gender gender);
    }
}
