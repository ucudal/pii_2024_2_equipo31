using System;
using System.Collections.Generic;

namespace Library;

// En esta clase pondre los metodos que necesite posteriormente, como curar, mostrar estado de la batalla, etc.

public class Facada
{
    private Jugador jugador1;
	private Jugador jugador2;
	private Batalla batalla;
	
	public Facada (string nombreJugador1, string nombreJugador2)
	{
		jugador1 = new Jugador(nombreJugador1);
		jugador2 = new Jugador(nombreJugador2);
	}
	
	public Pokemon SeleccionarPokemonParaJugar(int jugadorNumero)
	{
		if (jugadorNumero == 1)
		{
			return jugador1.Seleccionar_Pokemons();
		}
		else if (jugadorNumero == 2)
		{
			return jugador2.Seleccionar_Pokemons();
		}
		return null;
	}

	public void AgregarPokemonAJugador(int jugadorNumero, Pokemon pokemon)
	{
		if (jugadorNumero == 1)
		{
			jugador1.ListPokemons.Add(pokemon);
		}
		else if (jugadorNumero == 2)
		{
			jugador2.ListPokemons.Add(pokemon);
		}
	}


    public void IniciarPartida()
    {
        batalla = new Batalla(jugador1, jugador2);
		batalla.Iniciar();
    }
}

