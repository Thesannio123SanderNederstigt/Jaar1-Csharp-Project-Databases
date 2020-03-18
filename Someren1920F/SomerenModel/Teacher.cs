using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Teacher
    {

        public int Teachernumber { get; set; }
        public string Teachername { get; set; }
        public string Subject { get; set; }
        public int Teacherroomnumber { get; set; }

        public Teacher(int teachernumber, string teachername, string subject, int teacherroomnumber) //wederom een eigen constructor hier aangemaakt
        {
            this.Teachernumber = teachernumber;
            this.Teachername = teachername;
            this.Subject = subject;
            this.Teacherroomnumber = teacherroomnumber;
        }

    }
}
