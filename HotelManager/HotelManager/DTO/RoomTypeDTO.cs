using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class RoomTypeDTO
    {
        private int id;
        private string name;
        private int price;
        private int limitPerson;

        public RoomTypeDTO(int id, string name, int price, int limitPerson)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.limitPerson = limitPerson;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public int LimitPerson { get => limitPerson; set => limitPerson = value; }

        public RoomTypeDTO(DataRow row)
        {
            this.id = (int)row["id"];
            this.name = row["name"].ToString();
            this.price = (int)row["price"];
            this.limitPerson = (int)row["limitPerson"];
        }

        public bool Equals(RoomTypeDTO roomTypePre)
        {
            if (roomTypePre == null)
                return false;
            if (this.name != roomTypePre.name)
                return false;
            if (this.price != roomTypePre.price)
                return false;
            if (this.limitPerson != roomTypePre.limitPerson)
                return false;
            return true;
        }

    }
}
