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
            this.id = (int)row["id"];
            this.idCard = row["idcard"].ToString();
            this.name = row["Name"].ToString();
            this.idCustomerType = (int)row["idcustomerType"];
            this.dateOfBirth = (DateTime)row["DateOfBirth"];
            this.address = row["address"].ToString();
            this.phoneNumber = (int)row["phoneNumber"];
            this.sex = row["sex"].ToString();
            this.nationality = row["Nationality"].ToString();
        }

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
            if (this.DateOfBirth != customerPre.DateOfBirth)
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

        public int Id { get => id; set => id = value; }
        public string IdCard { get => idCard; set => idCard = value; }
        public string Name { get => name; set => name = value; }
        public int IdCustomerType { get => idCustomerType; set => idCustomerType = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Address { get => address; set => address = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Nationality { get => nationality; set => nationality = value; }


    }
}
