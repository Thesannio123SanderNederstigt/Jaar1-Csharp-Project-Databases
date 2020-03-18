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
    public class Student_DAO : Base
    {
      
        public List<Student> Db_Get_All_Students()
        {
            string query = "SELECT Studentnummer, studentnaam, Studentkamernummer FROM Student";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadTables(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            foreach (DataRow dr in dataTable.Rows)
            {
                int Number = (int)dr["Studentnummer"];
                string Name = (string)dr["studentnaam"];
                int Roomnumber = (int)dr["Studentkamernummer"];

                Student student = new Student(Number, Name, Roomnumber);

                students.Add(student);
            }

            return students;
        }

        public Student GetById(int studentId)
        {
            string query = "SELECT Studentnummer, studentnaam, Studentkamernummer FROM Student WHERE Studentnummer = @Id";
            SqlParameter[] sqlParameters = new SqlParameter[] { new SqlParameter("@Id", studentId) };

            return ReadStudent(ExecuteSelectQuery(query, sqlParameters));
        }

        private Student ReadStudent(DataTable dataTable)
        {
            Student student = null;

            foreach(DataRow dr in dataTable.Rows)
            {
                int Number = (int)dr["Studentnummer"];
                string Name = (string)dr["studentnaam"];
                int Roomnumber = (int)dr["Studentkamernummer"];

                student = new Student(Number, Name, Roomnumber);
            }

            return student;
        }
    }
}
