using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexiónBaseDeDatosMenu
{
    internal class OperaciónBaseDeDatos : ConexiónAbstracta
    {
        public OperaciónBaseDeDatos(string server, string db, string user, string password) :
            base(server, db, user, password)
        {
            
        }


        //Método para hacer un SELECT a toda la tabla - retorna una lista<Beer>
        public List<Beer> ConsultarTodo()
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

        /*
         * Nota: Cuando se manda a ejecutar un comando "command" SQL que no retorna ningún
         * resultado de la base de datos, se usa el ----  command.ExecuteNonQuery();  ----
         * cuando si retorna un resultado, se usa un reader ----   SqlDataReader reader = command.ExecuteReader();  ----
         * en el reader de tipo SqlDataReader se almancena el resultado en lineas, por lo que
         * se tiene que iterar con ----  reader.Read()  ---- para obtener los resultados.
         * 
         * 
         * 
         * Otra cosa es que los queries usan parámetros tipo ----  @algo @otro  ---- que 
         * posteriormente se llenan con ----  command.Parameters.AddWithValue("@PARAMETRO", var_valor);  ----
         * con el objetivo de proteger de inyección de código SQL la consulta.
         */



        //Método que inserta INSERT una cerveza
        public void Insertar(Beer beer)
        {
            Open();

            string query = "INSERT INTO BEER (NAME, BRAND_ID) VALUES (@NAME, @BRAND_ID)";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@NAME", beer.name);
            command.Parameters.AddWithValue("@BRAND_ID", beer.brandID);
            command.ExecuteNonQuery();

            Close();
        }


        //Método que hace SELECT a una sola cerveza
        public Beer ConsultaUno(int id)
        {
            Open();
            Beer beer = null;

            string query = "SELECT ID, NAME, BRAND_ID FROM BEER WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@ID", id);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(1);
                int brandId = reader.GetInt32(2);
                beer = new Beer(id, name, brandId);
            }

            Close();
            return beer;
        }

        //Método que hace un UPDATE a una sola cerveza
        public void Editar(Beer beer)
        {
            Open();

            string query = "UPDATE beer SET NAME = @NAME, BRAND_ID = @BRAND_ID WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@NAME", beer.name);
            command.Parameters.AddWithValue("@BRAND_ID", beer.brandID.ToString());
            command.Parameters.AddWithValue("@ID", beer.Id.ToString());
            command.ExecuteNonQuery();

            Close();
        }

        //Método para eliminar un registro beer por ID
        public void Eliminar(int id)
        {
            Open();

            string query = "DELETE FROM BEER WHERE ID = @ID";
            SqlCommand command = new SqlCommand (query, _connection);
            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery ();

            Close();

        }
    }
}
