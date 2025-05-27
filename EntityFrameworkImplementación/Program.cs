using EntityFrameWorkBaseDeDatos;//para el contexto de la librería que hicimos con EntityFramework
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;//Para las optionsBuilders
namespace EntityFrameworkImplementación
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DbContextOptionsBuilder<CursoCsContext> optionsBuilder = new DbContextOptionsBuilder<CursoCsContext>();

            //optionsBuilder.UseSqlServer("Server=B450M; Database=CursoCS; User=usuariodb; Password=elfruto; TrustServerCertificate=True;");



            //using(CursoCsContext context = new CursoCsContext(optionsBuilder.Options))
            //{
            //    var beers = context.Beers.ToList();

            //    foreach (var beer in beers)
            //    {
            //        Console.WriteLine(beer);
            //    }
            //}


            CursoCsContext context = new CursoCsContext();
            var beers = context.Beers.ToList();

            foreach (var beer in beers)
            {
                Console.WriteLine(beer);
            }
            
        }
    }
}
