using Epam.Shops.BLL.Interfaces;
using Epam.Shops.ConsolePL.Utils;
using Epam.Shops.Dependency;
using Epam.Shops.Entities;
using Epam.Shops.Entities.Enums;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shops.ConsolePL.UserViews
{
    public class Authorization
    {
        private IUserLogic _userLogic;

        public Authorization()
        {
            _userLogic = DependencyKernel.GetKernel().Get<IUserLogic>();
        }

        public void Show()
        {
            Console.WriteLine("Здравствуйте!\nРада приветстовать Вас в моей системе оценки магазинов.\n" +
                              "Пожалуйста, если у Вас уже имеется аккаунт, выберите 'Войти'.\nЕсли Вы здесь" +
                              " впервые - выберите 'Зарегистрироваться'.");

            var menuText = "\t1. Войти" + Environment.NewLine +
                           "\t2. Зарегистрироваться" + Environment.NewLine +
                           "Выбор: ";

            string select = "";
            while (select != "0")
            {
                Console.Write(menuText);
                select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        LogIn();
                        break;
                    case "2":
                        Register();
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;

                }
            }

        }

        private void LogIn()
        {
            Console.Write("Email: ");
            var responseUser = _userLogic.GetByEmail(Console.ReadLine());

            if (responseUser.Success == false)
            {
                foreach (var error in responseUser.Errors)
                {
                    Console.WriteLine(error);
                }
                return;
            }

            Console.Write("Пароль: ");
            var password = Console.ReadLine();

            if (!responseUser.Content.CheckPassword(password))
            {
                Console.WriteLine("Неверный пароль");
                return;
            }

            new UserMenu(responseUser.Content).Show();
        }

        private void Register()
        {
            var user = new User();

            Console.Write("Введите email: ");
            user.Email = Console.ReadLine();

            if (_userLogic.ContainsEmail(user.Email).Content)
            {
                Console.WriteLine("Пользоатель с таким email уже существует");
                return;
            }

            Console.Write("Введите имя: ");
            user.FirstName = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            user.LastName = Console.ReadLine();

            user.Age = InputUtils.ReadIntInRange(14, 150, "Введите возраст: ");

            Console.Write("Введите номер телефона (должен начинаться с +7): ");
            user.PhoneNumber = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("0. Не указан");
            Console.WriteLine("1. Мужской");
            Console.WriteLine("2. Женский");
            user.Gender = (Gender)InputUtils.ReadIntInRange(0, 2, "Укажите пол: ");

            string password;
            do
            {
                Console.Write("Придумайте пароль: ");
                password = Console.ReadLine();
                if (password != String.Empty)
                {
                    user.Password = User.Hash(password);
                }
            } while (password == String.Empty);
            
            var respose = _userLogic.Add(user);

            if (respose.Success)
            {
                Console.WriteLine("Вы успешно зарегистрированы");
            }
            else
            {
                Console.WriteLine(respose.Description);
                foreach (var error in respose.Errors)
                {
                    Console.WriteLine(error);
                }
            }
        }
    }
}
