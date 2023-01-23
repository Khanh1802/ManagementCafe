using ManagerCafe.Commons;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.UsersDto;
using ManagerCafe.Services;

namespace WinFormsAppManagerCafe.Logins.Changes
{
    public partial class FormPassword : Form
    {
        private readonly IMemoryCacheUserService _memoryCacheUserService;
        private readonly IUserService _userService;


        public FormPassword(IMemoryCacheUserService memoryCacheUserService, IUserService userService)
        {
            InitializeComponent();
            _memoryCacheUserService = memoryCacheUserService;
            _userService = userService;
            RefreshPasswordOldAndNew();
        }

        private async void BtChange_Click(object sender, EventArgs e)
        {
            var user = _memoryCacheUserService.UserDtoMemory();
            if (TbPasswordOld.Text == null)
            {
                MessageBox.Show("Password is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TbPassWordNew.Text == null)
            {
                MessageBox.Show("Password new is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TbPassWordNewRepeat.Text == null)
            {
                MessageBox.Show("Password repeat is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var passOld = CommonCreateMD5.Create(TbPasswordOld.Text);
            var passNew = CommonCreateMD5.Create(TbPassWordNew.Text);

            if (user.Password != passOld)
            {
                MessageBox.Show("Password old not correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TbPassWordNew.Text != TbPassWordNewRepeat.Text)
            {
                MessageBox.Show("Password new not same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var update = new UpdateUserDto()
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                UserTypeId = user.UserTypeId,
                UserName = user.UserName,
                Password = passNew,
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

        private void CbPasswordOld_CheckedChanged(object sender, EventArgs e)
        {
            if (CbPasswordOld.Checked)
            {
                TbPasswordOld.UseSystemPasswordChar = false;
                CbPasswordOld.Text = "Hide";
            }
            else
            {
                TbPasswordOld.UseSystemPasswordChar = true;
                CbPasswordOld.Text = "View";
            }
        }

        private void CbPasswordNew_CheckedChanged(object sender, EventArgs e)
        {
            if (CbPasswordOld.Checked)
            {
                TbPassWordNew.UseSystemPasswordChar = false;
                CbPasswordOld.Text = "Hide";
                TbPassWordNew.UseSystemPasswordChar = false;
                TbPassWordNewRepeat.UseSystemPasswordChar = false;
                CbPasswordNew.Text = "Hide";
            }
            else
            {
                TbPassWordNew.UseSystemPasswordChar = true;
                CbPasswordOld.Text = "View";
                TbPassWordNew.UseSystemPasswordChar = true;
                TbPassWordNewRepeat.UseSystemPasswordChar = true;
                CbPasswordNew.Text = "View";
            }
        }
        private void RefreshPasswordOldAndNew()
        {
            TbPasswordOld.UseSystemPasswordChar = true;
            CbPasswordOld.Text = "View";
            TbPassWordNew.UseSystemPasswordChar = true;
            TbPassWordNewRepeat.UseSystemPasswordChar = true;
            CbPasswordNew.Text = "View";
        }
    }
}
