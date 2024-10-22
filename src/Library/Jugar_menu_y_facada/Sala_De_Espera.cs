using System;
using System.Collections.Generic;

namespace Library;

public class Sala_De_Espera
{
    public List<Jugador> listaEspera = new List<Jugador>();
    public List<Jugador> jugadoresCreados { get; set; } = new List<Jugador>();

    public Sala_De_Espera()
    {
        listaEspera = new List<Jugador>();
    }

    public void AgregarJugadorCreado(Jugador jugador)
    {
        jugadoresCreados.Add(jugador);
    }
    public void UnirseALaListaDeEspera(Jugador jugador, List<Jugador> jugadoresCreados)
    {
        if (jugadoresCreados.Contains(jugador))
        {
            listaEspera.Add(jugador);
            Console.WriteLine($"{jugador.Name} se unio a la lista de espera");
        }
        else
        {
            Console.WriteLine("Solo los jugadores creados pueden unirse a la sala de espera.");
        }
    }
    public void MostrarListaDeEspera()
    {
        if (listaEspera.Count > 0)
        {
            Console.WriteLine("Jugadores en lista de espera: ");
            foreach (var jugador in listaEspera)
            {
                Console.WriteLine($" 👦 {jugador.Name}");
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
            batalla.Iniciar_Batalla();
        }
        else
        {
            Console.WriteLine("No hay jugadores suficientes en la lista de espera para batallar");
        }
    }
}