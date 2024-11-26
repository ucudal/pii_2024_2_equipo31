using System;
using System.Collections.Generic;
using NUnit.Framework; // Usando NUnit como ejemplo para Test
using Library; // Asegúrate de usar el namespace correcto

namespace Library.Tests;


using System;
using System.Collections.Generic;
using NUnit.Framework; 
using Library;


[TestFixture]
public class HistoriaDelUsuario1

{
    [Test]
    public void Seleccionar_6_Pokemons_Iniciales_Agrega_Pokemon_Valido()
    {
        // Arrange
        var jugador = new Jugador("Ash"); // Crear un jugador llamado Ash
        
        var TodosLosPokemons = jugador.Inicializar_Total_Pokemons_Disponibles_Juego();


        Pokemon pokemon1 = TodosLosPokemons[0];
        Pokemon pokemon2 = TodosLosPokemons[1];
        
        // Act
        string mensaje1 = jugador.Seleccionar_6_Pokemons_Iniciales(1); 
        string mensaje2 = jugador.Seleccionar_6_Pokemons_Iniciales(2); 

        // manualmente creo una lista para comparar
        List<Pokemon> listaAcomprobar = new List<Pokemon>();
        listaAcomprobar.Add(TodosLosPokemons[0]);
        listaAcomprobar.Add(TodosLosPokemons[0]);
        
        
        // Assert
        Assert.Contains(pokemon1, jugador.ListPokemons); // Verificar que pokemon1 está en la lista
        Assert.Contains(pokemon2, jugador.ListPokemons); // Verificar que pokemon2 está en la lista
        Assert.AreEqual("🐵 Ash añadio a Crocalor", mensaje1.Trim());
        Assert.AreEqual("🐵 Ash añadio a Cacnea", mensaje2.Trim());

    }

    [Test]
    public void Seleccionar_6_Pokemons_Iniciales_No_Agrega_Si_Limite_Alcanzado()
    {
        // Arrange
        var jugador = new Jugador("Ash");
        
        // Agrega 6 pokemons
        jugador.Seleccionar_6_Pokemons_Iniciales(1);
        jugador.Seleccionar_6_Pokemons_Iniciales(2);
        jugador.Seleccionar_6_Pokemons_Iniciales(3);
        jugador.Seleccionar_6_Pokemons_Iniciales(4);
        jugador.Seleccionar_6_Pokemons_Iniciales(5);
        jugador.Seleccionar_6_Pokemons_Iniciales(6);
        
        // ACT
        
        string mensaje = jugador.Seleccionar_6_Pokemons_Iniciales(7); // Intento agregar otro mas con el limite alcanzado
        
        // Assert
        Assert.AreEqual("Selección completada: tienes 6 pokemom.", mensaje.Trim()); // verificar que el mensaje sea correcto
        Assert.AreEqual(6, jugador.ListPokemons.Count); // Asegurar que tiene solo 6
    }
}

