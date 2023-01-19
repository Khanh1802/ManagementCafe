using AutoMapper;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryDtos;

namespace ManagerCafe.Profiles
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<Inventory, InventoryDto>();
            //.ForMember(x => x.ProductName, opt => opt.MapFrom(o => o.Product != null ? o.Product.Name : string.Empty));
            CreateMap<CreatenInvetoryDto, Inventory>();
            CreateMap<FilterInventoryDto, Inventory>();
            CreateMap<UpdateInventoryDto, Inventory>();
            CreateMap<InventoryDto, UpdateInventoryDto>();
        }
    }
}
