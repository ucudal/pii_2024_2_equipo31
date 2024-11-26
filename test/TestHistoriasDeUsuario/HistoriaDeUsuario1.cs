using NUnit.Framework;
using System.Collections.Generic;

namespace Library.Tests

[TestFixture]
public class Seleccionar6PokemonsInicialesTests
{
    [Test]
    public void Seleccionar_6_Pokemons_Iniciales_DeberiaAñadirPokemonALista()
    {
        // Arrange
        var jugador = new Jugador { Name = "Ash" };
        var pikachu = new Pokemon { ID = 1, Name = "Pikachu" };
        jugador.pokemonsDisponibles = new List<Pokemon> { pikachu };
        jugador.ListPokemons = new List<Pokemon>();

        // Act
        var resultado = jugador.Seleccionar_6_Pokemons_Iniciales(1);

        // Assert
        Assert.That(resultado, Does.Contain("🐵 Ash añadio a Pikachu")); // Verifica el mensaje correcto
        Assert.That(jugador.ListPokemons, Has.Count.EqualTo(1)); // Asegura que hay un Pokémon en la lista
        Assert.That(jugador.ListPokemons[0], Is.EqualTo(pikachu)); // Verifica que el Pokémon añadido es Pikachu
    }

    [Test]
    public void Seleccionar_6_Pokemons_Iniciales_DeberiaRechazarPokemonYaSeleccionado()
    {
        // Arrange
        var jugador = new Jugador { Name = "Ash" };
        var pikachu = new Pokemon { ID = 1, Name = "Pikachu" };
        jugador.pokemonsDisponibles = new List<Pokemon> { pikachu };
        jugador.ListPokemons = new List<Pokemon> { pikachu };

        // Act
        var resultado = jugador.Seleccionar_6_Pokemons_Iniciales(1);

        // Assert
        Assert.That(resultado, Does.Contain("🚫 Seleccion invalida o Pokemon ya seleccionado.")); // Mensaje de rechazo
        Assert.That(jugador.ListPokemons, Has.Count.EqualTo(1)); // No se añadió un Pokémon extra
    }

    [Test]
    public void Seleccionar_6_Pokemons_Iniciales_DeberiaRechazarSiYaHay6Pokemons()
    {
        // Arrange
        var jugador = new Jugador { Name = "Ash" };
        jugador.ListPokemons = new List<Pokemon>
        {
            new Pokemon { ID = 1, Name = "Pikachu" },
            new Pokemon { ID = 2, Name = "Charmander" },
            new Pokemon { ID = 3, Name = "Bulbasaur" },
            new Pokemon { ID = 4, Name = "Squirtle" },
            new Pokemon { ID = 5, Name = "Jigglypuff" },
            new Pokemon { ID = 6, Name = "Meowth" }
        };

        // Act
        var resultado = jugador.Seleccionar_6_Pokemons_Iniciales(7);

        // Assert
        Assert.That(resultado, Does.Contain("Selección completada: tienes 6 pokemom.")); // Mensaje de rechazo
        Assert.That(jugador.ListPokemons, Has.Count.EqualTo(6)); // Verifica que no se añadió ningún Pokémon extra
    }
}


