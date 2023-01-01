using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Services;

namespace WinFormsAppManagerCafe.Products
{
    public partial class FormAddProduct : Form
    {
        private readonly IProductService _productService;
        public bool IsDeleted = false;
        public FormAddProduct(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
        }

        private async void BtAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TbName.Text))
            {
                if (NUDPriceBuy.Value == 0)
                {
                    MessageBox.Show("Price buy is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (NUDPriceSell.Value == 0)
                {
                    MessageBox.Show("Price sell is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var createProduct = new CreateProductDto()
                    {
                        Name = TbName.Text,
                        PriceBuy = NUDPriceBuy.Value,
                        PriceSell = NUDPriceSell.Value
                    };
                    await _productService.AddAsync(createProduct);
                    MessageBox.Show("Create new product success", "Done", MessageBoxButtons.OK);
                    IsDeleted = true;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
