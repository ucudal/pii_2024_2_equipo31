using System;
using System.Collections.Generic;

namespace Library;

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

    public void Iniciar_Nueva_Batalla()	// CREO UNA NUEVA INSTANCIA DE BATALLA E INICIO
    {
        batalla = new Batalla(jugador1, jugador2);
		batalla.Iniciar_Batalla();
    }
}

