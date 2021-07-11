using Epam.Shops.BLL.Interfaces;
using Epam.Shops.Entities;
using System;
using Epam.Shops.ConsolePL.Utils;
using Epam.Shops.Dependency;
using Ninject;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Shops.ConsolePL.Menu
{
    public class UserMenu
    {
        private IFeedbackLogic _feedbackLogic;
        
        private User _currentUser;

        private Profile _profile;

        private ShopMenu _shopMenu;

        public UserMenu(User currentUser)
        {
            _currentUser = currentUser;

            _profile = new Profile(_currentUser);
            _shopMenu = new ShopMenu(_currentUser);

            _feedbackLogic = DependencyKernel.GetKernel().Get<IFeedbackLogic>();
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
                Console.Write(userMenuText);
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
            var responseShow = _feedbackLogic.GetByUser(_currentUser.Id);
            if (responseShow.Success)
            {
                responseShow.ShowFeedbacksWithoutUser();
            }
            else
            {
                responseShow.ShowResponse();
            }

            Console.WriteLine();
            Console.WriteLine("\t1. Удалить отзыв");
            Console.WriteLine("\t0. Назад");

            var select = InputUtils.ReadIntInRange(0, 1, "Выбор: ");

            if (select == 0)
                return;

            var removedFeedback = SelectFeedback(responseShow.Content);

            var responseRemove = _feedbackLogic.Remove(removedFeedback.Id);

            if (responseRemove.Success)
            {
                Console.WriteLine("Отзыв успешно удален");
            }
            else
            {
                responseRemove.ShowResponse();
            }
        }

        private Feedback SelectFeedback(IEnumerable<Feedback> collection)
        {
            var select = InputUtils.ReadIntInRange(1, collection.Count(), "Введите номер отзыва: ");

            return collection.GetByIndex(select - 1);
        }

    }
}
