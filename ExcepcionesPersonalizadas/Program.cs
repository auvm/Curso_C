namespace ExcepcionesPersonalizadas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Beer beer01 = new Beer
            {
                //Name = "London Porter",
                Brand = "Fuller's"
            };
            try
            {
                Console.WriteLine(beer01);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }

    public class Beer
    {
        public string Name { get; set; }
        public string Brand { get; set; }



        public override string ToString()
        {

            if (Name == null || Brand == null)
                throw new InvalidBeerException();
                /*lanza una excepción general para un evento en especial*/
                //throw new Exception();

            return $"Beer: {this.Name}, Brand:{this.Brand}";
        }
    }

    public class InvalidBeerException : Exception
    {
        public InvalidBeerException() : base("Error: falta el nombre o la marca\n")
        {
            
        }
    }
}
