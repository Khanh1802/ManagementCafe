using AutoMapper;
using ManagerCafe.Data.Data;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryTransactionDtos;

namespace ManagerCafe.Services
{
    public class InventoryTransactionService : IInventoryTransactionService
    {
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
        private readonly ManagerCafeDbContext _context;
        private readonly IMapper _mapper;

        public InventoryTransactionService(IInventoryTransactionRepository inventoryTransactionRepository, ManagerCafeDbContext context, IMapper mapper)
        {
            _inventoryTransactionRepository = inventoryTransactionRepository;
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateInventoryTransactionDto item)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var create = _mapper.Map<CreateInventoryTransactionDto, InventoryTransaction>(item);
                await _inventoryTransactionRepository.AddAsync(create);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex.GetBaseException();
            }
        }

        public async Task<List<InventoryTransactionDto>> GetAll()
        {
            var entites = await _inventoryTransactionRepository.GetAllAsync();
            return _mapper.Map<List<InventoryTransaction>, List<InventoryTransactionDto>>(entites);
        }
    }
}
