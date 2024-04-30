namespace Herencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Doctor doctor0 = new Doctor("Juan", 23, "Cardiólogo");
            Console.WriteLine("------------Heredado------------");
            Console.WriteLine(doctor0.info());
            Console.WriteLine("------------Método creado------------");
            Console.WriteLine(doctor0.completeInfo());
            Progammer programmer0 = new Progammer("Luis", 32, "C");
            Console.WriteLine("------------Método creado------------");
            Console.WriteLine(programmer0.completeInfo());
        }
    }

    /*clase principal de donde se originan los atributos y el método de las demás personas*/
    class People
    {
        private string _name;
        private int _age;

        public People(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public string info()
        {
            return $"Nombre: {_name}\nEdad: {_age}";
        }
    }

    /*para hacer referencia a la herencia, sobre el nombre de la nueva clase
     se ponen los dos puntos y la clase padre*/
    class Doctor : People
    {
        private string _speciality;

        /*para el nuevo constructor se pasan los atributos originales con los
         dos puntos : la palabra base y los parámetros en cuestión*/
        public Doctor(string name, int age, string speciality) : base(name, age)
        {
            _speciality = speciality;
        }


        /*como ya se hace referencia a la herencia, se puede acceder a los métodos originales*/
        public string completeInfo()
        {
            return info() + $"\nEspecialidad: {_speciality}";
        }
    }

    /*este es otro ejemplo de la implementación de la herencia*/
    class Progammer : People
    {
        private string _favoriteLanguage;

        public Progammer(string name, int age, string favoriteLanguage) : base(name, age)
        {
            _favoriteLanguage = favoriteLanguage;
        }

        public string completeInfo()
        {
            return info() + $"\nLenguaje Favorito: {_favoriteLanguage}";
        }
    }
}
