using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class BillDTO
    {
        private int id;
        private int idReceiveRoom;
        private string staffSetUp;
        private DateTime dateOfCreate;
        private int roomPrice;
        private int servicePrice;
        private int totalPrice;
        private int discount;
        private int idStatusBill;

        public BillDTO(int id, int idReceiveRoom, string staffSetUp, DateTime dateOfCreate, int roomPrice, int servicePrice, int totalPrice, int discount, int idStatusBill)
        {
            this.id = id;
            this.idReceiveRoom = idReceiveRoom;
            this.staffSetUp = staffSetUp;
            this.dateOfCreate = dateOfCreate;
            this.roomPrice = roomPrice;
            this.servicePrice = servicePrice;
            this.totalPrice = totalPrice;
            this.discount = discount;
            this.idStatusBill = idStatusBill;
        }

        public BillDTO(DataRow data)
        {
            this.id = (int)data["id"];
            this.idReceiveRoom = (int)data["idReceiveRoom"];
            this.staffSetUp = data["StaffSetUp"].ToString();
            this.dateOfCreate = (DateTime)data["dataOfCreate"];
            this.roomPrice = (int)data["RoomPrice"];
            this.servicePrice = (int)data["ServicePrice"];
            this.totalPrice = (int)data["TotalPrice"];
            this.discount = (int)data["discount"];
            this.idStatusBill = (int)data["idStatusBill"];
        }

        public int Id { get => id; set => id = value; }
        public int IdReceiveRoom { get => idReceiveRoom; set => idReceiveRoom = value; }
        public string StaffSetUp { get => staffSetUp; set => staffSetUp = value; }
        public DateTime DateOfCreate { get => dateOfCreate; set => dateOfCreate = value; }
        public int RoomPrice { get => roomPrice; set => roomPrice = value; }
        public int ServicePrice { get => servicePrice; set => servicePrice = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
        public int Discount { get => discount; set => discount = value; }
        public int IdStatusBill { get => idStatusBill; set => idStatusBill = value; }
    }
}
