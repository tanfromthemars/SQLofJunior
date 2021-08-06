using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class ServiceDTO
    {
        int id;
        string name;
        int idServiceType;
        int price;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int IdServiceType { get => idServiceType; set => idServiceType = value; }
        public int Price { get => price; set => price = value; }

        public ServiceDTO() { }

        public ServiceDTO(int id, string name, int idServiceType, int price)
        {
            this.id = id;
            this.name = name;
            this.idServiceType = idServiceType;
            this.price = price;
        }

        public ServiceDTO(DataRow data)
        {
            this.id = (int)data["id"];
            this.name = data["Name"].ToString();
            this.idServiceType = (int)data["idServiceType"];
            this.price = (int)data["Price"];
        }

        public bool Equals(ServiceDTO servicePre)
        {
            if (servicePre == null)
                return false;
            if (servicePre.idServiceType != this.idServiceType)
                return false;
            if (servicePre.name != this.name)
                return false;
            if (servicePre.price != this.price)
                return false;
        }
    }
}
