using System;
using System.Collections.Generic;

namespace Epam.Shops.Entities
{
    public class Shop : IEquatable<Shop>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Site { get; set; }
        public string Address { get; set; }
        public Category Category { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public bool Equals(Shop other) => this.Id == other.Id;
    }
}
