using Library; 
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace Library.Tests;

[TestFixture]
public class FacadaTests
{
    [Test]
    public void TestAgregarPokemonAJugador()
    {
        // Arrange
        string nombreJugador1 = "Ash";
        string nombreJugador2 = "Misty";
        Facada facada = new Facada(nombreJugador1, nombreJugador2);

        // Act
        facada.Jugador1.Seleccionar_6_Pokemons_Iniciales(); // Asumiendo que la función agrega Pokémon a la lista del jugador
        facada.Jugador2.Seleccionar_6_Pokemons_Iniciales();

        // Assert
        Assert.AreEqual(6, facada.Jugador1.ListPokemons.Count, "El jugador 1 debería tener 6 Pokémon.");
        Assert.AreEqual(6, facada.Jugador2.ListPokemons.Count, "El jugador 2 debería tener 6 Pokémon.");
    }

    [Test]
    public void TestIniciarPartida()
    {
        // Arrange
        string nombreJugador1 = "Ash";
        string nombreJugador2 = "Misty";
        Facada facada = new Facada(nombreJugador1, nombreJugador2);

        // Agregar Pokémon a los jugadores
        facada.Jugador1.Seleccionar_6_Pokemons_Iniciales();
        facada.Jugador2.Seleccionar_6_Pokemons_Iniciales();

        // Capturamos la salida de consola
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            facada.Iniciar_Nueva_Batalla(facada.Jugador1, facada.Jugador2); // Asegúrate de pasar los jugadores correctos

            // Assert
            string output = sw.ToString().Trim();
            Assert.IsTrue(output.Contains("Iniciando la batalla"), "La partida debería iniciar correctamente.");
        }
    }
}