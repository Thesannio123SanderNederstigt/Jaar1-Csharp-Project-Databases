using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Begeleider_Service
    {
        private readonly Begeleider_DAO begeleider_db = new Begeleider_DAO();

        public List<Begeleider> GetBegeleiders()
        {
            try
            {
                return begeleider_db.GetAllBegeleiders();
            }
            catch(Exception)
            {
                List<Begeleider> fakebegeleiderlist = new List<Begeleider>();

                Begeleider begeleider = new Begeleider(1, 2, "error", "Something went wrong", 1);

                fakebegeleiderlist.Add(begeleider);

                return fakebegeleiderlist;
            }
        }

        public Begeleider GetBegeleiderById(int BegeleiderId)
        {
            try
            {
                return begeleider_db.GetById(BegeleiderId);
            }
            catch(Exception)
            {
                Begeleider begeleider = new Begeleider(1, 2, "error", "Something went wrong", 1);

                return begeleider;
            }
        }

        public int AddNewBegeleider(int TeacherNumber)
        {
            try
            {
                return begeleider_db.AddBegeleider(TeacherNumber);
            }
            catch (Exception)
            {
                int unaltered = 0;
                return unaltered;
            }
        }

        public int DeleteBegeleider(int BegeleiderId)
        {
            try
            {
                return begeleider_db.DeleteBegeleider(BegeleiderId);
            }
            catch (Exception)
            {
                int unaltered = 0;
                return unaltered;
            }
        }
    }
}
