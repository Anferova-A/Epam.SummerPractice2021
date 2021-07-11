using Epam.Shops.BLL.Interfaces;
using Epam.Shops.DAL.Interfaces;
using Epam.Shops.Entities;
using Epam.Shops.Entities.Enums;
using Epam.Shops.Entities.Issues;
using Epam.Shops.Entities.Issues.Generic;
using Epam.Shops.Validation;
using System;
using System.Collections.Generic;

namespace Epam.Shops.BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserDAO _userDAO;
        private UserValidator _validator;

        public UserLogic(IUserDAO userDAO)
        {
            _userDAO = userDAO;
            _validator = new UserValidator();
        }

        public Response Add(User newUser)
        {
            var response = new Response();

            if (newUser is null)
            {
                response.Success = false;
                response.Description = "Операция не выполнена";
                response.Errors.Add("Отсутствует ссылка на объект пользователя");

                return response;
            }

            var validateResult = _validator.Validate(newUser);

            if (validateResult.IsValid)
            {
                if (!_userDAO.ContainsEmail(newUser.Email))
                {
                    _userDAO.Add(newUser);
                    response.Success = true;
                    response.Description = "Операция выполнена успешно";
                }
                else
                {
                    response.Success = false;
                    response.Description = "Ошибка добавления";
                    response.Errors.Add("Пользователь с таким email уже существует");
                }
            }
            else
            {
                response.Success = false;
                response.Description = "Ошибка валидации";
                foreach (var error in validateResult.Errors)
                {
                    response.Errors.Add(error.ErrorMessage);
                }
            }

            return response;
        }

        public Response<bool> ContainsEmail(string email)
            => new Response<bool>()
            {
                Success = true,
                Description = "Операция выполнена успешно",
                Content = _userDAO.ContainsEmail(email)
            };

        public Response<IEnumerable<User>> GetAll()
             => new Response<IEnumerable<User>>()
             {
                 Success = true,
                 Description = "Операция выполнена успешно",
                 Content = _userDAO.GetAll()
             };

        public Response<User> GetByEmail(string email)
        {
            var response = new Response<User>();

            var user = _userDAO.GetByEmail(email);

            if (user != null)
            {
                response.Success = true;
                response.Description = "Операция выполнена успешно";
                response.Content = user;
            }
            else
            {
                response.Success = false;
                response.Description = "Операция не выполнена";
                response.Errors.Add("Пользователь с таким email не найден");
            }

            return response;
        }

        public Response Remove(Guid id)
        {
            var response = new Response();

            if (_userDAO.Remove(id))
            {
                response.Success = true;
                response.Description = "Операция выполнена успешно";
            }
            else
            {
                response.Success = false;
                response.Description = "Операция не выполнена";
                response.Errors.Add("Объект не найден");
            }

            return response;
        }

        public Response Update(User user)
        {
            var response = new Response();

            var validateResult = _validator.Validate(user);

            if (validateResult.IsValid)
            {
                if (_userDAO.GetByEmail(user.Email).Id == user.Id)
                {
                    if (_userDAO.Update(user))
                    {
                        response.Success = true;
                        response.Description = "Операция выполнена успешно";
                    }
                    else
                    {
                        response.Success = false;
                        response.Description = "Операция не выполнена";
                        response.Errors.Add("Объект не найден");
                    }
                }
                else
                {
                    response.Success = false;
                    response.Description = "Ошибка обновления";
                    response.Errors.Add("Пользователь с таким email уже существует");
                }
            }
            else
            {
                response.Success = false;
                response.Description = "Ошибка валидации";
                foreach (var error in validateResult.Errors)
                {
                    response.Errors.Add(error.ErrorMessage);
                }
            }

            return response;
        }
    }
}
