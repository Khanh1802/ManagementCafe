using ManagerCafe.CacheItems.Users;
using Microsoft.Extensions.Caching.Memory;

namespace ManagerCafe.Services
{
    public class UserCacheService : IUserCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private const string LoginKey = "LoginKey";

        public UserCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public UserCacheItem GetOrDefault()
        {
            return _memoryCache.Get<UserCacheItem>(LoginKey);
        }

        public void Set(UserCacheItem userCacheItem)
        {
            _memoryCache.Set(LoginKey, userCacheItem);
        }
    }
}
