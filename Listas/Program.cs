using System.Collections.Generic;
using System.Linq.Expressions;

namespace Listas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Las listas tienen de ventaja sobre los arreglos que:
                *ya tienen métodos por defecto para trabajar con ellos
                *los arreglos hay que declararlos con cúantos espacios
                 va a contar, las listas no tienen límite
            */
            List<int> numbers0 = new List<int>();
            numbers0.Add(1);
            numbers0.Add(2);
            numbers0.Add(3);
            numbers0.Add(4);
            numbers0.Add(5);

            Console.WriteLine($"La primera lista tiene: {numbers0.Count} elementos");

            List<int> numbers1 = new List<int>()
            {
                6, 7, 8, 9, 10
            };
            Console.WriteLine($"La segunda lista tiene: {numbers1.Count} elementos");

            //para limpiar una lista eliminando sus elementos
            numbers1.Clear();
            Console.WriteLine($"La segunda lista tiene: {numbers1.Count} elementos");

            //listas de cadenas
            List<string> paises = new List<string>()
            {
                "México",
                "Argentina",
                "Austria",
                "USA",
                "Rusia"
            };
            Console.WriteLine("----------- Lista de cadenas -----------");
            for (int i = 0; i < paises.Count; i++)
            {
                Console.WriteLine(paises[i]);
            }
            
        }
    }
}
