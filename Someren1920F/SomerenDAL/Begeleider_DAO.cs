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
    public class Begeleider_DAO : Base
    {
        public List<Begeleider> GetAllBegeleiders()
        {
            string query = "SELECT Begeleidernummer, Docent.Docentnummer, docentnaam, schoolvak, Docentenkamernummer FROM Begeleider JOIN Docent ON Begeleider.DocentNummer = Docent.Docentnummer";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadBegeleiders(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Begeleider> ReadBegeleiders(DataTable dataTable)
        {
            List<Begeleider> begeleiders = new List<Begeleider>();

            foreach(DataRow dr in dataTable.Rows)
            {
                int BegeleiderNumber = (int)dr["Begeleidernummer"];
                int TeacherNumber = (int)dr["Docentnummer"];
                string TeacherName = (string)dr["docentnaam"];
                string Subject = (string)dr["schoolvak"];
                int RoomNumber = (int)dr["Docentenkamernummer"];

                Begeleider begeleider = new Begeleider(BegeleiderNumber, TeacherNumber, TeacherName, Subject, RoomNumber);

                begeleiders.Add(begeleider);
            }

            return begeleiders;
        }

        public Begeleider GetById(int BegeleiderId)
        {
            string query = "SELECT Begeleidernummer, Docent.Docentnummer, docentnaam, schoolvak, Docentenkamernummer FROM Begeleider JOIN Docent ON Begeleider.DocentNummer = Docent.Docentnummer WHERE Begeleidernummer = @Id";
            SqlParameter[] sqlParameters = new SqlParameter[] { new SqlParameter("@Id", BegeleiderId) };
            return ReadBegeleider(ExecuteSelectQuery(query, sqlParameters));
        }

        private Begeleider ReadBegeleider(DataTable dataTable)
        {
            Begeleider begeleider = null;

            foreach(DataRow dr in dataTable.Rows)
            {
                int BegeleiderNumber = (int)dr["Begeleidernummer"];
                int TeacherNumber = (int)dr["Docentnummer"];
                string TeacherName = (string)dr["docentnaam"];
                string Subject = (string)dr["schoolvak"];
                int RoomNumber = (int)dr["Docentenkamernummer"];

                begeleider = new Begeleider(BegeleiderNumber, TeacherNumber, TeacherName, Subject, RoomNumber);
            }

            return begeleider;
        }

        public int AddBegeleider(int TeacherNumber)
        {
            string query = "INSERT Begeleider(DocentNummer) VALUES (@Teachernumber)";
            SqlParameter[] sqlParameters = new SqlParameter[] { new SqlParameter("@Teachernumber", TeacherNumber) };
            ExecuteEditQuery(query, sqlParameters);


            int modified = sqlParameters.GetLength(0);
            return modified;
        }

        public int DeleteBegeleider(int BegeleiderId)
        {
            string query = "DELETE FROM Begeleider WHERE Begeleidernummer = @Id";
            SqlParameter[] sqlParameters = new SqlParameter[] { new SqlParameter("@Id", BegeleiderId) };
            ExecuteEditQuery(query, sqlParameters);

            int deleted = sqlParameters.GetLength(0);
            return deleted;
        }
    }
}
