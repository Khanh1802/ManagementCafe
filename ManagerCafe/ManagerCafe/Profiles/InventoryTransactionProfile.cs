using AutoMapper;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryTransactionDtos;

namespace ManagerCafe.Profiles
{
    public class InventoryTransactionProfile : Profile
    {
        public InventoryTransactionProfile()
        {
            CreateMap<InventoryTransaction, InventoryTransactionDto>();
            CreateMap<CreateInventoryTransactionDto, InventoryTransaction>();
        }
    }
}
