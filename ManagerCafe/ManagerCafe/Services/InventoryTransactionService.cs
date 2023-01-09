using AutoMapper;
using ManagerCafe.Data.Data;
using ManagerCafe.Data.Enums;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryTransactionDtos;
using ManagerCafe.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(CreateInventoryTransactionDto item, DbTransaction dbTransaction = null)
        {
            //var transaction = dbTransaction == null ?
            //    await _context.Database.BeginTransactionAsync() :
            //    await _context.Database.UseTransactionAsync(dbTransaction);

            var create = _mapper.Map<CreateInventoryTransactionDto, InventoryTransaction>(item);
            await _inventoryTransactionRepository.AddAsync(create);
        }

        public async Task<List<InventoryTransactionDto>> FilterAsync(FilterInventoryTransactionDto item)
        {
            var inventoryTransactions = await _inventoryTransactionRepository.GetQueryableAsync();
            //var fromDate = DateTime.Now.Date;
            //var toDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            //var codeBanhQuy = Guid.Parse("08daebd8-d83c-46f4-8d97-204459d3e0c9"); 
            var filter = inventoryTransactions
                .Include(x => x.Inventory)
                .ThenInclude(x => x.Product)
                .Include(x => x.Inventory)
                .ThenInclude(x => x.WareHouse)
                .Where(x => x.Type == item.Type /*&& x.CreateTime >= fromDate && x.CreateTime <= toDate && x.Inventory.ProductId == codeBanhQuy */)

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


            //        List<ResultLine> result = Lines
            //.GroupBy(l => l.ProductCode)
            //.Select(cl => new ResultLine
            //{
            //    ProductName = cl.First().Name,
            //    Quantity = cl.Count().ToString(),
            //    Price = cl.Sum(c => c.Price).ToString(),
            //}).ToList();
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
            return await filter.ToListAsync();
            //var entities = await _inventoryTransactionRepository.fi

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
    }
}
