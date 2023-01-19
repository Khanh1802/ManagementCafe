using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerCafe.Dtos.UsersDtos;

namespace ManagerCafe.Validations.Users
{
    public interface IUserValidate
    {
        Task<bool> IsInValidPhoneNumberAsync(IHasPhoneNumber phoneNumber);
    }
}
