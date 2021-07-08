using Epam.Shops.BLL.Interfaces;
using Epam.Shops.ConsolePL.Utils;
using Epam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Shops.ConsolePL.Menu
{
    public class ShopMenu
    {
        private ShopReviewer _shopReviewer;

        private IShopLogic _shopLogic;

        public ShopMenu(User currentUser)
        {
            _shopReviewer = new ShopReviewer(currentUser);
        }
        public void Show()
        {
            Console.Clear();

            string userMenuText = "Поиск магазина:\n" +
                "\t1. По названию\n" +
                "\t2. По категории\n" +
                "\t3. Показать все\n" +
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
                        FindByName();
                        break;
                    case "2":
                        FindByCategory();
                        break;
                    case "3":
                        FindAll();
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;

                }
            }
        }

        private void FindAll()
        {
            var response = _shopLogic.GetAll();

            if (!response.Success)
            {
                response.ShowResponse();
                return;
            }

            _shopReviewer.CurrentShop = SelectShop(response.Content);
            _shopReviewer.Show();
        }

        private void FindByCategory()
        {
            Category category = null;
            // TODO: получить категорию

            var response = _shopLogic.GetByCategory(category.Id);

            if (!response.Success)
            {
                response.ShowResponse();
                return;
            }

            _shopReviewer.CurrentShop = SelectShop(response.Content);
            _shopReviewer.Show();
        }

        private void FindByName()
        {
            Console.Write("Название магазина: ");
            var name = Console.ReadLine();

            var response = _shopLogic.GetByName(name);

            if (!response.Success)
            {
                response.ShowResponse();
                return;
            }

            _shopReviewer.CurrentShop = SelectShop(response.Content);
            _shopReviewer.Show();
        }

        private Shop SelectShop(IEnumerable<Shop> collection)
        {
            collection.ShowShops();

            var select = InputUtils.ReadIntInRange(1, collection.Count(), "Введите номер: ");

            return collection.GetByIndex(select - 1);
        }
    }
}
