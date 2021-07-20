using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    class AccessDAO
    {
        private static AccessDAO instance = new AccessDAO();
        internal static AccessDAO Instance { get => instance; }
        private AccessDAO() { }
        internal bool CheckAccess(string username, string formName)
        {
            string query = "USP_CheckAccess @username, @formname";
            return !(DataProvider.Instance.ExecuteScalar(query, new object[] { username, formName }) is null);
        }
        public DataTable GetFullAccessNow(int idStaffType)
        {
            string query = "USP_LoadFullAccessNow @idStaffType";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idStaffType });
        }
    }
}
