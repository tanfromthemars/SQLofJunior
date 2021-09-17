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
            else
                if (!fCustomer.CheckFillInText)
        }
    }
}
