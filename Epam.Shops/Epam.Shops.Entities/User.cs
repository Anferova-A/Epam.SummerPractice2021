using Epam.Shops.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace Epam.Shops.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        public bool CheckPassword(string password)
            => Password == Hash(password);

        private string Hash(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            var result = new SHA256Managed().ComputeHash(data);
            return BitConverter.ToString(result);
        }



    }
}
