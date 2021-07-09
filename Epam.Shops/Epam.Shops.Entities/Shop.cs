using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.Shops.Entities
{
    public class Shop : IEquatable<Shop>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Site { get; set; }
        public string Address { get; set; }
        public Category Category { get; set; }

        public bool Equals(Shop other) => this.Id == other.Id;
    }
}
