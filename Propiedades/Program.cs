using System.Numerics;

namespace Propiedades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Venta venta1 = new Venta(100, DateTime.Now);
            venta1.Total = 999;
            Console.WriteLine(venta1.GetInfo2());
        }
    }

    class Venta
    {
        int total;
        DateTime date;

        public int Total
        {
            get
            {
                return total;
            }
            set
            {
                if (value < 0)
                    value = 0;
                total = value;
            }
        }


        public Venta(int total, DateTime date)
        {
            this.total = total;
            this.date = date;
        }

        public string GetInfo()
        {
            return "Total: $" + total + "\nFecha de compra: " + date.ToLongDateString();
        }

        public string GetInfo2()
        {
            return "Total: $" + total + "\nFecha de compra: " + date.ToShortDateString();
        }
        public void show()
        {
            Console.WriteLine("Hola, soy una venta!");
            Console.WriteLine($"Total:{this.total}\nFecha de compra:{this.date}");
        }
    }
}
