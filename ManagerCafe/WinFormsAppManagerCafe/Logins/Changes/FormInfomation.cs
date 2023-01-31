using AutoMapper;
using ManagerCafe.Dtos.UsersDto;
using ManagerCafe.Dtos.UsersDtos.ValidateUserDto;
using ManagerCafe.Dtos.UserTypeDtos;
using ManagerCafe.Repositories;
using ManagerCafe.Services;
using Microsoft.EntityFrameworkCore;

namespace WinFormsAppManagerCafe.Logins.Changes
{
    public partial class FormInfomation : Form
    {
        private readonly IUserCacheService _userCacheService;
        private readonly IUserTypeService _userTypeService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IUserValidate _userValidate;
        private readonly IUserRepository _userRepository;

        private bool _isLoadingDone = false;
        private Guid _idUser;
        public FormInfomation(IMapper mapper, IUserTypeService userTypeService, IUserService userService, IUserValidate userValidate, IUserCacheService userCacheService, IUserRepository userRepository)
        {
            InitializeComponent();
            _mapper = mapper;
            _userTypeService = userTypeService;
            _userService = userService;
            _userValidate = userValidate;
            _userCacheService = userCacheService;
            _userRepository = userRepository;
        }

        private async Task Combobox()
        {
            CbbUserType.DataSource = await _userTypeService.GetAllAsync();
            CbbUserType.DisplayMember = "Name";
        }

        private async void FormInfomation_Load(object sender, EventArgs e)
        {
            await Combobox();
            var user = _userCacheService.GetOrDefault();
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
            if (CbbUserType.SelectedItem is UserTypeDto userType && _isLoadingDone)
            {
                var update = new UpdateUserDto()
                {
                    Id = _idUser,
                    Email = TbEmail.Text.Trim(),
                    FullName = TbFullName.Text.Trim(),
                    PhoneNumber = TbPhoneNumber.Text.Trim(),
                    UserTypeId = userType.Id,
                };
                try
                {
                    var updateInfomation = await _userService.UpdateInfomation(update);
                    if (updateInfomation)
                    {
                        MessageBox.Show("Delete success", "Ok", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
