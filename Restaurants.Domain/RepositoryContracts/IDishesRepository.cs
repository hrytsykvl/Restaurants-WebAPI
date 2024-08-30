using Restaurants.Domain.Entities;

namespace Restaurants.Domain.RepositoryContracts
{
    public interface IDishesRepository
    {
        Task<int> CreateDish(Dish dish);
        Task DeleteDishes(IEnumerable<Dish> dishes);
    }
}
