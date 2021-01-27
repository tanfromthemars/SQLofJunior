using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        internal string HashPass(string text)
        {
            MD5 md5 = MD5.Create();
            byte[] temp = Encoding.ASCII.GetBytes(text);
            byte[] hashData = md5.ComputeHash(temp);
            string hashPass = "";
            foreach (var item in hashData)
            {
                hashPass += item.ToString("x2");
            }
            return hashPass;
        }
        internal bool Login(string userName, string passWord)
        {
            string hashPass = HashPass(passWord);
            string query = "USP_Login @userName, @passWord";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, hashPass });
            return data.Rows.Count > 0;
        }
        internal AccountDTO LoadStaffInforByUserName(string username)
        {
            string query = "SELECT * FROM Staff WHERE UserName='" + username + "'";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            AccountDTO account = new AccountDTO(dataTable.Rows[0]);
            return account;
        }
        internal bool IsIdCardExists(string idCard)
        {
            string query = "USP_IsIdCardExistsAcc @idCard";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idCard }).Rows.Count > 0;
        }
        internal bool UpdateDisplayName(string username, string displayname)
        {
            string query = "USP_UpdateDisplayName @username, @displayname";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { username, displayname }) > 0;
        }
        internal bool UpdatePassword(string username, string password)
        {
            string query = "USP_UpdatePassword @username, @password";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { username, HashPass(password) }) > 0;
        }
        internal bool UpdateInfo(string username, string address, int phonenumber, string idCard, DateTime dateOfBirth, string sex)
        {
            string query = "USP_UpdateInfo @username, @address, @phonenumber, @idcard, @dateOfBirh, @sex";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { username, address, phonenumber, idCard, dateOfBirth, sex }) > 0;
        }
        internal AccountDTO GetStaffSetUp(int idBill)
        {
            string query = "USP_GetStaffSetUp @idBill";
            AccountDTO account = new AccountDTO(DataProvider.Instance.ExecuteQuery(query, new object[] { idBill }).Rows[0]);
            return account;
        }
        internal DataTable LoadFullStaff()
        {
            string query = "USP_LoadFullStaff";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        internal bool InsertAccount(AccountDTO account)
        {
            string query = "EXEC USP_InsertStaff @user, @name, @pass, @idStaffType, @idCard, @dateOfBirh, @sex, @address, @phoneNumber, @startDay";
            object[] parameter = new object[] { account.UserName, account.DisplayName, account.PassWord, account.IdStaffType,
            account.IdCard, account.DateOfBirth, account.Sex,
            account.Address, account.PhoneNumber, account.StartDay };
            return DataProvider.Instance.ExecuteNoneQuery(query, parameter) > 0;
        }
        internal bool UpdateAccount(AccountDTO account)
        {
            string query = "EXEC USP_UpdateStaff @user, @name, @idStaffType, @idCard, @dateOfBirth, @sex, @address, @phoneNumber, @startDay";
            object[] parameter = new object[] { account.UserName, account.DisplayName, account.IdStaffType,
            account.IdCard, account.DateOfBirth, account.Sex,
            account.Address, account.PhoneNumber, account.StartDay };
            return DataProvider.Instance.ExecuteNoneQuery(query, parameter) > 0;
        }
        internal bool ResetPassword(string user, string hashPass)
        {
            string query = "USP_UpdatePassword @user, @hashPass";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { user, hashPass }) > 0;
        }

        internal DataTable Search(string @string, int phoneNumber)
        {
            string query = "USP_SearchStaff @string, @int";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { @string, phoneNumber });
        }
        internal static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return instance;
            }
            set => instance = value;
        }
    }
}
