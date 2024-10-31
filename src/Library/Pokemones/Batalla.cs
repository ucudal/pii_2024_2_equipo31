using System;
using System.Collections.Generic;

namespace Library;

/// <summary>
/// Representa una batalla entre dos jugadores con sus respectivos Pokémon.
/// </summary>
public class Batalla
{
    private Jugador jugador1;
    private Jugador jugador2;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Batalla"/> con los jugadores especificados.
    /// </summary>
    /// <param name="jugador1">El primer jugador participante en la batalla.</param>
    /// <param name="jugador2">El segundo jugador participante en la batalla.</param>
    public Batalla(Jugador jugador1, Jugador jugador2)
    {
        this.jugador1 = jugador1;
        this.jugador2 = jugador2;
    }

    /// <summary>
    /// Inicia la batalla entre los jugadores, permitiendo que cada uno de ellos tome turnos alternos hasta que uno pierda.
    /// </summary>
    public void Iniciar_Batalla()
    {
        Console.WriteLine("\nIniciando la batalla.");
        Console.WriteLine($"Pokemos del jugador 1: {jugador1.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar()}");
        if (!jugador1.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar())
        {
            Console.WriteLine("No hay suficientes pokemons para iniciar una batalla");
            return;
        }

        Pokemon pokemon1 = jugador1.Seleccionar_Pokemons_Para_Luchar();
        Pokemon pokemon2 = null;

        if (jugador2 != null)
        {
            pokemon2 = jugador2.Seleccionar_Pokemons_Para_Luchar();
        }

        Random random = new Random();
        bool esTurnoJugador1 = random.Next(2) == 0;

        while (jugador1.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar() &&
               (jugador2 == null || jugador2.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar()))
        {
            if (esTurnoJugador1)
            {
                if (!pokemon1.El_Pokemon_Esta_Derrotado() || jugador1.CantidadItems[3].Cantidad != 0)
                {
                    Cada_Jugador_Tomar_Su_Turno(jugador1, ref pokemon1, pokemon2);
                    if (!jugador1.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar())
                    {
                        Console.WriteLine($"{jugador1.Name} perdió la batalla");
                        break;
                    }
                }
                else if (pokemon1.El_Pokemon_Esta_Derrotado() && jugador1.CantidadItems[3].Cantidad == 0)
                {
                    pokemon1 = jugador1.Seleccionar_Pokemons_Para_Luchar();
                    continue;
                }

                esTurnoJugador1 = false;
            }
            else
            {
                if (!pokemon2.El_Pokemon_Esta_Derrotado() || (jugador2 != null && jugador2.CantidadItems[3].Cantidad != 0))
                {
                    Cada_Jugador_Tomar_Su_Turno(jugador2, ref pokemon2, pokemon1);
                    if (!jugador2.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar())
                    {
                        Console.WriteLine($"{jugador2.Name} perdió la batalla");
                        break;
                    }
                }
                else if (pokemon2.El_Pokemon_Esta_Derrotado() && jugador2.CantidadItems[3].Cantidad == 0)
                {
                    pokemon2 = jugador2.Seleccionar_Pokemons_Para_Luchar();
                    continue;
                }

                esTurnoJugador1 = true;
            }
        }
    }

    /// <summary>
    /// Permite que cada jugador realice sus acciones de batalla en su turno, afectando al Pokémon oponente.
    /// </summary>
    /// <param name="jugador">El jugador que toma el turno.</param>
    /// <param name="propio">El Pokémon del jugador que toma el turno.</param>
    /// <param name="oponente">El Pokémon oponente.</param>
    public void Cada_Jugador_Tomar_Su_Turno(Jugador jugador, ref Pokemon propio, Pokemon oponente)
    {
        jugador.Acciones_Del_Jugador_En_Batalla(ref propio, oponente);
        Cada_Jugador_Actualiza_Los_Enfriamientos_De_Ataques_Especiales(jugador);
    }

    /// <summary>
    /// Actualiza los tiempos de enfriamiento de los ataques especiales de cada Pokémon del jugador.
    /// </summary>
    /// <param name="jugador">El jugador cuyos Pokémon actualizan sus ataques especiales.</param>
    public void Cada_Jugador_Actualiza_Los_Enfriamientos_De_Ataques_Especiales(Jugador jugador)
    {
        foreach (var pokemon in jugador.ListPokemons)
        {
            foreach (var ataque in pokemon.Ataques)
            {
                if (ataque is AtaqueEspecial ataqueEspecial)
                {
                    ataqueEspecial.ReducirEnfriamiento();
                }
            }
        }
    }
}
