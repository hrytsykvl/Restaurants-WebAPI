using Microsoft.Extensions.Logging;
using Restaurants.Application.Users;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Interfaces;

namespace Restaurants.Infrastructure.Authorization.Services
{
    public class RestaurantAuthorizationService(ILogger<RestaurantAuthorizationService> logger,
        IUserContext userContext) : IRestaurantAuthorizationService
    {
        public bool Authorize(Restaurant restaurant, ResourceOperation resourceOperation)
        {
            var user = userContext.GetCurrentUser();

            logger.LogInformation($"User: {user.Email} - Authorizing to {resourceOperation} for restaurant {restaurant.Name}");

            if (resourceOperation == ResourceOperation.Read || resourceOperation == ResourceOperation.Create)
            {
                logger.LogInformation("Create/Read operation - Authorization succeeded");
                return true;
            }

            if (resourceOperation == ResourceOperation.Delete && user.IsInRole("Admin"))
            {
                logger.LogInformation("Admin user, Delete operation - Authorization succeeded");
                return true;
            }

            if ((resourceOperation == ResourceOperation.Delete || resourceOperation == ResourceOperation.Update)
                && user.Id == restaurant.OwnerId)
            {
                logger.LogInformation("Restaurant owner - Authorization succeeded");
                return true;
            }

            return false;
        }
    }
}
