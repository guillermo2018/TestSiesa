using System;
using System.Collections.Generic;

class Program
{
	static void Main(string[] args)
	{
		// Lista generica de peso y calorias
		List<Elemento> elementos = new List<Elemento>
		{
			new Elemento { Peso = 5, Calorias = 3 },
			new Elemento { Peso = 3, Calorias = 5 },
			new Elemento { Peso = 5, Calorias = 2 },
			new Elemento { Peso = 1, Calorias = 8 },
			new Elemento { Peso = 2, Calorias = 3 }
		};
		
		int minCalorias = 15; // Calorias minimas
		int pesoMaximo = 10; // Peso maximo

		List<Elemento> seleccionados; 
		int totalCalorias;

		MochilaMinimoCalorias(elementos, minCalorias, pesoMaximo, out seleccionados, out totalCalorias);

		Console.WriteLine("Elementos óptimos:");
		// Ciclo encargado de mostrar el peso y las caloras.
		foreach (var elemento in seleccionados)
		{
			Console.WriteLine($"Peso: {elemento.Peso}, Calorías: {elemento.Calorias}");
		}

		Console.WriteLine("Total de calorías: " + totalCalorias);
	}
	/// <summary>
	/// Clase que representa cada uno de los elementos que se pueden utilizar para escalar el risco. 
	/// Cada elemento tiene dos propiedades: Peso, que indica el peso del elemento, y Calorias, 
	/// que indica la cantidad de calorías que proporciona el elemento.
	/// </summary>
	class Elemento
	{
		public int Peso { get; set; }
		public int Calorias { get; set; }
	}

	/// <summary>
	///  Metodo que resuelve el problema de mínimo de calorías. Recibe como parámetros la lista de elementos disponibles (elementos), el mínimo de calorías requeridas (minCalorias), y el peso máximo que se puede llevar (pesoMaximo).
	/// </summary>
	/// <param name="elementos"></param>
	/// <param name="minCalorias"></param>
	/// <param name="pesoMaximo"></param>
	/// <param name="seleccionados"></param>
	/// <param name="totalCalorias"></param>
	static void MochilaMinimoCalorias(List<Elemento> elementos, int minCalorias, int pesoMaximo, out List<Elemento> seleccionados, out int totalCalorias)
	{
		// Se crea una matriz tabla de tamaño (n + 1) x (pesoMaximo + 1) para almacenar los resultados
		// intermedios del algoritmo. Cada celda tabla[i, j] representa el valor
		// máximo de calorías que se puede obtener con los primeros i elementos y un peso máximo de j.
		int n = elementos.Count;
		int[,] tabla = new int[n + 1, pesoMaximo + 1];

		for (int i = 1; i <= n; i++)
		{
			int peso_i = elementos[i - 1].Peso;
			int calorias_i = elementos[i - 1].Calorias;

			for (int j = 0; j <= pesoMaximo; j++)
			{
				if (peso_i <= j)
				{
					tabla[i, j] = Math.Max(calorias_i + tabla[i - 1, j - peso_i], tabla[i - 1, j]);
				}
				else
				{
					tabla[i, j] = tabla[i - 1, j];
				}
			}
		}

		seleccionados = new List<Elemento>();
		int pesoActual = pesoMaximo;

		for (int i = n; i > 0; i--)
		{
			if (tabla[i, pesoActual] != tabla[i - 1, pesoActual])
			{
				Elemento elemento_i = elementos[i - 1];
				seleccionados.Add(elemento_i);
				pesoActual -= elemento_i.Peso;
			}
		}

		totalCalorias = tabla[n, pesoMaximo];
	}
}
