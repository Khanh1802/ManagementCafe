using ManagerCafe.Dtos.Orders;
using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Services;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using ManagerCafe.Commons;
using ManagerCafe.Data.Enums;
using ManagerCafe.Enums;
using ManagerCafe.Datas.Enums;

namespace WinFormsAppManagerCafe.Orders
{
    public partial class FormOrder : Form
    {
        private readonly IProductService _productService;

        private int _currentPage = 1;
        private int _skipCountPage = 0;
        private int _takeCount = 0;

        internal bool IsLoadingForm { get; set; } = false;
        public FormOrder(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
            CbbIndexPage.DataSource = EnumHelpers.GetEnumList<EnumSearchProduct>();
            CbbIndexPage.DisplayMember = "Name";
        }

        private void RefreshComBoBox()
        {
            if (CbbIndexPage.SelectedItem is CommonEnumDto<EnumSearchProduct> indexPage)
            {
                _takeCount = Convert.ToInt32(indexPage.Name);
            }
        }

        private async void FormOrder_Load(object sender, EventArgs e)
        {
            RefreshComBoBox();
            await RefreshDataGirdView();
        }

        private async Task RefreshDataGirdView()
        {
            IsLoadingForm = false;

            var filter = new FilterProductDto();
            filter.CurrentPage = _currentPage;
            filter.SkipCount = _skipCountPage;
            filter.TakeMaxResultCount = _takeCount;
            filter.Name = TbFind.Text;
            var data = await _productService.SearchProductAsync(filter);
            var allowNextPage = data.HasNextPage == true ? BtNextPage.Enabled = true : BtNextPage.Enabled = false;
            var allowReversePage = data.HasReversePage == true ? BtReversePage.Enabled = true : BtReversePage.Enabled = false;
            TbCurrentPage.Text = $"{data.CurrentPage} / {data.TotalPage}";
            Dtg.DataSource = data.Data;

            if (Dtg?.DataSource != null && Dtg.Columns.Contains("Id"))
            {
                Dtg.Columns["Id"]!.Visible = false;
            }

            IsLoadingForm = true;

        }
        private void Dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var pageOrderDetail = Program.ServiceProvider.GetService<FormOrderDetail>();
                var productDto = Dtg.Rows[e.RowIndex].DataBoundItem as SearchProductDto;
                pageOrderDetail.ProductId = productDto.Id;
                this.Hide();
                pageOrderDetail.ShowDialog();
                this.Show();
            }
        }

        private async void BtReversePage_Click(object sender, EventArgs e)
        {
            if (IsLoadingForm)
            {
                IsLoadingForm = false;
                _currentPage--;
                if (CbbIndexPage.SelectedItem is CommonEnumDto<EnumSearchProduct> indexPage)
                {
                    _skipCountPage -= Convert.ToInt32(indexPage.Name);
                }
                await RefreshDataGirdView();
            }
        }

        private async void BtNextPage_Click(object sender, EventArgs e)
        {
            if (IsLoadingForm)
            {
                IsLoadingForm = false;
                _currentPage++;
                if (CbbIndexPage.SelectedItem is CommonEnumDto<EnumSearchProduct> indexPage)
                {
                    _skipCountPage += Convert.ToInt32(indexPage.Name);
                }
                await RefreshDataGirdView();
            }
        }

        private async void CbbIndexPage_SelectedValueChanged(object sender, EventArgs e)
        {
            if (IsLoadingForm)
            {
                IsLoadingForm = false;
                _currentPage = 1;
                _skipCountPage = 0;
                RefreshComBoBox();
                await RefreshDataGirdView();
            }
        }

        private async void BtFind_Click(object sender, EventArgs e)
        {
            if (IsLoadingForm)
            {
                IsLoadingForm = false;
                _currentPage = 1;
                _skipCountPage = 0;
                RefreshComBoBox();
                await RefreshDataGirdView();
            }
        }

        private void BtCart_Click(object sender, EventArgs e)
        {
            var pageCart = Program.ServiceProvider.GetService<FormCart>();
            this.Hide();
            pageCart.ShowDialog();
            this.Show();
        }
    }
}
