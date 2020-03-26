using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Teacher_Service
    {
        private readonly Teacher_DAO teacher_db = new Teacher_DAO();

        public List<Teacher> GetTeachers()
        {
            try
            {
                return teacher_db.Db_Get_All_Teachers();
            }
            catch(Exception)
            {
                List<Teacher> dummylijst = new List<Teacher>();

                Teacher nietbestaandedocent1 = new Teacher(1, "Nepdocentnaam1", "Nepvak", 1);

                dummylijst.Add(nietbestaandedocent1);

                return dummylijst;
            }

        }

        public Teacher GetTeacherById(int TeacherId)
        {
            try
            {
                return teacher_db.GetById(TeacherId);
            }
            catch(Exception)
            {
                Teacher t = new Teacher(1, "Error", "something went wrong", 1);
                return t;
            }
        }
    }
}
