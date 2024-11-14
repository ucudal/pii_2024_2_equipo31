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

            // Simular entradas de usuario
            Queue<int> idsPokemonEntrada = new Queue<int>(new[] { 1, 2, 3, 4, 5, 6 }); // IDs de los Pokémon a seleccionar

            // Función de entrada simulada
            int ObtenerEntradaSimulada() => idsPokemonEntrada.Dequeue();

            // Act
            jugadorAsh.Seleccionar_6_Pokemons_Iniciales();

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
            jugador.ListPokemons.Add(new Pokemon(1, "Pikachu", 80, 45, "eléctrico", new List<IAtaque>()));
            jugador.ListPokemons.Add(new Pokemon(2, "Bulbasaur", 85, 70, "planta", new List<IAtaque>()));

            // Simular entradas de usuario
            Queue<int> entradas = new Queue<int>(new[] { 1 }); // Selecciona Pikachu
            int ObtenerEntradaSimulada() => entradas.Dequeue();

            // Act
            Pokemon pokemonSeleccionado = jugador.Seleccionar_Pokemons_Para_Luchar();

            // Assert
            Assert.IsNotNull(pokemonSeleccionado);
            Assert.AreEqual("Pikachu", pokemonSeleccionado.Name);
            Assert.IsTrue(pokemonSeleccionado.EnCombate);
        }

        [Test]
        public void TestAccionesDelJugadorEnBatalla_Atacar()
        {
            // Arrange
            Jugador jugador = new Jugador("Ash");
            Pokemon propio = new Pokemon(1, "Pikachu", 80, 45, "eléctrico", new List<IAtaque>());
            Pokemon oponente = new Pokemon(2, "Bulbasaur", 85, 70, "planta", new List<IAtaque>());
            jugador.ListPokemons.Add(propio);

            // Simular entradas de usuario
            Queue<string> entradas = new Queue<string>(new[] { "1", "1" }); // Selecciona Atacar y luego un ataque
            string ObtenerEntradaSimulada() => entradas.Dequeue();

            // Act
            jugador.Acciones_Del_Jugador_En_Batalla(ref propio, oponente);

            // Assert
            // Verifica que el ataque se haya ejecutado correctamente (esto depende de la implementación de los ataques).
        }

        [Test]
        public void TestAccionesDelJugadorEnBatalla_CambiarPokemon()
        {
            // Arrange
            Jugador jugador = new Jugador("Ash");
            Pokemon propio = new Pokemon(1, "Charmander", 70, 50, "fuego", new List<IAtaque>());
            Pokemon nuevoPokemon = new Pokemon(2, "Pikachu", 80, 40, "eléctrico", new List<IAtaque>());
            jugador.ListPokemons.Add(propio);
            jugador.ListPokemons.Add(nuevoPokemon);

            // Simular entrada para seleccionar "Cambiar Pokémon" (opción 3)
            Queue<string> entradas = new Queue<string>(new[] { "3" });
            string entrada = entradas.Dequeue();

            // Act
            jugador.Acciones_Del_Jugador_En_Batalla(ref propio, null); // Oponente no es relevante en este caso

            // Assert
            Assert.IsFalse(propio.EnCombate, $"{propio.Name} debería haber salido de combate.");
            Assert.AreEqual(nuevoPokemon, jugador.ListPokemons[1], "El nuevo Pokémon debería ser Pikachu.");
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
