using AutoMapper;
using ManagerCafe.Commons;
using ManagerCafe.Data.Data;
using ManagerCafe.Data.Enums;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryDtos;
using ManagerCafe.Dtos.InventoryTransactionDtos;
using ManagerCafe.Enums;
using ManagerCafe.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;

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

        private async Task<List<InventoryTransactionDto>> FilterWithDate(FilterInventoryTransactionDto item)
        {
            var inventoryTransactions = await _inventoryTransactionRepository.GetQueryableAsync();
            //var second = 
            var formdDate = item.FromDate.AddDays(1).AddSeconds(-1);
            var filter = inventoryTransactions
                .Include(x => x.Inventory)
                .ThenInclude(x => x.Product)
                .Include(x => x.Inventory)
                .ThenInclude(x => x.WareHouse)
                .Where(x => x.Type == item.Type && x.CreateTime >= item.FromDate && x.CreateTime <= formdDate
                && x.Inventory.WareHouseId == item.WarehouseId)

                .GroupBy(x => x.InventoryId).Select(x => new InventoryTransactionDto
                {
                    InventoryId = x.Key,
                    //Quantity = x.Sum(k => k.Quatity),
                    //Inventory = x.FirstOrDefault().Inventory
                    Type = x.FirstOrDefault().Type,
                    Quatity = x.Sum(k => k.Quatity),
                    ProductName = x.FirstOrDefault().Inventory.Product.Name,
                    WarehouseName = x.FirstOrDefault().Inventory.WareHouse.Name,
                    CreateTime = x.FirstOrDefault().CreateTime,
                })
                .OrderByDescending(x => x.Quatity)
                .Take(10);

            return await filter.ToListAsync();
        }

        private async Task<List<InventoryTransactionDto>> FilterWithNonDate(FilterInventoryTransactionDto item)
        {
            var inventoryTransactions = await _inventoryTransactionRepository.GetQueryableAsync();
            //var fromDate = DateTime.Now.Date;
            //var toDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            //var codeBanhQuy = Guid.Parse("08daebd8-d83c-46f4-8d97-204459d3e0c9"); 
            var filter = inventoryTransactions
                .Include(x => x.Inventory)
                .ThenInclude(k => k.Product)
                .Include(x => x.Inventory)
                .ThenInclude(k => k.WareHouse)
                .Where(x => x.Inventory.WareHouseId == item.WarehouseId)
                .GroupBy(x => x.InventoryId).Select(x => new InventoryTransactionDto()
                {
                    InventoryId = x.Key,
                    Quatity = x.Sum(x => x.Quatity),
                    CreateTime = x.FirstOrDefault().CreateTime,
                    Type = x.FirstOrDefault().Type,
                    ProductName = x.FirstOrDefault().Inventory.Product.Name,
                    WarehouseName = x.FirstOrDefault().Inventory.WareHouse.Name,
                })
                .Skip(item.SkipCount).Take(item.TakeMaxResultCount).ToListAsync();
            return await filter;

        }

        private async Task<List<InventoryTransactionDto>> FilterWithDateAndName(FilterInventoryTransactionDto item)
        {
            var inventoryTransactions = await _inventoryTransactionRepository.GetQueryableAsync();
            var filter = inventoryTransactions
                .Include(x => x.Inventory)
                .ThenInclude(k => k.Product)
                .Include(x => x.Inventory)
                .ThenInclude(j => j.WareHouse)
                .Where(x => x.Type == item.Type && x.CreateTime >= item.FromDate && x.CreateTime <= item.ToDate
                && x.Inventory.WareHouseId == item.WarehouseId && x.Inventory.Product.Name.Contains(item.ProductName))

                .GroupBy(x => x.InventoryId).Select(x => new InventoryTransactionDto
                {
                    InventoryId = x.Key,
                    Type = x.FirstOrDefault().Type,
                    Quatity = x.Sum(k => k.Quatity),
                    ProductName = x.FirstOrDefault().Inventory.Product.Name,
                    WarehouseName = x.FirstOrDefault().Inventory.WareHouse.Name,
                    CreateTime = x.FirstOrDefault().CreateTime,

                })
                .OrderByDescending(x => x.Quatity)
                .Take(10);

            return await filter.ToListAsync();
        }
        private async Task<List<InventoryTransactionDto>> FilterWithDateTimeAndNameWithNoNameAllWarehouse(FilterInventoryTransactionDto item)
        {
            var inventoryTransactions = await _inventoryTransactionRepository.GetQueryableAsync();
            var filter = inventoryTransactions
                .Include(x => x.Inventory)
                .ThenInclude(j => j.WareHouse)
                .Where(x => x.Type == item.Type)

                .GroupBy(x => x.InventoryId).Select(x => new InventoryTransactionDto
                {
                    InventoryId = x.Key,
                    Type = x.FirstOrDefault().Type,
                    Quatity = x.Sum(k => k.Quatity),
                    ProductName = x.FirstOrDefault().Inventory.Product.Name,
                    WarehouseName = x.FirstOrDefault().Inventory.WareHouse.Name,
                    CreateTime = x.FirstOrDefault().CreateTime,

                })
                .OrderByDescending(x => x.Quatity)
                .Skip(item.SkipCount)
                .Take(item.TakeMaxResultCount);

            return await filter.ToListAsync();
        }

        private async Task<List<InventoryTransactionDto>> FilterWithDateTimeAndNameWithAllWarehouse(FilterInventoryTransactionDto item)
        {
            var inventoryTransactions = await _inventoryTransactionRepository.GetQueryableAsync();
            var filter = inventoryTransactions
                .Include(x => x.Inventory)
                .ThenInclude(k => k.Product)
                .Include(x => x.Inventory)
                .ThenInclude(j => j.WareHouse)
                .Where(x => x.Type == item.Type && x.CreateTime >= item.FromDate && x.CreateTime <= item.ToDate
                && x.Inventory.Product.Name.Contains(item.ProductName))

                .GroupBy(x => x.InventoryId).Select(x => new InventoryTransactionDto
                {
                    InventoryId = x.Key,
                    Type = x.FirstOrDefault().Type,
                    Quatity = x.Sum(k => k.Quatity),
                    ProductName = x.FirstOrDefault().Inventory.Product.Name,
                    WarehouseName = x.FirstOrDefault().Inventory.WareHouse.Name,
                    CreateTime = x.FirstOrDefault().CreateTime,

                })
                .OrderByDescending(x => x.Quatity)
                .Take(10);

            return await filter.ToListAsync();
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

        public async Task<CommonPageDto<InventoryTransactionDto>> GetPagedListAsync(FilterInventoryTransactionDto item, int enums)
        {
            var count = await (await _inventoryTransactionRepository.GetQueryableAsync()).CountAsync();

            var Inventories = new List<InventoryTransactionDto>();
            if (Enum.IsDefined(typeof(EnumInventoryTransactionFilter), enums))
            {
                switch (enums)
                {
                    case (int)EnumInventoryTransactionFilter.FilterWithNonDateTime:
                        Inventories = await FilterWithNonDate(item);
                        break;
                    case (int)EnumInventoryTransactionFilter.FilterWithDateTime:
                        Inventories = await FilterWithDate(item);
                        break;
                    case (int)EnumInventoryTransactionFilter.FilterWithDateTimeAndName:
                        Inventories = await FilterWithDateAndName(item);
                        break;
                    case (int)EnumInventoryTransactionFilter.FilterWithDateTimeAndNameWithAllWarehouse:
                        Inventories = await FilterWithDateTimeAndNameWithAllWarehouse(item);
                        break;
                    case (int)EnumInventoryTransactionFilter.FilterWithDateTimeAndWithNoNameAllWarehouse:
                        Inventories = await FilterWithDateTimeAndNameWithNoNameAllWarehouse(item);
                        break;
                }
            }

            switch (item.TypeDate)
            {
                case Data.Enums.EnumInventoryTransactionTypeDate.Day:
                    break;
                case Data.Enums.EnumInventoryTransactionTypeDate.Month:
                    break;
                case Data.Enums.EnumInventoryTransactionTypeDate.Year:
                    break;
            }
            //var query = filter.ToQueryString();
            return new CommonPageDto<InventoryTransactionDto>(count, item, Inventories);
        }

        public Task<List<InventoryTransactionDto>> FilterAsync(FilterInventoryTransactionDto item)
        {
            throw new NotImplementedException();
        }
    }
}
