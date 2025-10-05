namespace LINQ_JOIN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Beer> beers = new List<Beer>()
            {
                new Beer (){Name="Corona", Country="México"},
                new Beer (){Name="Delirium", Country="Bélgica"},
                new Beer (){Name="Erdinger", Country="Alemania"},
                new Beer (){Name="Minerva", Country="México"},
            };

            var countries = new List<Country>()
            {
                new Country (){Name="México", Continent="America"},
                new Country (){Name="Bélgica", Continent="Europa"},
                new Country (){Name="Alemania", Continent="Europa"}
            };

            var beersWithCountry = from beer in beers
                                   join country in countries
                                   on beer.Country equals country.Name
                                   orderby country.Continent 
                                   select new
                                   {
                                       Name = beer.Name,
                                       Country = beer.Country,
                                       Continent = country.Continent
                                   };

            Console.WriteLine($"{"NOMBRE",-8}\t{"PAIS",-8}\t{"CONTINENTE",-8}\n");
            foreach ( var beer in beersWithCountry)
            {
                Console.WriteLine($"{beer.Name,-8}\t{beer.Country,-8}\t{beer.Continent,-8}");
            }
        }
    }

    class Beer
    {
        public string Name { get; set; }
        public string Country { get; set; }

    }

    public class Country
    {
        public string Name { get; set; }
        public string Continent { get; set; }
    }
}
