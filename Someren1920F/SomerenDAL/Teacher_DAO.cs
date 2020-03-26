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
    public class Teacher_DAO : Base
    {
        public List<Teacher> Db_Get_All_Teachers()
        {
            string query = "SELECT Docentnummer, docentnaam, schoolvak, Docentenkamernummer FROM Docent";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Teacher> ReadTables(DataTable dataTable)
        {
            List<Teacher> teachers = new List<Teacher>();

            foreach(DataRow dr in dataTable.Rows)
            {
                int Number = (int)dr["Docentnummer"];
                string Name = (string)dr["docentnaam"];
                string Subject = (string)dr["schoolvak"];
                int Roomnumber = (int)dr["Docentenkamernummer"];

                Teacher teacher = new Teacher(Number, Name, Subject, Roomnumber);

                teachers.Add(teacher);
            }

            return teachers;
        }

        public Teacher GetById(int TeacherId)
        {
            string query = "SELECT Docentnummer, docentnaam, schoolvak, Docentenkamernummer FROM Docent WHERE Docentnummer = @Id";
            SqlParameter[] sqlParameters = new SqlParameter[] { new SqlParameter("@Id", TeacherId) };
            return ReadTeacher(ExecuteSelectQuery(query, sqlParameters));
        }

        private Teacher ReadTeacher(DataTable dataTable)
        {
            Teacher teacher = null;

            foreach(DataRow dr in dataTable.Rows)
            {
                int Number = (int)dr["Docentnummer"];
                string Name = (string)dr["docentnaam"];
                string Subject = (string)dr["schoolvak"];
                int Roomnumber = (int)dr["Docentenkamernummer"];

                teacher = new Teacher(Number, Name, Subject, Roomnumber);
            }

            return teacher;
        }
    }
}
