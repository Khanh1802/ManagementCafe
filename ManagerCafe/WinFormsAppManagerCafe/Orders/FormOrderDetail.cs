using ManagerCafe.Dtos.OrderDetailDtos;
using ManagerCafe.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace WinFormsAppManagerCafe.Orders
{
    public partial class FormOrderDetail : Form
    {
        private readonly IOrderDetailService _oderDetailService;
        private readonly IOrderDetailCacheService _orderDetailCacheService;
        private readonly IInventoryService _inventoryService;
        internal Guid ProductId { get; set; }
        public FormOrderDetail(IInventoryService inventoryService, IOrderDetailService oderDetailService, IOrderDetailCacheService orderDetailCacheService)
        {
            InitializeComponent();
            _inventoryService = inventoryService;
            _oderDetailService = oderDetailService;
            _orderDetailCacheService = orderDetailCacheService;
        }

        private async void FormOrderDetail_Load(object sender, EventArgs e)
        {
            await RefreshPage();
        }

        private async Task RefreshPage()
        {
            var inventoryOrderDetail = await _inventoryService.GetInventoryOrderDetail(ProductId);
            TbProductName.Text = $"{inventoryOrderDetail.ProductName}";
            TbPrice.Text = Convert.ToString(inventoryOrderDetail.Price);
            TbTotalQuatity.Text = $"{Convert.ToString(inventoryOrderDetail.TotalQuatity)} total quantity available ";
            NUDQuatity.Maximum = Convert.ToDecimal(inventoryOrderDetail.TotalQuatity);
        }

        private async void BtAddToCart_Click(object sender, EventArgs e)
        {
            var orderDetails = _orderDetailCacheService.GetOrderDetails();
            if (orderDetails == null)
            {
                _orderDetailCacheService.SetOrderDetails();
            }
            var OrderDetailDto = new OrderDetailDto()
            {
                ProductId = ProductId,
                Quaity = Convert.ToInt32(NUDQuatity.Value),
                ProductName = TbProductName.Text,
                Price = Convert.ToDecimal(TbPrice.Text)
            };
            try
            {
                await _oderDetailService.AddAsync(OrderDetailDto);
                MessageBox.Show("Add cart success", "Done", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NUDQuatity_ValueChanged(object sender, EventArgs e)
        {

            //if (NUDQuatity.Value >= Convert.ToInt32(TbTotalQuatity.Text))
            //{
            //}
        }
    }
}
