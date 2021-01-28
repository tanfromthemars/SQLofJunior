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
            LoadData();
            LoadCustomerType();
            LoadDays();
            txbIDBookRoom.Text = _idBookRoom.ToString();
        }
        public void LoadRoomType()
        {
            cbRoomType.DataSource = RoomTypeDAO.Instance.LoadListRoomType();
            cbRoomType.DisplayMember = "Name";
        }
        public void LoadData()
        {
            DataRow data = BookRoomDAO.Instance.ShowBookRoomInfo(idBookRoom);
            dpkDateCheckIn.Value = (DateTime)data["DateCheckIn"];
            dpkDateCheckOut.Value = (DateTime)data["DateCheckOut"];

            cbRoomType.Text = RoomTypeDAO.Instance.GetRoomTypeByIdBookRoom(idBookRoom).Name;

            GetInfoByIdCard(idCard);
        }
        public void GetInfoByIdCard(string idCard)
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
        public void LoadCustomerType()
        {
            cbCustomerType.DataSource = CustomerTypeDAO.Instance.LoadListCustomerType();
            cbCustomerType.DisplayMember = "Name";
        }
        public void LoadDays()
        {
            txbDays.Text = (dpkDateCheckOut.Value.Date - dpkDateCheckIn.Value.Date).Days.ToString();
        }
        public bool IsIdCardExists(string idCard)
        {
            return CustomerDAO.Instance.IsIdCardExists(idCard);
        }
        public void UpdateCustomer()
        {
            int idCustomerType = (cbCustomerType.SelectedItem as CustomerTypeDTO).Id;
            CustomerDAO.Instance.UpdateCustomer(CustomerDAO.Instance.GetInfoByIdCard(idCard).Id, txbFullName.Text, txbIDCard.Text, idCustomerType, int.Parse(txbPhoneNumber.Text), dpkDateOfBirth.Value, txbAddress.Text, cbSex.Text, cbNationality.Text);
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
