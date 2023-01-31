using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.UsersDto;

namespace ManagerCafe.Services
{
    public interface IUserService : IGenericService<UserDto, CreateUserDto, UpdateUserDto, FilterUserDto,Guid>
    {
        Task<bool> CheckUserNameExistAysnc(string item);

        Task<bool> LoginAsync(string userName, string password);

        Task<bool> UpdatePassword(string passwordOld,string passwordNew,string passworldNewRepeat);
        Task<bool> UpdateInfomation(UpdateUserDto item);
    }
}
