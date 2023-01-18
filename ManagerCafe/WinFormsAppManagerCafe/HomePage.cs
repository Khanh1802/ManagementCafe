using Microsoft.Extensions.DependencyInjection;
using WinFormsAppManagerCafe.History;
using WinFormsAppManagerCafe.Inventories;
using WinFormsAppManagerCafe.UserTypes;
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
            if (pageProduct._isLoadingDone)
            {
                pageProduct.Close();
            }
        }

        private void BtPageWareHouse_Click(object sender, EventArgs e)
        {
            var pageWareHouse = Program.ServiceProvider.GetService<FormWareHouse>();
            pageWareHouse.ShowDialog();
            if (pageWareHouse._isLoadingDone)
            {
                pageWareHouse.Close();
            }
        }

        private void BtHistory_Click(object sender, EventArgs e)
        {
            var pageInventoryTransaction = Program.ServiceProvider.GetService<FormStatistic>();
            pageInventoryTransaction.ShowDialog();
            if (pageInventoryTransaction._isLoadingDone)
            {
                pageInventoryTransaction.Close();
            }
        }

        private void BtPageInventory_Click(object sender, EventArgs e)
        {
            var pageInventory = Program.ServiceProvider.GetService<FormInventory>();
            pageInventory.ShowDialog();

        }

        private void BtHistory_Click_1(object sender, EventArgs e)
        {
            var pageHistory = Program.ServiceProvider.GetService<FormHistory>();
            pageHistory.ShowDialog();
        }

        private void BtPageUserType_Click(object sender, EventArgs e)
        {
            var pageUserType = Program.ServiceProvider.GetService<FormUserType>();
            pageUserType.ShowDialog();
        }
    }
}