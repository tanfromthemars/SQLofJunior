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
            LoadData();
            LoadDays();
            txbIDBookRoom.Text = _idBookRoom.ToString();
        }

        private void LoadDays()
        {
            txbDays.Text = (dpkDateCheckOut.Value.Date - dpkDateCheckIn.Value.Date).Days.ToString();
        }

        private void LoadData()
        {
            DataRow data = BookRoomDAO.Instance.ShowBookRoomInfo(idBookRoom);
            dpkDateCheckIn.Value = (DateTime)data["DateCheckIn"];
            dpkDateCheckOut.Value = (DateTime)data["DateCheckOut"];

            cbRoomType.Text = RoomTypeDAO.Instance.GetRoomTypeByIdBookRoom(idBookRoom).Name;

            getInfoByIdCard(idCard);
        }

        private void getInfoByIdCard(string idCard)
        {
            CustomerDTO customer = CustomerDAO.Instance.GetInfoByIdCard(idCard);
            txbIDCard.Text = customer.IdCard.ToString();
            txbFullName.Text = customer.Name;
            txbAddress.Text = customer.Address;
            dpkDateOfBirth.Value = customer.DateOfBirth;
            cbSex.Text = customer.Sex;
            txbPhoneNumber.Text = customer.PhoneNumber.ToString();
            cbNationality.Text = customer.Nationality;
            cbCustomerType.Text = CustomerTypeDAO.Instance.GetNameByIdCard(idCard);
        }

        private void LoadCustomerType()
        {
            cbCustomerType.DataSource = CustomerTypeDAO.Instance.LoadListCustomerType();
            cbCustomerType.DisplayMember = "Name";
        }

        private void LoadRoomType()
        {
            cbRoomType.DataSource = RoomTypeDAO.Instance.LoadListRoomType();
            cbRoomType.DisplayMember = "Name";
        }
    }
}
