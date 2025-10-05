using LINQ;
using System.Net.Security;
namespace LINQ
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            List<Beer> beers = new List<Beer>()
            {
                new Beer (){Name="Corona", Country="México"},
                new Beer (){Name="Delirium", Country="Bélgica"},
                new Beer (){Name="Erdinger", Country="Germany"},
            };

            foreach (Beer beer in beers) {
                Console.WriteLine(beer);
            };

            Console.WriteLine("---------------- Consultas ---------------");
            //SELECT
            var listOfNames = from cerveza in beers
                              select new {
                                  Name = cerveza.Name,
                                  Letters = cerveza.Name.Length,
                                  FixedField = "Campo fijo"
                              };

            /*Ésta lista no es editable, pero podemos hacer otras copias*/
            foreach (var name in listOfNames) {
                Console.WriteLine(name);
            }

            var listRealNames = from cerveza in beers
                                select new
                                {
                                    Name = cerveza.Name
                                };
            foreach (var cerveza in listRealNames)
            {
                Console.WriteLine($"Name: {cerveza.Name}");
            }

            Console.WriteLine("---------------- Consulta con condicionales ---------------");

            var beersMéxico = from cerveza in beers
                              where cerveza.Country == "México"
                              || cerveza.Country == "Germany"
                              select cerveza;
                                
            foreach (var cerveza in beersMéxico)
            {
                /*llama al método toString() de la clase Beer
                 de otra forma imprime el OBJECT(compruebalo comentando el override toString())*/
                Console.WriteLine(cerveza);
            }
            Console.WriteLine("---------------- Consulta ordenadas ---------------");

            var beersOrderedByCountry = from cerveza in beers
                                        orderby cerveza.Country ascending
                                        select cerveza;
            foreach (var cerveza in beersOrderedByCountry)
            {
                Console.WriteLine(cerveza);
            }

            //------------------------------------------------------------------------

            beersOrderedByCountry = from cerveza in beers
                                        orderby cerveza.Country descending
                                        select cerveza;
            foreach (var cerveza in beersOrderedByCountry)
            {
                Console.WriteLine(cerveza);
            }

        }
    }

    public class Beer
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"Name: {this.Name} Country: {this.Country}";
        }
    }
}
