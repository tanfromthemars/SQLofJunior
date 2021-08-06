using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class CustomerTypeDTO
    {
        private int id;
        private string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public CustomerTypeDTO(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public CustomerTypeDTO(DataRow row)
        {
            this.id = (int)row["id"];
            this.name = row["Name"].ToString();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CustomerTypeDTO);
        }

        public bool Equals(CustomerTypeDTO customerTypePre)
        {
            if (customerTypePre == null)
                return false;
            return (this.name == customerTypePre.name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
