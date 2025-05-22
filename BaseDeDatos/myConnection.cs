using System;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    public abstract class myConnection
    {
        private string _stringconection;
        protected SqlConnection _connection; //usamos SqlConnection para conectarnos
        public myConnection(string server, string dbName)
        {
            _stringconection = $"Server={server};Database={dbName};Trusted_Connection=True;";
        }

        public void Connect()
        {
            //instanciamos el SqlConnection y usamos su método para abrir la conecxión
            _connection = new SqlConnection(_stringconection);
            _connection.Open();
            Console.WriteLine("Se conectó a la base de datos.");

        }

        public void Disconnect()
        {
            if( _connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
                Console.WriteLine("Se cerró la conexión a la base de datos.");
            }
            
        }

    }
}
