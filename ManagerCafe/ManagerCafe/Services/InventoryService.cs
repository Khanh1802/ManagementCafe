using AutoMapper;
using ManagerCafe.Commons;
using ManagerCafe.Data.Data;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryDto.InventoryDtos;
using ManagerCafe.Dtos.InventoryDtos;
using ManagerCafe.Dtos.InventoryTransactionDtos;
using ManagerCafe.Enums;
using ManagerCafe.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Transactions;

namespace ManagerCafe.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;
        private readonly IInventoryTransactionService _inventoryTransactionService;
        private readonly ManagerCafeDbContext _context;

        public InventoryService(IInventoryRepository inventoryRepository, IMapper mapper, ManagerCafeDbContext context, IInventoryTransactionService inventoryTransactionService, IMemoryCache memoryCache)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
            _context = context;
            _inventoryTransactionService = inventoryTransactionService;
            _memoryCache = memoryCache;
        }

        public async Task<InventoryDto> AddAsync(CreatenInvetoryDto item)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var entity = new Inventory();
                var filter = await FilterAsync(new FilterInventoryDto()
                {
                    ProductId = item.ProductId,
                    WareHouseId = item.WareHouseId,
                });
                if (filter.Count > 0)
                {
                    var inventory = filter.FirstOrDefault();
                    if (inventory == null)
                    {
                        throw new Exception("Not found Inventory to delete");
                    }
                    inventory.Quatity += item.Quatity;
                    var update = _mapper.Map<InventoryDto, UpdateInventoryDto>(inventory);
                    await UpdateAsync(update);

                    var inventoryTransaction = new CreateInventoryTransactionDto();

                    inventoryTransaction.Quatity = item.Quatity;
                    inventoryTransaction.InventoryId = inventory.Id;
                    inventoryTransaction.Type = EnumInventoryTransation.Import;
                    await _inventoryTransactionService.AddAsync(inventoryTransaction, transaction.GetDbTransaction());
                }
                else
                {
                    var createInventory = _mapper.Map<CreatenInvetoryDto, Inventory>(item);
                    entity = await _inventoryRepository.AddAsync(createInventory);

                    var inventoryTransaction = new CreateInventoryTransactionDto()
                    {
                        Quatity = entity.Quatity,
                        InventoryId = entity.Id,
                        Type = EnumInventoryTransation.Import
                    };
                    await _inventoryTransactionService.AddAsync(inventoryTransaction, transaction.GetDbTransaction());
                }
                await transaction.CommitAsync();
                return _mapper.Map<Inventory, InventoryDto>(entity);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex.GetBaseException();
            }

        }

        public async Task DeleteAsync<Tkey>(Tkey key)
        {
            var entity = await _inventoryRepository.GetByIdAsync(key);
            if (entity is null)
            {
                throw new Exception("Not found Inventory to delete");
            }
            await _inventoryRepository.Delete(entity);
        }

        public async Task<List<InventoryDto>> FilterAsync(FilterInventoryDto item)
        {
            var filter = await _inventoryRepository.GetQueryableAsync();

            if (item.ProductId != null)
            {
                filter = filter.Where(x => x.WareHouseId == item.WareHouseId);
            }
            if (item.WareHouseId != null)
            {
                filter = filter.Where(x => x.ProductId == item.ProductId);
            }

            var inventories = await filter
                      .OrderBy(x => x.Product.CreateTime)
                      .Include(x => x.WareHouse).Where(x => x.WareHouse.IsDeleted == false)
                      .Include(x => x.Product).Where(x => x.Product.IsDeleted == false)
                      .ToListAsync();
            return _mapper.Map<List<Inventory>, List<InventoryDto>>(inventories);
        }



        public async Task<List<InventoryDto>> GetAllAsync()
        {
            if (_memoryCache.TryGetValue<List<Inventory>>(InventoryCacheKey.InventoryAllKey, out var inventories))
            {
                return _mapper.Map<List<Inventory>, List<InventoryDto>>(inventories);
            }

            var entites = await _inventoryRepository.GetAllAsync();
            _memoryCache.Set<List<Inventory>>(InventoryCacheKey.InventoryAllKey, entites, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
            });
            return _mapper.Map<List<Inventory>, List<InventoryDto>>(entites);
        }

        public async Task<InventoryDto> GetByIdAsync<Tkey>(Tkey key)
        {
            var entity = await _inventoryRepository.GetByIdAsync(key);
            return _mapper.Map<Inventory, InventoryDto>(entity);
        }

        public async Task<CommonPageDto<InventoryDto>> GetPagedListAsync(FilterInventoryDto item, int choice)
        {
            if (Enum.IsDefined(typeof(EnumInventoryFilter), choice))
            {
                switch ((EnumInventoryFilter)choice)
                {
                    case EnumInventoryFilter.DateAsc:
                        return await FilterInventoryDtoDateAsc(item);
                    case EnumInventoryFilter.DateDesc:
                        return await FilterInventoryDtoDateDesc(item);
                    case EnumInventoryFilter.QuatityAsc:
                        return await FilterInventoryDtoQuatityAsc(item);
                    case EnumInventoryFilter.QuatytiDesc:
                        return await FilterInventoryDtoQuaityDesc(item);
                }
            }
            else if (item.ProductId != null && item.WareHouseId != null)
            {
                return await FilterInventoryByIdProductAndWarehouse(item);
            }
            return new CommonPageDto<InventoryDto>();
        }
        private async Task<CommonPageDto<InventoryDto>> FilterInventoryDtoDateAsc(FilterInventoryDto item)
        {
            var filter = await _inventoryRepository.GetQueryableAsync();
            var count = await filter.CountAsync();
            var InventoriesDto = await filter.OrderBy(x => x.CreateTime)
                .Include(x => x.Product).Where(k => !k.IsDeleted)
                .Include(x => x.WareHouse).Where(x => !x.IsDeleted)
                .Skip(item.SkipCount).Take(item.TakeMaxResultCount).ToListAsync();
            return new CommonPageDto<InventoryDto>(count, item, _mapper.Map<List<Inventory>, List<InventoryDto>>(InventoriesDto));
        }

        private async Task<CommonPageDto<InventoryDto>> FilterInventoryDtoDateDesc(FilterInventoryDto item)
        {
            var filter = await _inventoryRepository.GetQueryableAsync();
            var count = await filter.CountAsync();
            var InventoriesDto = await filter.OrderByDescending(x => x.CreateTime)
                .Include(x => x.Product).Where(k => !k.IsDeleted)
                .Include(x => x.WareHouse).Where(x => !x.IsDeleted)
                .Skip(item.SkipCount).Take(item.TakeMaxResultCount).ToListAsync();
            return new CommonPageDto<InventoryDto>(count, item, _mapper.Map<List<Inventory>, List<InventoryDto>>(InventoriesDto));
        }

        private async Task<CommonPageDto<InventoryDto>> FilterInventoryDtoQuatityAsc(FilterInventoryDto item)
        {
            var filter = await _inventoryRepository.GetQueryableAsync();
            var count = await filter.CountAsync();
            var InventoriesDto = await filter.OrderBy(x => x.Quatity)
                .Include(x => x.Product).Where(k => !k.IsDeleted)
                .Include(x => x.WareHouse).Where(x => !x.IsDeleted)
                .Skip(item.SkipCount).Take(item.TakeMaxResultCount).ToListAsync();
            return new CommonPageDto<InventoryDto>(count, item, _mapper.Map<List<Inventory>, List<InventoryDto>>(InventoriesDto));
        }

        private async Task<CommonPageDto<InventoryDto>> FilterInventoryDtoQuaityDesc(FilterInventoryDto item)
        {
            var filter = await _inventoryRepository.GetQueryableAsync();
            var count = await filter.CountAsync();
            var InventoriesDto = await filter.OrderByDescending(x => x.Quatity)
                .Include(x => x.Product).Where(k => !k.IsDeleted)
                .Include(x => x.WareHouse).Where(x => !x.IsDeleted)
                .Skip(item.SkipCount).Take(item.TakeMaxResultCount).ToListAsync();
            return new CommonPageDto<InventoryDto>(count, item, _mapper.Map<List<Inventory>, List<InventoryDto>>(InventoriesDto));
        }

        private async Task<CommonPageDto<InventoryDto>> FilterInventoryByIdProductAndWarehouse(FilterInventoryDto item)
        {
            var filter = await _inventoryRepository.GetQueryableAsync();
            var count = await filter.CountAsync();
            var InventoriesDto = filter.OrderByDescending(x => x.Quatity)
                .Include(x => x.Product).Where(k => !k.IsDeleted)
                .Include(x => x.WareHouse).Where(x => !x.IsDeleted);
            var result = await InventoriesDto.Where(x => x.Product.Id == item.ProductId &&
            x.WareHouse.Id == item.WareHouseId)
                .ToListAsync();
            return new CommonPageDto<InventoryDto>(count, item, _mapper.Map<List<Inventory>, List<InventoryDto>>(result));
        }

        public async Task<InventoryDto> UpdateAsync(UpdateInventoryDto item)
        {
            //1 Khởi tạo Init transaction
            // var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var entity = await _inventoryRepository.GetByIdAsync(item.Id);
                if (entity is null)
                {
                    throw new Exception("Not found Inventory to delete");
                }
                var update = _mapper.Map<UpdateInventoryDto, Inventory>(item, entity);
                await _inventoryRepository.UpdateAsync(update);

                //var a = await _inventoryRepository.GetAllAsync();
                // Khi ko bị lỗi thì save tất cả thay đổi xuống Db
                //1
                // await transaction.CommitAsync();
                return _mapper.Map<Inventory, InventoryDto>(entity);
            }
            catch (Exception ex)
            {
                //Nếu có lỗi trong lúc donw xuống db thì trả lại như cũ
                //await transaction.RollbackAsync();
                throw ex.GetBaseException();
            }
        }

        public void Teest()
        {

        }

        public Task<CommonPageDto<InventoryDto>> GetPagedListAsync(FilterInventoryDto item)
        {
            throw new NotImplementedException();
        }
    }
}
