﻿using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders
{
    internal class RestaurantSeeder(RestaurantsDbContext context) : IRestaurantSeeder
    {
        public async Task Seed()
        {
            if (await context.Database.CanConnectAsync())
            {
                if (!context.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    context.Restaurants.AddRange(restaurants);
                    await context.SaveChangesAsync();
                }

                if(!context.Roles.Any())
                {
                    var roles = GetRoles();
                    context.Roles.AddRange(roles);
                    await context.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<IdentityRole> GetRoles()
        {
            List<IdentityRole> roles =
                [
                    new (UserRoles.User)
                    {
                        NormalizedName = UserRoles.User.ToUpper()
                    },
                    new (UserRoles.Owner)
                    {
                        NormalizedName = UserRoles.Owner.ToUpper()
                    },
                    new (UserRoles.Admin)
                    {
                        NormalizedName = UserRoles.Admin.ToUpper()
                    },
                ];

            return roles;
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurants = [
            new()
            {
                Name = "KFC",
                Category = "Fast Food",
                Description =
                    "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken.",
                ContactEmail = "contact@kfc.com",
                HasDelivery = true,
                Dishes =
                [
                    new ()
                    {
                        Name = "Nashville Hot Chicken",
                        Description = "Nashville Hot Chicken (10 pcs.)",
                        Price = 10.30M,
                    },

                    new ()
                    {
                        Name = "Chicken Nuggets",
                        Description = "Chicken Nuggets (5 pcs.)",
                        Price = 5.30M,
                    },
                ],
                Address = new ()
                {
                    City = "New York",
                    Street = "Broad St 5",
                    ZipCode = "WC2N 5DU"
                },

            },
            new ()
            {
                Name = "McDonalds",
                Category = "Fast Food",
                Description =
                    "McDonald's Corporation (McDonald's), incorporated on December 21, 1964, operates and franchises McDonald's restaurants.",
                ContactEmail = "contact@mcdonald.com",
                HasDelivery = true,
                Address = new Address()
                {
                    City = "New York",
                    Street = "Madison 193",
                    ZipCode = "W1F 8SR"
                }
            }
        ];

            return restaurants;
        }
    }
}
