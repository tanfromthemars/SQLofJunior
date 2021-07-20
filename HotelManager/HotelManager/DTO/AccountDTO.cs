using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class AccountDTO
    {
        private string userName;
        private string displayName;
        private string passWord;
        private int idStaffType;
        private string idCard;
        private DateTime dateOfBirth;
        private string sex;
        private string address;
        private int phoneNumber;
        private DateTime startDay;

        public string UserName { get => userName; set => userName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int IdStaffType { get => idStaffType; set => idStaffType = value; }
        public string IdCard { get => idCard; set => idCard = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Address { get => address; set => address = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateTime StartDay { get => startDay; set => startDay = value; }
        
        public AccountDTO() { }
        public AccountDTO(string userName, string displayName, string passWord, int idStaffType, string idCard, DateTime dateOfBirth, string sex, string address, int phoneNumber, DateTime startDay)
        {
            this.userName = userName;
            this.displayName = displayName;
            this.passWord = passWord;
            this.idStaffType = idStaffType;
            this.idCard = idCard;
            this.dateOfBirth = dateOfBirth;
            this.sex = sex;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.startDay = startDay;
        }

        public AccountDTO(DataRow row)
        {
            this.UserName = row["UserName"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.idStaffType = (int)row["IDStaffType"];
            this.DateOfBirth = (DateTime)row["DateOfBirth"];
            this.Sex = row["Sex"].ToString();
            this.Address = row["Address"].ToString();
            this.PhoneNumber = (int)row["PhoneNumber"];
            this.StartDay = (DateTime)row["StartDay"];
            this.IdCard = (string)row["idCard"];
            this.PassWord = row["PassWord"].ToString();
        }
    }
}
