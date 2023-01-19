using ManagerCafe.Validations;

namespace ManagerCafe.Dtos.UsersDtos
{
    public class CreateUserDto :  IHasPhoneNumber, IValidateObject
    {
        public Guid Id { get; set; }
        public Guid UserTypeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                throw new Exception("Phone number is required");
            }
        }
    }
}
