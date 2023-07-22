using System;

namespace DivisionNumeros
{
	/// <summary>
	/// Clase encargada Dividir numeros enteros
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			// Leer el dividendo
			Console.Write("Ingrese el dividendo: ");
			int dividendo = int.Parse(Console.ReadLine());

			// Leer el divisor
			Console.Write("Ingrese el divisor: ");
			int divisor = int.Parse(Console.ReadLine());

			// Realizar la división
			if (divisor != 0)
			{
				double resultado = (double)dividendo / divisor;

				// Mostrar el resultado
				Console.WriteLine("El resultado de la división es: " + resultado);
			}
			else
			{
				Console.WriteLine("Error: No se puede dividir por cero.");
			}
		}
	}
}
