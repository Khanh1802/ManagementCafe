using ManagerCafe.Commons;
using ManagerCafe.Data.Models;
using ManagerCafe.Datas.Enums;
using ManagerCafe.Dtos.InventoryTransactionDtos;
using ManagerCafe.Dtos.WareHouseDtos;
using ManagerCafe.Enums;
using ManagerCafe.Services;

namespace WinFormsAppManagerCafe.Inventories
{
    public partial class FormInventoryTransaction : Form
    {
        private readonly IInventoryTransactionService _inventoryTransactionService;
        private readonly IWareHouseService _wareHouseService;

        internal bool _isLoadingDone = false;
        private const int filterWithNonDate = 1;
        private const int filterWithDate = 2;
        private const int FilterWithDateTimeAndName = 3;
        private const int filterWithDateAndNameWithAllWarehouse = 4;
        private const int filterWithDateAndWithNoNameAllWarehouse = 5;
        public FormInventoryTransaction(IInventoryTransactionService inventoryTransactionService, IWareHouseService wareHouseService)
        {
            InitializeComponent();
            _inventoryTransactionService = inventoryTransactionService;
            LoadComboboxData();
            _wareHouseService = wareHouseService;
        }

        private void LoadComboboxData()
        {
            CbbType.DataSource = EnumHelpers.GetEnumList<EnumInventoryTransation>();
            CbbType.DisplayMember = "Name";
        }

        private async void FormInventoryTransaction_Load(object sender, EventArgs e)
        {
            await RefershDataGirdView();
            await ComBoBoxWarehouse();
        }

        private async Task RefershDataGirdView()
        {
            var filterCbbType = new FilterInventoryTransactionDto();

            if (CbbType.SelectedItem is CommonEnumDto<EnumInventoryTransation> transation)
            {
                filterCbbType.Type = transation.Id;
            }
            var filters = await _inventoryTransactionService.FilterAsync(filterCbbType, filterWithNonDate);
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
            var filter = new FilterInventoryTransactionDto();
            if (DTPFormDate.Value is DateTime formDate && DTPToDate.Value is DateTime toDate)
            {
                filter.FormDate = formDate;
                filter.ToDate = toDate;
            }
            if (CbbType.SelectedItem is CommonEnumDto<EnumInventoryTransation> transation)
            {
                filter.Type = transation.Id;
            }
            if (CbbWarehouse.SelectedItem is WareHouseDto warehouse && !checkBoxWarehouse.Checked)
            {
                filter.WarehouseId = warehouse.Id;
                if (!string.IsNullOrEmpty(TbFind.Text))
                {
                    filter.ProductName = TbFind.Text;
                    var filters = await _inventoryTransactionService.FilterAsync(filter, FilterWithDateTimeAndName);
                    Dtg.DataSource = filters;
                }
                else
                {
                    var filters = await _inventoryTransactionService.FilterAsync(filter, filterWithDate);
                    Dtg.DataSource = filters;
                }
            }
            if (checkBoxWarehouse.Checked)
            {
                if (!string.IsNullOrEmpty(TbFind.Text))
                {
                    filter.ProductName = TbFind.Text;
                    var filters = await _inventoryTransactionService.FilterAsync(filter, filterWithDateAndNameWithAllWarehouse);
                    Dtg.DataSource = filters;
                }
                else
                {
                    var filters = await _inventoryTransactionService.FilterAsync(filter, filterWithDateAndWithNoNameAllWarehouse);
                    Dtg.DataSource = filters;
                }
            }
        }

        private async Task ComBoBoxWarehouse()
        {
            CbbWarehouse.DataSource = await _wareHouseService.GetAllAsync();
            CbbWarehouse.DisplayMember = "Name";
        }
    }
}
