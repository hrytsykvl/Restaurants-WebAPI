﻿using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.DTO
{
    public class DishDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Calories { get; set; }
        public int RestaurantId { get; set; }
    }
}
