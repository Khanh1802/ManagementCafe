using ManagerCafe.Commons;
using ManagerCafe.Data.Enums;
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
        private int _currentPage = 1;
        private int _skipCount = 0;
        private int _takeCount = 0;
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
            CbbPage.DataSource = EnumHelpers.GetEnumList<EnumIndexPage>();
            CbbPage.DisplayMember = "Name";
            if (CbbPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
            {
                _takeCount = Convert.ToInt32(indexPage.Name);
            }
        }

        private async void FormInventoryTransaction_Load(object sender, EventArgs e)
        {
            await ComBoBoxWarehouse();
            await RefershDataGirdView();
        }

        private async Task RefershDataGirdView()
        {
            _isLoadingDone = false;
            var filter = new FilterInventoryTransactionDto();

            if (CbbType.SelectedItem is CommonEnumDto<EnumInventoryTransation> transation)
            {
                filter.Type = transation.Id;
            }
            if (CbbWarehouse.SelectedItem is WareHouseDto warehouse)
            {
                filter.WarehouseId = warehouse.Id;
            }
            filter.CurrentPage = _currentPage;
            filter.SkipCount = _skipCount;
            filter.TakeMaxResultCount = _takeCount;
            var inventoryTransactions = await _inventoryTransactionService.GetPagedListAsync(filter, filterWithNonDate);

            Dtg.DataSource = inventoryTransactions.Data;
            var isToNextPage = inventoryTransactions.HasNextPage == true ? BtNextPage.Enabled = true : BtNextPage.Enabled = false;
            var isToReversePage = inventoryTransactions.HasReversePage == true ? BtReversePage.Enabled = true : BtReversePage.Enabled = false;
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
            _isLoadingDone = true;
        }

        private async void BtFind_Click(object sender, EventArgs e)
        {
            var filter = new FilterInventoryTransactionDto();
            if (DTPFormDate.Value is DateTime formDate && DTPToDate.Value is DateTime toDate)
            {
                filter.FromDate = formDate;
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
                    var filters = await _inventoryTransactionService.GetPagedListAsync(filter, FilterWithDateTimeAndName);
                    Dtg.DataSource = filters;
                }
                else
                {
                    var filters = await _inventoryTransactionService.GetPagedListAsync(filter, filterWithDate);
                    Dtg.DataSource = filters;
                }
            }
            if (checkBoxWarehouse.Checked)
            {
                if (!string.IsNullOrEmpty(TbFind.Text))
                {
                    filter.ProductName = TbFind.Text;
                    var filters = await _inventoryTransactionService.GetPagedListAsync(filter, filterWithDateAndNameWithAllWarehouse);
                    Dtg.DataSource = filters;
                }
                else
                {
                    var filters = await _inventoryTransactionService.GetPagedListAsync(filter, filterWithDateAndWithNoNameAllWarehouse);
                    Dtg.DataSource = filters;
                }
            }
        }

        private async Task ComBoBoxWarehouse()
        {
            CbbWarehouse.DataSource = await _wareHouseService.GetAllAsync();
            CbbWarehouse.DisplayMember = "Name";
        }

        private async void BtReversePage_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone && CbbPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
            {
                _currentPage--;
                _skipCount -= Convert.ToInt32(indexPage.Name);
                _takeCount -= Convert.ToInt32(indexPage.Name);
                if (!checkBoxWarehouse.Checked)
                {
                    await RefershDataGirdView();
                }
                else
                {
                    await RefreshCheckBoxWarehouse();
                }
            }
        }

        private async void BtNextPage_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone && CbbPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
            {
                _currentPage++;
                _skipCount += Convert.ToInt32(indexPage.Name);
                _takeCount += Convert.ToInt32(indexPage.Name);
                if(!checkBoxWarehouse.Checked)
                {
                    await RefershDataGirdView();
                }
                else
                {
                    await RefreshCheckBoxWarehouse();
                }
            }
        }

        private async void CbbPage_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                if (CbbPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
                {
                    _takeCount = Convert.ToInt32(indexPage.Name);
                    _currentPage = 1;
                    _skipCount = 0;
                }
                if (!checkBoxWarehouse.Checked)
                {
                    await RefershDataGirdView();
                }
                else
                {
                    await RefreshCheckBoxWarehouse();
                }
            }
        }

        private async void CbbWarehouse_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                await RefershDataGirdView();
            }
        }

        private async void checkBoxWarehouse_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone && checkBoxWarehouse.Checked)
            {
                await RefreshCheckBoxWarehouse();
            }
        }
        private async Task RefreshCheckBoxWarehouse()
        {
            var filter = new FilterInventoryTransactionDto();
            if (CbbType.SelectedItem is CommonEnumDto<EnumInventoryTransation> transation)
            {
                filter.Type = transation.Id;
            }
            filter.CurrentPage = _currentPage;
            filter.SkipCount = _skipCount;
            filter.TakeMaxResultCount = _takeCount;
            var inventoryTransactions = await _inventoryTransactionService.GetPagedListAsync(filter, filterWithDateAndWithNoNameAllWarehouse);
            Dtg.DataSource = inventoryTransactions.Data;
            var isToNextPage = inventoryTransactions.HasNextPage == true ? BtNextPage.Enabled = true : BtNextPage.Enabled = false;
            var isToReversePage = inventoryTransactions.HasReversePage == true ? BtReversePage.Enabled = true : BtReversePage.Enabled = false;
            TbCurrentPage.Text = $"{_currentPage} / {inventoryTransactions.TotalPage}";
        }
    }
}
