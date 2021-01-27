using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class CustomerDTO
    {
        private int id;
        private string idCard;
        private string name;
        private int idCustomerType;
        private DateTime dateOfBirth;
        private string address;
        private int phoneNumber;
        private string sex;
        private string nationality;
        public CustomerDTO()
        {

        }

        public CustomerDTO(int id, string idCard, string name, int idCustomerType, DateTime dateOfBirth, string address, int phoneNumber, string sex, string nationality)
        {
            this.id = id;
            this.idCard = idCard;
            this.name = name;
            this.idCustomerType = idCustomerType;
            this.dateOfBirth = dateOfBirth;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.sex = sex;
            this.nationality = nationality;
        }
        public CustomerDTO(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdCard = row["idcard"].ToString();
            this.Name = row["Name"].ToString();
            this.idCustomerType = (int)row["idcustomerType"];
            this.DateOfBirth = (DateTime)row["DateOfBirth"];
            this.Address = row["address"].ToString();
            this.PhoneNumber = (int)row["phoneNumber"];
            this.Sex = row["sex"].ToString();
            this.Nationality = row["Nationality"].ToString();
        }


        public string Address { get => address; set => address = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string IdCard { get => idCard; set => idCard = value; }
        public string Name { get => name; set => name = value; }
        public int IdCustomerType { get => idCustomerType; set => idCustomerType = value; }
        public int Id { get => id; set => id = value; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as CustomerDTO);
        }
        public bool Equals(CustomerDTO customerPre)
        {
            if (customerPre == null)
                return false;
            if (this.idCard != customerPre.idCard)
                return false;
            if (this.idCustomerType != customerPre.idCustomerType)
                return false;
            if (this.Name != customerPre.Name)
                return false;
            if (this.dateOfBirth != customerPre.dateOfBirth)
                return false;
            if (this.address != customerPre.address)
                return false;
            if (this.phoneNumber != customerPre.phoneNumber)
                return false;
            if (this.sex != customerPre.sex)
                return false;
            if (this.nationality != customerPre.nationality)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
