using ManagerCafe.Dtos.Orders;

namespace ManagerCafe.Services
{
    public interface IOrderService : IGenericService<OrderDto, CreateOrderDto, UpdateOrderDto, FilterOrderDto, Guid>
    {
        void SetCacheOrder();

    }
}
