using ManagerCafe.CacheItems.OrderDetails;

namespace ManagerCafe.Services
{
    public interface IOrderDetailCacheService
    {
        void SetOrderDetails();
        List<OrderDetailCacheItem> GetOrderDetails();
    }
}
