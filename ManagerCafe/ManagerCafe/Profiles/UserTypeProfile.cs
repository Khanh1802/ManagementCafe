using AutoMapper;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.UserTypeDtos;

namespace ManagerCafe.Profiles
{
    public class UserTypeProfile : Profile
    {
        public UserTypeProfile()
        {
            CreateMap<UserType, UserTypeDto>();
            CreateMap<CreateUserTypeDto, UserType>();
            CreateMap<FilterUserTypeDto, UserType>();
            CreateMap<UpdateUserTypeDto, UserType>();
        }
    }
}
