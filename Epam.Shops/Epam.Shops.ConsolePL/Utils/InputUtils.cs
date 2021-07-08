using System;

namespace Epam.Shops.ConsolePL.Utils
{
    public class InputUtils
    {
        public static int ReadIntInRange(int from, int to, string message = "")
        {
            int result;

            bool exit = false;
            do
            {
                Console.Write(message);

                exit = int.TryParse(Console.ReadLine(), out result) &&
                       !(result < from) &&
                       !(result > to);

                if (!exit)
                {
                    Console.WriteLine($"Число должно быть от {from} до {to}");
                }
            } while (!exit);

            return result;
        }
    }
}
