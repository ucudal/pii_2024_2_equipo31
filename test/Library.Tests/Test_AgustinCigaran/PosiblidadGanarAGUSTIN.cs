namespace Library.Tests;
using System;
using System.Collections.Generic;
using NUnit.Framework; 
using Library;


[TestFixture]
public class PosibilidadGanarAGUSTIN

{
    [Test]
    public void PosiblidadGanarTest()
    {
        // Arrange
        // Creo dos jugadores
        var jugador = new Jugador("Toretto"); 
        var jugadorRival = new Jugador("Braian");

        // Inicio todos los pokemons que puede seleccionar el pokemon
        jugador.Inicializar_Total_Pokemons_Disponibles_Juego();
        jugadorRival.Inicializar_Total_Pokemons_Disponibles_Juego();
        
        // Hago que el primer jugador seleccione 6 pokemons
        jugador.Seleccionar_6_Pokemons_Iniciales(1); // el primer pokemon es Crocalor, de tipo fuego
        jugador.Seleccionar_6_Pokemons_Iniciales(2); 
        jugador.Seleccionar_6_Pokemons_Iniciales(3); 
        jugador.Seleccionar_6_Pokemons_Iniciales(4); 
        jugador.Seleccionar_6_Pokemons_Iniciales(5); 
        jugador.Seleccionar_6_Pokemons_Iniciales(6); 
        
        // Hago que el jugador rival seleccione sus 6 pokemons
        jugadorRival.Seleccionar_6_Pokemons_Iniciales(1); 
        jugadorRival.Seleccionar_6_Pokemons_Iniciales(2); 
        jugadorRival.Seleccionar_6_Pokemons_Iniciales(3); 
        jugadorRival.Seleccionar_6_Pokemons_Iniciales(4); 
        jugadorRival.Seleccionar_6_Pokemons_Iniciales(5); 
        jugadorRival.Seleccionar_6_Pokemons_Iniciales(6);
        
        // Creo un pokemon y le asigno el primero que selecciono el rival
        Pokemon oponente = jugadorRival.ListPokemons[0];
        // Coloco el pokemon en combate ya que la historia de usuario pide que sea contra el pokemon del rival que esta activo
        oponente.EnCombate = true;
        
        // Act
        
        // Mensaje que obtengo del metodo
        var mensaje1 = jugador.PosibilidadDeGanarle(jugador.ListPokemons, oponente); 
        
        // Mensaje que espero que me de el metodo anterior
        string mensajeEsperado = $"***Crocalor es de tipo Fuego***" +
                                 $"\nTiene ***mas posibilidades*** de ganarle a los de tipo: ***Bicho, Fuego, Hierba***" +
                                 $"\nY tiene ***menos posibilidad*** de ganarle a los de tipo: ***Agua, Roca, Tierra***" +
                                 $"\nConsidere que el tipo de su rival es Fuego";
        
        // Hago el test en si para comprobar si los mensajes son iguales
        Assert.AreEqual(mensajeEsperado, mensaje1);
    }
}

