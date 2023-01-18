using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.UsersDto;

namespace ManagerCafe.Services
{
    public interface IUserService : IGenericService<UserDto, CreateUserDto, UpdateUserDto, FilterUserDto>
    {
        Task<Guid> CheckUserNameExist(string item);
        Task<User> CheckPassword(UserDto item);
        Task<User> LoginAccount(UserDto item);
    }
}
