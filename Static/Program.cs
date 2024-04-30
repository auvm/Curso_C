namespace Static
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Parte del ejemplo...
            People people0 = new People()
            {
                Name = "Ángel",
                Age = 22
            };
            People people1 = new People()
            {
                Name = "Uriel",
                Age = 23
            };

            //Formas de acceder a los elementos estáticos de la clase
            Console.WriteLine("Instancias creadas: "+People.count+".");
            Console.WriteLine(People.GetCount());
        }
    }

    public class People
    {
        //Una propiedad publica y estática puede ser consultada desde la clase
        public static int count = 0;
        public People()
        {
            count++;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        //Los métodos también pueden ser estáticos e invocarse desde la clase
        public static string GetCount()
        {
            return $"Instancias creadas: {count}.";
        }

    }

    /*Si se crea una clase static, todos los elementos(propiedades y métodos)
     deben ser estáticos.
    
     Son utilizadas para cuando no se debe o no se necesita crear una
    instancia de la clase.
    
     Si no se colocan todos los elementos estáticos, provoca un error.*/
    public static class A
    {
        private static decimal number;

        public static decimal ReturnNumber()
        {
            return number;
        }
    }
}
