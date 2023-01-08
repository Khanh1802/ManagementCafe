using ManagerCafe.Data.Models;

namespace ManagerCafe.Services
{
    public interface IInventoryTransactionService
    {
        Task<List<InventoryTransaction>> GetAll();
        Task AddAsync(InventoryTransaction item);
    }
}
