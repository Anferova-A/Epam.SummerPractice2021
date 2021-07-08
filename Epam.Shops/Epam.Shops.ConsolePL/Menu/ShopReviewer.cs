using Epam.Shops.Entities;
using System;

namespace Epam.Shops.ConsolePL.Menu
{
    internal class ShopReviewer
    {
        private User _currentShop;

        public ShopReviewer(User currentShop)
        {
            _currentShop = currentShop;
        }

        public Shop CurrentShop { get; set; }

        internal void Show()
        {
            throw new NotImplementedException();
        }
    }
}