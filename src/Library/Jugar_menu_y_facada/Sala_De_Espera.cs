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
    public List<Jugador> listaEspera;

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
    public string UnirseALaListaDeEspera(Jugador jugador, List<Jugador> jugadoresCreados)
    {
        if (jugadoresCreados.Contains(jugador))
        {
            listaEspera.Add(jugador);
            return $"{jugador.Name} se unió a la lista de espera";
        }
        else
        {
            return "Solo los jugadores creados pueden unirse a la sala de espera.";
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
    public Jugador ObtenerJugador(out string mesajeJugador, string nombreJugador)
    {
        mesajeJugador = "";
        Jugador jugadorBuscado = null;
        foreach (var jugador in listaEspera)
        {
            if (jugador.Name == nombreJugador)
            {
                jugadorBuscado = jugador;
                mesajeJugador = null;
                return jugadorBuscado;
            }
        }
        if (jugadorBuscado == null)
        {
            mesajeJugador = $"{nombreJugador} no está en la sala de espera!";
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
        foreach (var jugador in listaEspera)
        {
            if (listaEspera.Count >= 1 && jugador.Name != nombreJugador)
            {
                return jugador;
            }
        }
        return null;
    }

    /// <summary>
    /// Elimina a un jugador de la lista de espera.
    /// </summary>
    /// <param name="jugador">El jugador a eliminar.</param>
    public string EliminarJugador(Jugador jugador)
    {
        string mensaje = null;
        foreach (var jugadoresEspera in listaEspera)
        {
            if (jugadoresEspera == jugador)
            {
                listaEspera.Remove(jugadoresEspera);
                mensaje += $"{jugadoresEspera.Name} salio de la sala de espera";
            }
        }
        return mensaje;
    }
/*
    /// <summary>
    /// Inicia una batalla entre los primeros dos jugadores en la lista de espera.
    /// </summary>
    public string IniciarBatallaSalaEspera()
    {
        string mensajeBatalla = "";
        mensajeBatalla = (listaEspera.Count.ToString());
        if (listaEspera.Count >= 2)
        {
            Jugador jugador1 = listaEspera[0];
            mensajeBatalla += jugador1.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar();
            Jugador jugador2 = listaEspera[1];
            mensajeBatalla += jugador2.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar();
            listaEspera.RemoveRange(0, 2);

            mensajeBatalla += $"¡{jugador1.Name} y {jugador2.Name} comenzaron una batalla!";

            Random random = new Random();
            Jugador primero = random.Next(2) == 0 ? jugador1 : jugador2;

            mensajeBatalla += $"{primero.Name} comienza la partida.";

            Batalla batalla = new Batalla(jugador1, jugador2);
            batalla.Iniciar_Batalla();
        }
        else
        {
            mensajeBatalla = "No hay jugadores suficientes en la lista de espera para batallar";
        }
        return mensajeBatalla;
    }
*/
}
