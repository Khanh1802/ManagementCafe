using Microsoft.Extensions.DependencyInjection;
using WinFormsAppManagerCafe.Inventories;
using WinFormsAppManagerCafe.WareHouses;

namespace WinFormsAppManagerCafe
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pageProduct = Program.ServiceProvider.GetService<FormProduct>();
            pageProduct.ShowDialog();
        }

        private void BtPageWareHouse_Click(object sender, EventArgs e)
        {
            var pageWareHouse = Program.ServiceProvider.GetService<FormWareHouse>();
            pageWareHouse.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var pageInventory = Program.ServiceProvider.GetService<FormInventory>();
            pageInventory.ShowDialog();
        }

        private void BtHistory_Click(object sender, EventArgs e)
        {
            var pageInventoryTransaction = Program.ServiceProvider.GetService<FormInventoryTransaction>();
            pageInventoryTransaction.ShowDialog();
        }
    }
}