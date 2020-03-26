using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Begeleider : Teacher
    {
        public int Begeleidernummer { get; set; }

        public Begeleider(int begeleidernummer, int teachernumber, string teachername, string subject, int teacherroomnumber) : base(teachernumber, teachername, subject, teacherroomnumber)
        {
            this.Begeleidernummer = begeleidernummer;
        }

    }
}
