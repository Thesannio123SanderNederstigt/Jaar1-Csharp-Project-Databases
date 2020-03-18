using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Bestelling
    {
        public int Bestellingsnummer {get; set;}
        public DateTime Datum { get; set; }
        public decimal Bestellingsprijs { get; set; }
        public int Dranknummer { get; set; }
        public int Studentnummer { get; set; }

        public Bestelling(int bestellingsnummer, DateTime datum, decimal bestellingsprijs, int dranknummer, int studentnummer)
        {
            this.Bestellingsnummer = bestellingsnummer;
            this.Datum = datum;
            this.Bestellingsprijs = bestellingsprijs;
            this.Dranknummer = dranknummer;
            this.Studentnummer = studentnummer;
        }
    }
}
