﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;

namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applcationAssembly = typeof(ServiceCollectionExtensions).Assembly;
            services.AddScoped<IRestaurantsService, RestaurantsService>();

            services.AddAutoMapper(applcationAssembly);

            services.AddValidatorsFromAssembly(applcationAssembly)
                .AddFluentValidationAutoValidation();
        }
    }
}
