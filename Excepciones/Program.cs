namespace Excepciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Cómo leer un archivo
            try
            {
                string content = File.ReadAllText(@"D:\auvm\PROYECTOS\Curso_C#\Excepciones\document.txt");
                Console.WriteLine(content);

                

                string content2 = File.ReadAllText(@"D:\auvm\PROYECTOS\Curso_C#\Excepciones\document2.txt");
                Console.WriteLine(content2);

                /*para lanzar una excepción voluntariamente
                 si lo posiciono arriba, la cacha y ya no 
                 se ejecuta el resto*/
                throw new Exception("Ocurrio algo raro");


            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("Error: Archivo no existe");
                Console.WriteLine($"Descripción: {ex.Message}\n\n");

            }catch(Exception ex02)
            {
                Console.WriteLine(ex02.Message);
            }
            finally
            {
                /*una buena practica ejecutar una tarea necesaria
                  para que el proceso termine correctamente - siempre
                  se ejecuta haya o no excepciónç
                */
                Console.WriteLine("Cerrando conexión a base de datos...");
                Console.WriteLine("Cerrando conexión a los archivos...");
                Console.WriteLine("bip, bup, bip, bup...");
                Console.WriteLine("Listo!\n\n");
            }

            Console.WriteLine("Aquí se sigue ejecutando...");



        }
    }
}
