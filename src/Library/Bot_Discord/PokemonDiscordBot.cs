using System;
using Library; 
using Discord;
using System.Linq;
using System.Text;
using Discord.WebSocket;
using System.Threading.Tasks;

public class PokemonDiscordBot
{
    private DiscordSocketClient _client;
    private Facada _facada;
    private Sala_De_Espera _salaDeEspera;
    private string tokenDiscordPersonalFeijoada;

    public async Task StartAsync()
    {
        _client = new DiscordSocketClient();
        _client.Log += Log;

        tokenDiscordPersonalFeijoada = File.ReadAllText("C:\\Users\\agust\\OneDrive\\Escritorio\\Token.txt");
            
        // Tu token de Discord 
        await _client.LoginAsync(TokenType.Bot, tokenDiscordPersonalFeijoada);
        await _client.StartAsync();

        // Inicializar la Facada y la SalaDeEspera
        _facada = new Facada("Pepe");
        _salaDeEspera = new Sala_De_Espera();

        // Registrar comandos de Discord
        _client.MessageReceived += HandleMessageReceived;
        await Task.Delay(-1);
    }

    private async Task HandleMessageReceived(SocketMessage message)
    {
        if (message.Author.IsBot) return;

        // Comando para unirse a la lista de espera
        if (message.Content.StartsWith("!unirse"))
        {
            string nombreJugador = message.Author.Username;
            Jugador jugador = new Jugador(nombreJugador);
            _salaDeEspera.AgregarJugadorCreado(jugador);
            _salaDeEspera.UnirseALaListaDeEspera(jugador, _salaDeEspera.jugadoresCreados);
            await message.Channel.SendMessageAsync($"{nombreJugador} se ha unido a la lista de espera.");
        }

        // Comando para ver la lista de espera
        if (message.Content.StartsWith("!espera"))
        {
            _salaDeEspera.MostrarListaDeEspera();
            await message.Channel.SendMessageAsync($"Jugadores en la lista de espera: \n{_salaDeEspera.MostrarListaDeEspera()}"); 
        }

        // Comando para iniciar una batalla con otro jugador en espera
        if (message.Content.StartsWith("!batalla"))
        {
            // Obtener el usuario que inicia la batalla
            string nombreJugador = message.Author.Username;
            Jugador jugador1 = _salaDeEspera.ObtenerJugador(nombreJugador); 

            // Buscar otro jugador en la lista de espera
            Jugador jugador2 = _salaDeEspera.ObtenerOtroJugador(nombreJugador);

            // Si se encuentra otro jugador, iniciar la batalla
            if (jugador2 != null)
            {
                // Eliminar los jugadores de la lista de espera
                _salaDeEspera.EliminarJugador(jugador1);
                _salaDeEspera.EliminarJugador(jugador2);

                // Iniciar la batalla
                _facada.Iniciar_Nueva_Batalla(jugador1, jugador2); 

                // Mensaje de inicio de batalla
                await message.Channel.SendMessageAsync($"¡{jugador1.Name} y {jugador2.Name} han comenzado una batalla!");
            }
            else
            {
                await message.Channel.SendMessageAsync($"No hay otro jugador en la lista de espera.");
            }
        }

        // ... Otros comandos para atacar, cambiar Pokémon, usar ítems, etc.
    }

    private Task Log(LogMessage message)
    {
        Console.WriteLine(message.ToString());
        return Task.CompletedTask;
    }
}

