using ManagerCafe.Data.Data;
using ManagerCafe.Data.Models;

namespace ManagerCafe.Services
{
    public class InventoryTransactionService : IInventoryTransactionService
    {
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
        private readonly ManagerCafeDbContext _context;

        public InventoryTransactionService(IInventoryTransactionRepository inventoryTransactionRepository, ManagerCafeDbContext context)
        {
            _inventoryTransactionRepository = inventoryTransactionRepository;
            _context = context;
        }

        public async Task AddAsync(InventoryTransaction item)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            try
            {              
                await _inventoryTransactionRepository.AddAsync(item);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex.GetBaseException();
            }
        }

        public Task<List<InventoryTransaction>> GetAll()
        {
            return _inventoryTransactionRepository.GetAll();
        }
    }
}
