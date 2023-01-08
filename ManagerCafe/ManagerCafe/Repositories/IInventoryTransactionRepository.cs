using ManagerCafe.Data.Models;

namespace ManagerCafe
{
    public interface IInventoryTransactionRepository
    {
        Task<List<InventoryTransaction>> GetAll();
        Task AddAsync(InventoryTransaction item);
    }
}
