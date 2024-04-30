using System.Reflection.Metadata.Ecma335;

namespace SobreEscrituraMetodos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------- Primer Ejemplo -----------");
            B b = new B();
            Console.WriteLine(b.Hi());

            Console.WriteLine("----------- Segundo Ejemplo -----------");
            /*Crea una clase de ventas donde se agregan cantidades de los
             precios de las ventas, al objeto se le pueden agregar cantidades
             y una sumatoria total*/
            Console.Write("Venta sin impuesto:");
            Sale sale0 = new Sale(10);
            sale0.Add(3);
            sale0.Add(5);
            Console.WriteLine(sale0.GetTotal());
            /*Se sobre escribre un método para que utilice el método padre para
             obtener el total, pero añadiendo el impuesto del 16%*/
            Console.Write("Venta con impuesto:");
            SaleWithTax sale1 = new SaleWithTax(10, 1.16m);
            sale1.Add(3);
            sale1.Add(5);
            Console.WriteLine(sale1.GetTotal());

        }
    }
    /*clase original - para sobre escribir un método
                       se debe declarar el método como virtual
    */
    public class A
    {
        public virtual string Hi()
        {
            return "Hola mundo A!";
        }
    }

    /*clase heredada - para sobre escribir el método, se debe
                       debe declarar como override
                     - para hacer referencia al método padre,
                       se debe escribir la palabra base
    */
    public class B : A
    {
        public override string Hi()
        {
            //se invoca al mét. padre y añade funcionalidad
            return base.Hi() + "\nHola mundo B!";
        }
    }

    public class Sale
    {
        private int[] _amounts;
        private int _n;
        private int _end;

        public Sale(int n)
        {
            _amounts = new int[n];
            _n = n;
            _end = 0;
        }

        public void Add(int amount)
        {
            if(_end < _n)
            {
                _amounts[_end] = amount;
                _end++;
            }
        }

        public virtual decimal GetTotal()
        {
            decimal result = 0;
            for(int i = 0; i <= _end; i++)
            {
                result += _amounts[i];
            }
            return result;
        }

    }

    public class SaleWithTax : Sale
    {
        private decimal _tax;

        /*También crea un nuevo parámetro dentro del constructor, 
         pasando el dato necesaio para el constructor padre.*/
        public SaleWithTax(int n, decimal tax) : base(n)
        {
            _tax = tax;
        }


        /*Esta es la sobreescritura del método*/
        public override decimal GetTotal()
        {
            return base.GetTotal() * _tax;
        }
    }
}
