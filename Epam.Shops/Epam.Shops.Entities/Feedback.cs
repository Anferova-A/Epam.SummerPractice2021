using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.Shops.Entities
{
    public class Feedback
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Shop Shop { get; set; }

        public string Text { get; set; }

        public int Score { get; set; }
        public DateTime Date { get; set; }
        public Feedback()
        {
            Date = DateTime.Now;
        }
    }
}
