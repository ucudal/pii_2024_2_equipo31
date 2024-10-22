using Library;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace Library.Tests;

[TestFixture]
public class BatallaTests
{
    [Test]
    public void TestIniciar_BatallaSinPokemonsDisponibles()
    {
        // Arrange
        Jugador jugador1 = new Jugador("Ash");
        Jugador jugador2 = new Jugador("Misty");
        jugador1.ListPokemons = new List<Pokemon>(); // Sin Pokémon disponibles
        jugador2.ListPokemons = new List<Pokemon>(); // Sin Pokémon disponibles

        Batalla batalla = new Batalla(jugador1, jugador2);
        
        // Capturamos la salida de consola
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            batalla.Iniciar();

            // Assert
            string output = sw.ToString().Trim();
            Assert.AreEqual("No hay suficientes pokemons para inciar una batalla", output);
        }
    }

    [Test]
    public void TestIniciar_BatallaConPokemonsDisponibles()
    {
        // Arrange
        Jugador jugador1 = new Jugador("Ash");
        jugador1.ListPokemons = new List<Pokemon>
        {
            new Pokemon("Pikachu", 80, 45, "eléctrico", new List<IAtaque>())
        };

        Jugador jugador2 = new Jugador("Misty");
        jugador2.ListPokemons = new List<Pokemon>
        {
            new Pokemon("Bulbasaur", 85, 70, "planta", new List<IAtaque>())
        };

        Batalla batalla = new Batalla(jugador1, jugador2);

        // Capturamos la salida de consola
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            batalla.Iniciar();

            // Assert
            string output = sw.ToString().Trim();
            Assert.IsTrue(output.Contains("Iniciando la batalla"), "La batalla debería iniciar correctamente.");
        }
    }

    [Test]
    public void TestTomarTurno()
    {
        // Arrange
        Jugador jugador1 = new Jugador("Ash");
        Pokemon pikachu = new Pokemon("Pikachu", 80, 45, "eléctrico", new List<IAtaque>());
        jugador1.ListPokemons = new List<Pokemon> { pikachu };
        Jugador jugador2 = new Jugador("Misty");
        Pokemon bulbasaur = new Pokemon("Bulbasaur", 85, 70, "planta", new List<IAtaque>());
        jugador2.ListPokemons = new List<Pokemon> { bulbasaur };

        Batalla batalla = new Batalla(jugador1, jugador2);

        // Act
        batalla.TomarTurno(jugador1, pikachu, bulbasaur);

        // Assert: Verificar que el turno se haya manejado sin errores
        // En este caso, podrías verificar que se haya ejecutado algún método en la clase Jugador o en Pokémon
    }

    [Test]
    public void TestActualizarEnfriamientos()
    {
        // Arrange
        Jugador jugador = new Jugador("Ash");
        Pokemon pikachu = new Pokemon("Pikachu", 80, 45, "eléctrico", new List<IAtaque>());
        AtaqueEspecial ataqueEspecial = new AtaqueEspecial("Rayo", 50, 2);
        pikachu.Ataques.Add(ataqueEspecial);
        jugador.ListPokemons = new List<Pokemon> { pikachu };

        Batalla batalla = new Batalla(jugador, new Jugador("Misty")); // Segundo jugador no importa para este test

        // Act
        batalla.ActualizarEnfriamientos(jugador);

        // Assert: Verificar que el enfriamiento se haya reducido
        Assert.AreEqual(1, ataqueEspecial.EnfriamientoMax, "El enfriamiento debería haberse reducido.");
    }
}
