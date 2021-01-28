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
    public partial class fChangeRoom : Form
    {
        int idRoom, idReceiveRoom;
        public fChangeRoom(int _idRoom, int _idReceiveRoom)
        {
            InitializeComponent();
            idRoom = _idRoom;
            idReceiveRoom = _idReceiveRoom;
            LoadListRoomType();
            LoadRoomTypeInfo(_idRoom);
        }
        public void LoadListRoomType()
        {
            List<RoomTypeDTO> rooms = RoomTypeDAO.Instance.LoadListRoomType();
            cbRoomType.DataSource = rooms;
            cbRoomType.DisplayMember = "Name";
        }
        public void LoadRoomTypeInfo(int idRoom)
        {
            CultureInfo cultureInfo = new CultureInfo("vi-vn");
            RoomTypeDTO roomType = RoomTypeDAO.Instance.GetRoomTypeByIdBookRoom(idRoom);
            txbLimitPerson.Text = roomType.LimitPerson.ToString();
            txbPrice.Text = roomType.Price.ToString("c", cultureInfo);
            txbRoomTypeName.Text = roomType.Name;
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbRoomTypeName.Text = (cbRoomType.SelectedItem as RoomTypeDTO).Name;
            LoadEmptyRoom((cbRoomType.SelectedItem as RoomTypeDTO).Id);
            LoadRoomTypeInfo((cbRoom.SelectedItem as RoomDTO).Id);
        }

        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbRoomName.Text = (cbRoom.SelectedItem as RoomDTO).Name;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            RoomDAO.Instance.UpdateStatusRoom(idRoom);
            ReceiveRoomDAO.Instance.UpdateReceiveRoom(idReceiveRoom, (cbRoom.SelectedItem as RoomDTO).Id);
            MessageBox.Show("Đổi phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LoadEmptyRoom(int idRoomType)
        {
            List<RoomDTO> rooms = RoomDAO.Instance.LoadEmptyRoom(idRoomType);
            cbRoom.DataSource = rooms;
            cbRoom.DisplayMember = "Name";
        }
    }
}
