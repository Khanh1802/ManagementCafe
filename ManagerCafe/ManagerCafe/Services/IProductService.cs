using ManagerCafe.Commons;
using ManagerCafe.Dtos.Orders;
using ManagerCafe.Dtos.ProductDtos;

namespace ManagerCafe.Services
{
    public interface IProductService :
        IGenericService<ProductDto, CreateProductDto, UpdateProductDto, FilterProductDto, Guid>
    {
        Task<CommonPageDto<ProductDto>> GetPagedListAsync(FilterProductDto item, int choice);
        Task<CommonPageDto<SearchProductDto>> SearchProductAsync(FilterProductDto filter);
    }
}
