using AutoMapper;
using ProductsService.DTO;
using ProductsService.Models;
using ProductsService.Requests;

namespace ProductsService.Infrastructure.AutoMapper;

public class EntitiesProfile : Profile
{
    public EntitiesProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductRequest, Product>();
        CreateMap<UpdateProductRequest, Product>();
    }
}