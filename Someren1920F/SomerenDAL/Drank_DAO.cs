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
    public class Drank_DAO : Base
    {
        public List<Drank> Db_Get_Some_Drinks()
        {
            string query = "SELECT Voorraadnummer, hoeveelheid, Drank.Dranknummer, Drank.dranknaam, Drank.verkoopprijs, Drank.alcoholisch_of_niet, Drank.btw_tarief FROM Voorraad JOIN Drank ON Voorraad.Dranknummer = Drank.Dranknummer WHERE hoeveelheid > 1 AND verkoopprijs > 1 AND dranknaam <> 'Kersensap' AND dranknaam != 'Sinas' AND dranknaam <> 'Water' ORDER BY hoeveelheid DESC, verkoopprijs ASC;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Drank> ReadTables(DataTable dataTable)
        {
            List<Drank> drinks = new List<Drank>();

            foreach (DataRow dr in dataTable.Rows)
            {
                int Number = (int)dr["Dranknummer"];
                string Name = (string)dr["dranknaam"];
                int Amount = (int)dr["hoeveelheid"];
                decimal Price = (decimal)dr["verkoopprijs"];

                Drank drink = new Drank(Number, Name, Amount, Price);

                drinks.Add(drink);
            }

            return drinks;
        }

        public List<Drank> Db_Get_All_Drinks()
        {
            string query = "SELECT Drank.Dranknummer, Drank.dranknaam, hoeveelheid, Drank.verkoopprijs FROM Voorraad JOIN Drank ON Voorraad.Dranknummer = Drank.Dranknummer;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadDrankTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Drank> ReadDrankTables(DataTable dataTable)
        {
            List<Drank> dranken = new List<Drank>();

            foreach(DataRow dr in dataTable.Rows)
            {
                int Number = (int)dr["Dranknummer"];
                string Name = (string)dr["dranknaam"];
                int Amount = (int)dr["hoeveelheid"];
                decimal Price = (decimal)dr["verkoopprijs"];

                Drank drink = new Drank(Number, Name, Amount, Price);

                dranken.Add(drink);
            }

            return dranken;
        }

        public Drank GetById(int DrankId)
        {
            string query = "SELECT Drank.Dranknummer, Drank.dranknaam, hoeveelheid, Drank.verkoopprijs FROM Voorraad JOIN Drank ON Voorraad.Dranknummer = Drank.Dranknummer WHERE Drank.Dranknummer = @Id";
            SqlParameter[] sqlParameters = new SqlParameter[] { new SqlParameter("@Id", DrankId) };

            return ReadDrank(ExecuteSelectQuery(query, sqlParameters));
        }

        private Drank ReadDrank(DataTable dataTable)
        {
            Drank drank = null;

            foreach (DataRow dr in dataTable.Rows)
            {
                int Number = (int)dr["Dranknummer"];
                string Name = (string)dr["dranknaam"];
                int Amount = (int)dr["hoeveelheid"];
                decimal Price = (decimal)dr["verkoopprijs"];

                drank = new Drank(Number, Name, Amount, Price);

            }

            return drank;
        }
    }
}
