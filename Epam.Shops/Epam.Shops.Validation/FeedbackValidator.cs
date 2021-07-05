using Epam.Shops.Entities;
using FluentValidation;

namespace Epam.Shops.Validation
{
    public class FeedbackValidator : AbstractValidator<Feedback>
    {
        public FeedbackValidator()
        {
            RuleFor(f => f.Score)
                .InclusiveBetween(1, 5)
                .WithMessage("Некорректная оценка");

            RuleFor(f => f.User)
                .NotNull()
                .WithMessage("Отзыв не может быть анонимным");

            RuleFor(f => f.Shop)
                .NotNull()
                .WithMessage("Должен быть указан магазин");

            RuleFor(f => f.Text)
                .Length(1, 300)
                .WithMessage("Длина отзыва должна быть от {MinLength} до {MaxLength}");
        }
    }
}
