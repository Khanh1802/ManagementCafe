using ManagerCafe.Dtos.InventoryDto.InventoryDtos;
using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Dtos.WareHouseDtos;
using ManagerCafe.Services;

namespace WinFormsAppManagerCafe.Inventories
{
    public partial class FormAddInventory : Form
    {
        private readonly IProductService _productService;
        private readonly IWareHouseService _warehouseService;
        private readonly IInventoryService _inventoryService;
        private bool _isLoadingDone = false;
        public bool IsDeleted { get; set; }
        public FormAddInventory(IWareHouseService warehouseService, IProductService productService, IInventoryService inventoryService)
        {
            InitializeComponent();
            _warehouseService = warehouseService;
            _productService = productService;
            _inventoryService = inventoryService;
        }

        private async void BtAdd_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                var create = new CreatenInvetoryDto();
                create.Quatity = Convert.ToInt32(NUDQuatity.Value);
                if (NUDQuatity.Value > 0)
                {
                    if (CbbProduct.SelectedIndex >= 0 && CbbProduct.SelectedItem is ProductDto productDto)
                    {
                        create.ProductId = productDto.Id;
                    }
                    else
                    {
                        MessageBox.Show("Product is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (CbbWarehouse.SelectedIndex >= 0 && CbbWarehouse.SelectedItem is WareHouseDto warehouseDto)
                    {
                        create.WareHouseId = warehouseDto.Id;
                    }
                    else
                    {
                        MessageBox.Show("Warehouse is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (create.ProductId != null && create.WareHouseId != null)
                    {
                        await _inventoryService.AddAsync(create);

                    }
                }
                else
                {
                    MessageBox.Show("Quatity is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void FormAddInventory_Load(object sender, EventArgs e)
        {
            await RefreshCbbAsync();
            _isLoadingDone = true;
        }

        private async Task RefreshCbbAsync()
        {
            _isLoadingDone = false;
            CbbProduct.DataSource = await _productService.GetAllAsync();
            CbbProduct.DisplayMember = "Name";
            CbbWarehouse.DataSource = await _warehouseService.GetAllAsync();
            CbbWarehouse.DisplayMember = "Name";
            _isLoadingDone = true;
        }
    }
}
