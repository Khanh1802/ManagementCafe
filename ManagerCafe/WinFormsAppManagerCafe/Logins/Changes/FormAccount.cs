using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppManagerCafe.Logins.Changes;

namespace WinFormsAppManagerCafe
{
    public partial class FormAccount : Form
    {
        public FormAccount()
        {
            InitializeComponent();
        }

        private void BtReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtChangeInfo_Click(object sender, EventArgs e)
        {
            var pageInfomation = Program.ServiceProvider.GetService<FormInfomation>();
            pageInfomation.ShowDialog();
        }

        private void BtChangePassword_Click(object sender, EventArgs e)
        {
            var pagePassword = Program.ServiceProvider.GetService<FormPassword>();
            pagePassword.ShowDialog();
        }
    }
}
