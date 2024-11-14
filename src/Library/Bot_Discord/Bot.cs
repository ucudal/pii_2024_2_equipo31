using System;
using System.IO;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace Library
{
    public class Bot
    {
        private readonly DiscordSocketClient _client;
        private Facada _facada;
        private Sala_De_Espera _salaDeEspera;

        public Bot()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;
            _client.MessageReceived += MessageReceived;
        }

        public async Task StartAsync()
        {
            string token = File.ReadAllText("C:\\Users\\agust\\OneDrive\\Escritorio\\Token.txt");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            
            _facada = new Facada("FacadaDiscord");
            _salaDeEspera = new Sala_De_Espera();
        }

        private Task Log(LogMessage log)
        {
            Console.WriteLine(log);
            return Task.CompletedTask;
        }

        private async Task MessageReceived(SocketMessage arg)
        {
            if (arg.Author.IsBot) return;

            // Comando para que el jugador se una a la lista de espera
            else if (arg.Content.StartsWith("!unirse"))
            {
                string nombreJugador = arg.Author.Username;
                Jugador jugador = new Jugador(nombreJugador);
                _salaDeEspera.AgregarJugadorCreado(jugador);
                _salaDeEspera.UnirseALaListaDeEspera(jugador, _salaDeEspera.jugadoresCreados);
                await arg.Channel.SendMessageAsync($"{nombreJugador} se ha unido a la lista de espera.");
            }

            // Comando para mostrar la lista de espera
            else if (arg.Content.StartsWith("!espera"))
            {
                await arg.Channel.SendMessageAsync($"Jugadores en la lista de espera: \n{_salaDeEspera.MostrarListaDeEspera()}");
            }

            // Comando para iniciar una batalla con jugadores en la lista de espera
            else if (arg.Content.StartsWith("!batalla"))
            {
                string nombreJugador = arg.Author.Username;
                Jugador jugador1 = _salaDeEspera.ObtenerJugador(nombreJugador);
                Jugador jugador2 = _salaDeEspera.ObtenerOtroJugador(nombreJugador);

                if (jugador2 != null)
                {
                    // Verificar si ambos jugadores tienen sus Pokémon seleccionados
                    if (jugador1.ListPokemons.Count < 6)
                    {
                        await arg.Channel.SendMessageAsync($"{jugador1.Name}, debes seleccionar tus 6 Pokémon antes de iniciar la batalla.");
                        return;
                    }
                    if (jugador2.ListPokemons.Count < 6)
                    {
                        await arg.Channel.SendMessageAsync($"{jugador2.Name}, debes seleccionar tus 6 Pokémon antes de iniciar la batalla.");
                        return;
                    }

                    // Eliminar los jugadores de la lista de espera y comenzar la batalla
                    _salaDeEspera.EliminarJugador(jugador1);
                    _salaDeEspera.EliminarJugador(jugador2);

                    _facada.Iniciar_Nueva_Batalla(jugador1, jugador2);

                    await arg.Channel.SendMessageAsync(
                        $"¡{jugador1.Name} y {jugador2.Name} han comenzado una batalla!");
                }
                else
                {
                    await arg.Channel.SendMessageAsync($"No hay otro jugador en la lista de espera.");
                }
            }

            // Comando para mostrar todos los comandos disponibles
            else if (arg.Content.StartsWith("!"))
            {
                await arg.Channel.SendMessageAsync("Comandos disponibles:\n" +
                                           "!unirse - Unirte a la lista de espera.\n" +
                                           "!espera - Mostrar los jugadores en la lista de espera.\n" +
                                           "!batalla - Iniciar una batalla con otro jugador en la lista de espera.");
            }
        }
    }
}


