using System;

namespace Epam.Shops.Entities
{
    public class Feedback
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Shop Shop { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }
    }
}
