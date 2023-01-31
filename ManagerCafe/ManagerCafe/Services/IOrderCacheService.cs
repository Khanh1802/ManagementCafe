using ManagerCafe.CacheItems.OrderDetails;

namespace ManagerCafe.Services
{
    public interface IOrderCacheService
    {
        void SetOrder(OrderDetailCacheItem orderDetailCacheItem);
        OrderDetailCacheItem GetOrder();

    }
}
