using ManagerCafe.Commons;
using ManagerCafe.Data.Enums;
using ManagerCafe.Datas.Enums;
using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Enums;
using ManagerCafe.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using WinFormsAppManagerCafe.Products;

namespace WinFormsAppManagerCafe
{
    public partial class FormProduct : Form
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IProductService _productService;
        private Guid? _productId = null;
        internal bool _isLoadingDone = false;
        private int _skipCount = 0;
        private int _takeMaxResultCount = 10;
        private int _currentPage = 1;
        public FormProduct(IProductService productService, IMemoryCache memoryCache)
        {
            InitializeComponent();
            _productService = productService;

            //Load data into ComboBox

            //Lấy dữ liệu của Enum map về List<CommonEnumDto>
            //Trong đó Id chính là Enum, name là thuộc tính DisplayTypeInventoryTransaction
            CbbFilter.DataSource = EnumHelpers.GetEnumList<EnumProductFilter>();
            CbbFilter.DisplayMember = "Name";
            CbbIndexPage.DataSource = EnumHelpers.GetEnumList<EnumIndexPage>();
            CbbIndexPage.DisplayMember = "Name";
            if (CbbIndexPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
            {
                _takeMaxResultCount = Convert.ToInt32(indexPage.Name);
            }
            _memoryCache = memoryCache;
        }

        private async void BtAdd_Click(object sender, EventArgs e)
        {
            var pageAddProduct = Program.ServiceProvider.GetService<FormAddProduct>();
            pageAddProduct.ShowDialog();
            if (pageAddProduct.IsDeleted == true)
            {
                await RefreshDataGirdView();
            }
        }
        private async void BtUpdate_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone && _productId.HasValue && !string.IsNullOrEmpty(TbName.Text))
            {
                var updateProduct = new UpdateProductDto()
                {
                    Id = (Guid)_productId,
                    Name = TbName.Text,
                    PriceBuy = NUDPriceBuy.Value,
                    PriceSell = NUDPriceSell.Value
                };
                try
                {
                    _isLoadingDone = false;
                    await _productService.UpdateAsync(updateProduct);
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
        }

        private async void BtRemove_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                if (_productId is not null)
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        try
                        {
                            _isLoadingDone = false;
                            await _productService.DeleteAsync(_productId);
                            MessageBox.Show("Deleted product success", "Done", MessageBoxButtons.OK);
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
                }
            }
        }

        private async void FormProduct_Load(object sender, EventArgs e)
        {
            await RefreshDataGirdView();
        }

        private async Task RefreshDataGirdView()
        {
            _isLoadingDone = false;
            var choice = -1;

            if (CbbFilter.SelectedItem is CommonEnumDto<EnumProductFilter> filter)
            {
                choice = Convert.ToInt32(filter.Id);
            }
            var data = await _productService.GetPagedListAsync(new FilterProductDto()
            {
                SkipCount = _skipCount,
                TakeMaxResultCount = _takeMaxResultCount,
                CurrentPage = _currentPage,
            }, choice);
            TbCurrentPage.Text = $"{data.CurrentPage}/{Convert.ToString(data.TotalPage)}";
            BtReversePage.Enabled = false;
            BtNextPage.Enabled = false;
            if (data.HasReversePage)
            {
                BtReversePage.Enabled = true;
            }
            if (data.HasNextPage)
            {
                BtNextPage.Enabled = true;
            }

            Dtg.DataSource = data.Data;

            if (Dtg?.Columns != null && Dtg.Columns.Contains("Id"))
            {
                Dtg.Columns["Id"]!.Visible = false;
            }

            if (Dtg?.Columns != null && Dtg.Columns.Contains("PriceBuy"))
            {
                Dtg.Columns["PriceBuy"]!.Visible = false;
            }

            BtAdd.Enabled = true;
            BtRemove.Enabled = false;
            BtUpdate.Enabled = false;
            TbName.Text = string.Empty;
            NUDPriceBuy.Value = 0;
            NUDPriceSell.Value = 0;
            _productId = null;
            TbName.Enabled = false;
            NUDPriceBuy.Enabled = false;
            NUDPriceSell.Enabled = false;
            _isLoadingDone = true;
        }

        private async void BtFind_Click(object sender, EventArgs e)
        {
            _isLoadingDone = false;
            if (!string.IsNullOrEmpty(TbFind.Text))
            {
                CbAllResult.Checked = false;
                var filter = new FilterProductDto()
                {
                    Name = TbFind.Text,
                };
                try
                {
                    _isLoadingDone = false;
                    var filters = await _productService.FilterAsync(filter);

                    Dtg.DataSource = filters;
                    if (filters.Count == 0)
                    {
                        MessageBox.Show($"Not found any thing with \"{TbFind.Text}\"", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    _isLoadingDone = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Search is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _isLoadingDone = true;
        }

        private void Dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                BtAdd.Enabled = true;
                BtRemove.Enabled = false;
                BtUpdate.Enabled = false;
                TbName.Text = string.Empty;
                NUDPriceBuy.Value = 0;
                NUDPriceSell.Value = 0;
                _productId = null;
                TbName.Enabled = false;
                NUDPriceBuy.Enabled = false;
                NUDPriceSell.Enabled = false;
            }
            else
            {
                BtAdd.Enabled = false;
                BtRemove.Enabled = true;
                BtUpdate.Enabled = true;
                if (Dtg.Rows[e.RowIndex].DataBoundItem is ProductDto)
                {
                    var productDto = Dtg.Rows[e.RowIndex].DataBoundItem as ProductDto;
                    _productId = productDto.Id;
                    TbName.Text = productDto.Name;
                    NUDPriceBuy.Value = productDto.PriceBuy;
                    NUDPriceSell.Value = productDto.PriceSell;
                    TbName.Enabled = true;
                    NUDPriceBuy.Enabled = true;
                    NUDPriceSell.Enabled = true;
                }
            }
        }


        private async void CbbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                _currentPage = 1;
                _skipCount = 0;
                await RefreshDataGirdView();
            }
        }

        private async void BtNextPage_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                _isLoadingDone = false;
                _currentPage++;
                if (CbbIndexPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
                {
                    _skipCount += Convert.ToInt32(indexPage.Name);
                }
                await RefreshDataGirdView();
            }
        }

        private async void BtReversePage_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                _isLoadingDone = false;
                _currentPage--;
                if (CbbIndexPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
                {
                    _skipCount -= Convert.ToInt32(indexPage.Name);
                }
                await RefreshDataGirdView();
            }
        }

        private async void CbbIndexPage_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone && CbbIndexPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
            {
                _skipCount = 0;
                _currentPage = 1;
                _memoryCache.Remove(ProductCacheKey.ProductAllKey);
                await RefreshDataGirdView();
            }
        }

        private async void CbAllResult_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone && CbAllResult.Checked)
            {
                _skipCount = 0;
                _currentPage = 1;
                await RefreshDataGirdView();
            }
        }
    }
}
