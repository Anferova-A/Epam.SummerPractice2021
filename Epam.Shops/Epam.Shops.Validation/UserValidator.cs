using System;
using System.Linq;
using System.Text.RegularExpressions;
using Epam.Shops.Entities;
using FluentValidation;

namespace Epam.Shops.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        private const string phoneNumber = @"^\+7\d{10}$";

        public UserValidator()
        {
            RuleFor(user => user.FirstName)
                .NotNull()
                .NotEmpty()
                .Must(name => name.All(Char.IsLetter) && Char.IsUpper(name.FirstOrDefault()))
                .WithMessage("Некорректное имя");

            RuleFor(user => user.LastName)
                .NotNull()
                .NotEmpty()
                .Must(name => name.All(Char.IsLetter) && Char.IsUpper(name.FirstOrDefault()))
                .WithMessage("Некорректная фамилия");

            RuleFor(user => user.Age)
                .InclusiveBetween(14, 150)
                .WithMessage("Возраст может быть от {From} до {To}");

            RuleFor(user => user.Email)
                .EmailAddress()
                .WithMessage("Некорректный email");

            RuleFor(user => user.PhoneNumber)
                .Must(CheckPhoneNumber)
                .WithMessage("Некорректный номер телефона");
        }

        private bool CheckPhoneNumber(string arg) => Regex.IsMatch(arg, phoneNumber);
    }
}
