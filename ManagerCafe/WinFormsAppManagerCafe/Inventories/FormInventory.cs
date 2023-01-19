using ManagerCafe.Commons;
using ManagerCafe.Data.Enums;
using ManagerCafe.Data.Models;
using ManagerCafe.Datas.Enums;
using ManagerCafe.Dtos.InventoryDtos;
using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Dtos.WareHouseDtos;
using ManagerCafe.Enums;
using ManagerCafe.Services;
using Microsoft.Extensions.DependencyInjection;

namespace WinFormsAppManagerCafe.Inventories
{
    public partial class FormInventory : Form
    {
        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;
        private readonly IWareHouseService _wareHouseService;
        internal bool _isLoadingDone = false;
        private int _takePage = 0;
        private int _skipPage = 0;
        private int _currentPage = 1;
        private Guid? _InventoryId;

        public FormInventory(IInventoryService inventoryService, IProductService productService, IWareHouseService wareHouseService)
        {
            InitializeComponent();
            _inventoryService = inventoryService;
            _productService = productService;
            _wareHouseService = wareHouseService;
            CbbPage.DataSource = EnumHelpers.GetEnumList<EnumIndexPage>();
            CbbPage.DisplayMember = "Name";
            if (CbbPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
            {
                _takePage = Convert.ToInt32(indexPage.Name);
            }
            CbbInventoryFilter.DataSource = EnumHelpers.GetEnumList<EnumChoiceFilter>();
            CbbInventoryFilter.DisplayMember = "Name";
        }


        private async void BtAdd_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                _isLoadingDone = false;
                if (!string.IsNullOrEmpty(TbQuatity.Text))
                {
                    if (CbbWareHouse.SelectedIndex >= 0 && CbbWareHouse.SelectedIndex >= 0
                        && CbbProduct.SelectedItem is ProductDto product && CbbWareHouse.SelectedItem is WareHouseDto warehouse)
                    {
                        var quatity = Convert.ToInt32(TbQuatity.Text);
                        if (_InventoryId != null)
                        {
                            var entity = await _inventoryService.GetByIdAsync(_InventoryId);
                            if (entity != null)
                            {
                                var updateInventory = new UpdateInventoryDto()
                                {
                                    Id = entity.Id,
                                    Quatity = entity.Quatity,
                                    ProductId = entity.ProductId,
                                    WareHouseId = entity.WareHouseId,
                                };
                                updateInventory.Quatity += quatity;
                                await _inventoryService.UpdateAsync(updateInventory);
                                MessageBox.Show("Update success", "Done", MessageBoxButtons.OK);
                                await OnFilterInventoryAsync();
                            }
                        }
                        else
                        {
                            try
                            {
                                var createInventory = new CreatenInvetoryDto()
                                {
                                    ProductId = product.Id,
                                    WareHouseId = warehouse.Id,
                                    Quatity = quatity
                                };
                                await _inventoryService.AddAsync(createInventory);
                                MessageBox.Show("Create success", "Done", MessageBoxButtons.OK);
                                await OnFilterInventoryAsync();
                            }
                            catch (Exception ex)
                            {
                                if (CbbProduct.SelectedItem is ProductDto productDto &&
                                    CbbWareHouse.SelectedItem is WareHouseDto wareHouseDto)
                                {
                                    var filter = new FilterInventoryDto()
                                    {
                                        ProductId = productDto.Id,
                                        WareHouseId = wareHouseDto.Id,
                                    };
                                    var inventory = await _inventoryService.FindByIdProductAndWarehouse(filter);
                                    TbQuatity.Text = string.Empty;
                                    Dtg.DataSource = inventory;
                                }
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Product or Warehouse is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Quantity is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _isLoadingDone = true;
        }

        private void Dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                BtRemove.Enabled = false;
                TbQuatity.ReadOnly = true;
                TbQuatity.Text = string.Empty;
                _InventoryId = null;
            }
            else
            {
                BtRemove.Enabled = true;
                if (Dtg.Rows[e.RowIndex].DataBoundItem is InventoryDto)
                {
                    var inventory = Dtg.Rows[e.RowIndex].DataBoundItem as InventoryDto;
                    _InventoryId = inventory.Id;
                    TbQuatity.Text = Convert.ToString(inventory.Quatity);
                    TbQuatity.ReadOnly = false;
                }
            }
        }

        private async void FormInventory_Load(object sender, EventArgs e)
        {
            await RefreshCbb();
            await OnFilterInventoryAsync();
        }

        private async Task RefreshCbb()
        {
            if (_isLoadingDone)
            {
                _isLoadingDone = false;
                CbbProduct.DataSource = await _productService.GetAllAsync();
                CbbProduct.DisplayMember = "Name";
                CbbWareHouse.DataSource = await _wareHouseService.GetAllAsync();
                CbbWareHouse.DisplayMember = "Name";
                _isLoadingDone = true;
            }
        }

        private async void CbbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone && CbbProduct.SelectedIndex >= 0)
            {
                await OnFilterInventoryAsync();
            }
        }

