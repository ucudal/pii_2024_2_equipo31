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
			Console.WriteLine("1. Iniciar Batalla Local");
			Console.WriteLine("2. Unirse a la lista de espera");
			Console.WriteLine("3. Ver jugadores en la lista de espera");
			Console.WriteLine("4. Iniciar batalla con un jugador de la lista de espera");
			Console.WriteLine("5. Agregar bots a la lista de espera");
			Console.WriteLine("6. Salir");
			Console.WriteLine("Escriba su opcion: ");
			
			opcion = Console.ReadLine();

			switch (opcion)
			{
				case "1":
					facada.Iniciar_Nueva_Batalla();
					break;
				case "2":
					UnirJugadorALaEspera();
					break;
				case "3":
					facada.MostrarJugadoresEnEspera();
					break;
				case "4":
					facada.IniciarBatallaEnEspera();
					break;
				case "5":
					facada.AgregarMaquinaALaEspera();
					Console.WriteLine("Se agrego un bot a la lista de espera.");
					break;
				case "6":
					Console.WriteLine("Gracias por jugar\nHasta la proxima!\n");
					break;
				default:
					Console.WriteLine("Opcion incorrecta, ingrese una opcion valida.");
					break;
			}
		}
		while (opcion != "6");
	}
	private void UnirJugadorALaEspera()
	{	
		Console.WriteLine("Escribe el nombre del jugador que quiere unirse a la lista de espera: ");
		string nombreJugador = Console.ReadLine();
		Jugador jugador = new Jugador(nombreJugador);
		facada.Unir_Jugador_A_La_Espera(jugador);
	}
}
