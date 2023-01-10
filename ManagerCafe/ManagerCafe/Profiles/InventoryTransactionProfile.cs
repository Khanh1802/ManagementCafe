﻿using AutoMapper;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryTransactionDtos;

namespace ManagerCafe.Profiles
{
    public class InventoryTransactionProfile : Profile
    {
        public InventoryTransactionProfile()
        {
            CreateMap<InventoryTransaction, InventoryTransactionDto>()
            .ForMember(x => x.ProductName, opts => opts.MapFrom(x => x.Inventory.Product.Name))
            .ForMember(x => x.WarehouseName, opts => opts.MapFrom(x => x.Inventory.WareHouse.Name));
            CreateMap<CreateInventoryTransactionDto, InventoryTransaction>();
            CreateMap<FilterInventoryTransactionDto, InventoryTransaction>();
           //.ForMember(des => des., src => src.MapFrom(x => x.Inventory.Product.Name)
        }
    }
}
