using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class RoomTypeDAO
    {
        private static RoomTypeDAO instance;
        #region Method
        internal DataTable LoadFullRoomType()
        {
            return DataProvider.Instance.ExecuteQuery("USP_LoadFullRoomType");
        }
        internal bool InsertRoomType(string name, int price, int limitPerson)
        {
            string query = "USP_InsertRoomType @name, @price, @limitPerson";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { name, price, limitPerson }) > 0;
        }
        internal bool InsertRoomType(RoomTypeDTO roomTypeNow)
        {
            return InsertRoomType(roomTypeNow.Name, roomTypeNow.Price, roomTypeNow.LimitPerson);
        }
        internal bool UpdateRoomType(RoomTypeDTO roomNow, RoomTypeDTO roomPre)
        {
            string query = "USP_UpdateRoomType @id, @name, @price, @limitPerson";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { roomNow.Id, roomNow.Name, roomNow.Price, roomNow.LimitPerson }) > 0;
        }
        internal DataTable Search(string text, int id)
        {
            string query = "USP_SearchRoomType @string, @id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { text, id });
        }
        internal int GetMaxPersonByRoomType(int idRoomType)
        {
            string query = "USP_GetMaxPersonByRoomType @idRoomType";
            DataRow data = DataProvider.Instance.ExecuteQuery(query, new object[] { idRoomType }).Rows[0];
            return Convert.ToInt32((double)data["Value"]);
        }
        public static RoomTypeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new RoomTypeDAO();
                return instance;
            }
            private set => instance = value;
        }
        public RoomTypeDAO()
        {

        }
        public RoomTypeDTO LoadRoomTypeInfo(int id)
        {
            string query = "USP_RoomTypeInfo @id";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            RoomTypeDTO roomType = new RoomTypeDTO(data.Rows[0]);
            return roomType;
        }
        public List<RoomTypeDTO> LoadListRoomType()
        {
            string query = "select * from RoomType";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<RoomTypeDTO> listRoomType = new List<RoomTypeDTO>();
            foreach (DataRow item in data.Rows)
            {
                RoomTypeDTO roomType = new RoomTypeDTO(item);
                listRoomType.Add(roomType);
            }
            return listRoomType;
        }
        public RoomTypeDTO GetRoomTypeByIdRoom(int idRoom)
        {
            string query = "USP_GetRoomTypeByIdRoom @idRoom";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom });
            RoomTypeDTO roomType = new RoomTypeDTO(data.Rows[0]);
            return roomType;
        }
        public RoomTypeDTO GetRoomTypeByIdBookRoom(int idBookRoom)
        {
            string query = "USP_GetRoomTypeByIdBookRoom @idBookRoom";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idBookRoom });
            RoomTypeDTO roomType = new RoomTypeDTO(data.Rows[0]);
            return roomType;
        }
        #endregion
    }
}
