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
        Console.WriteLine("\nIniciando la batalla.");

        if (!jugador1.TienePokemonsDisponibles() || !jugador2.TienePokemonsDisponibles())
        {
            Console.WriteLine("No hay suficientes pokemons para inciar una batalla");
            return;
        }
        
        Pokemon pokemon1 = jugador1.Seleccionar_Pokemons();
        Pokemon pokemon2 = jugador2.Seleccionar_Pokemons();
        
        while (jugador1.TienePokemonsDisponibles() && jugador2.TienePokemonsDisponibles())
        {
            TomarTurno(jugador1, pokemon1, pokemon2);
            if (!jugador1.TienePokemonsDisponibles())
            {
                Console.WriteLine($"{jugador1.Name} gano la batalla");
                break;
            }

            TomarTurno(jugador2, pokemon2, pokemon1);
            if (!jugador2.TienePokemonsDisponibles())
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