using AutoMapper;
using ManagerCafe.Commons;
using ManagerCafe.Data.Data;
using ManagerCafe.Data.Enums;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryDto.InventoryDtos;
using ManagerCafe.Dtos.InventoryDtos;
using ManagerCafe.Dtos.InventoryTransactionDtos;
using ManagerCafe.Enums;
using ManagerCafe.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

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
                    if (inventory is not null)
                    {
                        throw new Exception("Inventory have been create");
                    }
                }
                else
                {
                    var transaction = await _context.Database.BeginTransactionAsync();
                    try
                    {
                        var createInventory = _mapper.Map<CreatenInvetoryDto, Inventory>(item);
                        entity = await _inventoryRepository.AddAsync(createInventory);

                        var inventoryTransaction = new CreateInventoryTransactionDto()
                        {
                            Quatity = entity.Quatity,
                            InventoryId = entity.Id,
                            Type = EnumInventoryTransation.Import
                        };
                        await _inventoryTransactionService.AddAsync(inventoryTransaction);
                        await transaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw ex.GetBaseException();
                    }
                }
                return _mapper.Map<Inventory, InventoryDto>(entity);
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        public async Task DeleteAsync<Tkey>(Tkey key)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var entity = await _inventoryRepository.GetByIdAsync(key);
                if (entity is null)
                {
                    throw new Exception("Not found Inventory to delete");
                }
                await _inventoryRepository.Delete(entity);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex.GetBaseException();
            }
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

            var dataGirdView = await filter
                      .Include(x => x.WareHouse)
                      .Include(x => x.Product)
                      .Where(x => !x.Product.IsDeleted && !x.WareHouse.IsDeleted)
                      .ToListAsync();
            return _mapper.Map<List<Inventory>, List<InventoryDto>>(dataGirdView);
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
            return new CommonPageDto<InventoryDto>();
        }
        private async Task<CommonPageDto<InventoryDto>> FilterInventoryDtoDateAsc(FilterInventoryDto item)
        {
            var query = await _inventoryRepository.GetQueryableAsync();
            var filter = query
                .OrderBy(x => x.CreateTime)
                .Include(x => x.Product)
                .Include(x => x.WareHouse)
                .Where(x => !x.Product.IsDeleted && !x.WareHouse.IsDeleted);
            var count = filter.Count();
            var dataGirdView = filter
            .Skip(item.SkipCount).Take(item.TakeMaxResultCount);
            return new CommonPageDto<InventoryDto>(count, item, _mapper.Map<List<Inventory>, List<InventoryDto>>(await dataGirdView.ToListAsync()));
        }

        private async Task<CommonPageDto<InventoryDto>> FilterInventoryDtoDateDesc(FilterInventoryDto item)
        {
            var query = await _inventoryRepository.GetQueryableAsync();
            var filter = query
                .OrderByDescending(x => x.CreateTime)
                .Include(x => x.Product)
                .Include(x => x.WareHouse)
                .Where(x => !x.Product.IsDeleted && !x.WareHouse.IsDeleted);
            var count = filter.Count();
            var dataGirdView = filter
            .Skip(item.SkipCount).Take(item.TakeMaxResultCount);
            return new CommonPageDto<InventoryDto>(count, item, _mapper.Map<List<Inventory>, List<InventoryDto>>(await dataGirdView.ToListAsync()));
        }

        private async Task<CommonPageDto<InventoryDto>> FilterInventoryDtoQuatityAsc(FilterInventoryDto item)
        {
            var query = await _inventoryRepository.GetQueryableAsync();
            var filter = query
                .OrderBy(x => x.Quatity)
                .Include(x => x.Product)
                .Include(x => x.WareHouse)
                .Where(x => !x.Product.IsDeleted && !x.WareHouse.IsDeleted);
            var count = filter.Count();
            var dataGirdView = filter
            .Skip(item.SkipCount).Take(item.TakeMaxResultCount);
            return new CommonPageDto<InventoryDto>(count, item, _mapper.Map<List<Inventory>, List<InventoryDto>>(await dataGirdView.ToListAsync()));
        }

        private async Task<CommonPageDto<InventoryDto>> FilterInventoryDtoQuaityDesc(FilterInventoryDto item)
        {
            var query = await _inventoryRepository.GetQueryableAsync();
            var filter = query
                .OrderByDescending(x => x.Quatity)
                .Include(x => x.Product)
                .Include(x => x.WareHouse)
                .Where(x => !x.Product.IsDeleted && !x.WareHouse.IsDeleted);
            var count = filter.Count();
            var dataGirdView = filter
            .Skip(item.SkipCount).Take(item.TakeMaxResultCount);
            return new CommonPageDto<InventoryDto>(count, item, _mapper.Map<List<Inventory>, List<InventoryDto>>(await dataGirdView.ToListAsync()));
        }

        //private async Task<CommonPageDto<InventoryDto>> FilterInventoryNotCheckAll(FilterInventoryDto item)
        //{
        //    var filter = (await _inventoryRepository.GetQueryableAsync())
        //        .AsNoTracking()
        //        .Include(x => x.WareHouse)
        //        .Include(x => x.Product)
        //        .Where(x => !x.WareHouse.IsDeleted && !x.Product.IsDeleted && x.Product.Id == item.ProductId && x.WareHouse.Id == item.WareHouseId);

        //    var count = await filter.CountAsync(); 
        //    var pagination = await filter
        //        .OrderByDescending(x => x.Quatity)
        //        .Skip(item.SkipCount)
        //        .Take(item.TakeMaxResultCount)
        //        .ToListAsync();
        //    //var count = await filter.
        //    //    Include(x => x.Product).Where(k => !k.IsDeleted)
        //    //    .Include(x => x.WareHouse).Where(x => !x.IsDeleted)
        //    //    .Where(x => x.Product.Id == item.ProductId && x.WareHouse.Id == item.WareHouseId)
        //    //    .CountAsync();
        //    //var dataGirdView = filter.OrderByDescending(x => x.Quatity)
        //    //    .Include(x => x.Product).Where(k => !k.IsDeleted)
        //    //    .Include(x => x.WareHouse).Where(x => !x.IsDeleted)
        //    //    .Where(x => x.Product.Id == item.ProductId && x.WareHouse.Id == item.WareHouseId)
        //    //    .Skip(item.SkipCount).Take(item.TakeMaxResultCount);
        //    return new CommonPageDto<InventoryDto>(count, item, _mapper.Map<List<Inventory>, List<InventoryDto>>(pagination));
        //}

        public async Task<InventoryDto> UpdateAsync(UpdateInventoryDto item)
        {
            //1 Khởi tạo Init transaction
            var transaction = await _context.Database.BeginTransactionAsync();
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
                var inventoryTransaction = new CreateInventoryTransactionDto()
                {
                    Quatity = item.Quatity,
                    InventoryId = item.Id,
                    Type = EnumInventoryTransation.Import
                };
                await _inventoryTransactionService.AddAsync(inventoryTransaction);
                await transaction.CommitAsync();
                return _mapper.Map<Inventory, InventoryDto>(entity);
            }
            catch (Exception ex)
            {
                //Nếu có lỗi trong lúc donw xuống db thì trả lại như cũ
                await transaction.RollbackAsync();
                throw ex.GetBaseException();
            }
        }

        public Task<CommonPageDto<InventoryDto>> GetPagedListAsync(FilterInventoryDto item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InventoryDto>> FindByIdProductAndWarehouse(FilterInventoryDto item)
        {
            var filter = await _inventoryRepository.GetQueryableAsync();
            var InventoriesDto = filter.Include(x => x.Product).Where(k => !k.IsDeleted)
                   .Include(x => x.WareHouse).Where(x => !x.IsDeleted)
                   .Where(x => x.Product.Id == item.ProductId && x.WareHouseId == item.WareHouseId)
                   .Select(x => x).ToListAsync();
            return _mapper.Map<List<Inventory>, List<InventoryDto>>(await InventoriesDto);
        }
    }
}
