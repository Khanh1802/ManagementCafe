using AutoMapper;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryDto.InventoryDtos;
using ManagerCafe.Dtos.InventoryDtos;
using ManagerCafe.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManagerCafe.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public InventoryService(IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<InventoryDto> AddAsync(CreatenInvetoryDto item)
        {
            var createInventory = _mapper.Map<CreatenInvetoryDto, Inventory>(item);
            var entity = await _inventoryRepository.AddAsync(createInventory);
            return _mapper.Map<Inventory, InventoryDto>(entity);
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
                      //.Include(x => x.WareHouse)
                      //.Include(x => x.Product)
                      .ToListAsync();
            return _mapper.Map<List<Inventory>, List<InventoryDto>>(inventories);
        }

        public async Task<List<InventoryDto>> GetAllAsync()
        {
            var entites = await _inventoryRepository.GetAllAsync();
            return _mapper.Map<List<Inventory>, List<InventoryDto>>(entites);
        }

        public async Task<InventoryDto> GetByIdAsync<Tkey>(Tkey key)
        {
            var entity = await _inventoryRepository.GetByIdAsync(key);
            return _mapper.Map<Inventory, InventoryDto>(entity);
        }

        public async Task<InventoryDto> UpdateAsync(UpdateInventoryDto item)
        {
            var entity = await _inventoryRepository.GetByIdAsync(item.Id);
            if (entity is null)
            {
                throw new Exception("Not found Inventory to delete");
            }
            await _inventoryRepository.UpdateAsync(entity);
            return _mapper.Map<Inventory, InventoryDto>(entity);
        }
    }
}
