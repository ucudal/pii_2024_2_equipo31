using System;
using System.Collections.Generic;

namespace Library;

public class Facada
{
    private Jugador jugador1;
	private Jugador jugador2;
	private Batalla batalla;
	private Sala_De_Espera salaDeEspera;
	
	public Facada (string nombreJugador1, string nombreJugador2)
	{
		jugador1 = new Jugador(nombreJugador1);
		jugador2 = new Jugador(nombreJugador2);
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

    public void Iniciar_Nueva_Batalla()	// CREO UNA NUEVA INSTANCIA DE BATALLA E INICIO
    {
        batalla = new Batalla(jugador1, jugador2);
		batalla.Iniciar_Batalla();
    }

    public void Unir_Jugador_A_La_Espera(Jugador jugador)
    {
	    salaDeEspera.UnirseALaListaDeEspera(jugador);
    }

    public void MostrarJugadoresEnEspera()
    {
	    salaDeEspera.MostrarListaDeEspera();
    }

    public void IniciarBatallaEnEspera()
    {
	    salaDeEspera.IniciarBatallaSalaEspera();
	    this.Iniciar_Nueva_Batalla();
    }

    public void AgregarMaquinaALaEspera()
    {
	    Maquina maquina = new Maquina("Computadora" + new Random().Next(1, 14));
	    salaDeEspera.UnirseALaListaDeEspera(maquina);
    }
}

