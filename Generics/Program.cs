using System.ComponentModel;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*MyList es una clase que utiliza tipos de datos genéricos
              para formar un arreglo de elementos, en su constructor recibe
              un número de elementos a contener en el arreglo y cuenta con un
              método para agregar los elementos, retornar un solo elmentos y 
              uno para imprimir una cadena con todos los elementos concatenados.
            
             People es una clase de ejemplo para sobre escribir el método ToString()
             y verificar que la clase MyList puede utilizar objetos para el arreglo.
             Ya que usa tipo de datos genéricos.
            */
            
            MyList<int> numbers = new MyList<int>(10);
            numbers.Add(1);
            numbers.Add(3);
            numbers.Add(8);
            Console.WriteLine(numbers.GetElement(2));

            MyList<string> persons = new MyList<string>(10);
            persons.Add("Ángel");
            persons.Add("Uriel");
            persons.Add("Velasco");
            persons.Add("Mejía");
            Console.WriteLine(persons.GetString());

            MyList<People> MyPeople = new MyList<People>(3);
            MyPeople.Add(new People("Ángel", "México"));
            MyPeople.Add(new People("Agustín", "México"));
            MyPeople.Add(new People("Vladimir", "USSR"));
            Console.WriteLine(MyPeople.GetString());

        }
    }

    public class MyList<T>
    {
        private int _index;
        private T[] _elements;

        public MyList(int n)
        {
            _elements = new T[n];
        }

        public void Add(T e)
        {
            if(_index < _elements.Length)
            {
                _elements[_index] = e;
            }
            _index++;
        }

        public T GetElement(int i)
        {
            if(i < _index && i > 0)
            {
                return _elements[i];
            }

            return default(T);
        }

        public string GetString()
        {
            string result = "";
            for (int i = 0; i < _elements.Length; i++)
            {
                if (_elements[i] != null)
                {
                    result += $"{_elements[i].ToString()} \n***********************\n ";
                }
            }

            return result;
        }

    }

    class People
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public People(string name, string country)
        {
            Name = name;
            Country = country;
        }

        //Sobre escritura del método ToString()
        public override string ToString()
        {
            return $"----Persona----\nNombre: {Name}\nPaís:{Country}";
        }
    }
}
