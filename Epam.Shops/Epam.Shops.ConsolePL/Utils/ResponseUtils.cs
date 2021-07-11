using Epam.Shops.Entities;
using Epam.Shops.Entities.Issues;
using Epam.Shops.Entities.Issues.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Shops.ConsolePL.Utils
{
    public static class ResponseUtils
    {
        public static void ShowResponse(this Response response)
        {
            Console.WriteLine(response.Description);
            foreach (var item in response.Errors)
            {
                Console.WriteLine(item);
            }
        }

        public static void ShowFeedbacksWithoutUser(this Response<IEnumerable<Feedback>> response)
        {
            int i = 1;

            foreach (var group in response.Content.GroupBy(f => f.Shop))
            {
                Console.WriteLine($"{group.Key.Name} ({group.Key.Category.Name}):");
                foreach (var item in group)
                {
                    Console.WriteLine($"\tОтзыв №{i++}. {item.Date}\n\tОценка: {item.Score}\n\t{item.Text}");
                }
                Console.WriteLine();
            }
        }

        public static void ShowFeedbacksWithoutShop(this Response<IEnumerable<Feedback>> response)
        {
            foreach (var feedback in response.Content.OrderBy(f => f.Date))
            {
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------");

                Console.WriteLine(feedback.Date);
                Console.WriteLine($"Пользователь: {feedback.User.FirstName} {feedback.User.LastName}");
                Console.WriteLine("Оценка: " + feedback.Score);
                Console.WriteLine("Отзыв: " + feedback.Text);

                Console.WriteLine("-----------------------------------------");
                Console.WriteLine();
            }
        }

        public static void ShowShops(this Response<IEnumerable<Shop>> response)
        {
            var i = 1;
            foreach (var item in response.Content)
            {
                Console.WriteLine($"{i++}. {item.Name} ({item.Category} адрес: {item.Address})");
            }
        }
    }
}
