namespace Library.Tests;

using System.Collections.Generic; // Necesario para usar listas.
using Xunit; // Marco de pruebas utilizado.

public class HistoriaDeUsuario6
{
    // Clase auxiliar para simular un Pokémon.
    public class Pokemon
    {
        public int Hp { get; set; } // Puntos de vida del Pokémon.
        public bool EnCombate { get; set; } // Indica si el Pokémon está en combate.
    }

    // Clase simulada del Jugador, que contiene la lista de Pokémon y el método a probar.
    public class Jugador
    {
        public List<Pokemon> ListPokemons { get; set; } = new List<Pokemon>(); // Lista de Pokémon del jugador.

        // Método a probar: verifica si el jugador tiene Pokémon disponibles para luchar.
        public bool Jugador_Tiene_Pokemons_Disponibles_Para_Luchar()
        {
            foreach (Pokemon pokemon in ListPokemons)
            {
                // Devuelve true si encuentra un Pokémon con Hp > 0 y que no esté en combate.
                if (pokemon.Hp > 0 && !pokemon.EnCombate)
                {
                    return true;
                }
            }
            // Si ninguno cumple las condiciones, devuelve false.
            return false;
        }
    }

    // Caso 1: Hay al menos un Pokémon con Hp positivo y que no está en combate.
    [Fact]
    public void Jugador_Tiene_Pokemons_Disponibles_Para_Luchar_Debe_Devolver_True_Si_Hay_Pokemon_Con_Hp_Positivo_Y_No_En_Combate()
    {
        // Arrange: Configuramos el jugador con dos Pokémon.
        var jugador = new Jugador();
        jugador.ListPokemons.Add(new Pokemon { Hp = 10, EnCombate = false }); // Este Pokémon cumple las condiciones.
        jugador.ListPokemons.Add(new Pokemon { Hp = 0, EnCombate = false });  // Este no cumple.

        // Act: Llamamos al método.
        var resultado = jugador.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar();

        // Assert: Verificamos que el resultado sea true.
        Assert.True(resultado);
    }

    // Caso 2: Todos los Pokémon tienen Hp igual a 0.
    [Fact]
    public void Jugador_Tiene_Pokemons_Disponibles_Para_Luchar_Debe_Devolver_False_Si_Todos_Estan_Sin_Hp()
    {
        // Arrange: Configuramos el jugador con dos Pokémon, ambos sin Hp.
        var jugador = new Jugador();
        jugador.ListPokemons.Add(new Pokemon { Hp = 0, EnCombate = false });
        jugador.ListPokemons.Add(new Pokemon { Hp = 0, EnCombate = true });

        // Act: Llamamos al método.
        var resultado = jugador.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar();

        // Assert: Verificamos que el resultado sea false.
        Assert.False(resultado);
    }

    // Caso 3: Todos los Pokémon están en combate.
    [Fact]
    public void Jugador_Tiene_Pokemons_Disponibles_Para_Luchar_Debe_Devolver_False_Si_Todos_Estan_En_Combate()
    {
        // Arrange: Configuramos el jugador con Pokémon en combate.
        var jugador = new Jugador();
        jugador.ListPokemons.Add(new Pokemon { Hp = 10, EnCombate = true });
        jugador.ListPokemons.Add(new Pokemon { Hp = 20, EnCombate = true });

        // Act: Llamamos al método.
        var resultado = jugador.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar();

        // Assert: Verificamos que el resultado sea false.
        Assert.False(resultado);
    }

    // Caso 4: No hay Pokémon en la lista.
    [Fact]
    public void Jugador_Tiene_Pokemons_Disponibles_Para_Luchar_Debe_Devolver_False_Si_No_Hay_Pokemons()
    {
        // Arrange: Configuramos el jugador sin Pokémon.
        var jugador = new Jugador();

        // Act: Llamamos al método.
        var resultado = jugador.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar();

        // Assert: Verificamos que el resultado sea false.
        Assert.False(resultado);
    }
}

