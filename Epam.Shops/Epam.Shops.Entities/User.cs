using Epam.Shops.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Epam.Shops.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        private string _password;
        public ICollection<Feedback> Feedbacks { get; set; }

    }
}
