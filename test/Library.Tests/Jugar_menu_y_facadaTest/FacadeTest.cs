using System;
using Library;
using NUnit.Framework;
/*
namespace LibraryTests
{

    [TestFixture]
    public class FacadaTests
    {
        
        [Test]
        public void TestAgregarPokemonAJugador()

        {
            private Facada facada;

            [SetUp]
            public void Setup()
            {
                // Crear la fachada con los jugadores Ash y Misty
                facada = new Facada("Ash", "Misty");
            }

            [Test]
            public void TestIniciarBatallaConAmbosJugadores()
            {
                // Simular que ambos jugadores han agregado sus pokémons
                facada.Cada_Jugador_Agrega_Pokemons(1);
                facada.Cada_Jugador_Agrega_Pokemons(2);

                // Iniciar la batalla
                facada.Iniciar_Nueva_Batalla(facada.Jugador1, facada.Jugador2);

                // Verificar que la batalla haya comenzado y que ambos jugadores estén participando
                Assert.AreEqual("Ash", facada.Jugador1.Name);
                Assert.AreEqual("Misty", facada.Jugador2.Name);
                // Se podría agregar más verificaciones para comprobar el estado de la batalla
            }

            [Test]
            public void TestUnirJugadorASalaDeEspera()
            {
                // Crear un jugador y unirlo a la sala de espera
                Jugador ash = new Jugador("Ash");
                facada.Unir_Jugador_A_La_Espera(ash);

                // Verificar que Ash está en la lista de espera
                string listaEspera = facada.MostrarJugadoresEnEspera();
                Assert.IsTrue(listaEspera.Contains("Ash"));
            }

            [Test]
            public void TestIniciarBatallaEnSalaDeEspera()
            {
                // Crear jugadores y unirlos a la sala de espera
                Jugador ash = new Jugador("Ash");
                Jugador misty = new Jugador("Misty");
                facada.Unir_Jugador_A_La_Espera(ash);
                facada.Unir_Jugador_A_La_Espera(misty);

                // Iniciar la batalla en la sala de espera
                facada.IniciarBatallaEnEspera();

                // Verificar que la batalla se ha iniciado entre Ash y Misty
                string listaEspera = facada.MostrarJugadoresEnEspera();
                Assert.IsTrue(listaEspera.Contains("Ash"));
                Assert.IsTrue(listaEspera.Contains("Misty"));
            }
        }
    }
}
*/
