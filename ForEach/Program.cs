using System.Collections.Generic;

namespace ForEach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>()
            {
                23, 12, 31, 41, 23, 42
            };

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            var students = new List<People>()
            {
                new People(){Name = "Ángel", Country = "México" },
                new People(){Name = "Uriel", Country = "Rusia" },
                new People(){Name = "Agustín", Country = "Francia" },
                new People(){Name = "Marco", Country = "Eslovaquia" }
            };

            Show(students);

            //método para remover elementos en las listas
            students.RemoveAt(3);
            Show(students);
        }

        public static void Show(List<People> people)
        {
            //otro ejemplo de foreach
            Console.WriteLine("---------- Lista de personas ----------");
            foreach (var person in people)
            {
                Console.WriteLine($"Nombre: {person.Name}\tPaís:{person.Country}");
            }
        }
    }

    internal class People
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public People() { }
        public People(string name, string country)
        {
            this.Name = name;
            this.Country = country;
        }
    }
}
