using ManagerCafe.Dtos.UsersDto;
using ManagerCafe.Dtos.UserTypeDtos;

namespace ManagerCafe.Services
{
    public interface IUserTypeService : IGenericService<UserTypeDto, CreateUserTypeDto, UpdateUserTypeDto, FilterUserTypeDto>
    {
    }
}
