using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexiónBaseDeDatosAbstracta
{
    public class ConsultaDeBeers : ConexionAbstracta
    {
        //como hereda de la conexión, hay que implementar y pasar datos del constructor 
        public ConsultaDeBeers(string server, string db, string user, string password) :
            base(server, db, user, password)
        {
            
        }

        public List<Beer> ConsultaTodo()
        {
            Open();

            List<Beer> beers = new List<Beer>(); //lista para almacenar cada linea del SELCT
            string query = "SELECT * FROM BEER"; //Query SQL a ejecutar
            SqlCommand command = new SqlCommand(query, _connection); //comando
            SqlDataReader reader = command.ExecuteReader(); // ejecución y lectura del resultado
            while (reader.Read()) //while especial para ir leyendo el resultado linea a linea hasta el final
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int brandId = reader.GetInt32(2);
                beers.Add(new Beer(id, name, brandId)); //creo el objeto y lo añado a la lista
            }

            Close();

            return beers;
        }
    }
}
