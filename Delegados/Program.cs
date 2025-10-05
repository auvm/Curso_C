using System.Threading.Channels;

namespace Delegados
{
    internal class Program
    {
        //(1) los delegados son los tipos de las variables que alamcenan funciones
        delegate int Operation(int a, int b);
        delegate void Show(string message);

        static void Main(string[] args)
        {

            /* (3) Aquí se asignan las funciones a las variables del tipo 
             * "delegado" creadas al principio
             */
            Operation mySum = Functions.Sum;
            Operation myMul = Functions.Mul;
            Show myShow = Functions.Show;


            /* (4) Aquí ya se imprimen las variables 
             * que contienen las funciones. Se les pasa a la
             * variables los parámetros que necesitan las 
             * funciones para que se ejecuten.
             */
            Console.WriteLine($"mySum: {mySum(2,3)}");
            Console.WriteLine($"myMul: {myMul(2,3)}");
            myShow("Hello, World!");
        }


        // (2) aquí se crean las funciones como tal que hacen las operaciones
        public class Functions
        {
            public static int Sum(int a, int b) => a + b;
            public static int Mul(int a, int b) => a * b;
            public static void Show(string message) => Console.WriteLine(message);
        }
    }
}
