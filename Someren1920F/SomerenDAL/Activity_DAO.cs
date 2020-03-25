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
    public class Activity_DAO : Base
    {
        public List<Activity> GetAllActivities()
        {
            string query = "SELECT Activiteitnummer, omschrijving, aanvangstijd, aantalStudenten, aantalDocenten FROM Activiteit";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadActivities(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Activity> ReadActivities(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();
            
            foreach(DataRow dr in dataTable.Rows)
            {
                int Number = (int)dr["Activiteitnummer"];
                string Description = (string)dr["omschrijving"];
                DateTime StartTime = (DateTime)dr["aanvangstijd"];
                int NumberofStudents = (int)dr["aantalStudenten"];
                int NumberofLecturers = (int)dr["aantalDocenten"];

                Activity activity = new Activity(Number, Description, StartTime, NumberofStudents, NumberofLecturers);

                activities.Add(activity);
            }

            return activities;
        }

        public Activity GetById(int ActivityId)
        {
            string query = "SELECT Activiteitnummer, omschrijving, aanvangstijd, aantalStudenten, aantalDocenten FROM Activiteit WHERE Activiteitnummer = @Id";
            SqlParameter[] sqlParameters = new SqlParameter[] { new SqlParameter("@Id", ActivityId) };
            return ReadActivity(ExecuteSelectQuery(query, sqlParameters));
        }

        private Activity ReadActivity(DataTable dataTable)
        {
            Activity activity = null;

            foreach (DataRow dr in dataTable.Rows)
            {
                int Number = (int)dr["Activiteitnummer"];
                string Description = (string)dr["omschrijving"];
                DateTime StartTime = (DateTime)dr["aanvangstijd"];
                int NumberofStudents = (int)dr["aantalStudenten"];
                int NumberofLecturers = (int)dr["aantalDocenten"];

                activity = new Activity(Number, Description, StartTime, NumberofStudents, NumberofLecturers);

            }

            return activity;
        }

        public int EditActivity(int activiteitid, string description, DateTime starttime, int numberofstudents, int numberoflecturers)
        {
            string query = "UPDATE Activiteit SET omschrijving = @Description, aanvangstijd = @Starttime, aantalStudenten = @NumberofStudents, aantalDocenten = @NumberofLecturers WHERE Activiteitnummer = @Id;";
            SqlParameter[] sqlParameters = new SqlParameter[] { new SqlParameter("@Description", description), new SqlParameter("@Starttime", starttime), new SqlParameter("@NumberofStudents", numberofstudents), new SqlParameter("@NumberofLecturers", numberoflecturers), new SqlParameter("@Id", activiteitid) };
            ExecuteEditQuery(query, sqlParameters);


            int modified = sqlParameters.GetLength(0);
            return modified;
        }

        public int DeleteActivity(int ActivityId)
        {
            string query = "DELETE FROM Activiteit WHERE Activiteitnummer = @Id";
            SqlParameter[] sqlParameters = new SqlParameter[] { new SqlParameter("@Id", ActivityId) };
            ExecuteEditQuery(query, sqlParameters);

            int deleted = sqlParameters.GetLength(0);
            return deleted;
        }

        public int AddActivity(string description, DateTime starttime, int numberofstudents, int numberoflecturers)
        {
            string query = "INSERT Activiteit(omschrijving, aanvangstijd, aantalStudenten, aantalDocenten) VALUES (@Description, @Starttime, @NumberofStudents, @NumberofLecturers)";
            SqlParameter[] sqlParameters = new SqlParameter[] { new SqlParameter("@Description", description), new SqlParameter("@Starttime", starttime), new SqlParameter("@NumberofStudents", numberofstudents), new SqlParameter("@NumberofLecturers", numberoflecturers) };
            ExecuteEditQuery(query, sqlParameters);


            int modified = sqlParameters.GetLength(0);
            return modified;
        }
    }
}
