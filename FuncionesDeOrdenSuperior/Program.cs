namespace FuncionesDeOrdenSuperior
{
    internal class Program
    {

        /*(1) Creo el tipo delegado, pública para que la pueda ver en otra clases*/
        public delegate void Show(string message);

        static void Main(string[] args)
        {
            /*(3) Creo mi variable y le asigno las funciones
             *  que necesito y mando a llamar a mi función de orden superior.
             */
            Show myShow = Functions.Show;
            myShow += Functions.ShowToUpper;
            myShow += Functions.ShowToLower;

            Functions.SupOrder("Juan", "Perez", myShow);

            /*(4) al mandar a llamar a mi función de orden superior también se 
             * ejecuta la multidifusión de la variable Show que le paso como parámetro.
             */


        }

        /*(2) Creo las funciones de ejemplo que se le asiganaran a mi variable de tipo 'delegado'
         *  y mi función que recibe otra función como parámetro (función de orden superior)
         */
        public class Functions
        {
            public static void Show(string message) => Console.WriteLine(message);
            public static void ShowToUpper(string message) => Console.WriteLine(message.ToUpper());
            public static void ShowToLower(string message) => Console.WriteLine(message.ToLower());

            //Una función de orden superior es una función que recibe otra función como parámetro o que devuelve una función como resultado.
            public static void SupOrder(string name, string lastName, Show showFunction)
            {
                showFunction($"Hola {name} {lastName}");
            }
        }
    }
}
