using AutoMapper;
using ManagerCafe.Commons;
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
            var entity = new Inventory();
            var filter = await this.FilterAsync(new FilterInventoryDto()
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
                await this.UpdateAsync(update);
            }
            else
            {
                var createInventory = _mapper.Map<CreatenInvetoryDto, Inventory>(item);
                entity = await _inventoryRepository.AddAsync(createInventory);
            }
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
                      .OrderBy(x => x.Product.CreateTime)
                      .Include(x => x.WareHouse).Where(x => x.WareHouse.IsDeleted == false)
                      .Include(x => x.Product).Where(x => x.Product.IsDeleted == false)
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

        public Task<CommonPageDto<InventoryDto>> GetPagedListAsync(FilterInventoryDto item)
        {
            throw new NotImplementedException();
        }

        public Task<List<InventoryDto>> IventoryTransation(InventoryTransationDto transation)
        {

            throw new NotImplementedException();
        }

        public async Task<InventoryDto> UpdateAsync(UpdateInventoryDto item)
        {
            var entity = await _inventoryRepository.GetByIdAsync(item.Id);
            if (entity is null)
            {
                throw new Exception("Not found Inventory to delete");
            }
            var update = _mapper.Map<UpdateInventoryDto, Inventory>(item, entity);
            await _inventoryRepository.UpdateAsync(update);
            return _mapper.Map<Inventory, InventoryDto>(entity);
        }
    }
}
