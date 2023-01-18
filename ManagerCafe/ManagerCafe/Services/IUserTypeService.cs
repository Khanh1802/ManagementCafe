using ManagerCafe.Commons;
using ManagerCafe.Dtos.UserTypeDtos;

namespace ManagerCafe.Services
{
    public interface IUserTypeService : IGenericService<UserTypeDto, CreateUserTypeDto, UpdateUserTypeDto, FilterUserTypeDto>
    {
        Task<CommonPageDto<UserTypeDto>> GetPagedListAsync(FilterUserTypeDto item);
    }
}
