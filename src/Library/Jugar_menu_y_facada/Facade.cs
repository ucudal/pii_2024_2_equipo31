using System;
using System.Collections.Generic;

namespace Library;

/// <summary>
/// Representa la fachada principal para gestionar jugadores, batallas y la sala de espera.
/// </summary>
public class Facada
{
    private Jugador jugador1;
    private Jugador jugador2;
    private Batalla batalla;
    private Sala_De_Espera salaDeEspera;

    /// <summary>
    /// Obtiene el primer jugador.
    /// </summary>
    public Jugador Jugador1 => jugador1;

    /// <summary>
    /// Obtiene el segundo jugador.
    /// </summary>
    public Jugador Jugador2 => jugador2;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Facada"/> con el nombre del primer jugador y opcionalmente del segundo jugador.
    /// </summary>
    /// <param name="nombreJugador1">Nombre del primer jugador.</param>
    /// <param name="nombreJugador2">Nombre del segundo jugador (opcional).</param>
    public Facada(string nombreJugador1, string nombreJugador2 = null)
    {
        jugador1 = new Jugador(nombreJugador1);
        if (nombreJugador2 != null)
        {
            jugador2 = new Jugador(nombreJugador2);
        }
        salaDeEspera = new Sala_De_Espera();
    }

    /// <summary>
    /// Permite que cada jugador seleccione sus Pokémon iniciales en función de su número.
    /// </summary>
    /// <param name="jugadorNumero">El número del jugador (1 o 2) que selecciona sus Pokémon iniciales.</param>
    public void Cada_Jugador_Agrega_Pokemons(int jugadorNumero)
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

    /// <summary>
    /// Crea una nueva instancia de batalla entre dos jugadores y la inicia.
    /// </summary>
    /// <param name="jugador1">El primer jugador en la batalla.</param>
    /// <param name="jugador2">El segundo jugador en la batalla (opcional).</param>
    public void Iniciar_Nueva_Batalla(Jugador jugador1, Jugador jugador2 = null)
    {
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

    /// <summary>
    /// Agrega un jugador a la sala de espera.
    /// </summary>
    /// <param name="jugador">El jugador que se agrega a la sala de espera.</param>
    public void Unir_Jugador_A_La_Espera(Jugador jugador)
    {
        salaDeEspera.AgregarJugadorCreado(jugador);
        salaDeEspera.UnirseALaListaDeEspera(jugador, salaDeEspera.jugadoresCreados);
    }

    /// <summary>
    /// Inicia una batalla entre los jugadores en la sala de espera.
    /// </summary>
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

    /// <summary>
    /// Muestra la lista de jugadores en la sala de espera.
    /// </summary>
    public string MostrarJugadoresEnEspera()
    {
        return salaDeEspera.MostrarListaDeEspera();
    }
}
