using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

            RuleFor(shop => shop.Category.Name)
                .NotNull()
                .NotEmpty()
                .Must(name => Char.IsUpper(name.First()))
                .WithMessage("Некорректное название категории");

            RuleFor(shop => shop.Category)
                .NotNull()
                .WithMessage("Некорректное название категории");

        }

        private bool CheckSite(string arg) => Regex.IsMatch(arg, sitePattern);
    }
}
