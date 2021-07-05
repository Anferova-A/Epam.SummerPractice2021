using System;
using System.Linq;
using Epam.Shops.Entities;
using FluentValidation;

namespace Epam.Shops.Validation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(cat => cat.Name)
                .NotNull()
                .NotEmpty()
                .Must(name => Char.IsUpper(name.First()))
                .WithMessage("Некорректное название категории");
        }
    }
}
