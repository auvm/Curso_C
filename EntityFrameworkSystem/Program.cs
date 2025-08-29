
using Azure;
using BD;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EntityFrameworkSystem

{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            DbContextOptionsBuilder<CursoCsContext> optionsBuilder = new DbContextOptionsBuilder<CursoCsContext>();
            optionsBuilder.UseSqlServer("Server=B450M; Database=CursoCS; User=usuariodb; password=elfruto; TrustServerCertificate=True");


            bool repetir = true;

            do
            {
                Console.Clear();

                MostrarMenú();
                Console.WriteLine("\nElige una opción:");

                string? respuesta = Console.ReadLine(); // mecanismo para evitar warnings de posibles nulos
                if (int.TryParse(respuesta, out int opción))// mecanismo para evitar warnings de posibles nulos
                {
                    switch (opción)
                    {
                        case 1:
                            Console.WriteLine("------------ Consultar Tabla ------------\n");
                            consultarTabla(optionsBuilder);
                            break;
                        case 2:
                            Console.WriteLine("------------ Consultar Cerveza ------------\n");
                            consultarCerveza(optionsBuilder);
                            break;
                        case 6:
                            repetir = false;
                            break;
                        default:
                            repetir = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nLa opción ingresada no es válida.");
                    Console.ReadLine();
                    return;
                }

            } while (repetir);

        }

        public static void MostrarMenú()
        {
            Console.WriteLine("------------ Menú ------------\n");
            Console.WriteLine("1.- Consultar tabla");
            Console.WriteLine("2.- Consultar una cerveza");
            Console.WriteLine("3.- Insertar");
            Console.WriteLine("4.- Modificar");
            Console.WriteLine("5.- Eliminar");
            Console.WriteLine("6.- Salir");
        }

        public static void consultarTabla(DbContextOptionsBuilder<CursoCsContext> optionBuilder)
        {
            Console.Clear();
            Console.WriteLine("------------ Consultar Tabla ------------\n");


            using (var context = new CursoCsContext(optionBuilder.Options))
            {
                //List<Beer> ListaDeBeers = context.Beers.ToList(); //Forma básica para traer la lista

                List<Beer> ListaDeBeers = context.Beers.OrderBy(b => b.Name).ToList(); //Ordena por nombre

                List<Beer> ListaDeBeers2 = (from b in context.Beers
                                            orderby b.Name descending
                                            select b).ToList(); //Otra forma de ordenar por nombre (hace exactamente lo mismo)

                List<Beer> ListaDeBeers3 = (from b in context.Beers
                                            where b.BrandId == 2 //añadiendo un filtro
                                            orderby b.Name descending
                                            select b).ToList(); 

                Console.WriteLine($"{"ID",-10} {"Nombre",-20} {"BrandID",-10}");
                foreach (Beer b in ListaDeBeers3)
                {
                    Console.WriteLine($"{b.Id,-10} {b.Name,-20} {b.BrandId,-10}");
                }


                List<Beer> ListaDeBeers4 = (from b in context.Beers
                                            where b.BrandId == 2
                                            orderby b.Name descending
                                            select b).Include(b=>b.Brand).ToList(); //Para hacer el join e incluir los datos de la tabla Brand

                Console.WriteLine($"\n\n{"ID",-10} {"Nombre",-20} {"Brand",-10}");
                foreach (Beer b in ListaDeBeers4)
                {
                    Console.WriteLine($"{b.Id,-10} {b.Name,-20} {b.Brand.Name,-10}");
                }

                Console.ReadLine();
            }
        }

        public static void consultarCerveza(DbContextOptionsBuilder<CursoCsContext> optionsBuilder)
        {
            System.Console.Clear();
            Console.Write("Ingresa el ID de la cerveza a consultar: ");

            string? respuesta = Console.ReadLine();
            if (int.TryParse(respuesta, out int id))
            {
                Beer? beer = null;
                using (var context = new CursoCsContext(optionsBuilder.Options))
                {
                    beer = context.Beers
                                  .Include(b => b.Brand) //Incluye los datos de la tabla Brand (join)
                                  .FirstOrDefault(b => b.Id == id); //Trae el primer resultado o null si no hay resultados
                }
                if (beer != null)
                {
                    Console.WriteLine($"\n{"ID",-10} {"Nombre",-20} {"Brand",-10}");
                    Console.WriteLine($"{beer.Id,-10} {beer.Name,-20} {beer.Brand.Name,-10}");
                }
                else
                {
                    Console.WriteLine("\nNo se encontró ninguna cerveza con ese ID.");
                }

                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nEl ID ingresado no es válido.");
                Console.ReadLine();
                return;
            }
        }           
                     
                    
    }
}
