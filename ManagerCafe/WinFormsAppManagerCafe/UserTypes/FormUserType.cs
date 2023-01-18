using ManagerCafe.Services;
using Microsoft.Extensions.DependencyInjection;

namespace WinFormsAppManagerCafe.UserTypes
{
    public partial class FormUserType : Form
    {
        private readonly IUserTypeService _userTypeService;

        private bool _isLoadingDone = false;
        public FormUserType(IUserTypeService userTypeService)
        {
            InitializeComponent();
            _userTypeService = userTypeService;
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            var pageAddUserType = Program.ServiceProvider.GetService<FormAddUserType>();
            pageAddUserType.ShowDialog();
        }

        private async void FormUserType_Load(object sender, EventArgs e)
        {
            await RefreshDataGirdView();
        }

        private async Task RefreshDataGirdView()
        {
            _isLoadingDone = false;
            Dtg.DataSource = await _userTypeService.GetAllAsync();
            _isLoadingDone = true;
        }
    }
}
