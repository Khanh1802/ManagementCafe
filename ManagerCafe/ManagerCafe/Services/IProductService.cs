using ManagerCafe.Dtos.ProductDtos;

namespace ManagerCafe.Services
{
    public interface IProductService : IGenericService<ProductDto, CreateProductDto, UpdateProductDto, FilterProductDto>
    {

    }
}
