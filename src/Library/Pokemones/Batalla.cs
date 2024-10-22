using System;
using System.Collections.Generic;

namespace Library;

public class Batalla
{
    private Jugador jugador1;
    private Jugador jugador2;

    public Batalla(Jugador jugador1, Jugador jugador2)
    {
        this.jugador1 = jugador1;
        this.jugador2 = jugador2;
    }

    public void Iniciar_Batalla() // INICIA LA BATALLA EN SI
    {
        Console.WriteLine("\nIniciando la batalla.");

        if (!jugador1.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar())
        {
            Console.WriteLine("No hay suficientes pokemons para inciar una batalla");
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
                if (!pokemon1.El_Pokemon_Esta_Derrotado() || jugador1.CantidadItems[1] != 0)
                {
                    Cada_Jugador_Tomar_Su_Turno(jugador1, ref pokemon1, pokemon2);
                    if (!jugador1.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar())
                    {
                        Console.WriteLine($"{jugador1.Name} perdio la batalla");
                        break;
                    }
                }
                else if (pokemon1.El_Pokemon_Esta_Derrotado() && jugador1.CantidadItems[1] == 0)
                {
                    pokemon1 = jugador1.Seleccionar_Pokemons_Para_Luchar();
                    continue;
                }

                esTurnoJugador1 = false;
            }
            else
            {
                if (!pokemon2.El_Pokemon_Esta_Derrotado() || (jugador2 != null && jugador2.CantidadItems[1] != 0))
                {
                    Cada_Jugador_Tomar_Su_Turno(jugador2, ref pokemon2, pokemon1);
                    if (!jugador2.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar())
                    {
                        Console.WriteLine($"{jugador2.Name} perdio la batalla");
                        break;
                    }
                }
                else if (pokemon2.El_Pokemon_Esta_Derrotado() && jugador2.CantidadItems[1] == 0)
                {
                    pokemon2 = jugador2.Seleccionar_Pokemons_Para_Luchar();
                    continue;
                }

                esTurnoJugador1 = true;
            }
        }
    }
    public void Cada_Jugador_Tomar_Su_Turno(Jugador jugador, ref Pokemon propio, Pokemon oponente) // CADA JUGADOR ENTRA EN SU SELECCION DE ACCIONES POR TURNO
    {
        jugador.Acciones_Del_Jugador_En_Batalla(ref propio, oponente);
        Cada_Jugador_Actualiza_Los_Enfriamientos_De_Ataques_Especiales(jugador);
    }

    public void Cada_Jugador_Actualiza_Los_Enfriamientos_De_Ataques_Especiales(Jugador jugador) // ACTUALIZA EL ENFRIAMIENTO DE LOS ATAQUES ESPECIALES
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