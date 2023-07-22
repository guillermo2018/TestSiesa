using System;

namespace ConversionBaseK
{
	/// <summary>
	/// Clase encargada de convertir numero x a base K
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			// Leer dicimal
			Console.Write("Ingrese Número decimal a convertir: ");
			int numero = int.Parse(Console.ReadLine());

			// Leer base
			Console.Write("Ingrese Base a la que se quiere convertir: ");
			int baseK = int.Parse(Console.ReadLine());

			string resultado = ConvertirBaseK(numero, baseK);
			Console.WriteLine($"El número {numero} en base {baseK} es: {resultado}");
		}

		/// <summary>
		/// Metodo que lee decimal y la base retornando base k
		/// </summary>
		/// <param name="numero"></param>
		/// <param name="baseK"></param>
		/// <returns></returns>
		static string ConvertirBaseK(int numero, int baseK)
		{
			// Digitos base K
			char[] digitos = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

			if (numero < baseK)
			{
				return digitos[numero].ToString();
			}
			else
			{

				int resto = numero % baseK;
				return ConvertirBaseK(numero / baseK, baseK) + digitos[resto].ToString();
			}
		}
	}
}