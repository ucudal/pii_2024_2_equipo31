using System;
using System.Collections.Generic;
using NUnit.Framework; // Usando NUnit como ejemplo para Test
using Library; // Asegúrate de usar el namespace correcto

namespace Library.Tests;

<<<<<<< HEAD
[TestFixture]
public class HistoriaDeUsuario1
=======
using System;
using System.Collections.Generic;
using NUnit.Framework; 
using Library;


[TestFixture]
public class HistoriaDelUsuario1
>>>>>>> origin/agustin
{
    [Test]
    public void Seleccionar_6_Pokemons_Iniciales_Agrega_Pokemon_Valido()
    {
        // Arrange
        var jugador = new Jugador("Ash"); // Crear un jugador llamado Ash
<<<<<<< HEAD

        // Instanciamos un AtaqueElectrico, que hereda de Ataque
        var ataqueElectrico = new AtaqueElectrico("Impactrueno", 40); // Crear un ataque eléctrico
        var pikachu = new Pokemon(1, "Pikachu", 100, 50, "Eléctrico", new List<IAtaque> { ataqueElectrico }); // Crear un Pokémon
        var charmander = new Pokemon(2, "Charmander", 120, 40, "Fuego", new List<IAtaque> { ataqueElectrico });

        // Act
        // Simulamos la disponibilidad de los Pokémon y los agregamos al jugador
        string mensaje1 = jugador.Seleccionar_6_Pokemons_Iniciales(1); // Seleccionar Pikachu
        string mensaje2 = jugador.Seleccionar_6_Pokemons_Iniciales(2); // Seleccionar Charmander

        // Assert
        Assert.Contains(pikachu, jugador.ListPokemons); // Verificar que Pikachu está en la lista
        Assert.Contains(charmander, jugador.ListPokemons); // Verificar que Charmander está en la lista
        Assert.AreEqual("\n 🐵 Ash añadió a Pikachu", mensaje1.Trim()); // Verificar mensaje de Pikachu
        Assert.AreEqual("\n 🐵 Ash añadió a Charmander", mensaje2.Trim()); // Verificar mensaje de Charmander
=======
        
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
>>>>>>> origin/agustin
    }

    [Test]
    public void Seleccionar_6_Pokemons_Iniciales_No_Agrega_Si_Limite_Alcanzado()
    {
        // Arrange
        var jugador = new Jugador("Ash");
<<<<<<< HEAD
        var ataqueElectrico = new AtaqueElectrico("Impactrueno", 40); // Crear un ataque eléctrico
        var pokemons = new List<Pokemon>
        {
            new Pokemon(1, "Pikachu", 100, 50, "Eléctrico", new List<IAtaque> { ataqueElectrico }),
            new Pokemon(2, "Charmander", 120, 40, "Fuego", new List<IAtaque> { ataqueElectrico }),
            new Pokemon(3, "Bulbasaur", 110, 45, "Planta", new List<IAtaque> { ataqueElectrico }),
            new Pokemon(4, "Squirtle", 105, 55, "Agua", new List<IAtaque> { ataqueElectrico }),
            new Pokemon(5, "Pidgey", 90, 30, "Volador", new List<IAtaque> { ataqueElectrico }),
            new Pokemon(6, "Rattata", 85, 25, "Normal", new List<IAtaque> { ataqueElectrico })
        };

        // Act
        // Ya tiene 6 Pokémon, intentamos agregar un séptimo
        foreach (var pokemon in pokemons)
        {
            jugador.Seleccionar_6_Pokemons_Iniciales(); // Seleccionamos los 6 Pokémon
        }

        var eevee = new Pokemon(7, "Eevee", 95, 35, "Normal", new List<IAtaque> { ataqueElectrico });
        string mensaje = jugador.Seleccionar_6_Pokemons_Iniciales(7); // Intentar añadir un 7° Pokémon

        // Assert
        Assert.AreEqual("\nSelección completada: tienes 6 pokemom.", mensaje.Trim());
        Assert.AreEqual(6, jugador.ListPokemons.Count); // Asegurar que tiene solo 6
    }
}

public class AtaqueElectrico : Ataque
{
    public AtaqueElectrico(string name, double daño)
    {
        this.Name = name;
        this.Daño = daño;
        this.TipoAtaque = "Electrico";
    }

    public override string Ejecutar_Ataque(Pokemon oponente)
    {
        // Implementación del ataque
        return "Ataque realizado.";
    }
}
=======
        
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
>>>>>>> origin/agustin
