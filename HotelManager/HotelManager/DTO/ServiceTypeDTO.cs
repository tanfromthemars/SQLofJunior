using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class ServiceTypeDTO
    {
        private int id;
        private string name;
        public ServiceTypeDTO() { }

        public ServiceTypeDTO(DataRow dataRow)
        {
            this.id = (int)dataRow["id"];
            this.name = dataRow["name"].ToString();
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public bool Equals(ServiceTypeDTO serviceTypePre)
        {
            return this.name == serviceTypePre.name;
        }
    }
}
