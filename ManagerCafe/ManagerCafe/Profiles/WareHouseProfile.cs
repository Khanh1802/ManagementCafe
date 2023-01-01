using AutoMapper;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.WareHouseDtos;

namespace ManagerCafe.Profiles
{
    public class WareHouseProfile : Profile
    {
        public WareHouseProfile()
        {
            CreateMap<WareHouse, WareHouseDto>();
            CreateMap<CreateWareHouseDto, WareHouse>();
            CreateMap<UpdateWareHouseDto, WareHouse>();
            CreateMap<FilterWareHouseDto,WareHouse>();
        }
    }
}
