using ManagerCafe.Data.Models;

namespace ManagerCafe
{
    public interface IInventoryTransactionRepository
    {
        Task<List<InventoryTransaction>> GetAllAsync();
        Task AddAsync(InventoryTransaction item);
    }
}
