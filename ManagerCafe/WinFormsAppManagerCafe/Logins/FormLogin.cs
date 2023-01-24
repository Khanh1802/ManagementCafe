using AutoMapper;
using ManagerCafe.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace WinFormsAppManagerCafe.Logins
{
    public partial class FormLogin : Form
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private bool _isLoadingDone = false;
        public FormLogin(IUserService userService, IMapper mapper, IMemoryCache memoryCache)
        {
            InitializeComponent();
            _userService = userService;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        private async void BtLogin_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                _isLoadingDone = false;
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
                try
                {

                    var isLogged = await _userService.LoginAsync(TbUserName.Text, TbPassword.Text);

                    if (!isLogged)
                    {
                        MessageBox.Show("Invalid login information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _isLoadingDone = true;
                        return;
                    }

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
            RefreshTableLogin();
            _isLoadingDone = true;
        }

        private void RefreshPassword()
        {
            TbPassword.UseSystemPasswordChar = true;
            CbPassword.Text = "View";
        }

        private void RefreshTableLogin()
        {
            TbPassword.Text = string.Empty;
        }
    }
}
