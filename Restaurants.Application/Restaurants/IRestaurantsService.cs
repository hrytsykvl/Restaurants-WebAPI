using Restaurants.Application.Restaurants.DTO;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantsService
    {
        Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
        Task<RestaurantDto?> GetById(int id);
        Task<int> CreateRestaurant(CreateRestaurantDto createRestaurantDto);
    }
}