using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class CustomerTypeDAO
    {
        private static CustomerTypeDAO instance;

        private CustomerTypeDAO() { }

        public List<CustomerTypeDTO> LoadListCustomerType()
        {
            string query = "select * from CustomerType";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<CustomerTypeDTO> listCustomerType = new List<CustomerTypeDTO>();
            foreach (DataRow item in data.Rows)
            {
                CustomerTypeDTO customerType = new CustomerTypeDTO(item);
                listCustomerType.Add(customerType);
            }
            return listCustomerType;
        }

        public string GetNameByIdCard(string idCard)
        {
            string query = "USP_GetCustomerTypeNameByIdCard @idCard";
            DataRow dataRow = DataProvider.Instance.ExecuteQuery(query, new object[] { idCard }).Rows[0];
            return dataRow["Name"].ToString();
        }

        internal bool UpdateCustomerType(CustomerTypeDTO customerTypeNow)
        {
            string query = "USP_UpdateCustomerType @id, @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { customerTypeNow.Id, customerTypeNow.Name }) > 0;
        }

        internal DataTable LoadFullCustomerType()
        {
            return DataProvider.Instance.ExecuteQuery("USP_LoadFullCustomerType");
        }

        public static CustomerTypeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CustomerTypeDAO();
                return instance;
            }
            private set => instance = value;
        }
    }
}
