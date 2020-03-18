using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Room_Service
    {
        private readonly Room_DAO room_db = new Room_DAO();

        public List<Room> GetRooms()
        {
            try
            {
                return room_db.Db_Get_All_Rooms();
            }
            catch(Exception)
            {
                List<Room> dummylijst = new List<Room>();

                Room nietbestaandekamer1 = new Room(1, 3, false);

                dummylijst.Add(nietbestaandekamer1);

                return dummylijst;
            }
        }
    }
}
