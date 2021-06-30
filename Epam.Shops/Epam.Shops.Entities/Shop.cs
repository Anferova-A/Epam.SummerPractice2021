using System;
using System.Collections.Generic;

namespace Epam.Shops.Entities
{
    public class Shop
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Site { get; set; }
        public string Address { get; set; }
        public Category Category { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

    }
}
