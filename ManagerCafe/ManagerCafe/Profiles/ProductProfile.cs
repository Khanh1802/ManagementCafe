using AutoMapper;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.Orders;
using ManagerCafe.Dtos.ProductDtos;

namespace ManagerCafe.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<FilterProductDto, Product>();

            CreateMap<Product, SearchProductDto>();
        }
    }
}
