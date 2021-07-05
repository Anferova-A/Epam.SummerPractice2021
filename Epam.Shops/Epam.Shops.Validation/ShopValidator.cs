using System;
using System.Linq;
using System.Text.RegularExpressions;
using Epam.Shops.Entities;
using FluentValidation;

namespace Epam.Shops.Validation
{
    public class ShopValidator : AbstractValidator<Shop>
    {
        private const string sitePattern = @"^www\.\w+\.[a-z]+$";

        public ShopValidator()
        {
            RuleFor(shop => shop.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Некорректное название магазина");

            RuleFor(shop => shop.Site)
                .Must(CheckSite)
                .WithMessage("Некорректное название сайта");

            RuleFor(shop => shop.Category)
                .NotNull()
                .WithMessage("Некорректное название категории");

        }

        private bool CheckSite(string arg) => Regex.IsMatch(arg, sitePattern);
    }
}
