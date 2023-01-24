using ManagerCafe.Commons;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.UsersDto;
using ManagerCafe.Services;

namespace WinFormsAppManagerCafe.Logins.Changes
{
    public partial class FormPassword : Form
    {
        private readonly IUserService _userService;
        private readonly IUserCacheService _userCacheService;

        public FormPassword(IUserService userService, IUserCacheService userCacheService)
        {
            InitializeComponent();
            _userService = userService;
            RefreshPasswordOldAndNew();
            _userCacheService = userCacheService;
        }

        private async void BtChange_Click(object sender, EventArgs e)
        {
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
            try
            {
                var changePassword =
                    await _userService.UpdatePassword(TbPasswordOld.Text, TbPassWordNew.Text, TbPassWordNewRepeat.Text);
                if (changePassword)
                {
                    MessageBox.Show("Update success", "Ok", MessageBoxButtons.OK);
                    this.Close();
                }
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
            if (CbPasswordNew.Checked)
            {
                TbPassWordNew.UseSystemPasswordChar = false;
                TbPassWordNewRepeat.UseSystemPasswordChar = false;
                CbPasswordNew.Text = "Hide";
            }
            else
            {
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
