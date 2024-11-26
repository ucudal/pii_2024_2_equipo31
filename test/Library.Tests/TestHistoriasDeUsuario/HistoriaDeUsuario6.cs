namespace Library.Tests;
using Library;
using Xunit; 

public class HistoriaDeUsuario6
{
    // Caso 1: Hay al menos un Pokémon con Hp positivo y que no está en combate.
    [Fact]
    public void Jugador_Tiene_Pokemons_Disponibles_Para_Luchar_Debe_Devolver_True_Si_Hay_Pokemon_Con_Hp_Positivo_Y_No_En_Combate()
    {
        // Arrange: Configuramos el jugador con dos Pokémon.
        var jugador = new Jugador("pepe");
        
        jugador.Seleccionar_6_Pokemons_Iniciales(1);
        jugador.Seleccionar_6_Pokemons_Iniciales(2);
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
        var jugador = new Jugador("pepe");
       
        
        // Le agrego dos pokemones 
        jugador.Seleccionar_6_Pokemons_Iniciales(1);
        jugador.Seleccionar_6_Pokemons_Iniciales(2);
        
        // le hago un daño que es 100% seguro que los matara
        jugador.ListPokemons[0].El_Pokemon_Recibio_Daño(99999);
        jugador.ListPokemons[1].El_Pokemon_Recibio_Daño(10000);
       
        
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
        var jugador = new Jugador("pepe");
        jugador.Seleccionar_6_Pokemons_Iniciales(1);
        jugador.Seleccionar_Pokemons_Para_Luchar(out string mensaje, 1);
       
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
        var jugador = new Jugador("pepe");

        // Act: Llamamos al método.
        var resultado = jugador.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar();

        // Assert: Verificamos que el resultado sea false.
        Assert.False(resultado);
    }
}

