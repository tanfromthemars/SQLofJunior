using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class RoomDAO
    {
        private static RoomDAO instance;

        internal DataTable LoadFullRoom()
        {
            return DataProvider.Instance.ExecuteQuery("USP_LoadFullRoom");
        }


        internal bool InsertRoom(string roomName, int idRoomType, int idStatusRoom)
        {
            string query = "USP_InsertRoom @nameRoom, @idRoomType, @idStatusRoom";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { roomName, idRoomType, idStatusRoom }) > 0;
        }
        internal bool InsertRoom(RoomDTO roomNow)
        {
            return InsertRoom(roomNow.Name, roomNow.IdRoomType, roomNow.IdStatusRoom);
        }

        internal bool UpdateCustomer(RoomDTO roomNow)
        {
            string query = "USP_UpdatetRoom @id, @nameRoom, @idRoomType, @idStatusRoom";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { roomNow.Id, roomNow.Name, roomNow.IdRoomType, roomNow.IdStatusRoom }) > 0;
        }

        internal DataTable Search(string text, int id)
        {
            string query = "USP_SearchRoom @string, @id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { text, id });
        }

        public List<RoomDTO> LoadEmptyRoom(int idRoomType)
        {
            List<RoomDTO> rooms = new List<RoomDTO>();
            string query = "USP_LoadEmptyRoom @idRoomType";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idRoomType });
            foreach (DataRow item in data.Rows)
            {
                RoomDTO room = new RoomDTO(item);
                rooms.Add(room);
            }
            return rooms;
        }

        public List<RoomDTO> LoadListFullRoom()
        {
            string query = "USP_LoadListFullRoom @getToday";
            List<RoomDTO> rooms = new List<RoomDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { DateTime.Now.Date });
            foreach (DataRow item in data.Rows)
            {
                RoomDTO room = new RoomDTO(item);
                rooms.Add(room);
            }
            return rooms;
        }

        public int GetPeoples(int idBill)
        {
            string query = "USP_GetPeoples @idBill";
            return (int)DataProvider.Instance.ExecuteScalar(query, new object[] { idBill }) + 1;
        }

        public int GetIdRoomFromReceiveRoom(int idReceiveRoom)
        {
            string query = "USP_GetIDRoomFromReceiveRoom @idReceiveRoom";
            return (int)DataProvider.Instance.ExecuteScalar(query, new object[] { idReceiveRoom });
        }

        public bool UpdateStatusRoom(int idRoom)
        {
            string query = "USP_UpdateStatusRoom @idRoom";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idRoom }) > 0;
        }

        public static RoomDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new RoomDAO();
                return instance;
            }
            private set => instance = value;
        }
        private RoomDAO() { }
    }
}
