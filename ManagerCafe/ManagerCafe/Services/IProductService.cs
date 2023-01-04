using ManagerCafe.Commons;
using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Enums;

namespace ManagerCafe.Services
{
    public interface IProductService : IGenericService<ProductDto, CreateProductDto, UpdateProductDto, FilterProductDto>
    {
        //Task<List<ProductDto>> FilterPriceDesc();
        //Task<List<ProductDto>> FilterPriceAcs();
        //Task<List<ProductDto>> FilterDayDesc();
        //Task<List<ProductDto>> FilterDayAsc();
        Task<int> AllCountAsync();
        Task<List<ProductDto>> FilterChoice(EnumProductFilter filter);
    }
}
