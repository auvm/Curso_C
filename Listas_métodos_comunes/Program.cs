namespace Listas_métodos_comunes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>()
            {
                23, 12, 31, 41, 23, 42
            };

            Show(numbers);

            //método para insertar en determinada posición
            //xxx.insert(posición, elemento);
            numbers.Insert(0,1);
            numbers.Insert(1,2);
            numbers.Insert(2,3);

            Show(numbers);


            //función xxx.Contains(), contiene un elemento en la lista? true/false
            if (numbers.Contains(33))
            {
                Console.WriteLine("Existe");
            }
            else
            {
                Console.WriteLine("No existe"); 
            }
            Console.WriteLine("---------- Ejemplos ----------");
            //función xxx.IndexOf(), retorna el índice de un elemento dentro de la lista
            Console.WriteLine("1 se encuentra en el índice:" + numbers.IndexOf(1));
            Console.WriteLine("23 se encuentra en el índice:"+numbers.IndexOf(23));
            //si el elemento no existe en la lista, retorna -1
            Console.WriteLine("100 se encuentra en el índice:" + numbers.IndexOf(100) + "o sea q no existe");

            Console.WriteLine("---------- Sort() mutable e inmutable----------");
            //método xxx.Sort(), ordena una lista
            numbers.Sort();
            /*El método Sort es un método mutable, porque modifica el 
              valor original de la lista
            */
            Show(numbers);

            //Ejemplo de un método no mutable
            string name = "ángel";
            Console.WriteLine(name.ToUpper());
            /*el método hace una modificación a una copia de la variable,
              pero el valor original de la variable sigue intecto
            */
            Console.WriteLine(name);

            Console.WriteLine("---------- AddRange() ----------");
            /*puede agregar por rangos y por listas
              previamente creadas
            */
            var numbers2 = new List<int>()
            {
                50,40,30,20
            };
            numbers.AddRange(numbers2);
            Show(numbers);
        }

        public static void Show(List<int> numbers)
        {
            //otro ejemplo de foreach
            Console.WriteLine("---------- Lista de números ----------");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }

}
