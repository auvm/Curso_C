namespace ConexiónBaseDeDatosAbstracta
{
    public class Program 
    {
        //Código más realista de como ejecutar la conexión

        static void Main(string[] args)
        {

            try
            {
                //Instancio la clase para conultar
                ConsultaDeBeers consulta = new ConsultaDeBeers("B450M", "CursoCS", "usuariodb", "elfruto");

                List<Beer> ListaDeBeers = consulta.ConsultaTodo();

                Console.WriteLine($"{"ID",-10} {"Nombre",-20} {"BrandID",-10}");
                foreach (Beer b in ListaDeBeers)
                {
                    Console.WriteLine(b);
                }




            }catch (Exception ex)
            {
                Console.WriteLine("No se pudo realizar la consulta SQL: ");
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
