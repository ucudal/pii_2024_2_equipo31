using System;
using System.Collections.Generic;
using NUnit.Framework;
using Library;


    [Test]
    public void TestSeleccionarPokemons()
    {
        // Arrange
        Jugador jugadorAsh = new Jugador("Ash");

        // Simular entradas de usuario
        Queue<string> nombresDePokemonEntrada = new Queue<string>(new[] { "Pikachu", "Charmander", "Bulbasaur", "InvalidPokemon", "Charmander", "Squirtle" });

        // Función de entrada simulada
        string ObtenerEntradaSimulada() => nombresDePokemonEntrada.Dequeue();

        // Act
        jugadorAsh.SeleccionarPokemons(ObtenerEntradaSimulada);

        // Assert
        Assert.AreEqual(3, jugadorAsh.ListPokemons.Count);
        Assert.AreEqual("Pikachu", jugadorAsh.ListPokemons[0].Name);
        Assert.AreEqual("Charmander", jugadorAsh.ListPokemons[1].Name);
        Assert.AreEqual("Bulbasaur", jugadorAsh.ListPokemons[2].Name);
    }
}
