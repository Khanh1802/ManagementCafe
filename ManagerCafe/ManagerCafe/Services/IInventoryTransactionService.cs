using ManagerCafe.Commons;
using ManagerCafe.Dtos.InventoryTransactionDtos;

namespace ManagerCafe.Services
{
    public interface IInventoryTransactionService
    {
        Task<List<InventoryTransactionDto>> GetAllAsync();
        Task AddAsync(CreateInventoryTransactionDto item);
        Task<List<InventoryTransactionDto>> FilterStatisticFindAsync(FilterInventoryTransactionDto item);
        Task<List<InventoryTransactionDto>> FilterHistoryFindAsync(FilterInventoryTransactionDto item);
        Task<CommonPageDto<InventoryTransactionDto>> GetPagedStatisticListAsync(FilterInventoryTransactionDto item, int choice);
        Task<CommonPageDto<InventoryTransactionDto>> GetPagedHistoryListAsync(FilterInventoryTransactionDto item, int choice);
    }
}
