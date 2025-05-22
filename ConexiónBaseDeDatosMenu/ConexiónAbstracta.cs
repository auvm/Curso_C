using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexiónBaseDeDatosMenu
{
    /*
     * Nota: Clases abstractas no se pueden instanciar, por lo que
     * deben heredar e implementar sus métodos otras clases.
     */

    public abstract class ConexiónAbstracta
    {
        private string _connectionString; //cadena de conexión

        //Constructor
        public ConexiónAbstracta(string server, string db, string user, string password)
        {
            _connectionString = $"Data Source={server};Initial Catalog={db};" +
                $"User={user};Password={password}";
        }



        //Conectar base de datos
        protected SqlConnection _connection;

        public void Open()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }




        //Desconectar base de datos
        public void Close()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }

        }
    }
}
