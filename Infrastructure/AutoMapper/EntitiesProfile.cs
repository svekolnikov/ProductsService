using AutoMapper;
using ProductsService.DTO;
using ProductsService.Models;

namespace ProductsService.Infrastructure.AutoMapper;

public class EntitiesProfile : Profile
{
    public EntitiesProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}