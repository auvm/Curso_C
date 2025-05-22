
namespace ConexiónBaseDeDatosMenu
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int opción = 0;
            bool repetir = true;

            try
            {
                OperaciónBaseDeDatos operación = new OperaciónBaseDeDatos("B450M", "CursoCS", "usuariodb", "elfruto");
                do
                {
                    Console.Clear();

                    MostrarMenú();
                    Console.WriteLine("\nElige una opción:");
                    opción = int.Parse(Console.ReadLine());

                    Console.Clear();


                    switch (opción)
                    {
                        case 1:
                            Console.WriteLine("------------ Consultar Tabla ------------\n");
                            consultarTabla(operación);
                            break;
                        case 2:
                            Console.WriteLine("------------ Consultar Cerveza ------------\n");
                            consultarCerveza(operación);
                            break;
                        case 3:
                            Console.WriteLine("------------ Insertar ------------\n");
                            insertar(operación);
                            break;
                        case 4:
                            Console.WriteLine("------------ Modificar ------------\n");
                            modificar(operación);
                            break;
                        case 5:
                            Console.WriteLine("------------ Eliminar ------------\n");
                            eliminar(operación);
                            break;
                        case 6:
                            repetir = false;
                            break;
                        default:
                            repetir = false;
                            break;
                    }
                }while(repetir);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo conectar al servidor SQL, lo siento.");
                Console.WriteLine(ex.ToString());
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

        public static void consultarTabla(OperaciónBaseDeDatos operación)
        {
            List<Beer> ListaDeBeers = operación.ConsultarTodo();

            Console.WriteLine($"{"ID",-10} {"Nombre",-20} {"BrandID",-10}");
            foreach (Beer b in ListaDeBeers)
            {
                Console.WriteLine(b);
            }
            Console.ReadLine();
        }
        public static void consultarCerveza(OperaciónBaseDeDatos operación)
        {
            Console.Write("Ingresa el ID de la cerveza a consultar: ");
            int id = int.Parse(Console.ReadLine());
            
            Beer beer = operación.ConsultaUno(id);

            if (beer != null)
            {
                Console.WriteLine($"\n{"ID",-10} {"Nombre",-20} {"BrandID",-10}");
                Console.WriteLine(beer);
            }
            else
            {
                Console.WriteLine("\nNo se encontró ninguna cerveza con ese ID.");
            }

            Console.ReadLine();
        }

        public static void insertar(OperaciónBaseDeDatos operación)
        {

            Console.Write("Nombre de la cerveza: ");
            string name = Console.ReadLine();

            Console.Write("Id de la marca: ");
            int brandId = int.Parse(Console.ReadLine());

            operación.Insertar(new Beer(name, brandId));

            Console.WriteLine("\nRegistro exitoso...");

            Console.ReadLine();
        }        
        public static void modificar(OperaciónBaseDeDatos operación)
        {

            Console.Write("Ingresa el ID de la cerveza a consultar: ");
            int id = int.Parse(Console.ReadLine());

            Beer beer = operación.ConsultaUno(id);
            if(beer != null)
            {
                Console.WriteLine("\n---- Registro actual ----");
                Console.WriteLine($"{"ID",-10} {"Nombre",-20} {"BrandID",-10}");
                Console.WriteLine(beer);


                Console.WriteLine("\n---- Nuevos datos ----");
                Console.Write("Nuevo nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Nuevo BrandID: ");
                int brandId = int.Parse(Console.ReadLine());

                beer = new Beer(id, nombre, brandId);
                operación.Editar(beer);

                Console.WriteLine("\n---- Resultado ----");
                Console.WriteLine($"{"ID",-10} {"Nombre",-20} {"BrandID",-10}");
                Console.WriteLine(beer);
            }
            else
            {
                Console.WriteLine("\nNo se encontró ninguna cerveza con ese ID.");
            }
               
            Console.ReadLine();
        }
        public static void eliminar(OperaciónBaseDeDatos operación)
        {
            Console.Write("Ingresa el ID de la cerveza a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            Beer beer = operación.ConsultaUno(id);
            if (beer != null)
            {
                Console.WriteLine("\n---- Registro encontrado ----");
                Console.WriteLine($"{"ID",-10} {"Nombre",-20} {"BrandID",-10}");
                Console.WriteLine(beer);
                Console.Write("\n¿Seguro que deseas eliminar? S/N: ");
                string confirmación = Console.ReadLine();
                if(confirmación == "s" || confirmación == "S")
                {
                    operación.Eliminar(id);
                    Console.WriteLine("\nSe eliminó correctamente.");
                }
                else
                {
                    Console.WriteLine("\nCancelado, no se realizó ningún cambio.");
                }
            }
            else
            {
                Console.WriteLine("\nNo se encontró ninguna cerveza con ese ID.");
            }

            Console.ReadLine();
        }

    }
}
