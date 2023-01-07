using ManagerCafe.Data.Models;

namespace ManagerCafe.Services
{
    public class InventoryTransactionService : IInventoryTransactionService
    {
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;

        public InventoryTransactionService(IInventoryTransactionRepository inventoryTransactionRepository)
        {
            _inventoryTransactionRepository = inventoryTransactionRepository;
        }

        public async Task AddAsync(InventoryTransaction item)
        {
            await _inventoryTransactionRepository.AddAsync(item);
        }

        public Task<List<InventoryTransaction>> GetAll()
        {
            return _inventoryTransactionRepository.GetAll();
        }
    }
}
