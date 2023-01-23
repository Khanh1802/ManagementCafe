using AutoMapper;
using ManagerCafe.CacheItems.Users;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.UsersDto;

namespace ManagerCafe.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<FilterUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            CreateMap<User, UserCacheItem>();
        }
    }
}
