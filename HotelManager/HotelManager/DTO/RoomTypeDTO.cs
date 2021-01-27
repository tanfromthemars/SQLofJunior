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
        public RoomTypeDTO() { }
        public RoomTypeDTO(int id, string name, int price, int limitPerson)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.limitPerson = limitPerson;
        }
        public RoomTypeDTO(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Price = (int)row["price"];
            this.LimitPerson = (int)row["limitPerson"];
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

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public int LimitPerson { get => limitPerson; set => limitPerson = value; }
    }
}
