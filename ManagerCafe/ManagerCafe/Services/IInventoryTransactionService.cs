using ManagerCafe.Commons;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryDtos;
using ManagerCafe.Dtos.InventoryTransactionDtos;
using System.Data.Common;

namespace ManagerCafe.Services
{
    public interface IInventoryTransactionService
    {
        Task<List<InventoryTransactionDto>> GetAllAsync();
        Task AddAsync(CreateInventoryTransactionDto item);
        Task<List<InventoryTransactionDto>> FilterAsync(FilterInventoryTransactionDto item);
        Task<CommonPageDto<InventoryTransactionDto>> GetPagedStatisticListAsync(FilterInventoryTransactionDto item, int choice);
        Task<CommonPageDto<InventoryTransactionDto>> GetPagedHistoryListAsync(FilterInventoryTransactionDto item, int choice);
    }
}
