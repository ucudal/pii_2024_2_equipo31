namespace Library.Tests;
using Library;
using Xunit;

public class HistoriaDeUsuario9
{
    // Caso de prueba para el método UnirJugador.
    [Test]
    public void UnirJugador_Debe_CrearJugadorYAgregarloCorrectamente()
    {
        Jugador jugador = new Jugador("pepe");
        // Arrange: Configuramos el entorno inicial.
        var salaDeEspera = new Sala_De_Espera(); // Se crea una sala de espera vacía.
        var facada = new Facada(salaDeEspera);
        
        // Act: Llamamos al método con un nombre de jugador.
        facada.UnirJugador(jugador.Name);
        
        // Assert: Verificamos que el jugador fue agregado correctamente.
        Assert.Single(salaDeEspera.jugadoresCreados); // Debe haber un único jugador creado.
        Assert.Equal("pepe", salaDeEspera.jugadoresCreados[0].Name); // El nombre debe coincidir.
        Assert.Single(salaDeEspera.listaEspera); // Debe haber un único jugador en la lista de espera.
        Assert.Equal("pepe", salaDeEspera.listaEspera[0].Name); // El nombre debe coincidir también aquí.
    }
}

