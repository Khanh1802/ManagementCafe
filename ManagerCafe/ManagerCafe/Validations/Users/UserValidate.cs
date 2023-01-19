using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerCafe.Dtos.UsersDtos;
using ManagerCafe.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManagerCafe.Validations.Users
{
    public class UserValidate : IUserValidate
    {
        private readonly IUserRepository _userRepository;

        public UserValidate(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Kiểm tra sđt đã tồn tại hay chưa
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>
        /// true: đã tồn tại
        /// false: chưa tồn tại
        /// </returns>
        public async Task<bool> IsInValidPhoneNumberAsync(IHasPhoneNumber phoneNumber)
        {
            var userQueryable = await _userRepository.GetQueryableAsync();
            return await userQueryable.AnyAsync(x => x.PhoneNumber == phoneNumber.PhoneNumber);
        }
    }
}
