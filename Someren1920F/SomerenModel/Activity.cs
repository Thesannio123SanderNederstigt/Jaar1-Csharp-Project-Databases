using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Activity
    {
        public int Number { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public int NumberofStudents { get; set; }
        public int NumberofLecturers { get; set; }

        public Activity(int activiteitnummer, string omschrijving, DateTime aanvangstijd, int aantalstudenten, int aantaldocenten)
        {
            this.Number = activiteitnummer;
            this.Description = omschrijving;
            this.StartTime = aanvangstijd;
            this.NumberofStudents = aantalstudenten;
            this.NumberofLecturers = aantaldocenten;
        }
        public string ActiviteitcmbBoxToString()
        {
            //hieronder stond eerst: return $"{Number}. {Description}"; omdat dat leuk leek voor de UI, maar dit werkt minder goed icm het kunnen ophalen van activiteitnummers mbv een substring, dus vandaar alleen een nummer hier
            return $"{Number}";
        }
        

    }
}
