using System;
using System.Collections.Generic;
using System.Linq;
using Discord;
using Discord.WebSocket;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using ButtonStyle = DSharpPlus.ButtonStyle;
using InteractionResponseType = DSharpPlus.InteractionResponseType;

namespace Library
{
    public class Facada
    {
        private Sala_De_Espera _salaDeEspera;
        public List<Jugador> jugadorEnEspera = new List<Jugador>();
        public Batalla batallaEnFacada;
        
        public Facada(Sala_De_Espera salaDeEspera)
        {
            _salaDeEspera = salaDeEspera;
            jugadorEnEspera = _salaDeEspera.listaEspera;
        }

        public void UnirJugador(string nombreJugador)
        {
            Jugador jugador = new Jugador(nombreJugador);
            _salaDeEspera.AgregarJugadorCreado(jugador);
            _salaDeEspera.UnirseALaListaDeEspera(jugador, _salaDeEspera.jugadoresCreados);
        }
        
        public string MostrarPokemonsDisponibles(string nombreJugador)
        {
            Jugador jugador = _salaDeEspera.ObtenerJugador(out string mensajeJugador, nombreJugador);
            return jugador != null ? jugador.Mostrar_Todos_Los_Pokemons_Disponibles_Del_Juego() : "Primero debes usar el comando >> /unirse <<";
        }
        
        public string MostrarPokemonsDisponiblesDelJugador(string nombreJugador)
        {
            Jugador jugadorEncontrado = _salaDeEspera.ObtenerJugador(out string mensajeJugador, nombreJugador);
            if (jugadorEncontrado != null)
            {
                return jugadorEncontrado.Mostrar_Pokemons_Disponibles_Del_Jugador();
            }
            else
            {
                return $"Jugador '{nombreJugador}' no encontrado."; 
            }
        }

        public async Task IniciarBatalla(string nombreJugador, InteractionContext ctx)
        {
            string mensajeRespuesta = "";
            
            Jugador jugador1 = _salaDeEspera.ObtenerJugador(out string mensajeJugador1, nombreJugador);
            
            
            if (jugador1.ListPokemons.Count < 6)
            {
                mensajeRespuesta = $"{jugador1.Name}, selecciona 6 Pokémon antes de iniciar la batalla.";
                
                var embed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Black,
                    Title = "Batalla",
                    Description = mensajeRespuesta
                };
                await ctx.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,new DiscordInteractionResponseBuilder().AddEmbed(embed));
                return;
            }
            
            Jugador jugador2 = _salaDeEspera.ObtenerOtroJugador(nombreJugador);
            
            if (jugador2.ListPokemons.Count < 6)
            {
                mensajeRespuesta = $"{jugador2.Name}, selecciona 6 Pokémon antes de iniciar la batalla.";
                var embed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Black,
                    Title = "Batalla",
                    Description = mensajeRespuesta
                };
                await ctx.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,new DiscordInteractionResponseBuilder().AddEmbed(embed));
                return;
            }
            
            batallaEnFacada = new Batalla(jugador1, jugador2);
            //await channel.SendMessageAsync();
            mensajeRespuesta =  $"¡{jugador1.Name} y {jugador2.Name} han comenzado una batalla!";
            
            try
            {
                var components = new DiscordComponent[]
                {
                    new DiscordButtonComponent(ButtonStyle.Primary, "Start", "Start")
                };
                var builder = new DiscordInteractionResponseBuilder()
                    .AddComponents(components);
                
                await ctx.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, builder);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error que sucedio durante la batalla: " + e);
                throw;
            }
            finally
            {
                _salaDeEspera.EliminarJugador(jugador1);
                _salaDeEspera.EliminarJugador(jugador2);
            }
        }
    }
}