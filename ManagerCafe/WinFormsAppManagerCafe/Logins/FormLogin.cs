using ManagerCafe.Dtos.UsersDto;
using ManagerCafe.Services;
using Microsoft.Extensions.DependencyInjection;

namespace WinFormsAppManagerCafe.Logins
{
    public partial class FormLogin : Form
    {
        private IUserService _userService;

        private string _nameUser = string.Empty;
        private bool _isLoadingDone = false;
        public FormLogin(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private async void BtLogin_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                _isLoadingDone = false;
                var account = new UserDto();
                if (string.IsNullOrEmpty(TbUserName.Text))
                {
                    MessageBox.Show("User is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _isLoadingDone = true;
                    return;
                }
                if (string.IsNullOrEmpty(TbPassword.Text))
                {
                    MessageBox.Show("Password is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _isLoadingDone = true;
                    return;
                }
                account.UserName = TbUserName.Text;
                account.Password = TbPassword.Text;
                try
                {
                    var user = await _userService.LoginAccount(account);
                    var homePage = Program.ServiceProvider.GetService<HomePage>();
                    homePage.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _isLoadingDone = true;
            }
        }

        private void BtPageRegister_Click(object sender, EventArgs e)
        {
            var pageRegister = Program.ServiceProvider.GetService<FormRegister>();
            pageRegister.ShowDialog();
        }

        private void CbPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (CbPassword.Checked)
            {
                TbPassword.UseSystemPasswordChar = false;
                CbPassword.Text = "Hide";
            }
            else
            {
                TbPassword.UseSystemPasswordChar = true;
                CbPassword.Text = "View";
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            RefreshPassword();
            _isLoadingDone = true;
        }
        private void RefreshPassword()
        {
            TbPassword.UseSystemPasswordChar = true;
            CbPassword.Text = "View";
        }
        private void RefreshTableLogin()
        {
            TbUserName.Text = string.Empty;
            TbUserName.Text = string.Empty;
        }
    }
}
