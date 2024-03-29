﻿using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class ServiceTypeDAO
    {
        private static ServiceTypeDAO instance;

        internal bool InsertServiceType(string name)
        {
            string query = "USP_InsertServiceType @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { name }) > 0;
        }

        internal bool InsertServiceType(ServiceTypeDTO serviceTypeNow)
        {
            return InsertServiceType(serviceTypeNow.Name);
        }

        internal bool UpdateServiceType(int id, string name)
        {
            string query = "USP_UpdateServiceType @id, @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id, name }) > 0;
        }

        internal bool UpdateServiceType(ServiceTypeDTO serviceTypeNow)
        {
            return UpdateServiceType(serviceTypeNow.Id, serviceTypeNow.Name);
        }

        internal DataTable LoadFullServiceType()
        {
            string query = "USP_LoadFullServiceType";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        internal DataTable Search(string name, int id)
        {
            string query = "USP_SearchServiceType @string , @int";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { name, id });
        }

        public static ServiceTypeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ServiceTypeDAO();
                return instance;
            }
            private set => instance = value;
        }

        public List<ServiceTypeDTO> GetServiceTypes()
        {
            string query = "select * from ServiceType";
            List<ServiceTypeDTO> serviceTypes = new List<ServiceTypeDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ServiceTypeDTO serviceType = new ServiceTypeDTO(item);
                serviceTypes.Add(serviceType);
            }
            return serviceTypes;
        }
    }
}
