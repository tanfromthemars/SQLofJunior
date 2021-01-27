using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    class AccountTypeDAO
    {
        private static AccountTypeDAO instance;
        #region method
        internal DataTable LoadFullStaffType()
        {
            string query = "USP_LoadFullStaffType";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public AccountTypeDTO GetStaffTypeByUserName(string username)
        {
            string query = "USP_GetNameStaffTypeByUserName @username";
            AccountTypeDTO staffType = new AccountTypeDTO(DataProvider.Instance.ExecuteQuery(query, new object[] { username }).Rows[0]);
            return staffType;
        }
        internal bool Delete(int idStaffType)
        {
            string query = "USP_DeleteStaffType @id";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idStaffType }) > 0;
        }
        internal bool Update(int idStaffType, string text)
        {
            string query = "USP_UpdateStaffType @id, @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idStaffType, text }) > 0;
        }
        internal bool Insert(string text)
        {
            string query = "USP_InsertStaffType @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { text }) > 0;
        }
        #endregion
        public static AccountTypeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountTypeDAO();
                return instance;
            }
            private set => instance = value;
        }
    }
}
