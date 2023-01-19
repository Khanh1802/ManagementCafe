using AutoMapper;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.UsersDtos;

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
        }
    }
}
