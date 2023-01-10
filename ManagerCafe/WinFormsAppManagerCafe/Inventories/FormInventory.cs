using ManagerCafe.Commons;
using ManagerCafe.Data.Enums;
using ManagerCafe.Data.Models;
using ManagerCafe.Datas.Enums;
using ManagerCafe.Dtos.InventoryDto.InventoryDtos;
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
        private bool _forwardPage = false;
        private bool _reversePage = false;
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
        }


        private async void BtAdd_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
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
        }

        private void Dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                BtRemove.Enabled = false;
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
                    TbQuatity.Enabled = true;
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
            CbbProduct.DataSource = await _productService.GetAllAsync();
            CbbProduct.DisplayMember = "Name";
            CbbWareHouse.DataSource = await _wareHouseService.GetAllAsync();
            CbbWareHouse.DisplayMember = "Name";
        }

        private async void CbbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone && CbbProduct.SelectedIndex >= 0)
            {
                _isLoadingDone = false;
                await OnFilterInventoryAsync();
                _isLoadingDone = true;
            }
        }

        private async Task OnFilterInventoryAsync()
        {
            var filter = new FilterInventoryDto();

            if (CbbProduct.SelectedItem is ProductDto productDto)
            {
                filter.ProductId = productDto.Id;
            }
            if (CbbWareHouse.SelectedItem is WareHouseDto warehouseDto)
            {
                filter.WareHouseId = warehouseDto.Id;
            }

            filter.TakeMaxResultCount = _takePage;
            filter.SkipCount = _skipPage;
            filter.CurrentPage = _currentPage;  
            var inventories = await _inventoryService.GetPagedListAsync(filter);
            Dtg.DataSource = inventories;

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
            _InventoryId = null;
        }

        private async void CbbWareHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone && CbbWareHouse.SelectedIndex >= 0)
            {
                _isLoadingDone = false;
                await OnFilterInventoryAsync();
                _isLoadingDone = true;
            }
        }

        private async void CbAllResult_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                if (CbAllResult.Checked)
                {
                    var filter = new FilterInventoryDto();
                    var inventories = new List<InventoryDto>();
                    inventories = await _inventoryService.FilterAsync(filter);
                    Dtg.DataSource = inventories;
                }
                else
                {
                    await OnFilterInventoryAsync();
                }
            }
        }

        private void BtReversePage_Click(object sender, EventArgs e)
        {

        }

        private void BtNextPage_Click(object sender, EventArgs e)
        {

        }
    }
}
