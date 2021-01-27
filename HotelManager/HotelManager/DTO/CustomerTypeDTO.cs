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
        public CustomerTypeDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public CustomerTypeDTO(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["Name"].ToString();
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
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
