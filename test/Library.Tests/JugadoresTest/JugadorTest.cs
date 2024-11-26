using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Library.Tests
{
    public class JugadorTests
    {
        
        [Test]
        public void TestSeleccionar6PokemonsIniciales()
        {
            // Arrange
            Jugador jugadorAsh = new Jugador("Ash");
            
            // Act
            jugadorAsh.Seleccionar_6_Pokemons_Iniciales(1);
            jugadorAsh.Seleccionar_6_Pokemons_Iniciales(2);
            jugadorAsh.Seleccionar_6_Pokemons_Iniciales(3);
            jugadorAsh.Seleccionar_6_Pokemons_Iniciales(4);
            jugadorAsh.Seleccionar_6_Pokemons_Iniciales(5);
            jugadorAsh.Seleccionar_6_Pokemons_Iniciales(6);

            // Assert
            Assert.AreEqual(6, jugadorAsh.ListPokemons.Count);
            Assert.AreEqual("Crocalor", jugadorAsh.ListPokemons[0].Name);
            Assert.AreEqual("Cacnea", jugadorAsh.ListPokemons[1].Name);
            Assert.AreEqual("Dewott", jugadorAsh.ListPokemons[2].Name);
            Assert.AreEqual("Gagnar", jugadorAsh.ListPokemons[3].Name);
            Assert.AreEqual("Mareep", jugadorAsh.ListPokemons[4].Name);
            Assert.AreEqual("NosePass", jugadorAsh.ListPokemons[5].Name);
        }
        
        [Test]
        public void TestSeleccionarPokemonParaLuchar()
        {
            // Arrange
            Jugador jugador = new Jugador("Ash");
            jugador.Inicializar_Total_Pokemons_Disponibles_Juego();
            // jugador.ListPokemons.Add(new Pokemon(1, "Pikachu", 80, 45, "eléctrico", new List<IAtaque>()));
            // jugador.ListPokemons.Add(new Pokemon(2, "Bulbasaur", 85, 70, "planta", new List<IAtaque>()));

            jugador.Seleccionar_6_Pokemons_Iniciales(1);
            

            // Act
            Pokemon pokemonSeleccionado = jugador.Seleccionar_Pokemons_Para_Luchar(out string mensaje, 1);

            // Assert
            Assert.IsNotNull(pokemonSeleccionado);
            Assert.AreEqual("Crocalor", pokemonSeleccionado.Name);
            Assert.IsTrue(pokemonSeleccionado.EnCombate);
        }
        
        [Test]
        public void TestJugadorTienePokemonsDisponibles()
        {
            // Arrange
            Jugador jugador = new Jugador("Ash");
            jugador.ListPokemons.Add(new Pokemon(1, "Pikachu", 80, 45, "eléctrico", new List<IAtaque>()));
            jugador.ListPokemons.Add(new Pokemon(2, "Charmander", 70, 50, "fuego", new List<IAtaque>()));

            // Act
            bool resultadoConVivos = jugador.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar();
            Assert.IsTrue(resultadoConVivos, "Se esperaba que el jugador tuviera Pokémon disponibles para luchar.");

            // Caso 2: Sin Pokémon vivos
            jugador.ListPokemons[0].Hp = 0; // Derrotar a Pikachu
            jugador.ListPokemons[1].Hp = 0; // Derrotar a Charmander

            // Act
            bool resultadoSinVivos = jugador.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar();
            Assert.IsFalse(resultadoSinVivos, "Se esperaba que el jugador no tuviera Pokémon disponibles para luchar.");
        }

        [Test]
        public void TestJugadorTienePokemonsDisponibles_SinPokemons()
        {
            // Arrange
            Jugador jugador = new Jugador("Ash");
            jugador.ListPokemons.Clear(); // Sin Pokémon

            // Act
            bool resultado = jugador.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar();

            // Assert
            Assert.IsFalse(resultado);
        }
    }
}