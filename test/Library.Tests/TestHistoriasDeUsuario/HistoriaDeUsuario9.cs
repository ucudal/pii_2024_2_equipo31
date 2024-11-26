namespace Library.Tests;

using System.Collections.Generic; // Necesario para usar listas.
using Xunit; // Marco de pruebas utilizado.

public class HistoriaDeUsuario9
{
    // Clase auxiliar para representar un jugador.
    public class Jugador
    {
        public string Nombre { get; private set; } // Nombre del jugador.

        public Jugador(string nombre)
        {
            Nombre = nombre; // Se inicializa el nombre al crear el jugador.
        }
    }

    // Clase para simular la sala de espera.
    public class SalaDeEspera
    {
        public List<Jugador> jugadoresCreados = new List<Jugador>(); // Lista de jugadores creados.
        public List<Jugador> listaDeEspera = new List<Jugador>();   // Lista de jugadores en espera.

        // Agrega un jugador a la lista de jugadores creados.
        public void AgregarJugadorCreado(Jugador jugador)
        {
            jugadoresCreados.Add(jugador);
        }

        // Permite a un jugador unirse a la lista de espera si está en la lista de jugadores creados.
        public void UnirseALaListaDeEspera(Jugador jugador, List<Jugador> jugadores)
        {
            if (jugadores.Contains(jugador)) // Solo se une si ya fue creado.
            {
                listaDeEspera.Add(jugador);
            }
        }
    }

    // Clase principal que contiene el método a probar.
    public class SistemaDeJuego
    {
        private SalaDeEspera _salaDeEspera; // Dependencia de SalaDeEspera.

        public SistemaDeJuego(SalaDeEspera salaDeEspera)
        {
            _salaDeEspera = salaDeEspera; // Se inicializa con una instancia de SalaDeEspera.
        }

        // Método que crea un jugador y lo agrega a la sala de espera.
        public void UnirJugador(string nombreJugador)
        {
            Jugador jugador = new Jugador(nombreJugador); // Se crea un jugador con el nombre proporcionado.
            _salaDeEspera.AgregarJugadorCreado(jugador);  // Se agrega a la lista de jugadores creados.
            _salaDeEspera.UnirseALaListaDeEspera(jugador, _salaDeEspera.jugadoresCreados); // Se une a la lista de espera.
        }
    }

    // Caso de prueba para el método UnirJugador.
    [Fact]
    public void UnirJugador_Debe_CrearJugadorYAgregarloCorrectamente()
    {
        // Arrange: Configuramos el entorno inicial.
        var salaDeEspera = new SalaDeEspera(); // Se crea una sala de espera vacía.
        var sistemaDeJuego = new SistemaDeJuego(salaDeEspera); // Se crea el sistema de juego con la sala de espera.

        // Act: Llamamos al método con un nombre de jugador.
        sistemaDeJuego.UnirJugador("Ash Ketchum");

        // Assert: Verificamos que el jugador fue agregado correctamente.
        Assert.Single(salaDeEspera.jugadoresCreados); // Debe haber un único jugador creado.
        Assert.Equal("Ash Ketchum", salaDeEspera.jugadoresCreados[0].Nombre); // El nombre debe coincidir.
        Assert.Single(salaDeEspera.listaDeEspera); // Debe haber un único jugador en la lista de espera.
        Assert.Equal("Ash Ketchum", salaDeEspera.listaDeEspera[0].Nombre); // El nombre debe coincidir también aquí.
    }
}

