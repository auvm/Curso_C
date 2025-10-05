namespace Multidifusión
{
    internal class Program
    {
        /*(1) Creo el tipo delegado*/
        delegate void Show(string message);

        static void Main(string[] args)
        {
            /*(3) Creo mi variable y le asigno las funciones
             *  que necesito, luego la invoco pasandole 
             *  mi mensaje. La multi difusión es que como mi
             *  variable tiene varias funciones asignadas, 
             *  al invocarla se ejecutan todas las funciones 
             *  al mismo tiempo.
             */
            Show myShow = Functions.Show;
            myShow += Functions.ShowToUpper;
            myShow += Functions.ShowToLower;

            myShow("Hello, World!");

        }

        /*(2) Creo las funciones de ejemplo que se le asiganaran a mi variable de tipo 'delegado'*/
        public class Functions
        {
            public static void Show(string message) => Console.WriteLine(message);
            public static void ShowToUpper(string message) => Console.WriteLine(message.ToUpper());
            public static void ShowToLower(string message) => Console.WriteLine(message.ToLower());
        }

    }
}
