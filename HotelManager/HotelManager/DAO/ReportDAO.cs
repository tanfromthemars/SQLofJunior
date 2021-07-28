using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class ReportDAO
    {
        private static ReportDAO instance;
        public static ReportDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ReportDAO();
                return instance;
            }
        }
        private ReportDAO() { }

        public DataTable LoadFullReport(int month, int year)
        {
            string query = "USP_LoadFullReport @month, @year";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { month, year });
        }

        public bool InsertReport(int idBill)
        {
            return DataProvider.Instance.ExecuteNoneQuery("USP_InsertReport @idBill", new object[] { idBill }) > 0;
        }
    }
}
