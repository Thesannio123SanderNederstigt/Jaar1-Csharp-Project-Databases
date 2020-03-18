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
    public class Bestelling_DAO : Base
    {
        public List<Bestelling> GetAllOrders()
        {
            string query = "SELECT Bestellingsnummer, datum, totaalbedrag, Dranknummer, Studentnummer FROM Bestelling;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadOrderTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Bestelling> ReadOrderTables(DataTable dataTable)
        {
            List<Bestelling> orders = new List<Bestelling>();

            foreach(DataRow dr in dataTable.Rows)
            {
                int Number = (int)dr["Bestellingsnummer"];
                DateTime Datum = (DateTime)dr["datum"];
                decimal Total = (decimal)dr["totaalbedrag"];
                int Dranknumber = (int)dr["Dranknummer"];
                int Studentnumber = (int)dr["Studentnummer"];

                Bestelling order = new Bestelling(Number, Datum, Total, Dranknumber, Studentnumber);

                orders.Add(order);
            }

            return orders;
        }

        public int InsertOrder(DateTime datum, decimal bestellingsprijs, int dranknummer, int studentnummer)
        {
            string query = "INSERT Bestelling(datum, totaalbedrag, Dranknummer, Studentnummer) VALUES(@Date, @Price, @DrinkNumber, @StudentNumber)";
            SqlParameter[] sqlParameters = new SqlParameter[] { new SqlParameter("@Date", datum), new SqlParameter("@Price", bestellingsprijs), new SqlParameter("@DrinkNumber", dranknummer), new SqlParameter("@StudentNumber", studentnummer) };
            ExecuteEditQuery(query, sqlParameters);


            int modified = sqlParameters.GetLength(0);
            return modified;
        }

        public int InsertRegister(int Bestellingsnummer, int VoorraadNumber)
        {
            string query = "INSERT Kassascherm(Bestellingsnummer, VoorraadNummer) VALUES(@OrderNumber, @VoorraadNumber)";
            SqlParameter[] sqlParameters = new SqlParameter[] { new SqlParameter("@OrderNumber", Bestellingsnummer), new SqlParameter("@VoorraadNumber", VoorraadNumber) };
            ExecuteEditQuery(query, sqlParameters);


            int modified = sqlParameters.GetLength(0);
            return modified;
        }
    }
}
