using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fCustomer : Form
    {
        internal fCustomer()
        {
            InitializeComponent();
            cbCustomerSearch.SelectedIndex = 3;
            LoadFullCustomerType();
            LoadFullCustomer(GetFullCustomer());
            comboBoxSex.SelectedIndex = 0;
            SaveCustomer.OverwritePrompt = true;
            comboboxID.DisplayMember = "id";
            FormClosing += fCustomer_FormClosing;
            txbSearch.KeyPress += txbSearch_KeyPress;
            dataGridViewCustomer.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("SegoeUI", 9.75F);
        }

        private void LoadFullCustomerType()
        {
            DataTable table = GetFullCustomerType();
            comboBoxCustomerType.DataSource = table;
            comboBoxCustomerType.DisplayMember = "Name";
            if (table.Rows.Count > 0)
                comboBoxCustomerType.SelectedIndex = 0;
        }

        private DataTable GetFullCustomerType()
        {
            return CustomerTypeDAO.Instance.LoadFullCustomerType();
        }

        private object GetFullCustomer()
        {
            return CustomerDAO.Instance.LoadFullCustomer();
        }

        private void LoadFullCustomer(DataTable table)
        {
            BindingSource source = new BindingSource();
            source.DataSource = table;
            dataGridViewCustomer.DataSource = source;
            bindingCustomer.BindingSource = source;
            comboboxID.DataSource = source;
        }

        private void fCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadFullCustomer(GetFullCustomer());
        }

        private void txbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSearch_Click(sender, null);
            else
                if (e.KeyChar == 27 && btnCancel.Visible == true)
                btnCancel_Click(sender, null);
        }

        public static bool CheckFillInText(Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control.Text == string.Empty)
                    return false;
            }
            return true;
        }

        private void InsertCustomer()
        {
            if (!CheckFillInText(new Control[]
            {
                txbPhoneNumber, txbFullName, txbIDCard, txbNationality, txbAddress, comboBoxCustomerType
            }))
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                CustomerDTO customer = GetCustomerNow();
                if (CustomerDAO.Instance.InsertCustomer(customer))
                {
                    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (btnCancel.Visible == false)
                        LoadFullCustomer(GetFullCustomerType());
                    else
                        btnCancel_Click(null, null);
                    comboboxID.SelectedIndex = dataGridViewCustomer.RowCount - 1;
                }
                else
                    MessageBox.Show("Khách Hàng đã tồn tại\nTrùng số chứng minh nhân dân", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch
            {
                MessageBox.Show("Lỗi thêm khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private CustomerDTO GetCustomerNow()
        {
            throw new NotImplementedException();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadFullCustomer(GetFullCustomer());
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                txbAddress.Text = string.Empty;
                txbFullName.Text = string.Empty;
                txbIDCard.Text = string.Empty;
                txbPhoneNumber.Text = string.Empty;
                txbNationality.Text = string.Empty;

                btnSearch.Visible = false;
                btnCancel.Visible = true;
                Search();
            }
        }

        private void Search()
        {
            throw new NotImplementedException();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật khách hàng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                if (CheckDate())
                {
                    UpdateCustomer();
                    comboboxID.Focus();
                }
                else
                    MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UpdateCustomer()
        {
            throw new NotImplementedException();
        }

        private bool CheckDate()
        {
            throw new NotImplementedException();
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            new fAddCustomer().ShowDialog();
            if (btnCancel.Visible == false)
                LoadFullCustomer(GetFullCustomer());
            else
                btnCancel_Click(null, null);
        }

        private void LoadFullCustomer(object v)
        {
            throw new NotImplementedException();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            bool check;
            if (SaveCustomer.ShowDialog() == DialogResult.Cancel)
                return;
            switch (SaveCustomer.FilterIndex)
            {
                case 2:
                    check = ExportToExcel.Instance.Export(dataGridViewCustomer, SaveCustomer.FileName, ModeExportToExcel.XLSX);
                    break;

                case 3:
                    check = ExportToExcel.Instance.Export(dataGridViewCustomer, SaveCustomer.FileName, ModeExportToExcel.PDF);
                    break;

                default:
                    check = ExportToExcel.Instance.Export(dataGridViewCustomer, SaveCustomer.FileName, ModeExportToExcel.XLS);
                    break;
            }
            if (check)
                MessageBox.Show("Xuất file thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Lỗi (Cần cài đặt Office", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
