using ManagerCafe.CacheItems.OrderDetails;
using ManagerCafe.CacheItems.Orders;
using ManagerCafe.Commons;
using ManagerCafe.Dtos.InventoryDto.InventoryDtos;
using ManagerCafe.Dtos.InventoryDtos;
using ManagerCafe.Dtos.OrderDetailDtos;

namespace ManagerCafe.Services
{
    public interface IInventoryService : IGenericService<InventoryDto, CreatenInvetoryDto, UpdateInventoryDto, FilterInventoryDto, Guid>
    {
        Task<CommonPageDto<InventoryDto>> GetPagedListAsync(FilterInventoryDto item, int choice);
        Task<List<InventoryDto>> FindByIdProductAndWarehouse(FilterInventoryDto item);
        Task<InventoryOrderDetail> GetInventoryOrderDetail(Guid productId);

        Task LogicProcessing(List<OrderDetailCacheItem> orderDetailCacheItems);
    }
}
