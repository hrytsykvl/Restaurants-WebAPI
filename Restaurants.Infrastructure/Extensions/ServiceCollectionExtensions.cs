﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Entities;
using Restaurants.Domain.RepositoryContracts;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<RestaurantsDbContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<RestaurantsDbContext>();

            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
            services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
            services.AddScoped<IDishesRepository, DishesRepository>();
        }
    }
}
