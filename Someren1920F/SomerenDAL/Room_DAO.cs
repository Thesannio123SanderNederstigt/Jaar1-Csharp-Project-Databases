using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

namespace SomerenDAL
{
    public class Room_DAO : Base
    {
        public List<Room> Db_Get_All_Rooms()
        {
            string query = "SELECT * FROM Kamer LEFT JOIN Studentenkamer ON Kamer.Kamernummer = Studentenkamer.Kamernummer LEFT JOIN Docentenkamer ON Kamer.Kamernummer = Docentenkamer.Kamernummer;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Room> ReadTables(DataTable dataTable)
        {
            List<Room> rooms = new List<Room>();

            foreach(DataRow dr in dataTable.Rows)
            {
                int Number = (int)dr["Kamernummer"];
                int Capacity = (int)dr["aantal_slaapplekken"];
                object type = (object)dr["Studentkamernummer"];
                object type2 = (object)dr["Docentenkamernummer"];

                bool type3 = false;

                if(type != DBNull.Value)
                {
                    type3 = false;

                }
                else if (type2 != DBNull.Value)
                {
                    type3 = true;
                }


                Room room = new Room(Number, Capacity, type3);

                rooms.Add(room);
            }

            return rooms;
        }
    }
}
