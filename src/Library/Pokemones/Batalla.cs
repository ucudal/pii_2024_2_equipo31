using System;
using System.Collections.Generic;
using Discord.WebSocket;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;

namespace Library;

/// <summary>
/// Representa una batalla entre dos jugadores con sus respectivos Pokémon.
/// </summary>
public class Batalla
{
    public Jugador jugador1;
    public Jugador jugador2;
    public bool esTurnoJugador1;
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Batalla"/> con los jugadores especificados.
    /// </summary>
    /// <param name="jugador1">El primer jugador participante en la batalla.</param>
    /// <param name="jugador2">El segundo jugador participante en la batalla.</param>
    public Batalla(Jugador jugador1, Jugador jugador2)
    {
        this.jugador1 = jugador1;
        this.jugador2 = jugador2;
    }
    
    public async Task Iniciar_Batalla_Pruebas(ComponentInteractionCreateEventArgs ctx)
    {
        // CADA JUGADOR INICIA CON EL PRIMER POKEMON QUE SELECCIONO PARA PROBARLO DE MANERA MAS SENCILLA
        Pokemon pokemon1 = jugador1.Seleccionar_Pokemons_Para_Luchar(out string mensaje, jugador1.ListPokemons[0].Id);
        Pokemon pokemon2  = jugador2.Seleccionar_Pokemons_Para_Luchar(out string mensaje2, jugador2.ListPokemons[0].Id);
        
        Random random = new Random();
        esTurnoJugador1 = random.Next(2) == 0;
        
        var components = new DiscordComponent[]
        {
            new DiscordButtonComponent(ButtonStyle.Primary, "attack", "Atacar"),
            new DiscordButtonComponent(ButtonStyle.Secondary, "bag", "Usar Mochila"),
            new DiscordButtonComponent(ButtonStyle.Success, "switch", "Cambiar Pokémon")
        };
        
        string mensaje1 = "";
        if (esTurnoJugador1)
        { 
            mensaje1 = $"\n ⚪ {jugador1.Name}, elige una accion:\n";
            
        }
        else
        { 
            mensaje1 = $"\n ⚪ {jugador2.Name}, elige una accion:\n";
        }
        
        var builder = new DiscordMessageBuilder()
            .WithContent(mensaje1)
            .AddComponents(components);
        
        await ctx.Message.ModifyAsync(builder);
    }

    public async Task turnoSiguiente(ComponentInteractionCreateEventArgs ctx)
    {
        if (!esTurnoJugador1)
        {
            esTurnoJugador1 = true;
            await jugador1.Acciones_Del_Jugador_En_Batalla(jugador1.pokemonEnBatalla,jugador2.pokemonEnBatalla,ctx);
            Cada_Jugador_Actualiza_Los_Enfriamientos_De_Ataques_Especiales(jugador1);
        }
        else
        {
            esTurnoJugador1 = false;
            await jugador2.Acciones_Del_Jugador_En_Batalla(jugador2.pokemonEnBatalla, jugador1.pokemonEnBatalla, ctx);
            Cada_Jugador_Actualiza_Los_Enfriamientos_De_Ataques_Especiales(jugador1);
        }
    }

    public bool EsMiTurno(ComponentInteractionCreateEventArgs args)
    {
        if (esTurnoJugador1)
        {
            if (jugador1.Name == args.User.Username)
            {
                return true;
            }
            args.Channel.SendMessageAsync("No es tu turno actualmente");
        }
        else 
        {
            if (jugador2.Name == args.User.Username)
            {
                return true;
            }
            args.Channel.SendMessageAsync("No es tu turno actualmente");
        }
        return false;
    }
    
    /// <summary>
    /// Actualiza los tiempos de enfriamiento de los ataques especiales de cada Pokémon del jugador.
    /// </summary>
    /// <param name="jugador">El jugador cuyos Pokémon actualizan sus ataques especiales.</param>
    public void Cada_Jugador_Actualiza_Los_Enfriamientos_De_Ataques_Especiales(Jugador jugador)
    {
        foreach (var pokemon in jugador.ListPokemons)
        {
            foreach (var ataque in pokemon.Ataques)
            {
                if (ataque is AtaqueEspecial ataqueEspecial)
                {
                    ataqueEspecial.ReducirEnfriamiento();
                }
            }
        }
    }
 
