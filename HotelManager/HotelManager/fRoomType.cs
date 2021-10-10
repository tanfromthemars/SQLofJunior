using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fRoomType : UserControl
    {
        private DataTable _tableRoomType;
        public DataTable TableRoomType
        {
            get => _tableRoomType;
            private set
            {
                _tableRoomType = value;
                BindingSource source = new BindingSource();
                ChangePrice(_tableRoomType);
                source.DataSource = _tableRoomType;
                dataGridViewRoomType.DataSource = source;
                bindingCustomerType.BindingSource = source;
                comboboxID.DataSource = source;
            }
        }

        private void ChangePrice(DataTable tableRoomType)
        {
            throw new NotImplementedException();
        }

        public fRoomType()
        {
            InitializeComponent();
        }
        public fRoomType(DataTable table)
        {
            InitializeComponent();
            TableRoomType = table;
            comboboxID.DisplayMember = "id";
            dataGridViewRoomType.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        }

        private void LoadFullRoomType(DataTable table)
        {
            this.TableRoomType = table;
        }

        private DataTable GetFullRoomType()
        {
            return RoomTypeDAO.Instance.LoadFullRoomType();
        }
        private RoomTypeDTO GetRoomTypeNow()
        {
            RoomTypeDTO roomType = new RoomTypeDTO();
            if (comboboxID.Text == string.Empty)
                roomType.Id = 0;
            else
                roomType.Id = int.Parse(comboboxID.Text);

            roomType.Name = txbName.Text;
            roomType.Price = int.Parse(StringToInt(txbPrice.Text));
            roomType.LimitPerson = int.Parse(txbLimitPerson.Text);
            return roomType;
        }

        private string StringToInt(string text)
        {
            throw new NotImplementedException();
        }

        private DataTable GetSearchRoomType()
        {
            if (int.TryParse(txbSearch.Text, out int id))
                return RoomTypeDAO.Instance.Search(txbSearch.Text, id);
            else
                return RoomTypeDAO.Instance.Search(txbSearch.Text, 0);
        }

        private void UpdateRoomType()
        {
            if (comboboxID.Text == string.Empty)
            {
                MessageBox.Show("Loại phòng này chưa tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (!fCustomer.CheckFillInText(new Control[] { txbName, txbPrice }))
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                RoomTypeDTO roomTypePre = groupRoomType.Tag as RoomTypeDTO;
                try
                {
                    RoomTypeDTO roomTypeNow = GetRoomTypeNow();
                    if (roomTypeNow.Equals(roomTypePre))
                        MessageBox.Show("Bạn chưa thay đổi dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        bool check = RoomTypeDAO.Instance.UpdateRoomType(roomTypeNow, roomTypePre);
                        if (check)
                        {
                            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupRoomType.Tag = roomTypeNow;
                            if (btnCancel.Visible == false)
                            {
                                int index = dataGridViewRoomType.SelectedRows[0].Index;
                                LoadFullRoomType(GetFullRoomType());
                                comboboxID.SelectedIndex = index;
                            }
                            else
                                btnCancel_Click(null, null);
                        }
                        else
                            MessageBox.Show("Loại phòng này chưa tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }    
                }
                catch
                {
                    MessageBox.Show("Lỗi nhập dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                txbName.Text = string.Empty;
                txbPrice.Text = "0";
                txbLimitPerson.Text = "0";
            }    
            else
            {
                txbName.Text = row.Cells["colName"].Value.ToString();
                txbPrice.Text = (string)row.Cells["colPrice"].Value;
                txbLimitPerson.Text = row.Cells["colLimitPerson"].Value.ToString();
                RoomTypeDTO roomType = new RoomTypeDTO(((DataRowView)row.DataBoundItem).Row);
                groupRoomType.Tag = roomType;
            }    
        }

        private void Search()
        {
            LoadFullRoomType(GetSearchRoomType());
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadFullRoomType(GetFullRoomType());
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật loại phòng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                UpdateRoomType();
            comboboxID.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (saveRoomType.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {
                bool check;
                try
                {
                    switch (saveRoomType.FilterIndex)
                    {
                        case 2:
                            check = ExportToExcel.Instance.Export(dataGridViewRoomType, saveRoomType.FileName, ModeExportToExcel.XLSX);
                            break;
                        case 3:
                            check = ExportToExcel.Instance.Export(dataGridViewRoomType, saveRoomType.FileName, ModeExportToExcel.PDF);
                            break;
                        default:
                            check = ExportToExcel.Instance.Export(dataGridViewRoomType, saveRoomType.FileName, ModeExportToExcel.XLS);
                            break;
                    }
                    if (check)
                        MessageBox.Show("Xuất thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Lỗi xuất thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Lỗi (Cần cài đặt Office)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                txbName.Text = string.Empty;
                txbPrice.Text = string.Empty;
                btnSearch.Visible = false;
                btnCancel.Visible = true;
                Search();
            }    
        }

        private void dataGridViewRoomType_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewRoomType.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewRoomType.SelectedRows[0];
                ChangeText(row);
            }    
        }

        private void txbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }    
        }

        private void txbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSearch_Click(sender, null);
            else
                if (e.KeyChar == 27 && btnCancel.Visible == true)
                btnCancel_Click(sender, null);
        }

        private void fRoomType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                btnCancel_Click(sender, null);
        }

        private void txbName_Leave(object sender, EventArgs e)
        {
            if (txbName.Text == string.Empty)
                txbName.Text = txbName.Tag as String;
        }

        private void txbPrice_Leave(object sender, EventArgs e)
        {
            if (txbPrice.Text == string.Empty)
            {
                txbPrice.Text = (string)txbPrice.Tag;
            }
            else
                txbPrice.Text = IntToString(txbPrice.Text);
        }

        private string IntToString(string text)
        {
            if (text == string.Empty)
                return 0.ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            if (text.Contains(".") || text.Contains(" "))
                return text;
            else
                return (int.Parse(text).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN")));
        }

        private void txbLimitPerson_Leave(object sender, EventArgs e)
        {
            if (txbLimitPerson.Text == string.Empty)
                txbLimitPerson.Text = txbLimitPerson.Tag as String;
        }

        private void txbPrice_Enter(object sender, EventArgs e)
        {
            txbPrice.Tag = txbPrice.Text;
            txbPrice.Text = StringToInt(txbPrice.Text);
        }

        private void txbName_Enter(object sender, EventArgs e)
        {
            txbName.Tag = txbName.Text;
        }

        private void txbLimitPerson_Enter(object sender, EventArgs e)
        {
            txbLimitPerson.Tag = txbLimitPerson.Text;
        }
    }
}
