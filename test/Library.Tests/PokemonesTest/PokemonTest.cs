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
            pokemon.El_Pokemon_Recibio_Daño(99999); 
            // el pokemon recibe un ataque que lo dejara sin vida

            // Act
            bool resultado = pokemon.El_Pokemon_Esta_Derrotado();
            // reviso si esta derrotado, deberia dar true ya que no tiene mas vida

            // Assert
            Assert.IsTrue(resultado);
        }
        

        [Test]
        public void TestElPokemonEstaDerrotado_CuandoHpEsPositivo()
        {
            // Arrange
            Pokemon pokemon = new Pokemon(1, "Pikachu", 80, 45, "eléctrico", new List<IAtaque>());
            // el pokemon tiene vida porque no recibio ningun ataque
            
            // Act
            bool resultado = pokemon.El_Pokemon_Esta_Derrotado();
            // reviso si el pokemon esta derrotado, mientras aun tiene vida 
            
            // Assert
            Assert.IsFalse(resultado);
            // el resultado debe ser falso ya que no esta derrotado
        }
    }
}

