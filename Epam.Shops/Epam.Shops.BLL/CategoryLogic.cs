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
    public class CategoryLogic : ICategoryLogic
    {
        private ICategoryDAO _categoryDAO;

        private CategoryValidator _validator;

        public CategoryLogic(ICategoryDAO categoryDAO)
        {
            _categoryDAO = categoryDAO;

            _validator = new CategoryValidator();
        }

        public Response Add(Category newCategory)
        {
            var response = new Response();

            if (newCategory is null)
            {
                response.Success = false;
                response.Description = "Операция не выполнена";
                response.Errors.Add("Отсутствует ссылка на объект категории");

                return response;
            }

            var validateResult = _validator.Validate(newCategory);

            if (validateResult.IsValid)
            {
                _categoryDAO.Add(newCategory);

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

        public Response<IEnumerable<Category>> GetAll() 
            => new Response<IEnumerable<Category>>()
                {
                    Success = true,
                    Description = "Операция выполнена успешно",
                    Content = _categoryDAO.GetAll()
                };

        public Response Remove(Guid id)
        {
            var response = new Response();
            
            if (_categoryDAO.Remove(id))
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

        public Response Update(Category category)
        {
            var response = new Response();

            if (_categoryDAO.Update(category))
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
    }
}
