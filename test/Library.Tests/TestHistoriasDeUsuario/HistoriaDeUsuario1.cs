using System;
using System.Collections.Generic;
using NUnit.Framework; // Usando NUnit como ejemplo para Test
using Library; // Asegúrate de usar el namespace correcto

namespace LibraryTests;
{
    
}

[TestFixture]
public class JugadorTests
{
    [Test]
    public void Seleccionar_6_Pokemons_Iniciales_Agrega_Pokemon_Valido()
    {
        // Arrange
        var jugador = new Jugador("Ash"); // Crear un jugador llamado Ash

        var ataque = new Ataque(); // Crear un ataque
        var pikachu = new Pokemon(1, "Pikachu", 100, 50, "Eléctrico", new List<IAtaque> { ataque }); // Crear un Pokémon
        var charmander = new Pokemon(2, "Charmander", 120, 40, "Fuego", new List<IAtaque> { ataque });

        // Lista de pokémon disponibles
        jugador.PokemonsDisponibles = new List<Pokemon> { pikachu, charmander };

        // Act
        string mensaje1 = jugador.Seleccionar_6_Pokemons_Iniciales(1); // Seleccionar Pikachu
        string mensaje2 = jugador.Seleccionar_6_Pokemons_Iniciales(2); // Seleccionar Charmander

        // Assert
        Assert.Contains(pikachu, jugador.ListPokemons); // Verificar que Pikachu está en la lista
        Assert.Contains(charmander, jugador.ListPokemons); // Verificar que Charmander está en la lista
        Assert.IsFalse(jugador.PokemonsDisponibles.Contains(pikachu)); // Verificar que Pikachu fue eliminado de disponibles
        Assert.IsFalse(jugador.PokemonsDisponibles.Contains(charmander)); // Verificar que Charmander fue eliminado de disponibles
        Assert.AreEqual("\n 🐵 Ash añadio a Pikachu", mensaje1.Trim());
        Assert.AreEqual("\n 🐵 Ash añadio a Charmander", mensaje2.Trim());
    }

    [Test]
    public void Seleccionar_6_Pokemons_Iniciales_No_Agrega_Si_Limite_Alcanzado()
    {
        // Arrange
        var jugador = new Jugador("Ash");
        var ataque = new Ataque();
        var pokemons = new List<Pokemon>
        {
            new Pokemon(1, "Pikachu", 100, 50, "Eléctrico", new List<IAtaque> { ataque }),
            new Pokemon(2, "Charmander", 120, 40, "Fuego", new List<IAtaque> { ataque }),
            new Pokemon(3, "Bulbasaur", 110, 45, "Planta", new List<IAtaque> { ataque }),
            new Pokemon(4, "Squirtle", 105, 55, "Agua", new List<IAtaque> { ataque }),
            new Pokemon(5, "Pidgey", 90, 30, "Volador", new List<IAtaque> { ataque }),
            new Pokemon(6, "Rattata", 85, 25, "Normal", new List<IAtaque> { ataque })
        };

        jugador.ListPokemons.AddRange(pokemons); // Ya tiene 6 Pokémon
        jugador.PokemonsDisponibles = new List<Pokemon>
        {
            new Pokemon(7, "Eevee", 95, 35, "Normal", new List<IAtaque> { ataque })
        };

        // Act
        string mensaje = jugador.Seleccionar_6_Pokemons_Iniciales(7); // Intentar añadir un 7° Pokémon

        // Assert
        Assert.AreEqual("\nSelección completada: tienes 6 pokemom.", mensaje.Trim());
        Assert.AreEqual(6, jugador.ListPokemons.Count); // Asegurar que tiene solo 6
    }
}
