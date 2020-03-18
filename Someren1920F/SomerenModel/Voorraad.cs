using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Voorraad
    {
        public int VoorraadNumber{ get; set; }
        public int AmountInStock { get; set; }
        public int DrankNumber { get; set; }

        public Voorraad(int voorraadnumber, int amountinstock, int dranknummer) //wederom een constructor hiervoor
        {
            this.VoorraadNumber = voorraadnumber;
            this.AmountInStock = amountinstock;
            this.DrankNumber = dranknummer;
        }
    }
}
