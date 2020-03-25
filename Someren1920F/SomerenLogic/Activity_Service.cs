using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Activity_Service
    {
        private readonly Activity_DAO activiteit_db = new Activity_DAO();

        public List<Activity> GetActivities()
        {
            try
            {
                return activiteit_db.GetAllActivities();
            }
            catch(Exception)
            {
                List<Activity> fakeactivitylist = new List<Activity>();

                Activity fakeactivity = new Activity(1, "generic error occured", DateTime.Now, 1, 1);

                fakeactivitylist.Add(fakeactivity);

                return fakeactivitylist;
            }
        }

        public Activity GetActivityById(int ActivityId)
        {
            try
            {
                return activiteit_db.GetById(ActivityId);
            }
            catch(Exception)
            {
                Activity a = new Activity(1, "an error occured", DateTime.Now, 1, 1);

                return a;
            }
        }

        public int EditActivity(int activiteitid, string description, DateTime starttime, int numberofstudents, int numberoflecturers)
        {
            try
            {
                return activiteit_db.EditActivity(activiteitid, description, starttime, numberofstudents, numberoflecturers);
            }
            catch (Exception)
            {
                {
                    int unaltered = 0;
                    return unaltered;
                }
            }
        }

        public int DeleteActivity(int ActivityId)
        {
            try
            {
                return activiteit_db.DeleteActivity(ActivityId);
            }
            catch(Exception)
            {
                int unaltered = 0;
                return unaltered;
            }
        }
        public int AddNewActivity(string Description, DateTime StartTime, int NumberofStudents, int NumberofLecturers)
        {
            try
            {
                return activiteit_db.AddActivity(Description, StartTime, NumberofStudents, NumberofLecturers);
            }
            catch (Exception)
            {
                int unaltered = 0;
                return unaltered;
            }
        }
    }
}
