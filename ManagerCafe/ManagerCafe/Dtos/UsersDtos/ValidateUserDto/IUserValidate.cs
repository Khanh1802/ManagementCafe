namespace ManagerCafe.Dtos.UsersDtos.ValidateUserDto
{
    public interface IUserValidate
    {
        Task<bool> IsValidatePhoneNumberAsync(IHasPhone hasPhone);
        Task<bool> IsValidateEmailAsync(IHasEmail hasEmail);
    }
}
