using System.Security.Cryptography.X509Certificates;

namespace Tuplas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Una tupla se define con los tipos de datos que van a
             albergar, el nombre de la tupla y la asignación en orden de los valores
            */
            (int id, string name) product = (1, "cerveza stout");

            Console.WriteLine($"ID: {product.id} descripción: {product.name}");

            //Las tuplas se pueden modificar, no como los tipos anónimos
            product.name = "cerveza porter";
            Console.WriteLine($"ID: {product.id} descripción: {product.name}");

            /*Se pueden declarar una tupla sin definir el tipo de dato que alberga
             pero se acceden por orden con name.Item1, name.Item2, name.ItemX...*/
            var product01 = (2, "cereales milky");
            Console.WriteLine($"ID: {product01.Item1} descripción: {product01.Item2}");

            /*Se pueden hacer arreglos de tuplas con el mismo orden 
              y tipo de datos
            */
            Console.WriteLine("-------------------------------------------");
            var people = new[]
            {
                (1,"ángel"),
                (2,"uriel"),
                (3,"miguel"),
                (4,"abraham")
            };

            foreach (var person in people)
            {
                Console.WriteLine($"ID: {person.Item1} Nombre: {person.Item2}");
            }

            Console.WriteLine("-------------------------------------------");
            //ésto hace el código más legible
            (int id, string name)[] people2 = new[]
            {
                (1,"ángel"),
                (2,"uriel"),
                (3,"miguel"),
                (4,"abraham")
            };
            foreach (var person in people2)
            {
                Console.WriteLine($"ID: {person.id} Nombre: {person.name}");
            }

            Console.WriteLine("-------------------------------------------");
            /*Ejemplo de una función que retorna una tupla,
             para cuando necesitamos retornar más de un valor*/
            var place = getLocationCDMX();
            Console.WriteLine($"latitud: {place.lat} Longitud: {place.lng} Nombre: {place.name}");


            /*Ejemplo para solo recibir uno de los valors retornados de una función*/
            var (_, longitud, _) = getLocationCDMX();
            Console.WriteLine($"Solo la longitud: {longitud}");


        }

        public static (float lat, float lng, string name) getLocationCDMX()
        {
            float latitud = 19.12121f;
            float longitud = -99.19212f;
            string name = "CDMX";

            return (latitud, longitud, name);
        }
    }
}
