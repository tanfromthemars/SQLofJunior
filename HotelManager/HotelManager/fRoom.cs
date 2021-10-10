using HotelManager.DAO;
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
    public partial class fRoom : Form
    {
        private fRoomType _fRoomType;
        public fRoom()
        {
            InitializeComponent();
            LoadFullRoomType();
            LoadFullStatusRoom();
            LoadFullRoom(GetFullRoom());
            dataGridViewRoom.SelectionChanged += dataGridViewRoom_SelectionChanged;
            comboboxID.DisplayMember = "id";
            dataGridViewRoom.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        }

        private void LoadFullRoom(DataTable table)
        {
            BindingSource source = new BindingSource();
            ChangePrice(table);
            source.DataSource = table;
            dataGridViewRoom.DataSource = source;
            bindingRoom.BindingSource = source;
            comboboxID.DataSource = source;
        }

        private void ChangePrice(object table)
        {
            throw new NotImplementedException();
        }

        private object GetFullRoom()
        {
            return RoomDAO.Instance.LoadFullRoom();
        }

        private void LoadFullStatusRoom()
        {
            DataTable table = GetFullStatusRoom();
            comboBoxStatusRoom.DataSource = table;
            comboBoxStatusRoom.DisplayMember = "Name";
            if (table.Rows.Count > 0)
                comboBoxStatusRoom.SelectedIndex = 0;
        }

        private DataTable GetFullStatusRoom()
        {
            return StatusRoomDAO.Instance.LoadFullStatusRoom();
        }

        private void LoadFullRoomType()
        {
            DataTable table = GetFullRoomType();
            comboBoxRoomType.DataSource = table;
            comboBoxRoomType.DisplayMember = "Name";
            if (table.Rows.Count > 0)
                comboBoxRoomType.SelectedIndex = 0;
            _fRoomType = new fRoomType(table);
            txbLimitPerson.DataBindings.Add(new Binding("Text", comboBoxRoomType.DataSource, "limiPerson"));
        }

        private DataTable GetFullRoomType()
        {
            return RoomTypeDAO.Instance.LoadFullRoomType();
        }

        private void dataGridViewRoom_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            new fAddRoom().ShowDialog();
            if (btnCancel.Visible == false)
                LoadFullRoom(GetFullRoom());
            else
                btnCancel_Click(null, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnRoomType_Click(object sender, EventArgs e)
        {
            this.Hide();
            _fRoomType.ShowDiaglog();
        }
    }
}
