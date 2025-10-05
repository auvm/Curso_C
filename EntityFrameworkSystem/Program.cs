using Azure;
using BD;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

                MostrarMenú();
                Console.Write("\nElige una opción:");

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
                        case 3:
                            Console.WriteLine("------------ Insertar Cerveza ------------\n");
                            insertarCerveza(optionsBuilder);
                            break;
                        case 4:
                            Console.WriteLine("------------ Modificar Cerveza ------------\n");
                            modificarCerveza(optionsBuilder);
                            break;
                        case 5:
                            Console.WriteLine("------------ Eliminar Cerveza ------------\n");
                            eliminarCerveza(optionsBuilder);
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
                    Console.Write("\nLa opción ingresada no es válida.");
                    Console.ReadLine();
                    return;
                }

            } while (repetir);

        }

        private static void eliminarCerveza(DbContextOptionsBuilder<CursoCsContext> optionsBuilder)
        {
            int idCerveza;
            string? respuesta;
            Console.Clear();
            Console.WriteLine("------------ Eliminar cerveza ------------\n");
            consultarTablaCervezas(optionsBuilder);
            Console.Write("\nIngresa el ID de la cerveza a eliminar: ");
            respuesta = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(respuesta))
            {
                Console.WriteLine("Se debe ingresar un ID.");
            }
            else
            {
                using(var context = new CursoCsContext(optionsBuilder.Options))
                {
                    if (!int.TryParse(respuesta, out idCerveza))
                    {
                        Console.WriteLine("El ID ingresado no es válido.");
                        Console.ReadLine();
                        return;
                    }
                    else 
                    {
                        var beer = context.Beers.Find(int.Parse(respuesta));
                        if (beer != null)
                        {
                            context.Beers.Remove(beer);
                            context.SaveChanges();
                            Console.WriteLine($"La cerveza con ID {idCerveza} eliminó correctamente.");
                        }
                    }
                    
                }
            }
            Console.ReadLine();


        }

        private static void modificarCerveza(DbContextOptionsBuilder<CursoCsContext> optionsBuilder)
        {
            
            Console.Clear();
            Console.WriteLine("------------ Modificar cerveza ------------\n");
            consultarTablaCervezas(optionsBuilder);
            Console.Write("\nIngresa el ID de la cerveza a modificar: ");
            int idCerveza;
            string? respuesta = Console.ReadLine();
            if (!int.TryParse(respuesta, out idCerveza))
            {
                Console.WriteLine("\nEl ID no puede estar vacío o no es válido.");
                Console.ReadLine();
                return;
            }
            using (var context = new CursoCsContext(optionsBuilder.Options))
            {
                var beer = context.Beers.Find(idCerveza);
                string? nuevoNombre;
                int nuevaMarca;
                if (beer != null)
                {
                    do
                    {
                        Console.Write($"\nIngresa el nuevo nombre de la cerveza (actual: {beer.Name}): ");
                        nuevoNombre = Console.ReadLine();
                    } while (string.IsNullOrWhiteSpace(nuevoNombre));

                    consultarTablaMarcas(optionsBuilder);
                    Brand? brand = null;
                    do
                    {
                        Console.Write($"\nIngresa el nuevo ID de la marca (actual: {beer.BrandId}): ");
                        string? marcaInput = Console.ReadLine();
                        if (int.TryParse(marcaInput, out nuevaMarca))
                        {
                            brand = context.Brands.Find(nuevaMarca);
                            if (brand == null)
                            {
                                Console.WriteLine("El ID de marca no existe. Intenta de nuevo.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("El ID ingresado no es válido. Intenta de nuevo.");
                        }
                    } while (brand == null);

                    beer.Name = nuevoNombre;
                    beer.BrandId = nuevaMarca;

                    context.Entry(beer).State = EntityState.Modified; //Marca la entidad como modificada   
                    context.SaveChanges();
                    Console.WriteLine("\nCerveza modificada exitosamente.");
                }
                else
                {
                    Console.WriteLine("\nNo se encontró ninguna cerveza con ese ID.");
                }
            }
            Console.ReadLine();

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

                List<Beer> ListaDeBeers4 = (from b in context.Beers
                                            //where b.BrandId == 2
                                            //orderby b.Name descending
                                            select b).Include(b=>b.Brand).ToList(); //Para hacer el join e incluir los datos de la tabla Brand

                Console.WriteLine($"{"ID",-10} {"Nombre",-20} {"Brand",-10}");
                foreach (Beer b in ListaDeBeers4)
                {
                    Console.WriteLine($"{b.Id,-10} {b.Name,-20} {b.Brand.Name,-10}");
                }

                Console.ReadLine();
            }
        }
        public static void consultarTablaCervezas(DbContextOptionsBuilder<CursoCsContext> optionBuilder)
        {
            Console.WriteLine("Cervezas registradas:");


            using (var context = new CursoCsContext(optionBuilder.Options))
            {

                List<Beer> ListaDeBeers = (from b in context.Beers
                                            select b).Include(b => b.Brand).ToList(); //Para hacer el join e incluir los datos de la tabla Brand

                Console.WriteLine($"{"ID",-10} {"Nombre",-20} {"Brand",-10}");
                foreach (Beer b in ListaDeBeers)
                {
                    Console.WriteLine($"{b.Id,-10} {b.Name,-20} {b.Brand.Name,-10}");
                }

            }
        }
        public static void consultarTablaMarcas(DbContextOptionsBuilder<CursoCsContext> optionBuilder)
        {
            Console.WriteLine("Marcas registradas:");
            using (var context = new CursoCsContext(optionBuilder.Options))
            {
                List<Brand> ListaDeMarcas = context.Brands.ToList(); //Forma básica para traer la lista

                Console.WriteLine($"{"ID",-10} {"Nombre",-20}");
                foreach (Brand b in ListaDeMarcas)
                {
                    Console.WriteLine($"{b.Id,-10} {b.Name,-20}");
                }
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
        private static void insertarCerveza(DbContextOptionsBuilder<CursoCsContext> optionsBuilder)
        {
            string? nombre = "";
            int marca;


            System.Console.Clear();
            
            
            Console.Write("Ingresa el nombre de la cerveza: ");
            nombre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("\nEl nombre no puede estar vacío.");
                Console.ReadLine();
            }
            else
            {
                consultarTablaMarcas(optionsBuilder);
                Console.Write("\nIngresa el ID de la marca:");
                string respuesta = Console.ReadLine();
                if (int.TryParse(respuesta, out marca))
                {
                    using (var context = new CursoCsContext(optionsBuilder.Options))
                    {
                        var beer = new Beer
                        {
                            Name = nombre,
                            BrandId = marca
                        };
                        context.Beers.Add(beer); //agrega la nueva cerveza al contexto
                        context.SaveChanges();  //guarda los cambios en la base de datos
                    }
                }
                else
                {
                    Console.WriteLine("\nEl ID no es válido.");
                    Console.ReadLine();
                }
            }           

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
    }
}
