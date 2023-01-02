using ManagerCafe.Commons;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryDtos;
using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Dtos.WareHouseDtos;
using ManagerCafe.Enums;
using ManagerCafe.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;

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
            CbbFilter.DataSource = EnumHelpers.GetEnumList<EnumInventoryFilter>();
            CbbFilter.DisplayMember = "Name";
        }

        private async void BtAdd_Click(object sender, EventArgs e)
        {
            if(_isLoadingDone)
            {
                _isLoadingDone = false;
                var pageAddInventory = Program.ServiceProvider.GetService<FormAddInventory>();
                pageAddInventory.ShowDialog();
                if (pageAddInventory.IsDeleted)
                {
                    await RefreshDataGirdView();
                }
                _isLoadingDone = true;
            }           
        }

        private void Dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                BtAdd.Enabled = true;
                BtRemove.Enabled = false;
                BtUpdate.Enabled = false;
                TbQuatity.Text = string.Empty;
                _InventoryId = null;
                TbQuatity.Enabled = false;
            }
            else
            {
                BtAdd.Enabled = false;
                BtRemove.Enabled = true;
                BtUpdate.Enabled = true;
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
            await RefreshDataGirdView();
        }

        private async Task RefreshDataGirdView()
        {
            CbbProduct.DataSource = await _productService.GetAllAsync();
            CbbProduct.DisplayMember = "Name";
            CbbWareHouse.DataSource = await _wareHouseService.GetAllAsync();
            CbbWareHouse.DisplayMember = "Name";
            _isLoadingDone = true;
        }

        private async void BtUpdate_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                if (!string.IsNullOrEmpty(TbQuatity.Text))
                {
                    var updateWareHouse = new UpdateInventoryDto()
                    {
                        Id = (Guid)_InventoryId,

                    };
                    try
                    {
                        _isLoadingDone = false;
                        await _inventoryService.UpdateAsync(updateWareHouse);
                        MessageBox.Show("Update success", "Done", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        await RefreshDataGirdView();
                    }
                }
                else
                {
                    MessageBox.Show("Name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void CbbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone && CbbProduct.SelectedIndex >= 0)
            {
                _isLoadingDone = false;
                // await RefreshDataGirdView();
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


            BtAdd.Enabled = true;
            BtRemove.Enabled = false;
            BtUpdate.Enabled = false;
            TbQuatity.Text = string.Empty;
            TbQuatity.Enabled = false;
            _InventoryId = null;
            _isLoadingDone = true;
        }
    }
}
