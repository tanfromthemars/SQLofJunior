using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class BookRoomDTO
    {
        private int id;
        private int idCustomer;
        private int idRoomType;
        private DateTime dateCheckIn;
        private DateTime dateCheckOut;
        private DateTime dateBookRoom;

        public BookRoomDTO(int id, int idCustomer, int idRoomType, DateTime dateCheckIn, DateTime dateCheckOut, DateTime dateBookRoom)
        {
            this.id = id;
            this.idCustomer = idCustomer;
            this.idRoomType = idRoomType;
            this.dateCheckIn = dateCheckIn;
            this.dateCheckOut = dateCheckOut;
            this.dateBookRoom = dateBookRoom;
        }

        public BookRoomDTO(DataRow row)
        {
            this.id = (int)row["id"];
            this.idCustomer = (int)row["idCustomer"];
            this.idRoomType = (int)row["IdRoomType"];
            this.dateCheckIn = (DateTime)row["DateCheckIn"];
            this.dateCheckOut = (DateTime)row["DateCheckOut"];
            this.dateBookRoom = (DateTime)row["DateBookRoom"];
        }

        public int Id { get => id; set => id = value; }
        public int IdCustomer { get => idCustomer; set => idCustomer = value; }
        public int IdRoomType { get => idRoomType; set => idRoomType = value; }
        public DateTime DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public DateTime DateBookRoom { get => dateBookRoom; set => dateBookRoom = value; }
    }
}
