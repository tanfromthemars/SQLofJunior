using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class StatusRoomDTO
    {
        private int id;
        private string name;
        public StatusRoomDTO(DataRow row)
        {
            this.Id = (int)row["ID"];
            this.Name = row["Name"].ToString();
        }

        public StatusRoomDTO(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public bool Equals(StatusRoomDTO statusRoomPre)
        {
            return this.name == statusRoomPre.name;
        }
    }
}
