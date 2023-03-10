using ManagerCafe.Commons;
using ManagerCafe.Dtos.UserTypeDtos;

namespace ManagerCafe.Services
{
    public interface IUserTypeService : IGenericService<UserTypeDto, CreateUserTypeDto, UpdateUserTypeDto, FilterUserTypeDto, Guid>
    {
        Task<CommonPageDto<UserTypeDto>> GetPagedListAsync(FilterUserTypeDto item);
    }
}
