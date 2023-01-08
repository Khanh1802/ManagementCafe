using ManagerCafe.Data.Data;
using ManagerCafe.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagerCafe.Repositories
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        private readonly ManagerCafeDbContext _context;

        public InventoryTransactionRepository(ManagerCafeDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(InventoryTransaction item)
        {
            item.CreateTime = DateTime.Now;
            await _context.InventoryTransactions.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public Task<List<InventoryTransaction>> GetAllAsync()
        {
            return _context.InventoryTransactions.ToListAsync();
        }
    }
}
