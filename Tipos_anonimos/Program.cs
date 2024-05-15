using System.Net.Sockets;

namespace Tipos_anonimos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //En la variable se está asignando un tipo anónimo
            var person = new
            {
                Name = "Uriel",
                Country = "México",
            };

            Console.WriteLine(person.Name +" "+ person.Country);

            //person.Name = "Otro nombre";//Esto produce un error, pq los objetos anónimo no se pueden modificar

            /*También puede haber arreglos con tipos de datos anónimos, pero 
                SON DE SOLO LECTURA!
            */
            var beers = new[]
            {
                new {Name = "Red", Brand = "Delirium"},
                new {Name = "London Porter", Brand = "Fullers"}
            };
            foreach (var item in beers)
            {
                Console.WriteLine($"Cerveza {item.Name} de {item.Brand}");
            }

        }
    }
}
