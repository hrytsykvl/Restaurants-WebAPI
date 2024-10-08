﻿using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.RepositoryContracts;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories
{
    internal class RestaurantsRepository(RestaurantsDbContext context) : IRestaurantsRepository
    {
        public async Task<int> CreateRestaurant(Restaurant restaurant)
        {
            context.Restaurants.Add(restaurant);
            await context.SaveChangesAsync();

            return restaurant.Id;
        }

        public async Task DeleteRestaurant(Restaurant restaurant)
        {
            context.Remove(restaurant);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await context.Restaurants.ToListAsync();
            return restaurants;
        }

        public async Task<Restaurant?> GetByIdAsync(int id)
        {
            var restaurant = await context.Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefaultAsync(r => r.Id == id);

            return restaurant;
        }

        public Task SaveChanges() => context.SaveChangesAsync();
    }
}
