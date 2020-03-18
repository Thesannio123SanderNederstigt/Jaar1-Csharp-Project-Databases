using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Voorraad_Service
    {
        private readonly Voorraad_DAO voorraad_db = new Voorraad_DAO();

        public Voorraad GetVoorraadByDrankId(int DrankId)
        {
            try
            {
                return voorraad_db.GetById(DrankId);
            }
            catch (Exception)
            {
                Voorraad v = new Voorraad(1, 1, 1);
                return v;
            }
        }
    }
}
