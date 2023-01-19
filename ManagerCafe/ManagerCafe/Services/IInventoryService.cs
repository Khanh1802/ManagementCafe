using ManagerCafe.Commons;
using ManagerCafe.Dtos.InventoryDtos;

namespace ManagerCafe.Services
{
    public interface IInventoryService : IGenericService<InventoryDto, CreatenInvetoryDto, UpdateInventoryDto, FilterInventoryDto>
    {
        Task<CommonPageDto<InventoryDto>> GetPagedListAsync(FilterInventoryDto item, int choice);
        Task<List<InventoryDto>> FindByIdProductAndWarehouse(FilterInventoryDto item);
    }
}
