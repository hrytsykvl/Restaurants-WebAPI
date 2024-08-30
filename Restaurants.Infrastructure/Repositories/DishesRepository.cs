using Restaurants.Domain.Entities;
using Restaurants.Domain.RepositoryContracts;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories
{
    internal class DishesRepository(RestaurantsDbContext context) : IDishesRepository
    {
        public async Task<int> CreateDish(Dish dish)
        {
            context.Dishes.Add(dish);
            await context.SaveChangesAsync();
            return dish.Id;
        }
    }
}
