using MediatR;

namespace Restaurants.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommand : IRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Calories { get; set; }
        public int RestaurantId { get; set; }
    }
}
