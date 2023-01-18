using ManagerCafe.Data.Models;

namespace ManagerCafe.Dtos.UsersDto
{
    public class CreateUserDto
    {
        public Guid Id { get; set; }
        public Guid UserTypeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
