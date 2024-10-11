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

    public void Iniciar()
    {
        Console.WriteLine("Todos los jugadores deben seleccionar 6 Pokemons para poder batallar.");

        jugador1.SeleccionarPokemons();
        jugador2.Seleccionar_Pokemons();
        
        Pokemon pokemon1 = jugador1.Seleccionar_Pokemons();
        Pokemon pokemon2 = jugador2.Seleccionar_Pokemons();

        if (pokemon1 == null || pokemon2 == null)
        {
            Console.WriteLine("No hay suficientes pokemons para inciar una batalla");
            return;
        }

        while (jugador1.TienePokemonsDisponibles() && jugador2.TienePokemonsDisponibles())
        {
            TomarTurno(jugador1, pokemon1, pokemon2);
            if (pokemon2.EstaDerrotado())
            {
                Console.WriteLine($"{jugador1.Name} gano la batalla");
                break;
            }

            TomarTurno(jugador2, pokemon2, pokemon1);
            if (pokemon1.EstaDerrotado())
            {
                Console.WriteLine($"{jugador2.Name} gano la batalla");
                break;
            }
        }
    }

    public void TomarTurno(Jugador jugador, Pokemon propio, Pokemon oponente)
    {
        jugador.TomarDecision(propio, oponente);
        ActualizarEnfriamientos(jugador);
    }

    public void ActualizarEnfriamientos(Jugador jugador)
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