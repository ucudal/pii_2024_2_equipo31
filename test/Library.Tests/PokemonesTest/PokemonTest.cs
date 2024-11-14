using NUnit.Framework;
using System.Collections.Generic;

namespace Library.Tests
{
    [TestFixture] // Asegúrate de incluir este atributo en la clase de pruebas
    public class PokemonTests
    {
        [Test]
        public void TestElPokemonEstaDerrotado_CuandoHpEsCero()
        {
            // Arrange
            Pokemon pokemon = new Pokemon(1, "Pikachu", 80, 45, "eléctrico", new List<IAtaque>());
            pokemon.Hp = 0; // Simulamos que el Pokémon ha sido derrotado

            // Act
            bool resultado = pokemon.El_Pokemon_Esta_Derrotado();

            // Assert
            Assert.IsTrue(resultado, "Se esperaba que el Pokémon estuviera derrotado.");
        }

        [Test]
        public void TestElPokemonEstaDerrotado_CuandoHpEsPositivo()
        {
            // Arrange
            Pokemon pokemon = new Pokemon(1, "Pikachu", 80, 45, "eléctrico", new List<IAtaque>());
            pokemon.Hp = 50; // El Pokémon está vivo

            // Act
            bool resultado = pokemon.El_Pokemon_Esta_Derrotado();

            // Assert
            Assert.IsFalse(resultado, "Se esperaba que el Pokémon no estuviera derrotado.");
        }
    }
}

