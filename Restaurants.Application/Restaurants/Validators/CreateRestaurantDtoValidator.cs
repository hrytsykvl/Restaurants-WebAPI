using FluentValidation;
using Restaurants.Application.Restaurants.DTO;

namespace Restaurants.Application.Restaurants.Validators
{
    public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
    {
        private readonly List<string> validCategories = ["Fast Food", "Traditional", "Italian", "Chinese", "Mexican", "Vegetarian"];
        public CreateRestaurantDtoValidator()
        {
            RuleFor(dto => dto.Name)
                .Length(3, 100);

            RuleFor(dto => dto.Category)
                .Must(validCategories.Contains)
                .WithMessage("Invalid category. Choose from the valid categories");

            RuleFor(dto => dto.ContactEmail)
                .EmailAddress().WithMessage("Provide a valid email address format");

            RuleFor(dto => dto.ZipCode)
                .Matches(@"^\d{2}-\d{3}$").WithMessage("Provide a valid zip code format (XX-XXX)");
        }
    }
}
