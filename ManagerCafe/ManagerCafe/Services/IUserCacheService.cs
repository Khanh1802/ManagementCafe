using ManagerCafe.CacheItems.Users;

namespace ManagerCafe.Services
{
    public interface IUserCacheService
    {
        UserCacheItem GetOrDefault();

        void Set(UserCacheItem userCacheItem);
    }
}
