using ManagerCafe.Data.Models;
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
        private bool _isLoadingDone = false;
        private Guid? _InventoryId;
        public FormInventory(IInventoryService inventoryService, IProductService productService, IWareHouseService wareHouseService)
        {
            InitializeComponent();
            _inventoryService = inventoryService;
            _productService = productService;
            _wareHouseService = wareHouseService;
            //ReloadInit();
        }

        private void ReloadInit()
        {
            //CbbFilter.DataSource = EnumHelpers.GetEnumList<EnumInventoryFilter>();
            //CbbFilter.DisplayMember = "Name";
            //CbbProduct.DataSource = EnumHelpers.GetEnumList<EnumProductFilter>();
            //CbbProduct.DisplayMember = "Name";
            //CbbWareHouse.DataSource = EnumHelpers.GetEnumList<EnumWareHouseFilter>();
            //CbbWareHouse.DisplayMember = "Name";
        }


        private async void BtAdd_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                var inventory = await _inventoryService.GetByIdAsync(_InventoryId);
                if (inventory != null)
                {
                    inventory.Quatity += Convert.ToInt32(TbQuatity.Text);
                    var itemInventory = new UpdateInventoryDto()
                    {
                        Id = inventory.Id,
                        Quatity = inventory.Quatity,
                        ProductId = inventory.ProductId,
                        WareHouseId = inventory.WareHouseId,
                    };
                    await _inventoryService.UpdateAsync(itemInventory);
                    MessageBox.Show("Update success", "Done", MessageBoxButtons.OK);
                    await OnFilterInventoryAsync();
                }
                else
                {
                    if (CbbWareHouse.SelectedIndex >= 0 && CbbWareHouse.SelectedIndex >= 0)
                    {
                        if (!string.IsNullOrEmpty(TbQuatity.Text))
                        {
                            if (CbbProduct.SelectedItem is ProductDto product && CbbWareHouse.SelectedItem is WareHouseDto warehouse)
                            {
                                //var itemInventory = new CreatenInvetoryDto()
                                //{
                                //    ProductId = product.Id,
                                //    WareHouseId = warehouse.Id,
                                //    Quatity = Convert.ToInt32(TbQuatity.Text)
                                //};
                                var filterInventory = new FilterInventoryDto()
                                {
                                    ProductId = product.Id,
                                    WareHouseId = warehouse.Id,
                                };
                                var inventories = await _inventoryService.FilterAsync(filterInventory);
                                if(inventories.Count > 0)
                                {
                                    await _inventoryService.UpdateAsync();
                                }
                                //await _inventoryService.AddAsync(itemInventory);
                                MessageBox.Show("Create success", "Done", MessageBoxButtons.OK);
                                await OnFilterInventoryAsync();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Quantity is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Product or Warehouse is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            var inventories = await _inventoryService.FilterAsync(filter);
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
            _isLoadingDone = true;
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
    }
}
