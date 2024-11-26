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
        /// <summary>
        /// Representa la fachada que interactúa con la sala de espera y la batalla.
        /// </summary>
        private Sala_De_Espera _salaDeEspera;
        
        /// <summary>
        /// Lista de jugadores en espera.  Esta lista se sincroniza con la lista de espera de la sala de espera.
        /// </summary>
        public List<Jugador> jugadorEnEspera = new List<Jugador>();
        
        /// <summary>
        /// La batalla gestionada por la fachada.
        /// </summary>
        public Batalla batallaEnFacada;
        
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Facada"/>.
        /// </summary>
        /// <param name="salaDeEspera">La sala de espera a la que se conecta la fachada.</param>
        public Facada(Sala_De_Espera salaDeEspera)
        {
            _salaDeEspera = salaDeEspera;
            jugadorEnEspera = _salaDeEspera.listaEspera;
        }

        /// <summary>
        /// Une a un jugador a la sala de espera.
        /// </summary>
        /// <param name="nombreJugador">El nombre del jugador que se va a unir.</param>
        public void UnirJugador(string nombreJugador)
        {
            Jugador jugador = new Jugador(nombreJugador);
            _salaDeEspera.AgregarJugadorCreado(jugador);
            _salaDeEspera.UnirseALaListaDeEspera(jugador, _salaDeEspera.jugadoresCreados);
        }
        
        /// <summary>
        /// Muestra todos los Pokémon disponibles en el juego para un jugador específico.
        /// </summary>
        /// <param name="nombreJugador">El nombre del jugador que solicita ver los Pokémon disponibles.</param>
        /// <returns>
        /// Una cadena con la lista de todos los Pokémon disponibles en el juego si el jugador está en la sala de espera.
        /// Si el jugador no está en la sala de espera, devuelve un mensaje indicando que debe unirse primero.
        /// </returns>
        /// <remarks>
        /// Este método verifica si el jugador está en la sala de espera utilizando el método 
        /// <see cref="SalaDeEspera.ObtenerJugador"/>. Si el jugador es encontrado, llama al método 
        /// <see cref="Jugador.Mostrar_Todos_Los_Pokemons_Disponibles_Del_Juego"/> para obtener la lista completa de Pokémon.
        /// En caso contrario, sugiere unirse al juego.
        /// </remarks>
        /// <example>
        /// Ejemplo de uso:
        /// <code>
        /// string pokemons = MostrarPokemonsDisponibles("Jugador1");
        /// Console.WriteLine(pokemons);
        /// </code>
        /// </example>
        public string MostrarPokemonsDisponibles(string nombreJugador)
        {
            Jugador jugador = _salaDeEspera.ObtenerJugador(out string mensajeJugador, nombreJugador);
            return jugador != null ? jugador.Mostrar_Todos_Los_Pokemons_Disponibles_Del_Juego() : "Primero debes usar el comando >> /unirse <<";
        }
        
        /// <summary>
        /// Muestra los Pokémon disponibles de un jugador específico en la sala de espera.
        /// </summary>
        /// <param name="nombreJugador">El nombre del jugador cuyos Pokémon disponibles se desean mostrar.</param>
        /// <returns>
        /// Una cadena con la lista de Pokémon disponibles del jugador si se encuentra en la sala de espera.
        /// Si el jugador no se encuentra, devuelve un mensaje indicando que no fue encontrado.
        /// </returns>
        /// <remarks>
        /// Este método busca al jugador en la sala de espera y, si lo encuentra, llama al método 
        /// <see cref="Jugador.Mostrar_Pokemons_Disponibles_Del_Jugador"/> para obtener la lista de sus Pokémon.
        /// Si el jugador no está en la sala de espera, devuelve un mensaje de error.
        /// </remarks>
        /// <example>
        /// Ejemplo de uso:
        /// <code>
        /// string pokemons = MostrarPokemonsDisponiblesDelJugador("Jugador1");
        /// Console.WriteLine(pokemons);
        /// </code>
        /// </example>
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

        /// <summary>
        /// Inicia una batalla entre dos jugadores seleccionados de la sala de espera.
        /// </summary>
        /// <param name="nombreJugador">El nombre del jugador que solicita iniciar la batalla.</param>
        /// <param name="ctx">El contexto de la interacción en Discord.</param>
        /// <returns>Una tarea asíncrona que representa la operación de iniciar la batalla.</returns>
        /// <remarks>
        /// Este método verifica que ambos jugadores tengan al menos 6 Pokémon seleccionados.
        /// Si alguno de los jugadores no cumple con este requisito, se envía un mensaje al canal de Discord
        /// indicando que deben seleccionar más Pokémon.
        /// Si ambos jugadores cumplen, se crea una instancia de la clase <see cref="Batalla"/> para gestionar el combate.
        /// </remarks>
        /// <exception cref="Exception">Lanza una excepción si ocurre un error durante el manejo de la interacción de Discord.</exception>
        /// <example>
        /// Ejemplo de uso:
        /// <code>
        /// await IniciarBatalla("Jugador1", ctx);
        /// </code>
        /// </example>
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