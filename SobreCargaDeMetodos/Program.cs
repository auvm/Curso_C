using System.Diagnostics.CodeAnalysis;

namespace SobreCargaDeMetodos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Math math = new Math();
            Console.WriteLine("-----invoca de dos esteros-----");
            Console.WriteLine(math.sum(1,2));
            Console.WriteLine("-----invoca de dos strings-----");
            Console.WriteLine(math.sum("10","20"));
            Console.WriteLine("-----invoca de un arreglo------");
            int[] array_numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24};
            Console.WriteLine(math.sum(array_numbers));
        }
    }


    /*la lección aquí es que se pueden sobrecargar los metodos
     haciendo que una definición del método reciba uno u otra
     cantidad de parámetros y que en función de los mismos retorne
     un resultado válido*/

    //Nota: la firma del método no cambia, solo los parámetros que reciben
    public class Math
    {
        public int sum(int a, int b)
        {
            return a + b;
        }

        public int sum(string a, string b)
        {
            return int.Parse(a) + int.Parse(b);
        }

        public int sum(int[] numbers)
        {
            int result = 0;

            foreach (var number in numbers)
            {
                result += number;
            }
            return result;
        }
    }
}
