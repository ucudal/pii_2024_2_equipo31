using System;
using System.Collections.Generic;
namespace Library;

public class Menu
{
    private Facada facada;
	
	public Menu()
	{
		facada = new Facada("Jugador 1", "Jugador 2");
		InicializarPokemons();
	}

	private void InicializarPokemons()
	{
		var jugador1Pokemon = facada.SeleccionarPokemonParaJugar(1);
		var jugador2Pokemon = facada.SeleccionarPokemonParaJugar(2);

		facada.AgregarPokemonAJugador(1, jugador1Pokemon);
		facada.AgregarPokemonAJugador(2, jugador2Pokemon);
	}
	
	public void MostrarMenuPrincipal()
	{
		Console.WriteLine("Bienvenido al menu de batallas!");
		Console.WriteLine("1. Iniciar Batalla");
		Console.WriteLine("2. Salir");
		Console.WriteLine("Escriba su opcion: ");

		string opcion = Console.ReadLine();
		switch (opcion)
		{
			case "1":
				facada.IniciarPartida();
				break;
			case "2":
				Console.WriteLine("Gracias por jugar\nHasta la proxima!");
				break;
			default:
				Console.WriteLine("Opcion incorrecta");
				break;
		}
	}
}
