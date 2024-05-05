using System.Text.Json; //para las funciones integradas de serialización y deserialización
namespace Json
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------Objetos individuales-----------");
            Beer myBeer = new Beer()
            {
                Name = "Pikantus",
                Brand = "Erdinger"
            };
            /*Formato Json:
             * En éste formato se representa un objeto
             {
                "Name":"Pikantus",
                "Brand": "Erdinger"
             }
            */
            string json_objeto = "{\"Name\":\"pikantus\",\"Brand\":\"Erdinger\"}";

            /*Formato Json:
             * En éste formato se representa una coleción de objetos
               [
                 {  "Name":"Pikantus", "Brand": "Erdinger"},
                 {  "Name":"Corona", "Brand": "Modelo"}
               ]
            */
            string json_colección_de_objetos =
                "[" +
                    "{\"Name\":\"Pikantus\",\"Brand\":\"Erdinger\"}," +
                    "{\"Name\":\"Corona\",\"Brand\":\"Modelo\"}," +
                "]";

            /*Una vez añadida la biblioteca System.Text.Json, podemos usar las funciones 
             de serialización de un objeto a una cadena Json*/

            string json0 = JsonSerializer.Serialize(myBeer);

            /*El método para recuperar el objeto usa genéricos, hay que indicar el 
             tipo de objeto y pasarle la cadena a deserializar*/

            //para el ejemplo...
            myBeer.Name = "Marco";
            myBeer.Brand = "Polo";
            Console.WriteLine(myBeer);

            //deserializo y re-asigno de nuevo a mi objeto
            myBeer = JsonSerializer.Deserialize<Beer>(json0);
            Console.WriteLine(myBeer);

            Console.WriteLine("-----------Coleción de Objetos-----------");
            /*Para la serialización y deserialización de arreglos de objetos...*/
            Beer[] myCollection = new Beer[] { 
                new Beer
                {
                    Name = "Pikantus",
                    Brand = "Erdinger"
                },
                new Beer
                {
                    Name = "Corona",
                    Brand = "Modelo"
                },
                new Beer
                {
                    Name = "Budweiser",
                    Brand = "Anheuser-Busch InBev"
                },
            };
            //serializa la colección
            string json1 = JsonSerializer.Serialize(myCollection);
            //borra la colección
            myCollection = [];
            //deserializa la colección
            myCollection = JsonSerializer.Deserialize<Beer[]>(json1);
            //imprime la colección
            foreach (var item in myCollection)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Beer
    {
        public string Name { get; set; }
        public string Brand { get; set; }

        public override string ToString()
        {
            return $"\n----Cerveza----\nNombre:{Name}\nMarca:{Brand}";
        }
    }
}
