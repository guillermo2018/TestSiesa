using System;
using System.Collections.Generic;

namespace ArbolPeso
{
	/// <summary>
	/// Clase encarga de crear un arbol de peso
	/// </summary>
	class Program
	{

		static void Main(string[] args)
		{
			// Creamos un árbol de peso
			var raiz = new Arbol(10);
			var subarbol1 = new Arbol(5);
			var subarbol2 = new Arbol(7);
			var subarbol3 = new Arbol(3);

			raiz.AgregarSubarbol(subarbol1);
			raiz.AgregarSubarbol(subarbol2);
			raiz.AgregarSubarbol(subarbol3);

			var subarbol4 = new Arbol(2);
			subarbol1.AgregarSubarbol(subarbol4);

			// Mostramos el árbol
			Console.WriteLine("Árbol de Peso:");
			raiz.MostrarArbol();
		}

		/// <summary>
		/// Clase tipo arbol encargada de crear el peso
		/// </summary>
		class Arbol
		{
			public int Peso { get; set; }
			public List<Arbol> Subarboles { get; set; }

			/// <summary>
			/// Constructor del arbol
			/// </summary>
			/// <param name="peso"></param>
			public Arbol(int peso)
			{
				Peso = peso;
				Subarboles = new List<Arbol>();
			}

			/// <summary>
			/// Metodo encargado de agregar cada pero a la lista subarbol
			/// </summary>
			/// <param name="subarbol"></param>
			public void AgregarSubarbol(Arbol subarbol)
			{
				Subarboles.Add(subarbol);
			}

			/// <summary>
			/// Metodo encargado de mostrar
			/// </summary>
			public void MostrarArbol()
			{
				MostrarArbol(this, 0);
			}

			/// <summary>
			/// Metodo encargado de calcular el peso 
			/// </summary>
			/// <param name="nodo"></param>
			/// <param name="nivel"></param>
			private void MostrarArbol(Arbol nodo, int nivel)
			{
				string espacios = new string(' ', nivel * 2);
				Console.WriteLine(espacios + "Peso: " + nodo.Peso);

				foreach (var subarbol in nodo.Subarboles)
				{
					MostrarArbol(subarbol, nivel + 1);
				}
			}
		}

	}
}