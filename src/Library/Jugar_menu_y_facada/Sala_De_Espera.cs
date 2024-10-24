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
    public string MostrarListaDeEspera()
    {
        if (listaEspera.Count > 0)
        {
            string lista = "Jugadores en lista de espera: \n";
            foreach (var jugador in listaEspera)
            {
                lista += $" 👦 {jugador.Name}";
            }

            return lista;
        }
        else
        {
            return "No hay jugadores en lista de espera.";
        }
    }

    public Jugador ObtenerJugador(string nombreJugador)
    {
        Jugador jugadorBuscado = new Jugador("buscado");
        foreach (var jugador in listaEspera)
        {
            if (jugador.Name == nombreJugador)
            {
                jugadorBuscado = jugador;
                return jugadorBuscado;
            }
            else
            {
                Console.WriteLine($"{nombreJugador} no esta en la sala de espera!");
                jugadorBuscado = null;
                return jugadorBuscado;
            }
        }
        return jugadorBuscado;
    }
    
    public Jugador ObtenerOtroJugador(string nombreJugador)
    {
        Jugador jugadorBuscado = new Jugador("buscado");
        foreach (var jugador in listaEspera)
        {
            if (listaEspera.Count >= 2 && jugador.Name != nombreJugador)
            {
                jugadorBuscado = jugador;
                return jugadorBuscado;
            }
            else
            {
                Console.WriteLine($"No hay rivales disponibles en la sala de espera.");
                jugadorBuscado = null;
                return jugadorBuscado;
            }
        }
        return jugadorBuscado;
    }

    public void EliminarJugador(Jugador jugador)
    {
        foreach (var jugadoresEspera in listaEspera)
        {
            if (jugadoresEspera == jugador)
            {
                listaEspera.Remove(jugadoresEspera);
            }
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