using System;
using System.Collections.Generic;

namespace Library;

/// <summary>
/// Clase que representa la sala de espera para jugadores que desean unirse a una batalla.
/// </summary>
public class Sala_De_Espera
{
    /// <summary>
    /// Lista de jugadores en la sala de espera.
    /// </summary>
    public List<Jugador> listaEspera = new List<Jugador>();

    /// <summary>
    /// Lista de jugadores que fueron creados en el sistema.
    /// </summary>
    public List<Jugador> jugadoresCreados { get; set; } = new List<Jugador>();

    /// <summary>
    /// Constructor de la clase <see cref="Sala_De_Espera"/>.
    /// </summary>
    public Sala_De_Espera()
    {
        listaEspera = new List<Jugador>();
    }

    /// <summary>
    /// Agrega un jugador a la lista de jugadores creados.
    /// </summary>
    /// <param name="jugador">El jugador a agregar.</param>
    public void AgregarJugadorCreado(Jugador jugador)
    {
        jugadoresCreados.Add(jugador);
    }

    /// <summary>
    /// Permite que un jugador se una a la lista de espera si fue creado previamente.
    /// </summary>
    /// <param name="jugador">El jugador que desea unirse.</param>
    /// <param name="jugadoresCreados">Lista de jugadores creados.</param>
    public void UnirseALaListaDeEspera(Jugador jugador, List<Jugador> jugadoresCreados)
    {
        if (jugadoresCreados.Contains(jugador))
        {
            listaEspera.Add(jugador);
            Console.WriteLine($"{jugador.Name} se unió a la lista de espera");
        }
        else
        {
            Console.WriteLine("Solo los jugadores creados pueden unirse a la sala de espera.");
        }
    }

    /// <summary>
    /// Muestra los jugadores que están en la lista de espera.
    /// </summary>
    /// <returns>Cadena con los nombres de los jugadores en la lista de espera.</returns>
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

    /// <summary>
    /// Busca y obtiene un jugador de la lista de espera por su nombre.
    /// </summary>
    /// <param name="nombreJugador">Nombre del jugador a buscar.</param>
    /// <returns>El jugador encontrado o null si no está en la lista de espera.</returns>
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
                Console.WriteLine($"{nombreJugador} no está en la sala de espera!");
                jugadorBuscado = null;
                return jugadorBuscado;
            }
        }
        return jugadorBuscado;
    }

    /// <summary>
    /// Busca y obtiene un jugador distinto en la lista de espera para formar un equipo de batalla.
    /// </summary>
    /// <param name="nombreJugador">Nombre del jugador que quiere un rival.</param>
    /// <returns>Un jugador disponible en la lista o null si no hay o es el mismo.</returns>
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

    /// <summary>
    /// Elimina a un jugador de la lista de espera.
    /// </summary>
    /// <param name="jugador">El jugador a eliminar.</param>
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

    /// <summary>
    /// Inicia una batalla entre los primeros dos jugadores en la lista de espera.
    /// </summary>
    public void IniciarBatallaSalaEspera()
    {
        Console.WriteLine(listaEspera.Count);
        if (listaEspera.Count >= 2)
        {
            Jugador jugador1 = listaEspera[0];
            Console.WriteLine(jugador1.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar());
            Jugador jugador2 = listaEspera[1];
            Console.WriteLine(jugador2.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar());
            listaEspera.RemoveRange(0, 2);

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
