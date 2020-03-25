using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Drank_Service
    {
        private readonly Drank_DAO drank_db = new Drank_DAO();

        public List<Drank> GetDrinks()
        {
            try
            {
                return drank_db.Db_Get_Some_Drinks();
            }
            catch (Exception)
            {
                List<Drank> neplijst = new List<Drank>();

                Drank nietbestaandedrank1 = new Drank(1, "Screwdriver", 1000, 12);

                neplijst.Add(nietbestaandedrank1);

                return neplijst;
            }
        }
        public string StockCheck(Drank d)
        {
            if(d.StockAmount >= 10)
            {
                return "Voldoende voorraad";
            }
            else
            {
                return "Voorraad bijna op!";
            }
        }

        public List<Drank> GetAllDrinks()
        {
            try
            {
                return drank_db.Db_Get_All_Drinks();
            }
            catch(Exception)
            {
                List<Drank> nepdranken = new List<Drank>();

                Drank nepdrank = new Drank(2, "Russian Roulette", 20, 4);

                nepdranken.Add(nepdrank);

                return nepdranken;
            }
        }

        public Drank GetDrankById(int DrankId)
        {
            try
            {
                return drank_db.GetById(DrankId);
            }
            catch (Exception)
            {
                Drank d = new Drank(3, "Nepdrank", 2, 3);

                return d;
            }
        }
    }
}
