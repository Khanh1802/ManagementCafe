using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryTransactionDtos;
using System.Data.Common;

namespace ManagerCafe.Services
{
    public interface IInventoryTransactionService 
    {
        Task<List<InventoryTransactionDto>> GetAllAsync();
        Task AddAsync(CreateInventoryTransactionDto item, DbTransaction dbTransaction = null);
        Task<List<InventoryTransactionDto>> FilterAsync(FilterInventoryTransactionDto item,int enums);
    }
}
