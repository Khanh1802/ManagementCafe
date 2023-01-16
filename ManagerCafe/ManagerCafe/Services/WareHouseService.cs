using AutoMapper;
using ManagerCafe.Commons;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.WareHouseDtos;
using ManagerCafe.Enums;
using ManagerCafe.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ManagerCafe.Services
{
    public class WareHouseService : IWareHouseService
    {
        private readonly IWareHouseRepository _wareHouseRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;

        public WareHouseService(IWareHouseRepository wareHouseRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _wareHouseRepository = wareHouseRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<WareHouseDto> AddAsync(CreateWareHouseDto item)
        {
            var entity = _mapper.Map<CreateWareHouseDto, WareHouse>(item);
            await _wareHouseRepository.AddAsync(entity);
            return _mapper.Map<WareHouse, WareHouseDto>(entity);
        }

        public async Task DeleteAsync<Tkey>(Tkey key)
        {
            var entity = await _wareHouseRepository.GetByIdAsync(key);
            if (entity == null)
            {
                throw new Exception("Not found WareHouse to detele");
            }
            await _wareHouseRepository.Delete(entity);
        }

        private async Task<IQueryable<WareHouse>> FilterQueryAbleAsync()
        {
            var query = await _wareHouseRepository.GetQueryableAsync();
            var filter = query.Where(x => !x.IsDeleted);
            return filter;
        }

        public async Task<List<WareHouseDto>> FilterAsync(FilterWareHouseDto item)
        {
            var filters = await _wareHouseRepository.GetQueryableAsync();
            if (!string.IsNullOrEmpty(item.Name))
            {
                filters = filters.Where(x => EF.Functions.Like(x.Name, $"%{item.Name}%"));
            }
            return _mapper.Map<List<WareHouse>, List<WareHouseDto>>(await filters.ToListAsync());
        }

        public async Task<List<WareHouseDto>> FilterChoice(int choice)
        {
            if (Enum.IsDefined(typeof(EnumWareHouseFilter), choice))
            {
                var query = await FilterQueryAbleAsync();
                switch ((EnumWareHouseFilter)choice)
                {
                    case EnumWareHouseFilter.DateAsc:
                        query = query.OrderBy(x => x.CreateTime);
                        break;
                    case EnumWareHouseFilter.DateDesc:
                        query = query.OrderByDescending(x => x.CreateTime);
                        break;
                }
                return new List<WareHouseDto>(_mapper.Map<List<WareHouse>, List<WareHouseDto>>(await query.ToListAsync()));
            }
            throw new Exception("Not found filter Product");
        }

        public async Task<List<WareHouseDto>> GetAllAsync()
        {
            if (_memoryCache.TryGetValue<List<WareHouse>>(WarehouseCacheKey.WarehouseAllKey, out var inventories))
            {
                return _mapper.Map<List<WareHouse>, List<WareHouseDto>>(inventories);
            }
            var entites = await _wareHouseRepository.GetAllAsync();
            _memoryCache.Set(WarehouseCacheKey.WarehouseAllKey, entites, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
            });
            return _mapper.Map<List<WareHouse>, List<WareHouseDto>>(entites);
        }

        public async Task<WareHouseDto> GetByIdAsync<Tkey>(Tkey key)
        {
            var entity = await _wareHouseRepository.GetByIdAsync(key);
            return _mapper.Map<WareHouse, WareHouseDto>(entity);
        }

        public async Task<WareHouseDto> UpdateAsync(UpdateWareHouseDto item)
        {
            var entity = await _wareHouseRepository.GetByIdAsync(item.Id);
            if (entity == null)
            {
                throw new Exception("Not found WareHouse to update");
            }
            var update = _mapper.Map<UpdateWareHouseDto, WareHouse>(item, entity);
            await _wareHouseRepository.UpdateAsync(update);
            return _mapper.Map<WareHouse, WareHouseDto>(update);
        }

        public Task<CommonPageDto<WareHouseDto>> GetPagedListAsync(FilterWareHouseDto item)
        {
            throw new NotImplementedException();
        }
    }
}
