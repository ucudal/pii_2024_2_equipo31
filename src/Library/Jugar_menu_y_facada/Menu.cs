using System;
using System.Collections.Generic;
namespace Library;

public class Menu
{
    private Facada facada;
	
	public Menu()
	{
		Console.WriteLine("\n 📝 ¿Cuantos jugadores desea crear? (1 0 2): ");
		string respuesta = Console.ReadLine();
		int cantidadJugadores;

		while (!int.TryParse(respuesta, out cantidadJugadores) || (cantidadJugadores < 1 || cantidadJugadores > 2))
		{
			Console.WriteLine("Intente ingresar un numero de jugadores valido (1 o 2): ");
			respuesta = Console.ReadLine();
		}

		List<string> nombreJugadores = new List<string>();
		for (int i = 1; i <= cantidadJugadores; i++)
		{
			Console.WriteLine($"\n 📝 Escribe el nombre del Jugador {i}: ");
			nombreJugadores.Add(Console.ReadLine());
		}
		facada = new Facada(nombreJugadores[0], nombreJugadores.Count > 1 ? nombreJugadores[1] : null);
		InicializarPokemons();
	}

	private void InicializarPokemons()	// CADA JUGADOR SELECCIONA SUS POKEMONS INICIALES
	{
		Console.WriteLine("El primer jugador debera seleccionar sus 6 pokemon: ");
		facada.Cada_Jugador_Agrega_Pokemons(1);
		if (facada.Jugador2 != null)
		{
			Console.WriteLine("El segundo jugador debera seleccionar sus 6 pokemons: ");
			facada.Cada_Jugador_Agrega_Pokemons(2);
		}
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
			Console.WriteLine("5. Salir");
			Console.WriteLine("Escriba su opcion: ");
			
			opcion = Console.ReadLine();

			switch (opcion)
			{
				case "1":
					facada.Iniciar_Nueva_Batalla(facada.Jugador2);
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
					Console.WriteLine("Gracias por jugar\nHasta la proxima!\n");
					break;
				default:
					Console.WriteLine("Opcion incorrecta, ingrese una opcion valida.");
					break;
			}
		}
		while (opcion != "5");
	}
	private void UnirJugadorALaEspera()
	{	
		Console.WriteLine("Escribe el nombre del jugador que quiere unirse a la lista de espera: ");
		string nombreJugador = Console.ReadLine();
		Jugador jugador = new Jugador(nombreJugador);
		facada.Unir_Jugador_A_La_Espera(jugador);
	}
}
