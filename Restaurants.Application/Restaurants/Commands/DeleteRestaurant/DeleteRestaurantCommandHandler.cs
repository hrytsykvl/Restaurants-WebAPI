using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Domain.RepositoryContracts;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
        IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand, bool>
    {
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleting restaurant with id: {request.Id}");
            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
            if(restaurant is null)
            {
                return false;
            }

            await restaurantsRepository.DeleteRestaurant(restaurant);
            return true;
        }
    }
}
