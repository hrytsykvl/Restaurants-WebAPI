using AutoMapper;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.DTO
{
    public class RestaurantsProfile : Profile
    {
        public RestaurantsProfile()
        {
            CreateMap<CreateRestaurantCommand, Restaurant>()
                .ForMember(d => d.Address, options => options.MapFrom(
                    src => new Address
                    {
                        City = src.City,
                        ZipCode = src.ZipCode,
                        Street = src.Street
                    }));

            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(d => d.City, options =>
                    options.MapFrom(src => src.Address == null ? null : src.Address.City))
                .ForMember(d => d.ZipCode, options =>
                    options.MapFrom(src => src.Address == null ? null : src.Address.ZipCode))
                .ForMember(d => d.Street, options =>
                    options.MapFrom(src => src.Address == null ? null : src.Address.Street))
                .ForMember(d => d.Dishes, options => options.MapFrom(src => src.Dishes));
        }
    }
}
