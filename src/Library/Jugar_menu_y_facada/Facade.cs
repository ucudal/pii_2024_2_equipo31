using System;
using System.Collections.Generic;

namespace Library;

public class Facada
{
    private Jugador jugador1;
<<<<<<< HEAD
<<<<<<< HEAD
    private Jugador jugador2;
    private Batalla batalla;

    public Facada(string nombreJugador1, string nombreJugador2)
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

    public void AgregarPokemonAJugador(int jugadorNumero)
    {
        if (jugadorNumero == 1)
        {
            jugador1.SeleccionarPokemons();
        }
        else if (jugadorNumero == 2)
        {
            jugador2.SeleccionarPokemons();
        }
    }
=======
=======
>>>>>>> origin/agustin
	private Jugador jugador2;
	private Batalla batalla;
	private Sala_De_Espera salaDeEspera;

	public Jugador Jugador2 => jugador2;
	public Facada (string nombreJugador1, string nombreJugador2 = null)
	{
		jugador1 = new Jugador(nombreJugador1);
		if (nombreJugador2 != null)
		{
			jugador2 = new Jugador(nombreJugador2);
		}
		salaDeEspera = new Sala_De_Espera();
	}
	
	public void Cada_Jugador_Agrega_Pokemons(int jugadorNumero)	// SEGUN EL JUGADOR, SELECCIONO LOS POKEMONS INICIALES
	{
		if (jugadorNumero == 1)
		{
			jugador1.Seleccionar_6_Pokemons_Iniciales();
		}
		else if (jugadorNumero == 2)
		{
			jugador2.Seleccionar_6_Pokemons_Iniciales();
		}
	}
<<<<<<< HEAD
>>>>>>> origin/agustin

    public void Iniciar_Nueva_Batalla()	// CREO UNA NUEVA INSTANCIA DE BATALLA E INICIO
    {
<<<<<<< HEAD
        batalla = new Batalla(jugador1, jugador2);
        batalla.Iniciar();
    }

    public List<Pokemon> ObtenerPokemonsJugador1()
    {
        return jugador1.ListPokemons;
    }

    public List<Pokemon> ObtenerPokemonsJugador2()
    {
        return jugador2.ListPokemons;
=======
=======

    public void Iniciar_Nueva_Batalla()	// CREO UNA NUEVA INSTANCIA DE BATALLA E INICIO
    {
>>>>>>> origin/agustin
	    if (jugador2 != null)
	    {
		    batalla = new Batalla(jugador1, jugador2);
	    }
	    else
	    {
		    Console.WriteLine("No hay suficientes jugadores para iniciar una batalla.");
		    return;
	    }
		batalla.Iniciar_Batalla();
    }

    public void Unir_Jugador_A_La_Espera(Jugador jugador)
    {
	    salaDeEspera.AgregarJugadorCreado(jugador);
	    salaDeEspera.UnirseALaListaDeEspera(jugador, salaDeEspera.jugadoresCreados);
    }
    
    public void IniciarBatallaEnEspera()
    {
	    if (salaDeEspera.listaEspera.Count >= 1)
	    {
		    Jugador jugadorEnEspera1 = salaDeEspera.listaEspera[0];
		    salaDeEspera.IniciarBatallaSalaEspera();
	    }
	    else
	    {
		    Console.WriteLine("No hay suficientes jugadores en la sala de espera.");
	    }
    }

    public void MostrarJugadoresEnEspera()
    {
	    salaDeEspera.MostrarListaDeEspera();
<<<<<<< HEAD
>>>>>>> origin/agustin
=======
    }

    public List<Pokemon> ObtenerPokemonsJugador2()
    {
        return jugador2.ListPokemons;
>>>>>>> origin/agustin
    }
}
