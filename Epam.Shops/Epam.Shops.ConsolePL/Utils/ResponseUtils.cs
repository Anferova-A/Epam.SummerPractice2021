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
            foreach (var group in response.Content.GroupBy(f => f.Shop))
            {
                Console.WriteLine($"{group.Key.Name} ({group.Key.Category}):");
                foreach (var item in group)
                {
                    Console.WriteLine($"\t{item.Date}\n\tОценка: {item.Score}\n\t{item.Text}");
                }
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
