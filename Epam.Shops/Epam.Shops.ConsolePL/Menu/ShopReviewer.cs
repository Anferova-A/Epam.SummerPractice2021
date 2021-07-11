using Epam.Shops.BLL.Interfaces;
using Epam.Shops.Dependency;
using Epam.Shops.Entities;
using Epam.Shops.ConsolePL.Utils;
using Ninject;
using System;

namespace Epam.Shops.ConsolePL.Menu
{
    internal class ShopReviewer
    {
        private IFeedbackLogic _feedbackLogic;

        private User _currentUser;

        public ShopReviewer(User currentUser)
        {
            _currentUser = currentUser;

            _feedbackLogic = DependencyKernel.GetKernel().Get<IFeedbackLogic>();
        }

        public Shop CurrentShop { get; set; }

        internal void Show()
        {
            ShowInfo();

            var reviewerMenuText = "Возможные действия:" + Environment.NewLine +
                                   "1. Посмотреть отзывы" + Environment.NewLine +
                                   "2. Оставить отзвы" + Environment.NewLine +
                                   "0. Выйти" + Environment.NewLine +
                                   "Выбор: ";

            string select = "";
            while (select != "0")
            {
                Console.Write(reviewerMenuText);
                select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        ShowFeedbacks();
                        break;
                    case "2":
                        WriteFeedback();
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;

                }
            }
        }

        private void ShowInfo()
        {
            Console.WriteLine();

            Console.WriteLine("ИНФОРМАЦИЯ О МАГАЗИНЕ");
            Console.WriteLine("\tНазвание: " + CurrentShop.Name);
            Console.WriteLine("\tСайт: " + CurrentShop.Site);
            Console.WriteLine("\tАдрес: " + CurrentShop.Address);
            Console.WriteLine("\tКатегория: " + CurrentShop.Category.Name);
        }

        private void ShowFeedbacks()
        {
            var response = _feedbackLogic.GetByShop(CurrentShop.Id);

            if (response.Success)
            {
                response.ShowFeedbacksWithoutShop();
            }
            else
            {
                response.ShowResponse();
            }
        }

        private void WriteFeedback()
        {
            Console.WriteLine();

            var feedback = new Feedback();

            feedback.User = _currentUser;
            feedback.Shop = CurrentShop;

            feedback.Score = InputUtils.ReadIntInRange(1, 5, "Оценка: ");

            Console.Write("Отзыв: ");
            feedback.Text = Console.ReadLine();

            var response = _feedbackLogic.Add(feedback);

            if (response.Success)
            {
                Console.WriteLine("Ваш отзыв успешно добавлен");
            }
            else
            {
                response.ShowResponse();
            }
        }
    }

}