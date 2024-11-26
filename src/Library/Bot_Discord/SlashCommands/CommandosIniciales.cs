using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;

namespace Library.SlashCommands;

/// <summary>
/// Módulo que contiene los comandos iniciales de la aplicación.
/// </summary>
public class CommandosIniciales : ApplicationCommandModule
{
    /// <summary>
    /// Instancia de la sala de espera.
    /// </summary>
    public static Sala_De_Espera nueva_SalaDeEspera = new Sala_De_Espera();
    
    /// <summary>
    /// Instancia de la fachada.
    /// </summary>
    public static Facada nueva_Facada = new Facada(nueva_SalaDeEspera);
    
    /// <summary>
    /// Une al usuario a la sala de espera para luchar.
    /// </summary>
    /// <param name="ctx">El contexto de la interacción.</param>
    /// <returns>Una tarea que representa la operación asíncrona.</returns>
    [SlashCommand("unirse", "Te une a una sala de espera para luchar")]
    public async Task UnirseAlaEspera(InteractionContext ctx)
    {
        await ctx.DeferAsync();
        
        try
        {
            string nombreJugadorActual = ctx.User.Username;
            Jugador jugadorActual = new Jugador(nombreJugadorActual);
            
            if (nueva_Facada.jugadorEnEspera.Count != 0) // CUANDO HAY ALGUIEN EN LA LISTA, REVISARA QUE EL MISMO NOS ENCUENTRE
            {
                foreach (Jugador enEspera in nueva_Facada.jugadorEnEspera)
                {
                    if (enEspera.Name == jugadorActual.Name) // SI SE ENCUENTRA, NO LO UNE, MUESTRA QUE YA ESTA EN LA LISTA
                    {
                        var embedMessage = new DiscordEmbedBuilder
                        {
                            Color = DiscordColor.Blue,
                            Title = $"Sala de espera",
                            ImageUrl = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcTnS4uW9trqisCCq1mCdVz5tYfcOPNpVWodqFM1ymGI30MSSyo1",
                            Description = $"{jugadorActual.Name} ya se encuentra en la sala de espera"
                        };
                
                        await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embedMessage));
                        
                    }
                    else // SI NINGUN NOMBRE COINCIDE CON EL SUYO, SE UNE
                    {
                        nueva_Facada.UnirJugador(jugadorActual.Name);
                        var embedMessage = new DiscordEmbedBuilder
                        {
                            Color = DiscordColor.Blue,
                            Title = $"Sala de espera",
                            ImageUrl = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcTnS4uW9trqisCCq1mCdVz5tYfcOPNpVWodqFM1ymGI30MSSyo1",
                            Description = $"{jugadorActual.Name} se ha unido a la lista de espera\n" +
                                          $"Ahora debes seleccionar tus pokemons iniciales!\n" +
                                          $"Usa el comando >> /todoslosPokemons << para ver los pokemon disponibles"
                        };
                
                        await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embedMessage));
                    }
                }
            }
            else // CUANDO NO HAY NADIE EN LA LISTA DE ESPERA DIRECTAMENTE LO UNE A LA MISMA 
            {
                nueva_Facada.UnirJugador(jugadorActual.Name);
                var embedMessage = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Blue,
                    Title = $"Sala de espera",
                    ImageUrl = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcTnS4uW9trqisCCq1mCdVz5tYfcOPNpVWodqFM1ymGI30MSSyo1",
                    Description = $"{jugadorActual.Name} se ha unido a la lista de espera\n" +
                                  $"Ahora debes seleccionar tus pokemons iniciales!\n" +
                                  $"Usa el comando >> /todoslosPokemons << para ver los pokemon disponibles"
                };
                
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embedMessage));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /*
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    */
    
    /// <summary>
    /// Muestra la lista de jugadores en espera.
    /// </summary>
    /// <param name="ctx">El contexto de la interacción.</param>
    /// <returns>Una tarea que representa la operación asíncrona.</returns>
    [SlashCommand("espera", "Muestra la lista de jugadores en espera")]
    public async Task JugadoresEnEspera(InteractionContext ctx)
    {
        await ctx.DeferAsync();
        
        var embedMessage = new DiscordEmbedBuilder
        {
            Color = DiscordColor.Brown,
            Title = "Jugadores en espera",
            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSgGeFhd3lPUOnH38kvkrnpqG2avn1EdCv7WZfWn_oJiyOjIULN",
            Description = $"{nueva_SalaDeEspera.MostrarListaDeEspera()}"
        };

        await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embedMessage));
    }

    /*
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    */
    
    /// <summary>
    /// Muestra los Pokémon disponibles del jugador para luchar.
    /// </summary>
    /// <param name="ctx">El contexto de la interacción.</param>
    /// <returns>Una tarea que representa la operación asíncrona.</returns>
    [SlashCommand("mis_pokemons", "muestra tus pokemons disponibles para luchar")]
    public async Task PokemonsDelJugadorParaLuchar(InteractionContext ctx)
    {
        await ctx.DeferAsync();
        
        string nombreJugadorActual = ctx.User.Username;
        Jugador jugadorActual = nueva_SalaDeEspera.ObtenerJugador(out string mensajeMetodo, nombreJugadorActual);
        
        if (nueva_SalaDeEspera.jugadoresCreados.Count == 0)
        {
            var embedMessage = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Red,
                Title = $"Pokemons disponibles de {nombreJugadorActual}",
                Description = "Actualmente no estas en una sala de espera.\n" +
                              "Utiliza > /unirse < primero."
            };

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embedMessage));
        }
        else if (nueva_SalaDeEspera.jugadoresCreados.Count > 0 && nueva_SalaDeEspera.jugadoresCreados.Contains(jugadorActual))
        {
            if (jugadorActual.ListPokemons.Count <= 6 && jugadorActual.ListPokemons.Count > 0)
            {
                var embedMessage = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Red,
                    Title = $"Pokemons disponibles de {jugadorActual.Name}",
                    ImageUrl = "https://img.ifunny.co/images/938fb6d81278fe4d1f525c456f769ecf17e410484faa6c002ce2aa9829463877_1.jpg",
                    Description = $"{jugadorActual.Mostrar_Pokemons_Disponibles_Del_Jugador()}"
                };

                await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embedMessage));
            }
            else if (jugadorActual.ListPokemons.Count == 0)
            {
                var embedMessage = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Red,
                    Title = $"Pokemons disponibles de {jugadorActual.Name}",
                    Description = "Actualmente no tienes pokemons disponibles.\n" +
                                  "Utiliza > /seleccionar < para agregar pokemons."
                };

                await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embedMessage));
            }
        }
    }
    
    /*
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    */
    
    /// <summary>
    /// Permite al jugador seleccionar 6 Pokémon iniciales para luchar.
    /// </summary>
    /// <param name="ctx">El contexto de la interacción.</param>
    /// <param name="idPokemon">El ID del Pokémon a seleccionar.</param>
    /// <returns>Una tarea que representa la operación asíncrona.</returns>
    [SlashCommand("seleccionar", "<<PRIMERO UTILIZA EL COMANDO /todoslosPokemons>>\nselecciona 6 pokemons iniciales para luchar")]
    public async Task SeleccionarLosPokemonsInciales(InteractionContext ctx, [Option("ID_Pokemon", "Id del pokemon a seleccionar")] double idPokemon)
    {
        await ctx.DeferAsync();

        string nombreJugadorActual = ctx.User.Username;
        Jugador jugadorActual = nueva_SalaDeEspera.ObtenerJugador(out string mensajeMetodo, nombreJugadorActual);
        
        if (nueva_SalaDeEspera.jugadoresCreados.Count != 0)
        {
            if (jugadorActual.ListPokemons.Count == 0)
            {
                string mensajesSeleccionPokemon = jugadorActual.Seleccionar_6_Pokemons_Iniciales(idPokemon);
                
                var embedMessage = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    ImageUrl = "https://media.tenor.com/OauN6v63OYgAAAAj/pokemon-pokememes.gif",
                    Title = $"Pokemons seleccionados",
                    Description =
                        $"{mensajesSeleccionPokemon}\n{nueva_Facada.MostrarPokemonsDisponiblesDelJugador(jugadorActual.Name)}" +
                        "\nPuedes tener hasta 6 pokemon"
                };
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embedMessage));
            }
            else if (jugadorActual.ListPokemons.Count < 6)
            {
                string mensajesSeleccionPokemon = jugadorActual.Seleccionar_6_Pokemons_Iniciales(idPokemon); 
                
                var embedMessage = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    ImageUrl = "https://media.tenor.com/OauN6v63OYgAAAAj/pokemon-pokememes.gif",
                    Title = $"Pokemons seleccionados",
                    Description =
                        $"{mensajesSeleccionPokemon}\n{nueva_Facada.MostrarPokemonsDisponiblesDelJugador(jugadorActual.Name)}" +
                        "\nPuedes tener hasta 6 pokemon"
                };
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embedMessage));
            }
            else
            {
                var embedMessage = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    ImageUrl = "https://media.tenor.com/OauN6v63OYgAAAAj/pokemon-pokememes.gif",
                    Title = $"Pokemons seleccionados",
                    Description =
                        $"Ya tienes 6 pokemon\n {nueva_Facada.MostrarPokemonsDisponiblesDelJugador(jugadorActual.Name)}"
                };
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embedMessage));
            }
        }
        else
        {
            var embedMessage = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Green,
                Title = $"Pokemons seleccionados",
                Description =
                    $"Primero debes unirte a la sala de espera, utiliza el comando >> /unirse <<"
            };
            
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embedMessage));
        }
    }
    
    /*
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    */

    /// <summary>
    /// Muestra todos los Pokémon disponibles del juego.
    /// </summary>
    /// <param name="ctx">El contexto de la interacción.</param>
    /// <returns>Una tarea que representa la operación asíncrona.</returns>
    [SlashCommand("todoslosPokemons", "Muestra todos los pokemons disponibles del juego")]
    public async Task TodosLosPokemon(InteractionContext ctx)
    {
        await ctx.DeferAsync();
        
        string nombreJugadorActual = ctx.User.Username;
        Jugador jugadorContarTodosLosPokemons = new Jugador(nombreJugadorActual);

        var embed = new DiscordEmbedBuilder
        {
            Color = DiscordColor.Yellow,
            Title = "Pokemons del juego",
            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQWAsgP5HWhuhm0Uj0vrUakFYDcUPgeneoBf0kOjwYZifaeXVf3",
            Description = "Usa el comando >> /seleccionar [ID del pokemon] << para seleccionarlo" + nueva_Facada.MostrarPokemonsDisponibles(jugadorContarTodosLosPokemons.Name) 
        };
        
        await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embed));
    }
    
    /*
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    */

    /// <summary>
    /// Inicia una batalla con otra persona en la sala de espera.
    /// </summary>
    /// <param name="ctx">El contexto de la interacción.</param>
    /// <returns>Una tarea que representa la operación asíncrona.</returns>
    [SlashCommand("batalla", "inicia una batalla con otra persona que este en la sala de espera.")]
    public async Task IniciarLaBatallaDiscord(InteractionContext ctx)
    {
        string nombreJugadorActual = ctx.User.Username;
        Jugador jugadorActual = nueva_SalaDeEspera.ObtenerJugador(out string mensajeMetodo, nombreJugadorActual);
        
        if (nueva_SalaDeEspera.jugadoresCreados.Count >= 2)
        {
            await nueva_Facada.IniciarBatalla(jugadorActual.Name, ctx);
        }
        else
        {
            var embed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Black,
                ImageUrl = "https://i.imgur.com/cAwSDmR.gif",
                Title = "Batalla",
                Description = $"No hay suficientes jugadores para iniciar una batalla."
            };
            await ctx.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,new DiscordInteractionResponseBuilder().AddEmbed(embed));
        }
    }

    /*
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    */
    
    /// <summary>
    /// Comando de prueba para seleccionar los 6 primeros Pokémon.
    /// </summary>
    /// <param name="ctx">El contexto de la interacción.</param>
    /// <returns>Una tarea que representa la operación asíncrona.</returns>
    [SlashCommand("testSeleccionMultiple", "SELECCIONA LOS 6 PRIMEROS POKEMONS PARA TESTEAR RAPIDO")]
    public async Task TestSleccion(InteractionContext ctx)
    {
        ctx.CreateResponseAsync("Seleccion multiple exitosa");
        string nombreJugadorActual = ctx.User.Username;
        Jugador jugadorActual = nueva_SalaDeEspera.ObtenerJugador(out string mensajeMetodo, nombreJugadorActual);
        jugadorActual.Seleccionar_6_Pokemons_Iniciales(1);
        jugadorActual.Seleccionar_6_Pokemons_Iniciales(2);
        jugadorActual.Seleccionar_6_Pokemons_Iniciales(3);
        jugadorActual.Seleccionar_6_Pokemons_Iniciales(4);
        jugadorActual.Seleccionar_6_Pokemons_Iniciales(5);
        jugadorActual.Seleccionar_6_Pokemons_Iniciales(6);
    }
    
    /*
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    */
}