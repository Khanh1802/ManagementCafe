using AutoMapper;
using ManagerCafe.Commons;
using ManagerCafe.Data.Data;
using ManagerCafe.Data.Enums;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryTransactionDtos;
using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Enums;
using ManagerCafe.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManagerCafe.Services
{
    public class InventoryTransactionService : IInventoryTransactionService
    {
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ManagerCafeDbContext _context;
        private readonly IMapper _mapper;
        public InventoryTransactionService(IInventoryTransactionRepository inventoryTransactionRepository, ManagerCafeDbContext context, IMapper mapper, IInventoryRepository inventoryRepository)
        {
            _inventoryTransactionRepository = inventoryTransactionRepository;
            _context = context;
            _mapper = mapper;
            _inventoryRepository = inventoryRepository;
        }

        public async Task AddAsync(CreateInventoryTransactionDto item)
        {
            var create = _mapper.Map<CreateInventoryTransactionDto, InventoryTransaction>(item);
            await _inventoryTransactionRepository.AddAsync(create);
        }

        private async Task<CommonPageDto<InventoryTransactionDto>> FilterQuatityAsc(FilterInventoryTransactionDto item)
        {
            var query = await _inventoryTransactionRepository.GetQueryableAsync();
            var filter = query
                .Include(x => x.Inventory)
                .ThenInclude(x => x.Product)
                .Include(x => x.Inventory)
                .ThenInclude(x => x.WareHouse)
                .Where(x => x.Type == item.Type && !x.Inventory.Product.IsDeleted && !x.Inventory.WareHouse.IsDeleted)

                .GroupBy(x => x.InventoryId).Select(x => new InventoryTransactionDto
                {
                    InventoryId = x.Key,
                    Type = x.FirstOrDefault().Type,
                    Quatity = x.Sum(k => k.Quatity),
                    ProductName = x.FirstOrDefault().Inventory.Product.Name,
                    WarehouseName = x.FirstOrDefault().Inventory.WareHouse.Name,
                    CreateTime = x.FirstOrDefault().CreateTime,
                });
            var count = filter.CountAsync();
            var data = filter.OrderBy(x => x.Quatity).Skip(item.SkipCount).Take(item.TakeMaxResultCount);
            return new CommonPageDto<InventoryTransactionDto>(await count, item, await data.ToListAsync());
        }

        private async Task<CommonPageDto<InventoryTransactionDto>> FilterQuatityDesc(FilterInventoryTransactionDto item)
        {
            var query = await _inventoryTransactionRepository.GetQueryableAsync();
            var filter = query
                .Include(x => x.Inventory)
                .ThenInclude(k => k.Product)
                .Include(x => x.Inventory)
                .ThenInclude(k => k.WareHouse)
                .Where(x => !x.Inventory.IsDeleted)
                .GroupBy(x => x.InventoryId).Select(x => new InventoryTransactionDto
                {
                    CreateTime = x.FirstOrDefault().CreateTime,
                    ProductName = x.FirstOrDefault().Inventory.Product.Name,
                    WarehouseName = x.FirstOrDefault().Inventory.WareHouse.Name,
                    Quatity = x.Sum(x => x.Quatity),
                    Type = x.FirstOrDefault().Type,
                    InventoryId = x.FirstOrDefault().InventoryId,
                });
            var count = filter.CountAsync();
            var data = filter.OrderByDescending(x => x.Quatity).Skip(item.SkipCount).Take(item.TakeMaxResultCount);
            return new CommonPageDto<InventoryTransactionDto>(await count, item, await data.ToListAsync());
        }

        private async Task<CommonPageDto<InventoryTransactionDto>> FilterDateAsc(FilterInventoryTransactionDto item)
        {
            var query = await _inventoryTransactionRepository.GetQueryableAsync();
            var filter = query
                .Include(x => x.Inventory)
                .ThenInclude(x => x.Product)
                .Include(x => x.Inventory)
                .ThenInclude(x => x.WareHouse)
                .Where(x => x.Type == item.Type && !x.Inventory.Product.IsDeleted && !x.Inventory.WareHouse.IsDeleted)

                .GroupBy(x => x.InventoryId).Select(x => new InventoryTransactionDto
                {
                    InventoryId = x.Key,
                    Type = x.FirstOrDefault().Type,
                    Quatity = x.Sum(k => k.Quatity),
                    ProductName = x.FirstOrDefault().Inventory.Product.Name,
                    WarehouseName = x.FirstOrDefault().Inventory.WareHouse.Name,
                    CreateTime = x.FirstOrDefault().CreateTime,
                });
            var count = filter.CountAsync();
            var data = filter.OrderBy(x => x.CreateTime).Skip(item.SkipCount).Take(item.TakeMaxResultCount);
            return new CommonPageDto<InventoryTransactionDto>(await count, item, await data.ToListAsync());
        }

        private async Task<CommonPageDto<InventoryTransactionDto>> FilterDateDesc(FilterInventoryTransactionDto item)
        {
            var query = await _inventoryTransactionRepository.GetQueryableAsync();
            var filter = query
                .Include(x => x.Inventory)
                .ThenInclude(x => x.Product)
                .Include(x => x.Inventory)
                .ThenInclude(x => x.WareHouse)
                .Where(x => x.Type == item.Type && !x.Inventory.Product.IsDeleted && !x.Inventory.WareHouse.IsDeleted)

                .GroupBy(x => x.InventoryId).Select(x => new InventoryTransactionDto
                {
                    InventoryId = x.Key,
                    Type = x.FirstOrDefault().Type,
                    Quatity = x.Sum(k => k.Quatity),
                    ProductName = x.FirstOrDefault().Inventory.Product.Name,
                    WarehouseName = x.FirstOrDefault().Inventory.WareHouse.Name,
                    CreateTime = x.FirstOrDefault().CreateTime,
                });
            var count = filter.CountAsync();
            var data = filter.OrderByDescending(x => x.CreateTime).Skip(item.SkipCount).Take(item.TakeMaxResultCount);
            return new CommonPageDto<InventoryTransactionDto>(await count, item, await data.ToListAsync());
        }

        private async Task<List<InventoryTransactionDto>> FilterImport()
        {
            var inventoryTransactions = await _inventoryTransactionRepository.GetQueryableAsync();
            inventoryTransactions.GroupBy(x => x.InventoryId);
            return _mapper.Map<List<InventoryTransaction>, List<InventoryTransactionDto>>(await inventoryTransactions.ToListAsync());
        }

        public async Task<List<InventoryTransactionDto>> GetAllAsync()
        {
            var entites = await _inventoryTransactionRepository.GetAllAsync();
            return _mapper.Map<List<InventoryTransaction>, List<InventoryTransactionDto>>(entites);
        }

        public async Task<CommonPageDto<InventoryTransactionDto>> GetPagedStatisticListAsync(FilterInventoryTransactionDto item, int enums)
        {
            if (Enum.IsDefined(typeof(EnumInventoryTransactionFilter), enums))
            {
                switch ((EnumInventoryTransactionFilter)enums)
                {
                    case EnumInventoryTransactionFilter.DateAsc:
                        return await FilterDateAsc(item);
                    case EnumInventoryTransactionFilter.DateDesc:
                        return await FilterDateDesc(item);
                    case EnumInventoryTransactionFilter.QuatityAsc:
                        return await FilterQuatityAsc(item);
                    case EnumInventoryTransactionFilter.QuatytiDesc:
                        return await FilterQuatityDesc(item);
                }
            }
            return new CommonPageDto<InventoryTransactionDto>();
        }

        public async Task<List<InventoryTransactionDto>> FilterAsync(FilterInventoryTransactionDto item)
        {
            var query = await _inventoryTransactionRepository.GetQueryableAsync();
            var toDate = item.ToDate.AddDays(1).AddSeconds(-1);
            var filter = query
                .Include(x => x.Inventory)
                .ThenInclude(k => k.WareHouse)
                .Include(x => x.Inventory)
                .ThenInclude(k => k.Product)
                .Where(x => x.Inventory.CreateTime >= item.FromDate && x.Inventory.CreateTime <= toDate
                && x.Inventory.ProductId == item.ProductId && x.Inventory.WareHouseId == item.WarehouseId
                && x.Type == item.Type);
            return _mapper.Map<List<InventoryTransaction>, List<InventoryTransactionDto>>(await filter.ToListAsync());
        }

        public async Task<CommonPageDto<InventoryTransactionDto>> GetPagedHistoryListAsync(FilterInventoryTransactionDto item, int choice)
        {
            if (Enum.IsDefined(typeof(EnumInventoryTransactionFilter), choice))
            {
                switch ((EnumInventoryTransactionFilter)choice)
                {
                    case EnumInventoryTransactionFilter.DateAsc:
                        return await FilterHistoryDateAsc(item);
                    case EnumInventoryTransactionFilter.DateDesc:
                        break;
                    case EnumInventoryTransactionFilter.QuatityAsc:
                        break;
                    case EnumInventoryTransactionFilter.QuatytiDesc:
                        break;
                }
            }
            return new CommonPageDto<InventoryTransactionDto>();
        }

        private async Task<CommonPageDto<InventoryTransactionDto>> FilterHistoryDateAsc(FilterInventoryTransactionDto item)
        {
            var query = await _inventoryTransactionRepository.GetQueryableAsync();
            var filter = query
                .Include(x => x.Inventory)
                .ThenInclude(k => k.Product)
                .Include(x => x.Inventory)
                .ThenInclude(k => k.WareHouse);
            var count = filter.CountAsync();
            var data = filter.OrderBy(x => x.CreateTime).Skip(item.SkipCount).Take(item.TakeMaxResultCount);
            return new CommonPageDto<InventoryTransactionDto>(await count, item, _mapper.Map<List<InventoryTransaction>, List<InventoryTransactionDto>>(await data.ToListAsync()));
        }
    }
}
