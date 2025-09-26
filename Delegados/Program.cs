using System.Net.NetworkInformation;

Console.BackgroundColor = ConsoleColor.DarkBlue;
Console.ForegroundColor = ConsoleColor.White;
Console.Clear();

/*Los delegados son definicinoes de tipos de datos personalizados, en donde
 *los tipos de datos son funciones, las funciones deben devolver el mismo
 *tipo y recibir la misma cantidad de argumentos.
 */

//Uso de los delegados - los pongo antes de las definiciones porque marca error si van después
Operacion mi_operacion = Funciones.Sumar;
System.Console.WriteLine(mi_operacion(3, 2));

mi_operacion = Funciones.Multiplicar;
System.Console.WriteLine(mi_operacion(3, 2));

Impresion mi_impresion = Funciones.MostrarMensaje;
mi_impresion("Hola, este es un mensaje de prueba");

mi_impresion = Console.WriteLine;
mi_impresion("Hola mundo!");



//Definiciones del delegados
delegate int Operacion(int a, int b); //Funciones que retornan un entero y reciben dos enteros como parámetros
delegate void Impresion(string mensaje);//Funciones que no retornan nada y reciben un string como parámetro


//Definiciones de funciones de ejemplo
public static class Funciones
{
    public static int Sumar(int a, int b) => a + b;
    public static int Multiplicar(int a, int b) => a * b;
    public static void MostrarMensaje(string mensaje) => Console.WriteLine(mensaje);
}


