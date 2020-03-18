using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Drank
    {
        public int DrankNumber { get; set; }
        public string DrankName { get; set; }
        public int StockAmount { get; set; }
        public decimal Price { get; set; }

        public Drank(int dranknummer, string dranknaam, int stockamount, decimal price) //wederom een constructor hiervoor
        {
            this.DrankNumber = dranknummer;
            this.DrankName = dranknaam;
            this.StockAmount = stockamount;
            this.Price = price;
        }

        /*public override string ToString()
        {
            return $"{DrankName} met {StockAmount} op voorraad met een prijs van {Price} per stuk";
        }*/
    }
}
