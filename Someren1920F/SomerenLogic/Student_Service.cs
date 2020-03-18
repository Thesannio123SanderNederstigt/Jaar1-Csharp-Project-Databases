using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Student_Service
    {
        private readonly Student_DAO student_db = new Student_DAO();

        public List<Student> GetStudents()
        {
            try
            {
                List<Student> student = student_db.Db_Get_All_Students();
                return student;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Student> student = new List<Student>();
                Student a = new Student(1, "Sander Nederstigt", 1);

                student.Add(a);

                Student b = new Student(2, "Hajk Grigorian", 2);

                student.Add(b);

                return student;
                //throw new Exception("Someren couldn't connect to the database");
            }

        }

        public Student GetStudentById(int studentId)
        {
            try
            {
                return student_db.GetById(studentId);
            }
            catch(Exception)
            {
                Student c = new Student(3, "Timo Korver", 3);
                return c;
            }
        }
    }
}
