using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.UsersDto;

namespace ManagerCafe.Services
{
    public interface IUserService : IGenericService<UserDto, CreateUserDto, UpdateUserDto, FilterUserDto>
    {
        Task<bool> CheckUserNameExistAysnc(string item);

        Task<bool> LoginAsync(string userName, string password);

        Task<bool> ChangePassword(string passwordOld,string passwordNew,string passworldNewRepeat);
    }
}
