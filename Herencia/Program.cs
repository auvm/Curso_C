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

    class Doctor : People
    {
        private string _speciality;

        public Doctor(string name, int age, string speciality) : base(name, age)
        {
            _speciality = speciality;
        }

        public string completeInfo()
        {
            return info() + $"\nEspecialidad: {_speciality}";
        }
    }

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
