using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Bestelling_Kassa_Service
    {
        private readonly Bestelling_DAO bestelling_db = new Bestelling_DAO();

        public List<Bestelling> GetOrders()
        {
            try
            {
                return bestelling_db.GetAllOrders();
            }
            catch(Exception)
            {
                List<Bestelling> fakeorderlist = new List<Bestelling>();

                Bestelling neporder = new Bestelling(1, DateTime.Now, 2, 1, 1);

                fakeorderlist.Add(neporder);

                return fakeorderlist;

            }
        }

        public int PlaceOrder(DateTime datum, decimal bestellingsprijs, int dranknummer, int studentnummer)
        {
            try
            {
                return bestelling_db.InsertOrder(datum, bestellingsprijs, dranknummer, studentnummer);
            }
            catch(Exception)
            {
                int unaltered = 0;
                return unaltered;
            }
        }

        public int RegisterOrder(int Bestellingsnummer, int VoorraadNummer)
        {
            try
            {
                return bestelling_db.InsertRegister(Bestellingsnummer, VoorraadNummer);
            }
            catch(Exception)
            {
                int unaltered = 0;
                return unaltered;
            }
        }

        public bool ValidDateRangeCheck(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate || startDate > DateTime.Now || endDate > DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Bestelling> GetRangedOrders(DateTime startDate, DateTime endDate)
        {
            try
            {
                return bestelling_db.GetRangeOfOrders(startDate, endDate);
            }
            catch (Exception)
            {
                List<Bestelling> fakeorderlist2 = new List<Bestelling>();

                Bestelling neporder2 = new Bestelling(1, DateTime.Now, 2, 1, 1);

                fakeorderlist2.Add(neporder2);

                return fakeorderlist2;

            }
        }
    }
}
