using ManagerCafe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCafe.Dtos.UsersDto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public Guid UserTypeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLoginTime { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}
