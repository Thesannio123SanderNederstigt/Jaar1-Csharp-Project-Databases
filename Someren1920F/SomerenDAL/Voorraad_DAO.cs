using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

namespace SomerenDAL
{
    public class Voorraad_DAO : Base
    {
        public Voorraad GetById(int DrankId)
        {
            string query = "SELECT Voorraadnummer, hoeveelheid, Dranknummer FROM Voorraad WHERE Dranknummer = @Id";
            SqlParameter[] sqlParameters = new SqlParameter[] { new SqlParameter("@Id", DrankId) };
            return ReadStock(ExecuteSelectQuery(query, sqlParameters));
        }

        private Voorraad ReadStock(DataTable dataTable)
        {
            Voorraad voorraad = null;

            foreach (DataRow dr in dataTable.Rows)
            {
                int StockNumber = (int)dr["Voorraadnummer"];
                int Amount = (int)dr["hoeveelheid"];
                int DrinkNumber = (int)dr["Dranknummer"];

                voorraad = new Voorraad(StockNumber, Amount, DrinkNumber);

            }

            return voorraad;
        }
    }
}
