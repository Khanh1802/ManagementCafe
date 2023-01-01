using AutoMapper;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.WareHouseDtos;
using ManagerCafe.Enums;
using ManagerCafe.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManagerCafe.Services
{
    public class WareHouseService : IWareHouseService
    {
        private readonly IWareHouseRepository _wareHouseRepository;
        private readonly IMapper _mapper;

        public WareHouseService(IWareHouseRepository wareHouseRepository, IMapper mapper)
        {
            _wareHouseRepository = wareHouseRepository;
            _mapper = mapper;
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

        public async Task<List<WareHouseDto>> FilterAsync(FilterWareHouseDto item)
        {
            var entites = await (await _wareHouseRepository.GetQueryableAsync())
                .Where(x => x.Name.Contains(item.Name))
                .ToListAsync();
            return _mapper.Map<List<WareHouse>, List<WareHouseDto>>(entites);
        }
        private async Task<List<WareHouseDto>> FilterDayAsc()
        {
            var warehouses = await (await _wareHouseRepository.GetQueryableAsync())
              .OrderBy(x => x.CreateTime).ToListAsync();
            return _mapper.Map<List<WareHouse>, List<WareHouseDto>>(warehouses);
        }

        private async Task<List<WareHouseDto>> FilterDayDesc()
        {
            var warehouses = await (await _wareHouseRepository.GetQueryableAsync())
              .OrderByDescending(x => x.CreateTime).ToListAsync();
            return _mapper.Map<List<WareHouse>, List<WareHouseDto>>(warehouses);
        }

        public async Task<List<WareHouseDto>> FilterChoice(int filter)
        {
            if (Enum.IsDefined(typeof(EnumFilterWareHouse), filter))
            {
                switch ((EnumFilterWareHouse)filter)
                {
                    case EnumFilterWareHouse.NgayTangDan:
                        return await FilterDayAsc();
                    case EnumFilterWareHouse.NgayGiamDan:
                        return await FilterDayDesc();
                }
            }
            return null;
        }

        public async Task<List<WareHouseDto>> GetAllAsync()
        {
            var entites = await _wareHouseRepository.GetAllAsync();
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
    }
}
