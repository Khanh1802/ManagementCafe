using ManagerCafe.Commons;
using ManagerCafe.Dtos.UsersDto;
using ManagerCafe.Dtos.UserTypeDtos;
using ManagerCafe.Services;

namespace WinFormsAppManagerCafe.Logins
{
    public partial class FormRegister : Form
    {
        private readonly IUserService _userService;
        private readonly IUserTypeService _userTypeService;

        private bool _isLoadingDone = false;
        public FormRegister(IUserService userService, IUserTypeService userTypeService)
        {
            InitializeComponent();
            _userService = userService;
            _userTypeService = userTypeService;
        }

        private async void BtRegister_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                _isLoadingDone = false;
                var createUser = new CreateUserDto();
                if (string.IsNullOrEmpty(TbFullName.Text))
                {
                    MessageBox.Show("Full name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _isLoadingDone = true;
                    return;
                }
                if (string.IsNullOrEmpty(TbEmail.Text))
                {
                    MessageBox.Show("Email is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _isLoadingDone = true;
                    return;
                }
                if (string.IsNullOrEmpty(TbPhoneNumber.Text) || TbPhoneNumber.Text.Length != 10)
                {
                    MessageBox.Show("Phone number is empty or not enough number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _isLoadingDone = true;
                    return;
                }
                if (string.IsNullOrEmpty(TbUserName.Text))
                {
                    MessageBox.Show("User name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _isLoadingDone = true;
                    return;
                }
                if (string.IsNullOrEmpty(TbPasswork.Text))
                {
                    MessageBox.Show("Passwork is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _isLoadingDone = true;
                    return;
                }
                if (CbbUserType.SelectedItem is not UserTypeDto userType)
                {
                    MessageBox.Show("User type is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _isLoadingDone = true;
                    return;
                }
                else
                {
                    createUser.UserTypeId = userType.Id;
                }
                createUser.FullName = TbFullName.Text.Trim();
                createUser.Email = TbEmail.Text.Trim();
                createUser.PhoneNumber = TbPhoneNumber.Text.Trim();
                createUser.UserName = TbUserName.Text.Trim();
                createUser.Password = TbPasswork.Text.Trim();
                try
                {
                    await _userService.AddAsync(createUser);
                    RefreshWhenComplete();
                    MessageBox.Show("Create USER successfully", "Ok", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _isLoadingDone = true;
            }
        }

        private void BtReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void BtCheckUserName_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                _isLoadingDone = false;
                if (string.IsNullOrEmpty(TbUserName.Text))
                {
                    MessageBox.Show("Full user name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _isLoadingDone = true;
                    return;
                }

                var checkUserName = await _userService.CheckUserNameExist(TbUserName.Text);
                if (checkUserName != default(Guid))
                {
                    MessageBox.Show("Already exist", "", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Allow", "", MessageBoxButtons.OK);
                }
                _isLoadingDone = true;
            }
        }

        private async void FormRegister_Load(object sender, EventArgs e)
        {
            await RefreshComBoBox();
            RefreshHidePass();
            _isLoadingDone = true;
        }

        private async Task RefreshComBoBox()
        {
            CbbUserType.DataSource = await _userTypeService.GetAllAsync();
            CbbUserType.DisplayMember = "Name";
        }

        private void RefreshHidePass()
        {
            TbPasswork.UseSystemPasswordChar = true;
            CbPassword.Text = "View";
        }

        private void RefreshWhenComplete()
        {
            RefreshHidePass();
            RefreshTableRegister();
        }

        private void RefreshTableRegister()
        {
            TbFullName.Text = string.Empty;
            TbEmail.Text = string.Empty;
            TbPasswork.Text = string.Empty;
            TbPhoneNumber.Text = string.Empty;
            TbUserName.Text = string.Empty;
        }

        private void CbPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (CbPassword.Checked)
            {
                TbPasswork.UseSystemPasswordChar = false;
                CbPassword.Text = "Hide";
            }
            else
            {
                TbPasswork.UseSystemPasswordChar = true;
                CbPassword.Text = "View";
            }
        }

        private void FormRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isLoadingDone)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
