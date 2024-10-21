using System;
using System.Collections.Generic;
namespace Library;

public class Menu
{
    private Facada facada;
	
	public Menu()
	{
		Console.WriteLine("\n 📝 Escriba el nombre del Jugador 1");
		string jug1 = Console.ReadLine();
		Console.WriteLine("\n 📝 Escriba el nombre del Jugador 2");
		string jug2 = Console.ReadLine();
		facada = new Facada(jug1, jug2);
		InicializarPokemons();
	}

	private void InicializarPokemons()	// CADA JUGADOR SELECCIONA SUS POKEMONS INICIALES
	{
		Console.WriteLine("El primer jugador debera seleccionar sus 6 pokemon: ");
		facada.Cada_Jugador_Agrega_Pokemons(1);
		
		Console.WriteLine("El segundo jugador debera seleccionar sus 6 pokemons: ");
		facada.Cada_Jugador_Agrega_Pokemons(2);
	}
	
	public void MostrarMenuPrincipal()	// MUESTRO EL MENU PARA INICIAR LAS BATALLAS O SALIR
	{
		string opcion;
		
		do
		{		
			Console.WriteLine("\nBienvenido al menu de batallas!");
			Console.WriteLine("1. Iniciar Batalla");
			Console.WriteLine("2. Salir");
			Console.WriteLine("Escriba su opcion: ");
			
			opcion = Console.ReadLine();

			switch (opcion)
			{
				case "1":
					facada.Iniciar_Nueva_Batalla();
					break;
				case "2":
					Console.WriteLine("Gracias por jugar\nHasta la proxima!\n");
					break;
				default:
					Console.WriteLine("Opcion incorrecta, ingrese una opcion valida.");
					break;
			}
		}
		while (opcion != "2");
	}
}
