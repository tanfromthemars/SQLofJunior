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
    public partial class fReceiveRoom : Form
    {
        List<int> ListIDCustomer = new List<int>();
        int IDBookRoom = -1;
        DateTime dateCheckIn;
        public fReceiveRoom(int idBookRoom)
        {
            IDBookRoom = idBookRoom;
            InitializeComponent();
            LoadData();
            ShowBookRoomInfo(IDBookRoom);
        }
        public fReceiveRoom()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            LoadListRoomType();
            LoadReceiveRoomInfo();
        }
        public void LoadListRoomType()
        {
            List<RoomTypeDTO> rooms = RoomTypeDAO.Instance.LoadListRoomType();
            cbRoomType.DataSource = rooms;
            cbRoomType.DisplayMember = "Name";
        }
        public void LoadEmptyRoom(int idRoomType)
        {
            List<RoomDTO> rooms = RoomDAO.Instance.LoadEmptyRoom(idRoomType);
            cbRoom.DataSource = rooms;
            cbRoom.DisplayMember = "Name";
        }
        public bool IsIDBookRoomExists(int idBookRoom)
        {
            return BookRoomDAO.Instance.IsIDBookRoomExists(idBookRoom);
        }
        public void LoadReceiveRoomInfo()
        {
            dataGridViewReceiveRoom.DataSource = ReceiveRoomDAO.Instance.LoadReceiveRoomInfo();
        }
        public void ShowBookRoomInfo(int idBookRoom)
        {
            DataRow dataRow = BookRoomDAO.Instance.ShowBookRoomInfo(idBookRoom);
            txbFullName.Text = dataRow["FullName"].ToString();
            txbIDCard.Text = dataRow["IDCard"].ToString();
            txbRoomTypeName.Text = dataRow["RoomTypeName"].ToString();
            cbRoomType.Text = dataRow["RoomTypeName"].ToString();
            txbDateCheckIn.Text = dataRow["DateCheckIn"].ToString().Split(' ')[0];
            dateCheckIn = (DateTime)dataRow["DateCheckIn"];
            txbDateCheckOut.Text = dataRow["DateCheckOut"].ToString().Split(' ')[0];
            txbAmountPeople.Text = dataRow["LimitPerson"].ToString();
            txbPrice.Text = dataRow["Price"].ToString();
        }
        public bool InsertReceiveRoom(int idBookRoom, int idRoom)
        {
            return ReceiveRoomDAO.Instance.InsertReceiveRoom(idBookRoom, idRoom);
        }
        public bool InsertReceiveRoomDetails(int idReceiveRoom, int idCustomerOther)
        {
            return ReceiveRoomDetailsDAO.Instance.InsertReceiveRoomDetails(idReceiveRoom, idCustomerOther);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbRoomTypeName.Text = (cbRoomType.SelectedItem as RoomTypeDTO).Name;
            LoadEmptyRoom((cbRoomType.SelectedItem as RoomTypeDTO).Id);
        }

        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbRoomName.Text = cbRoom.Text;
        }

        private void txbIDBookRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                btnSearch_Click(sender, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txbIDBookRoom.Text != string.Empty)
            {
                if (IsIDBookRoomExists(int.Parse(txbIDBookRoom.Text)))
                {
                    btnSearch.Tag = txbIDBookRoom.Text;
                    ShowBookRoomInfo(int.Parse(txbIDBookRoom.Text));
                }
                else
                    MessageBox.Show("Mã đặt phòng không tồn tại.\nVui lòng nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbIDBookRoom.Text = string.Empty;
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (txbRoomName.Text != string.Empty && txbRoomTypeName.Text != string.Empty && txbFullName.Text != string.Empty && txbIDCard.Text != string.Empty && txbDateCheckIn.Text != string.Empty && txbDateCheckOut.Text != string.Empty && txbAmountPeople.Text != string.Empty && txbPrice.Text != string.Empty)
            {

            }    
        }
    }
}
