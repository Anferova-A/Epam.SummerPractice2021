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
    public class FeedbackLogic : IFeedbackLogic
    {
        private IFeedbackDAO _feedbackDAO;
        private FeedbackValidator _validator;

        public FeedbackLogic(IFeedbackDAO feedbackDAO)
        {
            _feedbackDAO = feedbackDAO;
            _validator = new FeedbackValidator();
        }

        public Response Add(Feedback newFeedback)
        {
            var response = new Response();

            if (newFeedback is null)
            {
                response.Success = false;
                response.Description = "Операция не выполнена";
                response.Errors.Add("Отсутствует ссылка на объект отзыва");

                return response;
            }

            var validateResult = _validator.Validate(newFeedback);

            if (validateResult.IsValid)
            {
                _feedbackDAO.Add(newFeedback);
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

        public Response<IEnumerable<Feedback>> GetAll()
            => new Response<IEnumerable<Feedback>>()
            {
                    Success = true,
                    Description = "Операция выполнена успешно",
                    Content = _feedbackDAO.GetAll()
            };


        public Response<IEnumerable<Feedback>> GetByShop(Guid shopId)
            => new Response<IEnumerable<Feedback>>()
            {
                Success = true,
                Description = "Операция выполнена успешно",
                Content = _feedbackDAO.GetByShop(shopId)
            };

        public Response<IEnumerable<Feedback>> GetByUser(Guid userId)
            => new Response<IEnumerable<Feedback>>()
            {
                Success = true,
                Description = "Операция выполнена успешно",
                Content = _feedbackDAO.GetByUser(userId)
            };

        public Response Remove(Guid id)
        {
            var response = new Response();

            if (_feedbackDAO.Remove(id))
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

        public Response Update(Feedback feedback)
        {
            var response = new Response();

            var validateResult = _validator.Validate(feedback);

            if (validateResult.IsValid)
            {
                if (_feedbackDAO.Update(feedback))
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
