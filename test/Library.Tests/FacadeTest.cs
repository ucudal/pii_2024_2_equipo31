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

        // Simular entradas de usuario
        Queue<string> nombresDePokemonEntrada = new Queue<string>(new[] { "Pikachu", "Charmander", "Bulbasaur", "InvalidPokemon", "Charmander", "Squirtle" });

        // Función de entrada simulada
        string ObtenerEntradaSimulada() => nombresDePokemonEntrada.Dequeue();

        // Act
        facada.AgregarPokemonAJugador(1); // Agregar Pokémon para el jugador 1

        // Assert
        Assert.AreEqual(3, facada.ObtenerPokemonsJugador1().Count, "El jugador 1 debería tener 3 Pokémon.");
        Assert.AreEqual("Pikachu", facada.ObtenerPokemonsJugador1()[0].Name, "El primer Pokémon debería ser Pikachu.");
        Assert.AreEqual("Charmander", facada.ObtenerPokemonsJugador1()[1].Name, "El segundo Pokémon debería ser Charmander.");
        Assert.AreEqual("Bulbasaur", facada.ObtenerPokemonsJugador1()[2].Name, "El tercer Pokémon debería ser Bulbasaur.");

    }

    [Test]
    public void TestIniciarPartida()
    {
        // Arrange
        string nombreJugador1 = "Ash";
        string nombreJugador2 = "Misty";
        Facada facada = new Facada(nombreJugador1, nombreJugador2);

        // Agregar Pokémon a los jugadores
        facada.AgregarPokemonAJugador(1);
        facada.AgregarPokemonAJugador(2);

        // Capturamos la salida de consola
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            facada.IniciarPartida();

            // Assert
            string output = sw.ToString().Trim();
            Assert.IsTrue(output.Contains("Iniciando la batalla"), "La partida debería iniciar correctamente.");
        }
    }
}
