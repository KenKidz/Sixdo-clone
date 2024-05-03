using AutoMapper;
using ClothShop.DTOs;
using ClothShop.Entities;

namespace ClothShop
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<ProductImgDto, ProductImg>();
        }
    }
}
