using AutoMapper;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.ProductDtos;

namespace BookStore.WebApi.Mappings
{
    public class ProductDtos : Profile
    {
        public ProductDtos() 
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
        }
    }
}
