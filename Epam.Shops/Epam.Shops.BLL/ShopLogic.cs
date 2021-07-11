using Epam.Shops.BLL.Interfaces;
using Epam.Shops.DAL.Interfaces;
using Epam.Shops.Entities;
using Epam.Shops.Entities.Issues;
using Epam.Shops.Entities.Issues.Generic;
using Epam.Shops.Validation;
using System;
using System.Collections.Generic;

namespace Epam.Shops.BLL
{
    public class ShopLogic : IShopLogic
    {
        private IShopDAO _shopDAO;
        private ShopValidator _validator;

        public ShopLogic(IShopDAO shopDAO)
        {
            _shopDAO = shopDAO;
            _validator = new ShopValidator();
        }

        public Response Add(Shop newShop)
        {
            var response = new Response();

            if (newShop is null)
            {
                response.Success = false;
                response.Description = "Операция не выполнена";
                response.Errors.Add("Отсутствует ссылка на объект магазина");

                return response;
            }

            var validateResult = _validator.Validate(newShop);

            if (validateResult.IsValid)
            {
                _shopDAO.Add(newShop);
                response.Success = true;
                response.Description = "Операция выполнена успешно";
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

        public Response<IEnumerable<Shop>> GetAll()
            => new Response<IEnumerable<Shop>>()
            {
                Success = true,
                Description = "Операция выполнена успешно",
                Content = _shopDAO.GetAll()
            };

        public Response<IEnumerable<Shop>> GetByCategory(Guid categoryId)
            => new Response<IEnumerable<Shop>>()
            {
                Success = true,
                Description = "Операция выполнена успешно",
                Content = _shopDAO.GetByCategory(categoryId)
            };

        public Response<IEnumerable<Shop>> GetByName(string name)
            => new Response<IEnumerable<Shop>>()
            {
                Success = true,
                Description = "Операция выполнена успешно",
                Content = _shopDAO.GetByName(name)
            };

        public Response Remove(Guid id)
        {
            var response = new Response();

            if (_shopDAO.Remove(id))
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

        public Response Update(Shop shop)
        {
            var response = new Response();

            var validateResult = _validator.Validate(shop);

            if (validateResult.IsValid)
            {
                if (_shopDAO.Update(shop))
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
