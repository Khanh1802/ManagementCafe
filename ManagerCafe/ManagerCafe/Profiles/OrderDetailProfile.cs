using AutoMapper;
using ManagerCafe.CacheItems.OrderDetails;
using ManagerCafe.Dtos.OrderDetailDtos;

namespace ManagerCafe.Profiles
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetailDto, OrderDetailCacheItem>();
        }
    }
}
