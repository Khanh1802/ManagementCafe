using AutoMapper;
using ManagerCafe.Commons;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.UsersDto;
using ManagerCafe.Dtos.UsersDtos.ValidateUserDto;
using ManagerCafe.Dtos.UserTypeDtos;
using ManagerCafe.Services;
using Microsoft.VisualBasic.ApplicationServices;
using System.Security.Principal;

namespace WinFormsAppManagerCafe.Logins.Changes
{
    public partial class FormInfomation : Form
    {
        private readonly IMemoryCacheUserService _memoryCacheUserService;
        private readonly IUserTypeService _userTypeService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IUserValidate _userValidate;

        private bool _isLoadingDone = false;
        private Guid _idUser;
        public FormInfomation(IMemoryCacheUserService memoryCacheUserService, IMapper mapper, IUserTypeService userTypeService, IUserService userService, IUserValidate userValidate)
        {
            InitializeComponent();
            _memoryCacheUserService = memoryCacheUserService;
            _mapper = mapper;
            _userTypeService = userTypeService;
            _userService = userService;
            _userValidate = userValidate;
        }

        private async Task Combobox()
        {
            CbbUserType.DataSource = await _userTypeService.GetAllAsync();
            CbbUserType.DisplayMember = "Name";
        }

        private async void FormInfomation_Load(object sender, EventArgs e)
        {
            await Combobox();
            var user = _memoryCacheUserService.UserDtoMemory();
            TbEmail.Text = user.Email;
            TbFullName.Text = user.FullName;
            TbPhoneNumber.Text = user.PhoneNumber;
            if (CbbUserType.SelectedItem is UserTypeDto userType)
            {
                user.UserTypeId = user.Id;
            }
            _idUser = user.Id;
            _isLoadingDone = true;
        }

        private void BtReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void BtChange_Click(object sender, EventArgs e)
        {
            var user = _memoryCacheUserService.UserDtoMemory();
            if (CbbUserType.SelectedItem is UserTypeDto userType && _isLoadingDone)
            {
                var update = new UpdateUserDto()
                {
                    Id = _idUser,
                    Email = TbEmail.Text.Trim(),
                    FullName = TbFullName.Text.Trim(),
                    PhoneNumber = TbPhoneNumber.Text.Trim(),
                    UserTypeId = userType.Id,
                    UserName = user.UserName,
                    Password = user.Password
                };
                try
                {
                    await _userService.UpdateAsync(update);
                    MessageBox.Show("Update success", "Ok", MessageBoxButtons.OK);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
