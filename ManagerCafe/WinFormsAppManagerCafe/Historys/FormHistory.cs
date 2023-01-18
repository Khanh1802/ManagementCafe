using ManagerCafe.Commons;
using ManagerCafe.Data.Enums;
using ManagerCafe.Datas.Enums;
using ManagerCafe.Dtos.InventoryTransactionDtos;
using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Dtos.WareHouseDtos;
using ManagerCafe.Enums;
using ManagerCafe.Services;

namespace WinFormsAppManagerCafe.History
{
    public partial class FormHistory : Form
    {
        private readonly IInventoryTransactionService _inventoryTransactionService;
        private readonly IProductService _productService;
        private readonly IWareHouseService _wareHouseService;

        private bool _isLoadingDone = false;
        private int _currentPage = 1;
        private int _skipCount = 0;
        private int _takeMaxRecordCount = 0;
        public FormHistory(IProductService productService, IWareHouseService wareHouseService, IInventoryTransactionService inventoryTransactionService)
        {
            InitializeComponent();
            _productService = productService;
            _wareHouseService = wareHouseService;
            RefreshComBoBox();
            _inventoryTransactionService = inventoryTransactionService;
        }

        private void RefreshComBoBox()
        {
            _isLoadingDone = false;
            CbbPage.DataSource = EnumHelpers.GetEnumList<EnumIndexPage>();
            CbbPage.DisplayMember = "Name";
            CbbType.DataSource = EnumHelpers.GetEnumList<EnumInventoryTransation>();
            CbbType.DisplayMember = "Name";
            CbbFilter.DataSource = EnumHelpers.GetEnumList<EnumChoiceFilter>();
            CbbFilter.DisplayMember = "Name";
            _isLoadingDone = true;
        }

        private async void FormHistory_Load(object sender, EventArgs e)
        {
            await RefreshDataGirdView();
        }
        private async Task RefreshDataGirdView()
        {
            _isLoadingDone = false;
            int choice = -1;
            var filter = new FilterInventoryTransactionDto();
            CbbProduct.DataSource = await _productService.GetAllAsync();
            CbbProduct.DisplayMember = "Name";
            CbbWareHouse.DataSource = await _wareHouseService.GetAllAsync();
            CbbWareHouse.DisplayMember = "Name";
            if (CbbFilter.SelectedItem is CommonEnumDto<EnumChoiceFilter> choiceFilter)
            {
                choice = Convert.ToInt32(choiceFilter.Id);
            }
            if (CbbProduct.SelectedItem is ProductDto product)
            {
                filter.ProductId = product.Id;
            }
            if (CbbWareHouse.SelectedItem is WareHouseDto warehouse)
            {
                filter.WarehouseId = warehouse.Id;
            }
            if (CbbPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
            {
                _takeMaxRecordCount = Convert.ToInt32(indexPage.Name);
            }
            if (CbbType.SelectedItem is CommonEnumDto<EnumInventoryTransation> type)
            {
                filter.Type = type.Id;
            }

            filter.CurrentPage = _currentPage;
            filter.SkipCount = _skipCount;
            filter.TakeMaxResultCount = _takeMaxRecordCount;
            filter.FromDate = DTPFormDate.Value;
            filter.ToDate = DTPToDate.Value;
            var pagination = await _inventoryTransactionService.GetPagedHistoryListAsync(filter, choice);
            Dtg.DataSource = pagination.Data;
            var allowNextPage = pagination.HasNextPage == true ? BtNextPage.Enabled = true : BtNextPage.Enabled = false;
            var allowReversPage = pagination.HasReversePage == true ? BtReversePage.Enabled = true : BtReversePage.Enabled = false;
            TbCurrentPage.Text = $"{_currentPage}/{pagination.TotalPage}";
            if (Dtg?.Columns != null && Dtg.Columns.Contains("InventoryId"))
            {
                Dtg.Columns["InventoryId"].Visible = false;
            }
            _isLoadingDone = true;
        }

        private async void CbbPage_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                _currentPage = 1;
                _skipCount = 0;
                await RefreshDataGirdView();
            }
        }

        private async void BtReversePage_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone && CbbPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
            {
                _currentPage--;
                _skipCount -= Convert.ToInt32(indexPage.Name);
                await RefreshDataGirdView();
            }
        }

        private async void BtNextPage_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone && CbbPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
            {
                _currentPage++;
                _skipCount += Convert.ToInt32(indexPage.Name);
                await RefreshDataGirdView();
            }
        }

        private async void CbbFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                _currentPage = 1;
                _skipCount = 0;
                await RefreshDataGirdView();
            }
        }

        private async void BtFind_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                _isLoadingDone = false;
                CbAllResult.Checked = false;
                TbCurrentPage.Text = "1/1";
                BtNextPage.Enabled = false;
                BtReversePage.Enabled = false;
                var filter = new FilterInventoryTransactionDto();

                if (CbbProduct.SelectedItem is ProductDto product)
                {
                    filter.ProductId = product.Id;
                }
                if (CbbWareHouse.SelectedItem is WareHouseDto warehouse)
                {
                    filter.WarehouseId = warehouse.Id;
                }
                if (CbbPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
                {
                    _takeMaxRecordCount = Convert.ToInt32(indexPage.Name);
                }
                if (CbbType.SelectedItem is CommonEnumDto<EnumInventoryTransation> type)
                {
                    filter.Type = type.Id;
                }
                filter.FromDate = DTPFormDate.Value;
                filter.ToDate = DTPToDate.Value;
                var data = await _inventoryTransactionService.FilterHistoryFindAsync(filter);
                Dtg.DataSource = data;
                _isLoadingDone = true;
            }
        }

        private async void CbAllResult_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone && CbAllResult.Checked)
            {
                _currentPage = 1;
                _skipCount = 0;
                await RefreshDataGirdView();
            }
        }

        private void FormHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isLoadingDone)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
