using ManagerCafe.Dtos.ProductDtos;

namespace ManagerCafe.Services
{
    public interface IProductService : IGenericService<ProductDto, CreateProductDto, UpdateProductDto, FilterProductDto>
    {
        Task<List<ProductDto>> FilterPriceDesc();
        Task<List<ProductDto>> FilterPriceAcs();
        Task<List<ProductDto>> FilterDayDesc();
        Task<List<ProductDto>> FilterDayAsc();
    }
}
