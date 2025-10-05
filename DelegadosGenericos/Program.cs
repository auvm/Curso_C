using System.Security.Cryptography.X509Certificates;

namespace DelegadosGenericos
{
    internal class Program
    {

        #region DelegadosGenericos
        /*(1) Se crean los datos genéricos
         * Tipos - toda aquella función que recibe un parámetro string y devuelve void
         * Los delegados genéricos siempre retornan void 
         * La parte que lo hace genérico es el "Action<tipoDeDatoQueRecibeLaFunción>"
         */
        public static Action<string> showMessage = System.Console.WriteLine; //public y static solo para poderla ver en el main()


        /* (3) Comparar con un delegado genérico que recibe dos parámetros
         * 
         * Para cada número y tipo de parámetros, solo se añade en los signos "<>"*/
        Action<string, string> showMessage2 = Functions.Show2;
        Action<string, string, int> showMessage2Int = Functions.Show2Int;

        #endregion

        #region Delegados normales
        /* (2) Comparamos con lo que se necesita si se usan delegados normales
         * Tipo - toda aquella función que recibe un parámetro string*/
        public delegate void Show(string message);

        /*Tipos - todas aquellas funciones que reciben dos o tres parámetros string respectivamente
         *Así tendría que crear un delegado para cada número de N parámetros que se necesiten
         */
        public delegate void Show2(string message, string message2);
        public delegate void Show3(string message, string message2, string message3);
        #endregion

        static void Main(string[] args)
        {
            Action<string> showMessage = System.Console.WriteLine;

            /*(5) Mando a llamar a la función de orden superior que utiliza todo lo anterior*/
            Functions.Some("Juan", "Perez", showMessage);
        }

        public class Functions
        {
            #region Funciones
            public static void Show2(string message, string message2) => Console.WriteLine($"{message} {message2}");
            public static void Show2Int(string message, string message2, int num) => Console.WriteLine($"{message} {message2} {num.ToString()}");

            /*(4) Se crean funciones de orden superior que reciben un delegado genérico, para el ejemplo*/
            public static void Some(string name, string lastName, Action<string> fn) {
                //manda a llamar a la misma función que se le pasó como parámetro con los parámetros se necesiten
                fn($"Hola {name} {lastName}");
            }
            #endregion
        }
    }
}
