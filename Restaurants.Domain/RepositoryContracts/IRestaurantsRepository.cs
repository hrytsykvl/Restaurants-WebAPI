using Restaurants.Domain.Entities;

namespace Restaurants.Domain.RepositoryContracts
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Task<Restaurant?> GetByIdAsync(int id);
        Task<int> CreateRestaurant(Restaurant restaurant);
        Task DeleteRestaurant(Restaurant restaurant);
        Task SaveChanges();
    }
}
