using Epam.Shops.ConsolePL.UserViews;
using Epam.Shops.Entities;
using Epam.Shops.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shops.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            var user2 = new User()
            {
                Id = new Guid("DEAC1581-C7A7-40D9-81B9-4FD5CF525EA2"),
                FirstName = "Наталия",
                LastName = "Растопшина",
                Email = "rastopchyanin@list.ru",
                Age = 14,
                Password = User.Hash("12aa"),
                Gender = Gender.NotSpecified,
                PhoneNumber = "+79195237656"
            };

            new Authorization().Show();
        }
    }
}
