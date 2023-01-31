using ManagerCafe.CacheItems.OrderDetails;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace ManagerCafe.Services
{
    public class OrderDetailCacheService : IOrderDetailCacheService
    {
        private const string CacheOrderDetail = "key_OrderDetail";
        private readonly IMemoryCache _memoryCache;

        public OrderDetailCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<OrderDetailCacheItem> GetOrderDetails()
        {
            return _memoryCache.Get<List<OrderDetailCacheItem>>(CacheOrderDetail);
        }

        public void SetOrderDetails()
        {
            _memoryCache.Set<List<OrderDetailCacheItem>>(CacheOrderDetail, new List<OrderDetailCacheItem>());
        }
    }
}
