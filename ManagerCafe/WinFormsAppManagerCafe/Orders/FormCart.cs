using ManagerCafe.CacheItems.OrderDetails;
using ManagerCafe.Dtos.OrderDetailDtos;
using ManagerCafe.Services;

namespace WinFormsAppManagerCafe.Orders
{

    public partial class FormCart : Form
    {
        private readonly IOrderDetailService _oderDetailService;
        private readonly IOrderDetailCacheService _orderDetailCacheService;
        private readonly IInventoryService _inventoryService;
        internal OrderDetailDto OrderDetailDto;
        private OrderDetailCacheItem _orderDetailCacheItem;
        internal bool IsLoadingDone { get; set; }
        public FormCart(IOrderDetailCacheService orderDetailCacheService, IOrderDetailService oderDetailService, IInventoryService inventoryService)
        {
            InitializeComponent();
            _orderDetailCacheService = orderDetailCacheService;
            _oderDetailService = oderDetailService;
            _inventoryService = inventoryService;
        }

        private async void FormCart_Load(object sender, EventArgs e)
        {
            RefreshComBoBox();
            await RefreshPage();
        }
        private async void BtDelete_Click(object sender, EventArgs e)
        {
            if (CbbOrderDetail.SelectedIndex >= 0 && CbbOrderDetail.SelectedItem is OrderDetailCacheItem orderDetail)
            {
                var update = new OrderDetailDto()
                {
                    ProductId = orderDetail.ProductId
                };
                _oderDetailService.Delete(update);
                RefreshComBoBox();
                await RefreshPage();
            }
        }

        private void RefreshComBoBox()
        {
            IsLoadingDone = false;
            CbbOrderDetail.DataSource = _orderDetailCacheService.GetOrderDetails();
            CbbOrderDetail.DisplayMember = "ProductName";
            IsLoadingDone = true;

        }

        private async void CbbProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            if (IsLoadingDone)
            {
                await RefreshPage();
            }
        }
        private async Task RefreshPage()
        {
            if (CbbOrderDetail.SelectedItem is OrderDetailCacheItem orderDetail && IsLoadingDone)
            {
                IsLoadingDone = false;
                var inventoryOrderDetail = await _inventoryService.GetInventoryOrderDetail(orderDetail.ProductId);
                TbPrice.Text = Convert.ToString(orderDetail.Price);
                NUDQuatity.Maximum = inventoryOrderDetail.TotalQuatity;
                NUDQuatity.Value = Convert.ToDecimal(orderDetail.Quaity);
                TbTotalPrice.Text = Convert.ToString(orderDetail.Quaity * orderDetail.Price);
                _orderDetailCacheItem = orderDetail;
                IsLoadingDone = true;
            }
        }

        private async void NUDQuatity_ValueChanged(object sender, EventArgs e)
        {
            if (IsLoadingDone && _orderDetailCacheItem != null)
            {
                _orderDetailCacheItem.Quaity = Convert.ToInt32(NUDQuatity.Value);
                await RefreshPage();
            }
        }

        private async void BtPay_Click(object sender, EventArgs e)
        {
            await _inventoryService.LogicProcessing(_orderDetailCacheService.GetOrderDetails());
        }
    }
}
