using ManagerCafe.Commons;
using ManagerCafe.Data.Models;
using ManagerCafe.Datas.Enums;
using ManagerCafe.Dtos.InventoryTransactionDtos;
using ManagerCafe.Enums;
using ManagerCafe.Services;

namespace WinFormsAppManagerCafe.Inventories
{
    public partial class FormInventoryTransaction : Form
    {
        private readonly IInventoryTransactionService _inventoryTransactionService;
        public FormInventoryTransaction(IInventoryTransactionService inventoryTransactionService)
        {
            InitializeComponent();
            _inventoryTransactionService = inventoryTransactionService;
            LoadComboboxData();
        }

        private void LoadComboboxData()
        {
            CbbType.DataSource = EnumHelpers.GetEnumList<EnumInventoryTransation>();
            CbbType.DisplayMember = "Name";
        }

        private async void FormInventoryTransaction_Load(object sender, EventArgs e)
        {
            await RefershDataGirdView();
        }

        private async Task RefershDataGirdView()
        {
            var filterCbbType = new FilterInventoryTransactionDto();
            if (CbbType.SelectedItem is CommonEnumDto<EnumInventoryTransation> transation)
            {
                filterCbbType.Type = transation.Id;
            }
            var filters = await _inventoryTransactionService.FilterAsync(filterCbbType);
            Dtg.DataSource = filters;

            if (Dtg?.Columns != null && Dtg.Columns.Contains("Id"))
            {
                Dtg.Columns["Id"]!.Visible = false;
            }
            if (Dtg?.Columns != null && Dtg.Columns.Contains("InventoryId"))
            {
                Dtg.Columns["InventoryId"]!.Visible = false;
            }
            if (Dtg?.Columns != null && Dtg.Columns.Contains("Inventory"))
            {
                Dtg.Columns["Inventory"]!.Visible = false;
            }
        }

        private async void BtFind_Click(object sender, EventArgs e)
        {
            await RefershDataGirdView();
        }
    }
}
