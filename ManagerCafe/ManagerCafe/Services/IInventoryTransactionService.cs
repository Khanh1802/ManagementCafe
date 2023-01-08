using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryTransactionDtos;

namespace ManagerCafe.Services
{
    public interface IInventoryTransactionService
    {
        Task<List<InventoryTransactionDto>> GetAll();
        Task AddAsync(CreateInventoryTransactionDto item);
    }
}
