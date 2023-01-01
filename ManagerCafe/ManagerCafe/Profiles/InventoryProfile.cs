using AutoMapper;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryDto.InventoryDtos;
using ManagerCafe.Dtos.InventoryDtos;

namespace ManagerCafe.Profiles
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<Inventory, InventoryDto>();
            CreateMap<CreatenInvetoryDto, Inventory>();
            CreateMap<FilterInventoryDto, Inventory>();
            CreateMap<UpdateInventoryDto, Inventory>();
        }
    }
}
