using ManagerCafe.Data.Models;
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
        }

        private async void FormInventoryTransaction_Load(object sender, EventArgs e)
        {
            await RefershDataGirdView();
        }

        private async Task RefershDataGirdView()
        {
            Dtg.DataSource = await _inventoryTransactionService.GetAll();

            if (Dtg?.Columns != null && Dtg.Columns.Contains("Id"))
            {
                Dtg.Columns["Id"]!.Visible = false;
            }
            if (Dtg?.Columns != null && Dtg.Columns.Contains("Inventory"))
            {
                Dtg.Columns["Inventory"]!.Visible = false;
            }
            if (Dtg?.Columns != null && Dtg.Columns.Contains("InventoryId"))
            {
                Dtg.Columns["InventoryId"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
