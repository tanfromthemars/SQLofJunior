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
    public partial class fReceiveRoomDetails : Form
    {
        int idReceiveRoom;
        public fReceiveRoomDetails(int _idReceiveRoom)
        {
            InitializeComponent();
            idReceiveRoom = _idReceiveRoom;
            ShowReceiveRoom(_idReceiveRoom);
        }

        public void ShowReceiveRoom(int idReceiveRoom)
        {
            DataRow data = ReceiveRoomDAO.Instance.ShowReceiveRoom(idReceiveRoom).Rows[0];
            txbIDReceiveRoom.Text = ((int)data["Mã nhận phòng"]).ToString();
            txbRoomName.Text = ((DateTime)data["Ngày nhận"]).ToString().Split(' ')[0];
            txbDateCheckIn.Text = ((DateTime)data["Ngày nhận"]).ToString().Split(' ')[0];
            txbDateCheckOut.Text = ((DateTime)data["Ngày trả"]).ToString().Split(' ')[0];
        }

        public void ShowCustomers(int idReceiveRoom)
        {
            dataGridView.DataSource = ReceiveRoomDAO.Instance.ShowCustomers(idReceiveRoom);
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
