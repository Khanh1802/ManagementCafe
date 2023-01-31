using ManagerCafe.Dtos.UserTypeDtos;
using ManagerCafe.Services;

namespace WinFormsAppManagerCafe.UserTypes
{
    public partial class FormAddUserType : Form
    {
        private readonly IUserTypeService _userTypeService;
        public FormAddUserType(IUserTypeService userTypeService)
        {
            InitializeComponent();
            _userTypeService = userTypeService;
        }

        private async void BtAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TbName.Text))
            {
                var create = new CreateUserTypeDto()
                {
                    Name = TbName.Text
                };
                try
                {
                    await _userTypeService.AddAsync(create);
                    MessageBox.Show("Create user type successfully", "Ok", MessageBoxButtons.OK);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