    public async Task Client_ComponentInteractionCreated(DiscordClient sender, ComponentInteractionCreateEventArgs args)
    {
        Jugador jugadorenTurno = null;
        Pokemon propio = null;
        Pokemon oponente = null;
        
        var disabledButton = new DiscordButtonComponent(
            ButtonStyle.Primary,
            "one_time_button",
            "¡Ya clickeado!",
            disabled: true
        );

        var builderDeshabilitador = new DiscordMessageBuilder()
            .WithContent(args.Message.Content)
            .AddComponents(disabledButton);
        
        if (esTurnoJugador1)
        {
            if (jugador1.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar())
            {
                propio = jugador1.pokemonEnBatalla;
                jugadorenTurno = jugador1;
                oponente = jugador2.pokemonEnBatalla;
            }

            jugadorenTurno = jugador1;
        }
        
        else
        {
            if (jugador2.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar())
            {
                propio = jugador2.pokemonEnBatalla;
                jugadorenTurno = jugador2;
                oponente = jugador1.pokemonEnBatalla;
            }

            jugadorenTurno = jugador2;
        }
        
        string mensajeAtaque;
        
        string mensaje = $"\n ⚪ {jugadorenTurno.Name}, elige una accion:\n";
        
        Random random = new Random();

        switch (args.Interaction.Data.CustomId)
        {
            case "Start":
                await Iniciar_Batalla_Pruebas(args);
                await args.Interaction.DeferAsync();
                await args.Interaction.DeleteOriginalResponseAsync();
                break;
            case "attack":
                if (!EsMiTurno(args)) break;
                if (!jugadorenTurno.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar())
                {
                    await args.Message.ModifyAsync(builderDeshabilitador);
                    await args.Channel.SendMessageAsync($"\nLa batalla acabo, {jugadorenTurno.Name} fue derrotado");
                    await args.Interaction.DeferAsync();
                    await args.Interaction.DeleteOriginalResponseAsync(); 
                    break;
                }
                mensaje = $" ❗ {jugadorenTurno.Name} decidio atacar";
                    if (propio.El_Pokemon_Esta_Derrotado())
                    {
                        await args.Channel.SendMessageAsync($" 🔻 {propio.Name} no puede seguir luchando, debe cambiar o revivir al pokemon: ");
                        jugadorenTurno.Acciones_Del_Jugador_En_Batalla(jugadorenTurno.pokemonEnBatalla, oponente,args);
                        Cada_Jugador_Actualiza_Los_Enfriamientos_De_Ataques_Especiales(jugadorenTurno);
                    }
                    else
                    {
                        if (propio.EstadoNegativo == "Dormido")
                        {
                            mensaje = $"{propio.Name} no puede atacar en este turno porque esta {propio.EstadoNegativo} 💤 ";
                            int TurnosAleatorios = random.Next(1, 5);
                            if (TurnosAleatorios == 1)
                            {
                                mensaje += $"\n{propio.Name} ya dejo de estar {propio.EstadoNegativo} 💤 .";
                                propio.EstadoNegativo = "Ninguno";
                            }
                            await args.Message.ModifyAsync(builderDeshabilitador);
                            await args.Channel.SendMessageAsync(mensaje);
                            await args.Interaction.DeferAsync();
                            await args.Interaction.DeleteOriginalResponseAsync(); 
                            await turnoSiguiente(args);
                            break;
                        }
                        if (propio.EstadoNegativo == "Paralizado")
                        {
                            mensaje = $"{propio.Name} perdio este turno porque estaba {propio.EstadoNegativo} 😨 ";
                            int TurnosAleatorios = random.Next(1, 3);
                            if (TurnosAleatorios == 1)
                            {
                                mensaje += $"\n{propio.Name} ya dejo de estar {propio.EstadoNegativo} 😨 .";
                                propio.EstadoNegativo = "Ninguno";
                            }
                            await args.Message.ModifyAsync(builderDeshabilitador);
                            await args.Channel.SendMessageAsync(mensaje);
                            await args.Interaction.DeferAsync();
                            await args.Interaction.DeleteOriginalResponseAsync(); 
                            await turnoSiguiente(args);
                            break;
                        }
                        else
                        {
                            Cada_Jugador_Actualiza_Los_Enfriamientos_De_Ataques_Especiales(jugadorenTurno);
                            mensaje = $"\n***Selecciona un ataque: ***";
                            
                            var componentsAtaque = new DiscordComponent[]
                            {
                                new DiscordButtonComponent(ButtonStyle.Primary, "AttackFirst", $"{propio.Ataques[0].Name} - [{propio.Ataques[0].Daño}💥]"),
                                new DiscordButtonComponent(ButtonStyle.Secondary, "AttackSecond", $"{propio.Ataques[1].Name} - [{propio.Ataques[1].Daño}💥]"),
                                new DiscordButtonComponent(ButtonStyle.Success, "AttackThree", $"{propio.Ataques[2].Name} - [{propio.Ataques[2].Daño}💥]"),
                                new DiscordButtonComponent(ButtonStyle.Danger, "AttackFour", $"{propio.Ataques[3].Name} - [{propio.Ataques[3].Daño}💥]")
                            };
                
                            var builderAtaques = new DiscordMessageBuilder()
                                .WithContent(mensaje)
                                .AddComponents(componentsAtaque);
                            
                            await args.Message.ModifyAsync(builderAtaques);
                            await args.Interaction.DeferAsync();
                            await args.Interaction.DeleteOriginalResponseAsync();
                        }
                    }
                break;
            case "bag":
                if (!EsMiTurno(args)) break;
                if (!jugadorenTurno.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar())
                {
                    await args.Message.ModifyAsync(builderDeshabilitador);
                    await args.Channel.SendMessageAsync($"\nLa batalla acabo, {jugadorenTurno.Name} fue derrotado");
                    await args.Interaction.DeferAsync();
                    await args.Interaction.DeleteOriginalResponseAsync(); 
                    break;
                }
                var builderBag = new DiscordMessageBuilder()
                    .WithContent(" 🎒 Selecciona un item: \n");
                
                List<DiscordComponent> buttonsBag = new List<DiscordComponent>();
                
                for (int i = 0; i < jugadorenTurno.Items.Count; i++)
                {
                    if (jugadorenTurno.Items[i].Cantidad > 0)
                    {
                        buttonsBag.Add(
                            new DiscordButtonComponent(ButtonStyle.Primary, $"Item_{i}", $"{jugadorenTurno.Items[i].Nombre} {jugadorenTurno.Items[i].Cantidad}"));
                    }
                }
                
                builderBag.AddComponents(buttonsBag);
                await args.Message.ModifyAsync(builderBag);
                await args.Interaction.DeferAsync();
                await args.Interaction.DeleteOriginalResponseAsync();
                break;
            case "Item_0":
                if (!EsMiTurno(args)) break;
                mensaje = jugadorenTurno.Mochila_Del_Jugador(jugadorenTurno.Items[0].Nombre, propio);
                
                await args.Message.ModifyAsync(builderDeshabilitador);
                await args.Channel.SendMessageAsync(mensaje);
                await args.Interaction.DeferAsync();
                await args.Interaction.DeleteOriginalResponseAsync();
                await turnoSiguiente(args);
                break;
            case "Item_1":
                if (!EsMiTurno(args)) break;
                mensaje = jugadorenTurno.Mochila_Del_Jugador(jugadorenTurno.Items[1].Nombre, propio);
                
                await args.Message.ModifyAsync(builderDeshabilitador);
                await args.Channel.SendMessageAsync(mensaje);
                await args.Interaction.DeferAsync();
                await args.Interaction.DeleteOriginalResponseAsync();
                await turnoSiguiente(args);
                break;
            case "Item_2":
                if (!EsMiTurno(args)) break;
                mensaje = jugadorenTurno.Mochila_Del_Jugador(jugadorenTurno.Items[2].Nombre, propio);
                
                await args.Message.ModifyAsync(builderDeshabilitador);
                await args.Channel.SendMessageAsync(mensaje);
                await args.Interaction.DeferAsync();
                await args.Interaction.DeleteOriginalResponseAsync();
                await turnoSiguiente(args);
                break;
            case "switch":
                if (!EsMiTurno(args)) break;
                if (!jugadorenTurno.Jugador_Tiene_Pokemons_Disponibles_Para_Luchar())
                {
                    await args.Message.ModifyAsync(builderDeshabilitador);
                    await args.Channel.SendMessageAsync($"\nLa batalla acabo, {jugadorenTurno.Name} fue derrotado");
                    await args.Interaction.DeferAsync();
                    await args.Interaction.DeleteOriginalResponseAsync(); 
                    break;
                }
                var builderCambiar = new DiscordMessageBuilder()
                    .WithContent("Seleccione un nuevo pokemon");
                
                List<DiscordComponent> buttonsPokemons = new List<DiscordComponent>();
                
               for (int i = 0; i < jugadorenTurno.ListPokemons.Count; i++)
               {
                   if (!jugadorenTurno.ListPokemons[i].El_Pokemon_Esta_Derrotado() && jugadorenTurno.ListPokemons[i] != jugadorenTurno.pokemonEnBatalla)
                   {
                       buttonsPokemons.Add(
                           new DiscordButtonComponent(ButtonStyle.Primary, $"cambiarA_{i}", $"{jugadorenTurno.ListPokemons[i].Name}"));
                   }
               }
               
                builderCambiar.AddComponents(buttonsPokemons);
                await args.Message.ModifyAsync(builderCambiar);
                await args.Interaction.DeferAsync();
                await args.Interaction.DeleteOriginalResponseAsync();
                break;
            case "cambiarA_0":
                if (!EsMiTurno(args)) break;
                Pokemon nuevoPokemon0 = jugadorenTurno.Seleccionar_Pokemons_Para_Luchar(out mensaje, jugadorenTurno.ListPokemons[0].Id, propio);
                
                await args.Message.ModifyAsync(builderDeshabilitador);
                await args.Channel.SendMessageAsync(mensaje);
                await args.Interaction.DeferAsync();
                await args.Interaction.DeleteOriginalResponseAsync();
                await turnoSiguiente(args);
                break;
            case "cambiarA_1":
                if (!EsMiTurno(args)) break;
                Pokemon nuevoPokemon1 = jugadorenTurno.Seleccionar_Pokemons_Para_Luchar(out mensaje, jugadorenTurno.ListPokemons[1].Id, propio);
                
                await args.Message.ModifyAsync(builderDeshabilitador);
                await args.Channel.SendMessageAsync(mensaje);
                await args.Interaction.DeferAsync();
                await args.Interaction.DeleteOriginalResponseAsync();
                await turnoSiguiente(args);
                break;
            case "cambiarA_2":
                if (!EsMiTurno(args)) break;
                Pokemon nuevoPokemon2 = jugadorenTurno.Seleccionar_Pokemons_Para_Luchar(out mensaje, jugadorenTurno.ListPokemons[2].Id, propio);
                
                await args.Message.ModifyAsync(builderDeshabilitador);
                await args.Channel.SendMessageAsync(mensaje);
                await args.Interaction.DeferAsync();
                await args.Interaction.DeleteOriginalResponseAsync();
                await turnoSiguiente(args);
                break;
            case "cambiarA_3":
                if (!EsMiTurno(args)) break;
                Pokemon nuevoPokemon3 = jugadorenTurno.Seleccionar_Pokemons_Para_Luchar(out mensaje, jugadorenTurno.ListPokemons[3].Id, propio);
                
                await args.Message.ModifyAsync(builderDeshabilitador);
                await args.Channel.SendMessageAsync(mensaje);
                await args.Interaction.DeferAsync();
                await args.Interaction.DeleteOriginalResponseAsync();
                await turnoSiguiente(args);
                break;
            case "cambiarA_4":
                if (!EsMiTurno(args)) break;
                Pokemon nuevoPokemon4 = jugadorenTurno.Seleccionar_Pokemons_Para_Luchar(out mensaje, jugadorenTurno.ListPokemons[4].Id, propio);
                
                await args.Message.ModifyAsync(builderDeshabilitador);
                await args.Channel.SendMessageAsync(mensaje);
                await args.Interaction.DeferAsync();
                await args.Interaction.DeleteOriginalResponseAsync();
                await turnoSiguiente(args);
                break;
            case "cambiarA_5":
                if (!EsMiTurno(args)) break;
                Pokemon nuevoPokemon5 = jugadorenTurno.Seleccionar_Pokemons_Para_Luchar(out mensaje, jugadorenTurno.ListPokemons[5].Id, propio);
                
                await args.Message.ModifyAsync(builderDeshabilitador);
                await args.Channel.SendMessageAsync(mensaje);
                await args.Interaction.DeferAsync();
                await args.Interaction.DeleteOriginalResponseAsync();
                await turnoSiguiente(args);
                break;
            case "AttackFirst":
                if (!EsMiTurno(args)) break;
                mensajeAtaque = propio.Ataques[0].Ejecutar_Ataque(oponente);
                await args.Message.ModifyAsync(builderDeshabilitador);
                await args.Channel.SendMessageAsync(mensajeAtaque);
                await turnoSiguiente(args);
                await args.Interaction.DeferAsync();
                await args.Interaction.DeleteOriginalResponseAsync();
                break;
            case "AttackSecond":
                if (!EsMiTurno(args)) break;
                mensajeAtaque = propio.Ataques[1].Ejecutar_Ataque(oponente);
                await args.Message.ModifyAsync(builderDeshabilitador);
                await args.Channel.SendMessageAsync(mensajeAtaque);
                await turnoSiguiente(args);
                await args.Interaction.DeferAsync();
                await args.Interaction.DeleteOriginalResponseAsync();
                break;
            case "AttackThree":
                if (!EsMiTurno(args)) break;
                mensajeAtaque = propio.Ataques[2].Ejecutar_Ataque(oponente);
                await args.Message.ModifyAsync(builderDeshabilitador);
                await args.Channel.SendMessageAsync(mensajeAtaque);
                await turnoSiguiente(args);
                await args.Interaction.DeferAsync();
                await args.Interaction.DeleteOriginalResponseAsync();
                break;
            case "AttackFour":
                if (!EsMiTurno(args)) break;
                mensajeAtaque = propio.Ataques[3].Ejecutar_Ataque(oponente);
                await args.Message.ModifyAsync(builderDeshabilitador);
                await args.Channel.SendMessageAsync(mensajeAtaque);
                await turnoSiguiente(args);
                await args.Interaction.DeferAsync();
                await args.Interaction.DeleteOriginalResponseAsync();
                break;
            default:
               await args.Channel.SendMessageAsync("Opcion incorrecta.");
                break;
        }
    }
}
