namespace ExpresionesLambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*(1) Asigno una función lambda a un delegado genérico*/
            Action<string> showMessage = (message)=> Console.WriteLine(message);

            /*(2) Asigno una función lambda de varias lineas a un delegado genérico*/
            Action<string, string> showMessage2 = (name, lastName) =>
            {
                Console.WriteLine($"Hola {name} {lastName}");
            };

            /*(4) Las funciones lambda se pueden almacenar o se pueden pasar directamente 
             * como parámetros de funciones de orden superior*/

            Functions.Some("Juan", "Perez", showMessage); //delegado genérico con función lambda almacenada
            Functions.Some("Ana", "Gomez", (message) => Console.WriteLine(message) ); //función lambda pasada directamente
        }
    }
    public class Functions
    {
        #region Funciones
        
        /*(3) Función de orden superior*/
        public static void Some(string name, string lastName, Action<string> fn)
        {
            //manda a llamar a la misma función que se le pasó como parámetro con los parámetros se necesiten
            fn($"Hola {name} {lastName}");
        }
        #endregion
    }
}
