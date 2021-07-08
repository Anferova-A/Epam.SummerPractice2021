using Epam.Shops.Entities;
using System;
using System.Collections.Generic;

namespace Epam.Shops.ConsolePL.Utils
{
    public static class EnumerableUtils
    {
        public static T GetByIndex<T>(this IEnumerable<T> collection, int index)
        {
            var cur = 0;
            foreach (var item in collection)
            {
                if (index == cur++)
                {
                    return item;
                }
            }

            throw new IndexOutOfRangeException();
        }

        public static void ShowShops(this IEnumerable<Shop> shops)
        {
            var i = 1;
            foreach (var item in shops)
            {
                Console.WriteLine($"{i++}. {item.Name} ({item.Category} адрес: {item.Address})");
            }
        }
    }
}
