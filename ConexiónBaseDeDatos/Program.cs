namespace ConexiónBaseDeDatos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conexion conexion = new Conexion("B450M", "CursoCS", "usuariodb", "elfruto");
            conexion.Open();
            Console.WriteLine("Hello, World!");
            conexion.Close();
            Console.WriteLine("Se abrió y cerró la conexión exitosamente.");
        }
    }
}
