using ManagerCafe.Datas.Enums;
using ManagerCafe.Dtos.WareHouseDtos;
using ManagerCafe.Enums;
using ManagerCafe.Services;
using Microsoft.Extensions.DependencyInjection;

namespace WinFormsAppManagerCafe.WareHouses
{
    public partial class FormWareHouse : Form
    {
        private IWareHouseService _wareHouseService;
        private Guid? _wareHouseId;
        internal bool _isLoadingDone = false;
        public FormWareHouse(IWareHouseService wareHouseService)
        {
            InitializeComponent();
            _wareHouseService = wareHouseService;
            CbbFilter.DataSource = EnumHelpers.GetEnumList<EnumWareHouseFilter>();
            CbbFilter.DisplayMember = "Name";
        }

        private async void BtAdd_Click(object sender, EventArgs e)
        {
            var pageAddWareHouse = Program.ServiceProvider.GetService<FormAddWareHouse>();
            pageAddWareHouse.ShowDialog();
            if (pageAddWareHouse.IsDeleted == true)
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
                    var updateWareHouse = new UpdateWareHouseDto()
                    {
                        Id = (Guid)_wareHouseId,
                        Name = TbName.Text
                    };
                    try
                    {
                        _isLoadingDone = false;
                        await _wareHouseService.UpdateAsync(updateWareHouse);
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
                if (_wareHouseId is not null)
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        try
                        {
                            _isLoadingDone = false;
                            await _wareHouseService.DeleteAsync(_wareHouseId);
                            MessageBox.Show("Deleted WareHouse success", "Done", MessageBoxButtons.OK);
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

        private void Dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                BtAdd.Enabled = true;
                BtRemove.Enabled = false;
                BtUpdate.Enabled = false;
                TbName.Text = string.Empty; 
                _wareHouseId = null;
                TbName.Enabled = false;
            }
            else
            {
                BtAdd.Enabled = false;
                BtRemove.Enabled = true;
                BtUpdate.Enabled = true;
                if (Dtg.Rows[e.RowIndex].DataBoundItem is WareHouseDto)
                {
                    var wareHouse = Dtg.Rows[e.RowIndex].DataBoundItem as WareHouseDto;
                    _wareHouseId = wareHouse.Id;
                    TbName.Text = wareHouse.Name; 
                    TbName.Enabled = true; 
                }
            }
        }

        private async void FormWareHouse_Load(object sender, EventArgs e)
        {
            await RefreshDataGirdView();
        }

        private async void CbbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbbFilter.SelectedIndex != -1 && _isLoadingDone)
            {
                var filter = CbbFilter.SelectedIndex;
                _isLoadingDone = false;
                Dtg.DataSource = await _wareHouseService.FilterChoice(filter);
                _isLoadingDone = true;
            }
        }

        private async void BtFind_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TbFind.Text))
            {
                var filter = new FilterWareHouseDto()
                {
                    Name = TbFind.Text,
                };
                try
                {
                    _isLoadingDone = false;
                    var filters = await _wareHouseService.FilterAsync(filter);
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
        private async Task RefreshDataGirdView()
        {
            Dtg.DataSource = await _wareHouseService.GetAllAsync();
            if(Dtg?.Columns != null && Dtg.Columns.Contains("Id"))
            {
                Dtg.Columns["Id"]!.Visible = false;
            }
            BtAdd.Enabled = true;
            BtRemove.Enabled = false;
            BtUpdate.Enabled = false;
            TbName.Text = string.Empty;
            _wareHouseId = null;
            TbName.Enabled = false;
            _isLoadingDone = true;
        }

        private void FormWareHouse_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isLoadingDone)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
