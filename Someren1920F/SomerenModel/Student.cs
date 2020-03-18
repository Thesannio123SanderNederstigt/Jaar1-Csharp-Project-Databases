using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Student
    { 
        public int Studentnumber { get; set; }
        public string Studentname { get; set; }
        public int Studentroomnumber { get; set; }

        public Student(int studentnumber, string studentname, int studentroomnumber) //eigen aangemaakte Constructor
        {
            this.Studentnumber = studentnumber;
            this.Studentname = studentname;
            this.Studentroomnumber = studentroomnumber;
        }

    }
}
