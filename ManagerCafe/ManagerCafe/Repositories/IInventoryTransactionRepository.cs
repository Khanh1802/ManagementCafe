using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryTransactionDtos;

namespace ManagerCafe
{
    public interface IInventoryTransactionRepository
    {
        Task<List<InventoryTransaction>> GetAllAsync();
        Task AddAsync(InventoryTransaction item);
        Task<InventoryTransaction> GetByIdAsync<T>(T key);
        Task<IQueryable<InventoryTransaction>> GetQueryableAsync();
    }
}
