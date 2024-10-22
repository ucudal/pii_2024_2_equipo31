using System;
using System.Collections.Generic;

namespace Library;

public class Sala_De_Espera
{
    private List<Jugador> listaEspera = new List<Jugador>();

    public Sala_De_Espera()
    {
        listaEspera = new List<Jugador>();
    }
    public void UnirseALaListaDeEspera(Jugador jugador)
    {
        listaEspera.Add(jugador);
        Console.WriteLine($"{jugador.Name} se unio a la lista de espera.");
    }

    public void MostrarListaDeEspera()
    {
        if (listaEspera.Count > 0)
        {
            Console.WriteLine("Jugadores en lista de espera: ");
            foreach (var jugador in listaEspera)
            {
                Console.WriteLine($"- {jugador.Name}");
            }
        }
        else
        {
            Console.WriteLine("No hay jugadores en lista de espera.");
        }
    }

    public void IniciarBatallaSalaEspera()
    {
        if (listaEspera.Count >= 2)
        {
            Jugador jugador1 = listaEspera[0];
            Jugador jugador2 = listaEspera[1];
            listaEspera.RemoveRange(0,2);
            
            Console.WriteLine($"¡{jugador1.Name} y {jugador2.Name} comenzaron una batalla!");

            Random random = new Random();
            Jugador primero = random.Next(2) == 0 ? jugador1 : jugador2;
            
            Console.WriteLine($"{primero.Name} comienza la partida.");
            Batalla batalla = new Batalla(jugador1, jugador2);
        }
        else
        {
            Console.WriteLine("No hay jugadores suficientes en la lista de espera para batallar");
        }
    }
}