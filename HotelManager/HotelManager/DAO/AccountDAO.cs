using HotelManager.DTO;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace HotelManager.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        internal static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return instance;
            }
            private set => instance = value;
        }
        private AccountDAO() { }
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
        internal AccountDTO LoadStaffInfoByUserName(string username)
        {
            //string query = "select * from Staff where UserName=" + username + "";
            //DataTable dataTable = DataProvider.Instace.ExecuteQuery(query);
            string query = "USP_GetNameStaffTypeByUserName @username";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { username });
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
    }
}
