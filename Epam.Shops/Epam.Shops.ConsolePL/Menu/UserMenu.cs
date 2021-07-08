using Epam.Shops.BLL.Interfaces;
using Epam.Shops.Entities;
using System;
using Epam.Shops.ConsolePL.Utils;

namespace Epam.Shops.ConsolePL.Menu
{
    public class UserMenu
    {
        private User _currentUser;

        private Profile _profile;

        private ShopMenu _shopMenu;

        private IFeedbackLogic _feedbackLogic;

        private IShopLogic _shopLogic;

        public UserMenu(User currentUser)
        {
            _currentUser = currentUser;

            _profile = new Profile(_currentUser);
            _shopMenu = new ShopMenu(_currentUser);
        }

        public void Show()
        {
            Console.Clear();

            string userMenuText = "Список действий:\n" +
                "\t1. Мой профиль\n" +
                "\t2. Мои отзывы\n" +
                "\t3. Поиск магазина\n" +
                "\t0. Выйти\n" +
                "Ввод: ";

            string select = "";
            while (select != "0")
            {
                Console.WriteLine(userMenuText);
                select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        _profile.Show();
                        break;
                    case "2":
                        ShowFeedbacks();
                        break;
                    case "3":
                        _shopMenu.Show();
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;

                }
            }
        }

        private void ShowFeedbacks()
        {
            var response = _feedbackLogic.GetByUser(_currentUser.Id);
            if (response.Success)
            {
                response.ShowFeedbacksWithoutUser();
            }
            else
            {
                response.ShowResponse();
            }
        }

    }
}
