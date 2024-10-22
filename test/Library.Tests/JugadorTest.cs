using Library;
using NUnit.Framework.Internal;


    [Test]
        void TestSeleccionarPokemons()
    {
        // Arrange
        Jugador jugadorAsh = new Jugador("Ash");

        // Simular entradas de usuario
        Queue<string> nombresDePokemonEntrada = new Queue<string>(new[] { "Pikachu", "Charmander", "Bulbasaur", "InvalidPokemon", "Charmander", "Squirtle" });

        // Función de entrada simulada
        string ObtenerEntradaSimulada() => nombresDePokemonEntrada.Dequeue();

        // Act
        jugadorAsh.SeleccionarPokemons();

        // Assert
        Assert.AreEqual(3, jugadorAsh.ListPokemons.Count);
        Assert.AreEqual("Pikachu", jugadorAsh.ListPokemons[0].Name);
        Assert.AreEqual("Charmander", jugadorAsh.ListPokemons[1].Name);
        Assert.AreEqual("Bulbasaur", jugadorAsh.ListPokemons[2].Name);
    }
        
    
    [Test]
    void TestTomarDecision_Atacar()
    {
        // Arrange
        Jugador jugador = new Jugador("Ash");
        Pokemon propio = new Pokemon("Pikachu", 80, 45, "eléctrico", new List<IAtaque>());
        Pokemon oponente = new Pokemon("Bulbasaur", 85, 70, "planta", new List<IAtaque>());

        Queue<string> entradas = new Queue<string>(new[] { "1", "1" }); // Selecciona Atacar y luego Impactrueno
        string ObtenerEntradaSimulada() => entradas.Dequeue();

        // Act
        jugador.TomarDecision(propio, oponente);

        // Assert
        // Aquí deberías verificar que el ataque se haya ejecutado correctamente.
        // Esto dependerá de la implementación de la clase Ataque y el método Ejecutar.
    }

    [Test]
    void TestTomarDecision_UsarMochila()
    {
        // Arrange
        Jugador jugador = new Jugador("Ash");
        Pokemon propio = new Pokemon ("Pikachu", 80, 45, "eléctrico", new List<IAtaque>() ); // Sin ataques para simplificar
        Pokemon oponente = new Pokemon("Bulbasaur", 85, 70, "planta", new List<IAtaque>());

        Queue<string> entradas = new Queue<string>(new[] { "2", "🍄 poción" }); // Selecciona Usar Mochila y luego Poción
        string ObtenerEntradaSimulada() => entradas.Dequeue();

        // Act
        jugador.TomarDecision(propio, oponente);

        // Assert
        // Aquí deberías verificar que se haya utilizado el objeto correcto.
    }
    [Test] 
        void TestTomarDecision_CambiarPokemon()
    {
        // Arrange
        Jugador jugador = new Jugador("Ash");
        Pokemon propio = new Pokemon("Charmander", 70, 50, "fuego", new List<IAtaque>());
        Pokemon nuevoPokemon = new Pokemon("Pikachu", 80, 40, "eléctrico", new List<IAtaque>());

        // Simulamos la entrada para seleccionar "Cambiar Pokémon" (opción 3)
        Queue<string> entradas = new Queue<string>(new[] { "3" }); // Selecciona Cambiar Pokémon
        string entrada = entradas.Dequeue(); // Obtenemos la entrada

        // Agrega el nuevo Pokémon a la lista del jugador
        jugador.ListPokemons.Add(nuevoPokemon);
    
        // Act
        Console.SetIn(new StringReader(entrada)); // Simulamos la entrada del usuario
        jugador.TomarDecision(propio, null); // Oponente no es relevante en este caso

        // Assert
        Assert.IsFalse(propio.EnCombate, $"{propio.Name} debería haber salido de combate.");
        Assert.AreEqual(nuevoPokemon, jugador.ListPokemons[1], "El nuevo Pokémon debería ser Pikachu.");
    }


    [Test]
        void TestTienePokemonsDisponibles()
    {
        // Arrange
        Jugador jugador = new Jugador("Ash");

        // Caso 1: Con Pokémon vivos
        jugador.ListPokemons = new List<Pokemon>
        {
            new Pokemon("Pikachu", 80, 45, "eléctrico", new List<IAtaque>()),
            new Pokemon("Charmander", 70, 50, "fuego", new List<IAtaque>())
        };

        // Act y Assert para el caso de Pokémon vivos
        bool resultadoConVivos = jugador.TienePokemonsDisponibles();
        Assert.IsTrue(resultadoConVivos, "Se esperaba que el jugador tuviera Pokémon vivos.");

        // Caso 2: Sin Pokémon vivos
        jugador.ListPokemons[0] = new Pokemon("Pikachu", 0, 45, "eléctrico", new List<IAtaque>());
        jugador.ListPokemons[1] = new Pokemon("Charmander", 0, 50, "fuego", new List<IAtaque>());

        // Act y Assert para el caso de sin Pokémon vivos
        bool resultadoSinVivos = jugador.TienePokemonsDisponibles();
        Assert.IsFalse(resultadoSinVivos, "Se esperaba que el jugador no tuviera Pokémon vivos.");
    }


    [Test]
        void TestTienePokemonsDisponibles_SinPokemons()
    {
        // Arrange
        Jugador jugador = new Jugador("Ash");
        jugador.ListPokemons = new List<Pokemon>(); // Sin Pokémon

        // Act
        bool resultado = jugador.TienePokemonsDisponibles();

        // Assert
        Assert.IsFalse(resultado);
    }
    
