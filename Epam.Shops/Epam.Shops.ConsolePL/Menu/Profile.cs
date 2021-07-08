using Epam.Shops.Entities;
using System;

namespace Epam.Shops.ConsolePL.Menu
{
    internal class Profile
    {
        private User _currentUser;

        public Profile(User currentUser)
        {
            this._currentUser = currentUser;
        }

        internal void Show()
        {
            throw new NotImplementedException();
        }
    }
}