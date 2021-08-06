using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class ReceiveRoomDetailsDTO
    {
        private int idReceiveRoom;
        private int idCustomerOther;
        public ReceiveRoomDetailsDTO(DataRow row)
        {
            this.idReceiveRoom = (int)row["idReceiveRoom"];
            this.idCustomerOther = (int)row["idCustomerOther"];
        }

        public ReceiveRoomDetailsDTO(int idReceiveRoom, int idCustomerOther)
        {
            this.idReceiveRoom = idReceiveRoom;
            this.idCustomerOther = idCustomerOther;
        }

        public int IdReceiveRoom { get => idReceiveRoom; set => idReceiveRoom = value; }
        public int IdCustomerOther { get => idCustomerOther; set => idCustomerOther = value; }
    }
}
