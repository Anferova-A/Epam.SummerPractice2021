using Epam.Shops.BLL.Interfaces;
using Epam.Shops.ConsolePL.Utils;
using Epam.Shops.Dependency;
using Epam.Shops.Entities;
using Epam.Shops.Entities.Enums;
using Ninject;
using System;

namespace Epam.Shops.ConsolePL.UserViews
{
    internal class Profile
    {
        private IUserLogic _userLogic;

        private User _currentUser;

        public Profile(User currentUser)
        {
            this._currentUser = currentUser;

            _userLogic = DependencyKernel.GetKernel().Get<IUserLogic>();
        }

        internal void Show()
        {
            ShowInfo();

            string prifileMenuText = "Возможные действия:" + Environment.NewLine +
                                     "\t1. Изменить информацию" + Environment.NewLine +
                                     "\t2. Сменить пароль" + Environment.NewLine +
                                     "\t0. Назад" + Environment.NewLine +
                                     "Выбор: ";

            string select = "";
            while (select != "0")
            {
                Console.Write(prifileMenuText);
                select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        EditProfile();
                        break;
                    case "2":
                        EditPassword();
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;

                }
            }
        }

        private void EditProfile()
        {
            string editProfileText = "Изменить:" + Environment.NewLine +
                                     "\t1. Имя" + Environment.NewLine +
                                     "\t2. Фамилию" + Environment.NewLine +
                                     "\t3. Возраст" + Environment.NewLine +
                                     "\t4. Пол" + Environment.NewLine +
                                     "\t5. Номер телефона" + Environment.NewLine +
                                     "\t6. Email" + Environment.NewLine +
                                     "\t0. Назад" + Environment.NewLine +
                                     "Выбор: ";

            string select = "";
            while (select != "0")
            {
                Console.Write(editProfileText);
                select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        EditFirstName();
                        break;
                    case "2":
                        EditLastName();
                        break;
                    case "3":
                        EditAge();
                        break;
                    case "4":
                        EditGender();
                        break;
                    case "5":
                        EditPhoneNumber();
                        break;
                    case "6":
                        EditEmail();
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;

                }
            }
        }

        private void EditFirstName()
        {
            Console.WriteLine();

            Console.WriteLine("Старое значение: " + _currentUser.FirstName);
            Console.Write("Новое значение: ");
            var newFirstName = Console.ReadLine();

            var editedUser = CopyUser(_currentUser);
            editedUser.FirstName = newFirstName;

            var response = _userLogic.Update(editedUser);

            if (response.Success)
            {
                _currentUser = editedUser;
                Console.WriteLine("Имя успешно изменено");
                ShowInfo();
            }
            else
            {
                response.ShowResponse();
            }
        }

        private void EditLastName()
        {
            Console.WriteLine();

            Console.WriteLine("Старое значение: " + _currentUser.LastName);
            Console.Write("Новое значение: ");
            var newLastName = Console.ReadLine();

            var editedUser = CopyUser(_currentUser);
            editedUser.LastName = newLastName;

            var response = _userLogic.Update(editedUser);

            if (response.Success)
            {
                _currentUser = editedUser;
                Console.WriteLine("Фамилия успешно изменена");
                ShowInfo();
            }
            else
            {
                response.ShowResponse();
            }
        }

        private void EditAge()
        {
            Console.WriteLine();

            Console.WriteLine("Старое значение: " + _currentUser.Age);
            Console.Write("Новое значение: ");
            var newAge = InputUtils.ReadIntInRange(0, 150);

            var editedUser = CopyUser(_currentUser);
            editedUser.Age = newAge;

            var response = _userLogic.Update(editedUser);

            if (response.Success)
            {
                _currentUser = editedUser;
                Console.WriteLine("Возраст успешно изменен");
                ShowInfo();
            }
            else
            {
                response.ShowResponse();
            }
        }

        private void EditGender()
        {
            Console.WriteLine();

            Console.WriteLine("Старое значение: " + _currentUser.Gender.ToStringRus());
            Console.WriteLine();
            Console.WriteLine("0. Не указан");
            Console.WriteLine("1. Мужской");
            Console.WriteLine("2. Женский");
            Console.Write("Новое значение: ");
            var newGender = (Gender)InputUtils.ReadIntInRange(0, 2);

            var editedUser = CopyUser(_currentUser);
            editedUser.Gender = newGender;

            var response = _userLogic.Update(editedUser);

            if (response.Success)
            {
                _currentUser = editedUser;
                Console.WriteLine("Пол успешно изменен");
                ShowInfo();
            }
            else
            {
                response.ShowResponse();
            }
        }

        private void EditPhoneNumber()
        {
            Console.WriteLine();

            Console.WriteLine("Старое значение: " + _currentUser.PhoneNumber);
            Console.Write("Новое значение: ");
            var newPhoneNumber = Console.ReadLine();

            var editedUser = CopyUser(_currentUser);
            editedUser.PhoneNumber = newPhoneNumber;

            var response = _userLogic.Update(editedUser);

            if (response.Success)
            {
                _currentUser = editedUser;
                Console.WriteLine("Номер телефона успешно изменен");
                ShowInfo();
            }
            else
            {
                response.ShowResponse();
            }
        }

        private void EditEmail()
        {
            Console.WriteLine();

            Console.WriteLine("Старое значение: " + _currentUser.Email);
            Console.Write("Новое значение: ");
            var newEmail = Console.ReadLine();

            var editedUser = CopyUser(_currentUser);
            editedUser.Email = newEmail;

            var response = _userLogic.Update(editedUser);

            if (response.Success)
            {
                _currentUser = editedUser;
                Console.WriteLine("Email успешно изменен");
                ShowInfo();
            }
            else
            {
                response.ShowResponse();
            }
        }

        private void EditPassword()
        {
            Console.WriteLine();
            Console.Write("Введите старый пароль: ");
            var oldPassword = Console.ReadLine();

            if (!_currentUser.CheckPassword(oldPassword))
            {
                Console.WriteLine("Пароль введен неверно");
                return;
            }

            Console.Write("Введите новый пароль: ");
            var newPassword = Console.ReadLine();

            _currentUser.Password = User.Hash(newPassword);
            var response = _userLogic.Update(_currentUser);
            if (response.Success)
            {
                Console.WriteLine("Пароль успешно измененен");
            }
            else
            {
                response.ShowResponse();
            }
        }

        private void ShowInfo()
        {
            Console.WriteLine("ИНФОРМАЦИЯ О ПРОФИЛЕ");
            Console.WriteLine("\tИмя: " + _currentUser.FirstName);
            Console.WriteLine("\tФамилия: " + _currentUser.LastName);
            Console.WriteLine("\tВозвраст: " + _currentUser.Age);
            Console.WriteLine("\tПол: " + _currentUser.Gender.ToStringRus());
            Console.WriteLine("\tНомер телефона: " + _currentUser?.PhoneNumber);
            Console.WriteLine("\tEmail: " + _currentUser.Email);
        }

        private User CopyUser(User oldUser)
        {
            var newUser = new User();

            newUser.Id = oldUser.Id;
            newUser.FirstName = oldUser.FirstName;
            newUser.LastName = oldUser.LastName;
            newUser.Age = oldUser.Age;
            newUser.PhoneNumber = oldUser.PhoneNumber;
            newUser.Email = oldUser.Email;
            newUser.Password = oldUser.Password;


            return newUser;
        }
    }
}