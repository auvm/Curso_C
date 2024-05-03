using System.Reflection.Metadata;

namespace Interfaz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shark[] sharks = new Shark[]
            {
                new Shark("tiburoncín", 100),
                new Shark("jaws", 56)
            };

            ShowFish(sharks);
            ShowAnimals(sharks);

            
        }

        public static void ShowFish(IFish[] fishes)
        {
            int i = 0;
            Console.WriteLine("List of Fishes:");
            while (i < fishes.Length)
            {
                Console.WriteLine($"{i+1}.- {fishes[i].Swim()}");
                i++;
            }

        }

        public static void ShowAnimals(IAnimal[] animals)
        {
            int i = 0;
            Console.WriteLine("List of Animals:");
            while (i < animals.Length)
            {
                Console.WriteLine($"{i+1}.- {animals[i].Name.ToUpper()}");
                i++;
            }

        }

    }

    public interface IAnimal
    {
        public string Name { get; set; }
    }

    public interface IFish : IAnimal
    {
        public int Speed { get; set; }

        public string Swim();
    }

    public class Shark : IAnimal, IFish
    {
        public string Name { get; set; }
        public int Speed { get; set; }

        public Shark(string name, int speed)
        {
            this.Name = name;
            this.Speed = speed;
        }
        public string Swim()
        {
            return $"El tiburón nada a {Speed} Km/m.";
        }
    }
}
