

/*Las definiciones de delegados normales
* siempre van abajo del código
*/



/*(1) se crea el delegado genérico Func
* Los delegados genéricos Func siempre retornan un valor y pueden recibir parámetros
* La parte que lo hace genérico es el "Func<tipoDeDatoQueRetornaLaFunción>" 
*/
Func<int> randomNumber = () => new Random().Next(0, 3);

System.Console.WriteLine($"Número aleatorio: {randomNumber()}");

/*(2) siempre el último tipo de dato que le pasemos en el generico "< >" 
* va a ser el tipo de dato que retorne la función,
* si tiene otros tipos de datos, equivalen a parámetros que recibe la función,
* es decir:
* Func<1_tipoDeUnParámetro, 2_tipoDeUnParámetro, ....N_tipoDeUnParámetro, tipoDeDatoQueRetornaLaFunción>
*/
Func<int, int, int> sum = (a, b) => a + b; //toma dos enteros y retorna un entero
System.Console.WriteLine($"Suma: {sum(2, 3)}");

Func<string, string, string> fullName = (name, lastName) => $"{name} {lastName}";
System.Console.WriteLine($"Nombre completo: {fullName("Ángel", "Uriel")}");

Func<int, int> randomNumberLimit = (limit) => new Random().Next(0, limit);
System.Console.WriteLine($"Número aleatorio con límite 10: {randomNumberLimit(10)}");