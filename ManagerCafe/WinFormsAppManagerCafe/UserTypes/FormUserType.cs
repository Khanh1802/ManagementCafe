using ManagerCafe.Commons;
using ManagerCafe.Data.Enums;
using ManagerCafe.Datas.Enums;
using ManagerCafe.Dtos.UserTypeDtos;
using ManagerCafe.Services;
using Microsoft.Extensions.DependencyInjection;

namespace WinFormsAppManagerCafe.UserTypes
{
    public partial class FormUserType : Form
    {
        private readonly IUserTypeService _userTypeService;

        private bool _isLoadingDone = false;
        private Guid? _idUserType;
        private int _currentPage = 1;
        private int _skipCount = 0;
        private int _takeCount = 0;
        public FormUserType(IUserTypeService userTypeService)
        {
            InitializeComponent();
            _userTypeService = userTypeService;
            RefreshComBoBox();
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            var pageAddUserType = Program.ServiceProvider.GetService<FormAddUserType>();
            pageAddUserType.ShowDialog();
        }

        private async void FormUserType_Load(object sender, EventArgs e)
        {
            await RefreshDataGirdView();
        }

        private async Task RefreshDataGirdView()
        {
            _isLoadingDone = false;
            var filter = new FilterUserTypeDto();
            filter.CurrentPage = _currentPage;
            filter.SkipCount = _skipCount;
            filter.TakeMaxResultCount = _takeCount;
            var data = await _userTypeService.GetPagedListAsync(filter);
            Dtg.DataSource = data.Data;
            if (Dtg?.Columns != null && Dtg.Columns.Contains("Id"))
            {
                Dtg.Columns["Id"].Visible = false;
            }
            if (Dtg?.Columns != null && Dtg.Columns.Contains("IsDeleted"))
            {
                Dtg.Columns["IsDeleted"].Visible = false;
            }
            TbCurrentPage.Text = $"{_currentPage}/{data.TotalPage}";
            var allowNextPage = data.HasNextPage == true ? BtNextPage.Enabled = true : BtNextPage.Enabled = false;
            var allowReversePage = data.HasReversePage == true ? BtReversePage.Enabled = true : BtReversePage.Enabled = false;
            _isLoadingDone = true;
        }

        private void RefreshComBoBox()
        {
            _isLoadingDone = false;
            CbbIndexPage.DataSource = EnumHelpers.GetEnumList<EnumIndexPage>();
            CbbIndexPage.DisplayMember = "Name";
            if (CbbIndexPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
            {
                _takeCount = Convert.ToInt32(indexPage.Name);
            }
            _isLoadingDone = true;

        }

        private void CbbIndexPage_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                _currentPage = 1;
                _skipCount = 0;
                if (CbbIndexPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
                {
                    _takeCount = Convert.ToInt32(indexPage.Name);
                }
            }
        }

        private void Dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                _idUserType = null;
                BtRemove.Enabled = false;
                BtUpdate.Enabled = false;
                BtAdd.Enabled = true;
                TbName.Text = string.Empty;
            }
            else
            {
                BtAdd.Enabled = false;
                BtRemove.Enabled = true;
                BtUpdate.Enabled = true;
                if (Dtg.Rows[e.RowIndex].DataBoundItem is UserTypeDto userTypeDto)
                {
                    _idUserType = userTypeDto.Id;
                    TbName.Text = userTypeDto.Name;
                }
            }
        }

        private async void BtUpdate_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                if (_idUserType != null)
                {
                    _isLoadingDone = false;
                    var update = new UpdateUserTypeDto()
                    {
                        Id = (Guid)_idUserType,
                        Name = TbName.Text,
                    };
                    try
                    {
                        await _userTypeService.UpdateAsync(update);
                        MessageBox.Show("Update successfully", "Done", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        await RefreshDataGirdView();
                        _isLoadingDone = true;
                    }
                }
            }
        }

        private async void BtRemove_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone)
            {
                if (_idUserType is not null)
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        try
                        {
                            _isLoadingDone = false;
                            await _userTypeService.DeleteAsync(_idUserType);
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

        private async void BtReversePage_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone && CbbIndexPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
            {
                _isLoadingDone = false;
                _currentPage--;
                _skipCount -= Convert.ToInt32(indexPage.Name);
                await RefreshDataGirdView();
            }
        }

        private async void BtNextPage_Click(object sender, EventArgs e)
        {
            if (_isLoadingDone && CbbIndexPage.SelectedItem is CommonEnumDto<EnumIndexPage> indexPage)
            {
                _isLoadingDone = false;
                _currentPage++;
                _skipCount += Convert.ToInt32(indexPage.Name);
                await RefreshDataGirdView();
            }
        }

        private void FormUserType_FormClosing(object sender, FormClosingEventArgs e)
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
