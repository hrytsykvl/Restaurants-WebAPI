using FluentValidation;

namespace Restaurants.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator()
        {
            RuleFor(d => d.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be a non-negative number");

            RuleFor(d => d.Calories)
                 .GreaterThanOrEqualTo(0)
                 .WithMessage("Calories must be a non-negative number");
        }
    }
}
