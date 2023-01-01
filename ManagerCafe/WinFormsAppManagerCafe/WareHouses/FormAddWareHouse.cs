using ManagerCafe.Dtos.WareHouseDtos;
using ManagerCafe.Services;

namespace WinFormsAppManagerCafe.WareHouses
{
    public partial class FormAddWareHouse : Form
    {
        private readonly IWareHouseService _wareHouseService;
        public bool IsDeleted = false;
        public FormAddWareHouse(IWareHouseService wareHouseService)
        {
            InitializeComponent();
            _wareHouseService = wareHouseService;
        }

        private async void BtAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TbName.Text))
            {
                var createWareHouse = new CreateWareHouseDto()
                {
                    Name = TbName.Text,
                };
                await _wareHouseService.AddAsync(createWareHouse);
                MessageBox.Show("Create new WareHouse success", "Done", MessageBoxButtons.OK);
                IsDeleted = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
