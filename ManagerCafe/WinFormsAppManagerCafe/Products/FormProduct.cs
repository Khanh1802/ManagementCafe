using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Enums;
using ManagerCafe.Services;
using Microsoft.Extensions.DependencyInjection;
using WinFormsAppManagerCafe.Products;

namespace WinFormsAppManagerCafe
{
    public partial class FormProduct : Form
    {
        private Guid? _productId = null;
        private readonly IProductService _productService;
        private bool _isLoadingDone = false;
        public FormProduct(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
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
            if (_isLoadingDone)
            {
                if (!string.IsNullOrEmpty(TbName.Text))
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
                else
                {
                    MessageBox.Show("Name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Dtg.DataSource = await _productService.GetAllAsync();
            Dtg.Columns["Id"].Visible = false;
            Dtg.Columns["PriceBuy"].Visible = false;
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
            if (!string.IsNullOrEmpty(TbFind.Text))
            {
                var filter = new FilterProductDto()
                {
                    Name = TbFind.Text,
                };
                try
                {
                    _isLoadingDone = false;
                    var filters = await _productService.FilterAsync(filter);
                    Dtg.DataSource = filters;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                await RefreshDataGirdView();
            }
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
            if (CbbFilter.SelectedIndex != -1 && _isLoadingDone)
            {
                var filter = CbbFilter.SelectedIndex;
                _isLoadingDone = false;
                Dtg.DataSource = await _productService.FilterChoice(filter);
                _isLoadingDone = true;
            }
        }
    }
}
