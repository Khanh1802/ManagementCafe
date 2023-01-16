using ManagerCafe.Commons;
using ManagerCafe.Data.Enums;
using ManagerCafe.Data.Models;
using ManagerCafe.Datas.Enums;
using ManagerCafe.Dtos.InventoryTransactionDtos;
using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Dtos.WareHouseDtos;
using ManagerCafe.Enums;
using ManagerCafe.Services;

namespace WinFormsAppManagerCafe.Inventories
{
    public partial class FormStatistic : Form
    {
        private readonly IInventoryTransactionService _inventoryTransactionService;
        private readonly IWareHouseService _wareHouseService;
        private readonly IProductService _productService;

        internal bool _isLoadingDone = false;
        private int _currentPage = 1;
        private int _skipCount = 0;
        private int _takeCount = 0;
        public FormStatistic(IInventoryTransactionService inventoryTransactionService, IWareHouseService wareHouseService, IProductService productService)
        {
            InitializeComponent();
            _inventoryTransactionService = inventoryTransactionService;
            _wareHouseService = wareHouseService;
            _productService = productService;
        }

        private async Task LoadComboboxData()
        {
            CbbWarehouse.DataSource = await _wareHouseService.GetAllAsync();
            CbbWarehouse.DisplayMember = "Name";
            CbbProduct.DataSource = await _productService.GetAllAsync();
            CbbProduct.DisplayMember = "Name";
            CbbFilter.DataSource = EnumHelpers.GetEnumList<EnumInventoryTransactionFilter>();
            CbbFilter.DisplayMember = "Name";
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
            await LoadComboboxData();
            await RefershDataGirdView();
        }

        private async Task RefershDataGirdView()
        {
            int choice = -1;
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
            if (CbbFilter.SelectedItem is CommonEnumDto<EnumInventoryTransactionFilter> filterInventoryTransaction)
            {
                choice = Convert.ToInt32(filterInventoryTransaction.Id);
            }
            filter.CurrentPage = _currentPage;
            filter.SkipCount = _skipCount;
            filter.TakeMaxResultCount = _takeCount;
            var inventoryTransactions = await _inventoryTransactionService.GetPagedStatisticListAsync(filter, choice);
            Dtg.DataSource = inventoryTransactions.Data;
            var isToNextPage = inventoryTransactions.HasNextPage == true ? BtNextPage.Enabled = true : BtNextPage.Enabled = false;
            var isToReversePage = inventoryTransactions.HasReversePage == true ? BtReversePage.Enabled = true : BtReversePage.Enabled = false;
            TbCurrentPage.Text = $"{_currentPage} / {inventoryTransactions.TotalPage}";
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
            if (_isLoadingDone)
            {
                _isLoadingDone = false;
                _currentPage = 1;
                _skipCount = 0;
                var filter = new FilterInventoryTransactionDto();
                if (CbbWarehouse.SelectedItem is WareHouseDto warehouse)
                {
                    filter.WarehouseId = warehouse.Id;
                }
                if (CbbProduct.SelectedItem is ProductDto product)
                {
                    filter.ProductId = product.Id;
                }
                if (CbbType.SelectedItem is CommonEnumDto<EnumInventoryTransation> type)
                {
                    filter.Type = type.Id;
                }
                filter.FromDate = DTPFormDate.Value;
                filter.ToDate = DTPToDate.Value;
                var resultFilter = await _inventoryTransactionService.FilterStatisticFindAsync(filter);
                Dtg.DataSource = resultFilter;
                BtNextPage.Enabled = false;
                BtReversePage.Enabled = false;
                TbCurrentPage.Text = $"{1} / {1}";
                _isLoadingDone = true;
            }
        }


        private async void BtReversePage_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone && CbbPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
            {
                _currentPage--;
                _skipCount -= Convert.ToInt32(indexPage.Name);
                _takeCount = Convert.ToInt32(indexPage.Name);
                if (!CbAll.Checked)
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
                _takeCount = Convert.ToInt32(indexPage.Name);
                if (!CbAll.Checked)
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
                if (!CbAll.Checked)
                {
                    await RefershDataGirdView();
                }
                else
                {
                    await RefreshCheckBoxWarehouse();
                }
            }
        }

        private async Task RefreshCheckBoxWarehouse()
        {
            int choice = -1;
            var filter = new FilterInventoryTransactionDto();
            if (CbbType.SelectedItem is CommonEnumDto<EnumInventoryTransation> transation)
            {
                filter.Type = transation.Id;
            }
            filter.CurrentPage = _currentPage;
            filter.SkipCount = _skipCount;
            filter.TakeMaxResultCount = _takeCount;
            var inventoryTransactions = await _inventoryTransactionService.GetPagedStatisticListAsync(filter, choice);
            Dtg.DataSource = inventoryTransactions.Data;
            var isToNextPage = inventoryTransactions.HasNextPage == true ? BtNextPage.Enabled = true : BtNextPage.Enabled = false;
            var isToReversePage = inventoryTransactions.HasReversePage == true ? BtReversePage.Enabled = true : BtReversePage.Enabled = false;
            TbCurrentPage.Text = $"{_currentPage} / {inventoryTransactions.TotalPage}";
        }

        private async void CbbFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                _currentPage = 1;
                _skipCount = 0;
                await RefershDataGirdView();
            }
        }

        private async void CbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone && CbAll.Checked)
            {
                await RefreshCheckBoxWarehouse();
            }
        }
    }
}
