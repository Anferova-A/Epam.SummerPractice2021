using Epam.Shops.BLL.Interfaces;
using Epam.Shops.ConsolePL.Utils;
using Epam.Shops.Dependency;
using Epam.Shops.Entities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Shops.ConsolePL.ShopViews
{
    public class ShopMenu
    {
        private IShopLogic _shopLogic;
        private ICategoryLogic _caegoryLogic;
        
        private ShopReviewer _shopReviewer;

        public ShopMenu(User currentUser)
        {
            _shopReviewer = new ShopReviewer(currentUser);

            _shopLogic = DependencyKernel.GetKernel().Get<IShopLogic>();
            _caegoryLogic = DependencyKernel.GetKernel().Get<ICategoryLogic>();
        }
        public void Show()
        {
            Console.Clear();

            string userMenuText = "Поиск магазина:\n" +
                "\t1. По названию\n" +
                "\t2. По категории\n" +
                "\t3. Показать все\n" +
                "\t0. Назад\n" +
                "Ввод: ";

            string select = "";
            while (select != "0")
            {
                Console.Write(userMenuText);
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
            // find category
            var responseCategories = _caegoryLogic.GetAll();
            if (!responseCategories.Success)
            {
                responseCategories.ShowResponse();
                return;
            }

            var category = SelectCategory(responseCategories.Content);

            // find shop by category
            var responseShops = _shopLogic.GetByCategory(category.Id);

            if (!responseShops.Success)
            {
                responseShops.ShowResponse();
                return;
            }

            _shopReviewer.CurrentShop = SelectShop(responseShops.Content);
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

            var select = InputUtils.ReadIntInRange(1, collection.Count(), "Введите номер магазина: ");

            return collection.GetByIndex(select - 1);
        }

        private Category SelectCategory(IEnumerable<Category> collection)
        {
            collection.ShowCategories();

            var select = InputUtils.ReadIntInRange(1, collection.Count(), "Введите номер категории: ");

            return collection.GetByIndex(select - 1);
        }

    }
}
