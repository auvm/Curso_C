/* (1) Un delegado genérico Predicate siempre retorna un booleano (true o false)
* y solo puede recibir un parámetro
* La parte que lo hace genérico es el "Predicate<tipoDeDatoQueRecibeLaFunción>"
* TODOS los delegados son "tipos de datos" para funciones funciones
*/


//(2) tipo - toda aquella función que recibe un parámetro string y devuelve un booleano
Predicate<string> hasSpaceOrA = (word) => word.Contains(" ") || word.ToUpper().Contains("A");

System.Console.WriteLine("beer -"+hasSpaceOrA("beer"));
System.Console.WriteLine("Hola mundo! -" + hasSpaceOrA("Hola mundo!"));

//(3) su utilidad radica en contener bloques evaluadores lógicos que ayuden a tomar decisiones
var list = new List<string>
{
    "beer!",
    "paito",
    "hello world",
    "C#",
    "Sandia"
};
var results = list.FindAll(hasSpaceOrA); // (4) retorna una lista con las palabras que cumplen la condición del Predicate
System.Console.WriteLine("Palabras que contienen espacio o la letra 'a':");
foreach (var word in results)
{
    System.Console.WriteLine(word);
}

//(5) para hacer lo contrario y obtener una lista con las palabras que NO cumplen la condición del Predicate
results = list.FindAll((word) => !hasSpaceOrA(word));
System.Console.WriteLine("Palabras que NO contienen espacio o la letra 'a':");
foreach (var word in results)
{
    System.Console.WriteLine(word);
}