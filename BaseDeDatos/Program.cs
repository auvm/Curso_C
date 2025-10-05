namespace BaseDeDatos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * UPDATE: LA CLASE myConnection se hizo abstracta por lo que no va a funcionar
             * este programa.
             * 
             * Primero se conecta a la base de datos para después
             * realizar operaciones. Para la conexíón de la base de datos añadirmos
             * la otra clase para la lógica de la conexión.
            */
            //myConnection myconnection = new myConnection("localost", "csharpdb");
            
            try
            {
                /*Aquí va todo nuestro código intermedio*/
                BeerDB beerdb = new BeerDB("localhost", "csharpdb");

                List<Beer> beers = beerdb.GetAll();
                foreach (Beer beer in beers)
                {
                    Console.WriteLine(beer.Name);
                }

                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo establecer la conexión a la base de datos.");
                
            }
        }
    }
}
