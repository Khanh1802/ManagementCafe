using ManagerCafe.Data.Data;
using ManagerCafe.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagerCafe.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ManagerCafeDbContext _context;

        public InventoryRepository(ManagerCafeDbContext context)
        {
            _context = context;
        }

        public async Task<Invetory> AddAsync(Invetory entity)
        {
            await _context.Invetories.AddAsync(entity);
            entity.CreateTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(Invetory entity)
        {
            entity.IsDeleted = true;
            entity.DeletetionTime = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Invetory>> GetAllAsync()
        {
            return await _context.Invetories.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<Invetory> GetById<TKey>(TKey key)
        {
            var entity = await _context.Invetories.FindAsync(key);
            return entity;
        }

        public async Task<IQueryable<Invetory>> GetQueryableAsync()
        {
            return await Task.FromResult(_context.Invetories.AsQueryable().Where(x => !x.IsDeleted));
        }

        public async Task<Invetory> UpdateAsync(Invetory entity)
        {
            _context.Invetories.Update(entity);
            await _context.SaveChangesAsync();
            entity.LastModificationTime = DateTime.Now;
            return entity;
        }
    }
}
