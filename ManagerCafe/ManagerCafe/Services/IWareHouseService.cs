using ManagerCafe.Commons;
using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Dtos.WareHouseDtos;

namespace ManagerCafe.Services
{
    public interface IWareHouseService : IGenericService<WareHouseDto, CreateWareHouseDto, UpdateWareHouseDto, FilterWareHouseDto>
    {
        Task<List<WareHouseDto>> FilterChoice(int filter);
        Task<CommonPageDto<WareHouseDto>> GetPagedListAsync(FilterWareHouseDto item);
    }
}
