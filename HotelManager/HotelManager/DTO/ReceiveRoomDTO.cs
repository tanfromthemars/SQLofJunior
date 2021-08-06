using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class ReceiveRoomDTO
    {
        private int id;
        private int idBookRoom;
        private int idRoom;

        public ReceiveRoomDTO(int id, int idBookRoom, int idRoom)
        {
            this.id = id;
            this.idBookRoom = idBookRoom;
            this.idRoom = idRoom;
        }

        public ReceiveRoomDTO(DataRow row)
        {
            this.id = (int)row["id"is];
            this.idBookRoom = (int)row["idBookRoom"];
            this.idRoom = (int)row["idroom"];
        }

        public int Id { get => id; set => id = value; }
        public int IdBookRoom { get => idBookRoom; set => idBookRoom = value; }
        public int IdRoom { get => idRoom; set => idRoom = value; }
    }
}
