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
    public partial class fBookRoomDetails : Form
    {
        int idBookRoom;
        string idCard;
        public fBookRoomDetails(int _idBookRoom, string _idCard)
        {
            idBookRoom = _idBookRoom;
            idCard = _idCard;
            InitializeComponent();
            LoadRoomType();
            LoadCustomerType();
        }

        private void LoadCustomerType()
        {
            cbCustomerType.DataSource = CustomerTypeDAO.Instance.LoadListCustomerType();
        }

        private void LoadRoomType()
        {
            cbRoomType.DataSource = RoomTypeDAO.Instance.LoadListRoomType();
            cbRoomType.DisplayMember = "Name";
        }
    }
}
