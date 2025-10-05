using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos
{
    public class BeerDB : myConnection
    {

        public BeerDB(string server, string databaseName)
               : base(server, databaseName)
        { 
        
        }
        

        public List<Beer> GetAll()
        {
            Connect();
            List<Beer> beers = new List<Beer>();
            string query = "SELECT ID, NAME, BRAND_ID FROM BEER";
            SqlCommand command = new SqlCommand(query, _connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int brand_id = reader.GetInt32(2);
                beers.Add(new Beer(id, name, brand_id));

            }
            Connect();
            return beers;
        }
    }
}