        private async Task OnFilterInventoryAsync()
        {
            _isLoadingDone = false;
            var filter = new FilterInventoryDto();
            var choice = -1;

            if (CbbInventoryFilter.SelectedItem is CommonEnumDto<EnumChoiceFilter> enumFilter)
            {
                choice = (int)enumFilter.Id;
            }

            filter.TakeMaxResultCount = _takePage;
            filter.SkipCount = _skipPage;
            filter.CurrentPage = _currentPage;
            var inventories = await _inventoryService.GetPagedListAsync(filter, choice);
            Dtg.DataSource = inventories.Data;

            if (Dtg?.Columns != null && Dtg.Columns.Contains("Id"))
            {
                Dtg.Columns["Id"]!.Visible = false;
            }
            if (Dtg?.Columns != null && Dtg.Columns.Contains("ProductId"))
            {
                Dtg.Columns["ProductId"]!.Visible = false;
            }
            if (Dtg?.Columns != null && Dtg.Columns.Contains("WareHouseId"))
            {
                Dtg.Columns["WareHouseId"]!.Visible = false;
            }
            if (Dtg?.Columns != null && Dtg.Columns.Contains("Product"))
            {
                Dtg.Columns["Product"]!.Visible = false;
            }
            if (Dtg?.Columns != null && Dtg.Columns.Contains("WareHouse"))
            {
                Dtg.Columns["WareHouse"]!.Visible = false;
            }
            if (Dtg?.Columns != null && Dtg.Columns.Contains("IsDeleted"))
            {
                Dtg.Columns["IsDeleted"]!.Visible = false;
            }
            if (Dtg?.Columns != null && Dtg.Columns.Contains("DeletetionTime"))
            {
                Dtg.Columns["DeletetionTime"]!.Visible = false;
            }

            BtRemove.Enabled = false;
            TbQuatity.Text = string.Empty;
            TbQuatity.ReadOnly = false;
            var isToNextPage = inventories.HasNextPage == true ? BtNextPage.Enabled = true : BtNextPage.Enabled = false;
            var isToReserPage = inventories.HasReversePage == true ? BtReversePage.Enabled = true : BtReversePage.Enabled = false;
            _InventoryId = null;
            TbCurrentPage.Text = $"{_currentPage}/{inventories.TotalPage}";
            _isLoadingDone = true;
        }

        private async void BtReversePage_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                if (CbbPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
                {
                    _currentPage--;
                    _skipPage -= Convert.ToInt32(indexPage.Name);
                    await OnFilterInventoryAsync();
                }
            }
        }

        private async void BtNextPage_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                if (CbbPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
                {
                    _currentPage++;
                    _skipPage += Convert.ToInt32(indexPage.Name);
                    await OnFilterInventoryAsync();
                }
            }
        }

        private async void CbbPage_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                if (CbbPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
                {
                    _takePage = Convert.ToInt32(indexPage.Name);
                    _currentPage = 1;
                    _skipPage = 0;
                    await OnFilterInventoryAsync();
                }
            }
        }

        private async void BtFind_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                _isLoadingDone = false;
                CbAllResult.Checked = false;
                var dataGirdView = new List<InventoryDto>();
                _isLoadingDone = false;
                var filter = new FilterInventoryDto();
                if (CbbProduct.SelectedItem is ProductDto productDto)
                {
                    filter.ProductId = productDto.Id;
                }
                if (CbbWareHouse.SelectedItem is WareHouseDto warehouseDto)
                {
                    filter.WareHouseId = warehouseDto.Id;
                }
                if (filter.ProductId != null && filter.WareHouseId != null)
                {
                    dataGirdView = await _inventoryService.FilterAsync(filter);
                    Dtg.DataSource = dataGirdView;
                }

                BtRemove.Enabled = false;
                BtNextPage.Enabled = true;
                BtReversePage.Enabled = true;
                TbQuatity.ReadOnly = false;
                TbQuatity.Text = string.Empty;
                _InventoryId = null;
                _isLoadingDone = true;
            }
        }

        private async void CbbInventoryFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone && CbbPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
            {
                _takePage = Convert.ToInt32(indexPage.Name);
                _currentPage = 1;
                _skipPage = 0;
                await OnFilterInventoryAsync();
            }
        }

        private async void BtRemove_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone && _InventoryId is not null)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    try
                    {
                        _isLoadingDone = false;
                        await _inventoryService.DeleteAsync(_InventoryId);
                        MessageBox.Show("Deleted inventory success", "Done", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        await OnFilterInventoryAsync();
                    }
                }
            }
        }

        private async void CbAllResult_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                await OnFilterInventoryAsync();
            }
        }

        private void FormInventory_FormClosing(object sender, FormClosingEventArgs e)
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
