using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class RoomDTO
    {
        private int id;
        private string name;
        private int idRoomType;
        private int idStatusRoom;

        public RoomDTO(int id, string name, int idRoomType, int idStatusRoom)
        {
            this.id = id;
            this.name = name;
            this.idRoomType = idRoomType;
            this.idStatusRoom = idStatusRoom;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int IdRoomType { get => idRoomType; set => idRoomType = value; }
        public int IdStatusRoom { get => idStatusRoom; set => idStatusRoom = value; }

        public RoomDTO(DataRow row)
        {
            this.id = (int)row["ID"];
            this.name = row["Name"].ToString();
            this.idRoomType = (int)row["idRoomType"];
            this.idStatusRoom = (int)row["idStatusRoom"];
        }

        public bool Equals(RoomDTO roomPre)
        {
            if (roomPre == null)
                return false;
            if (roomPre.id != this.id)
                return false;
            if (roomPre.Name != this.Name)
                return false;
            if (roomPre.idRoomType != this.idRoomType)
                return false;
            if (roomPre.idStatusRoom != this.idStatusRoom)
                return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as RoomDTO);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
