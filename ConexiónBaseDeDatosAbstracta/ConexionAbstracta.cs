using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexiónBaseDeDatosAbstracta
{
    /*Al ser una clase abstracta, puede tener métodos implementados
     o no implementados y campos que pueden heredarse, por lo que
    hacerla abstracta tiene el objetivo de ser reutilizada muchas veces
    por distintas otras clases*/
    public abstract class ConexionAbstracta
    {
        //Constructor de la clase que crea la cadena de conexión --------------------------------------------
        private string _connectionString;

        

        //Constructor
        public ConexionAbstracta(string server, string db, string user, string password)
        {
            _connectionString = $"Data Source={server};Initial Catalog={db};" +
                $"User={user};Password={password}";
        }



        //Método que se conecta (abre la conexión) a la base de datos --------------------------------------------
        protected SqlConnection _connection;

        public void Open()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }




        //Método para desconectar (cerrar la conexión) --------------------------------------------
        public void Close()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }

        }
    }
}
