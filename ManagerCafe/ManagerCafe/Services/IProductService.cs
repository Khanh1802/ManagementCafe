using ManagerCafe.Commons;
using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Enums;

namespace ManagerCafe.Services
{
    public interface IProductService : IGenericService<ProductDto, CreateProductDto, UpdateProductDto, FilterProductDto>
    {
        Task<CommonPageDto<ProductDto>> GetPagedListAsync(FilterProductDto item,int choice);
    }
}
