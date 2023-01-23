using ManagerCafe.Commons;
using ManagerCafe.Data.Models;
using ManagerCafe.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace ManagerCafe.Services
{
    public class MemoryCacheUserService : IMemoryCacheUserService
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheUserService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public User UserDtoMemory()
        {
            if (_memoryCache.TryGetValue<User>(AccountCacheKey.User_Key, out User user))
            {
                return user;
            }
            return null;
        }
    }
}
