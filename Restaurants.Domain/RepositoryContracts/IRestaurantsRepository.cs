using Restaurants.Domain.Entities;

namespace Restaurants.Domain.RepositoryContracts
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Task<Restaurant?> GetByIdAsync(int id);
    }
}
