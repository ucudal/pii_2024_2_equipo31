using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Library;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using Library.commands;
using Library.SlashCommands;

namespace Program;
internal class Program
{
    private static Facada nueva_Facada = CommandosIniciales.nueva_Facada;
    private static Sala_De_Espera nueva_SalaDeEspera = CommandosIniciales.nueva_SalaDeEspera;
    
    private static DiscordClient Client { get; set; }
    private static CommandsNextExtension Commands { get; set; }
    static async Task Main(string[] args)
    {
        
        var discordConfig = new DiscordConfiguration()
        {
            Intents = DiscordIntents.All,
            Token = File.ReadAllText("C:\\Users\\agust\\OneDrive\\Escritorio\\Token.txt"),
            TokenType = TokenType.Bot,
            AutoReconnect = true
        };
        
        var interactivityConfig = new InteractivityConfiguration
        {
            Timeout = TimeSpan.FromMinutes(2),
            PollBehaviour = PollBehaviour.DeleteEmojis
        };
        
        Client = new DiscordClient(discordConfig);
        Client.UseInteractivity(interactivityConfig);
        Client.Ready += Client_Ready;
        Client.ComponentInteractionCreated += Client_ComponentInteractionCreated;

        var commandsCofig = new CommandsNextConfiguration()
        {
            StringPrefixes = new string[] { "!" },
            EnableMentionPrefix = true,
            EnableDms = true,
            EnableDefaultHelp = false
        };
        
        Commands = Client.UseCommandsNext(commandsCofig);
        var slashCommandsConfiguration = Client.UseSlashCommands();
        
        slashCommandsConfiguration.RegisterCommands<CommandosIniciales>();
        
        await Client.ConnectAsync();
        await Task.Delay(-1);
    }

    private static async Task Client_ComponentInteractionCreated(DiscordClient sender, ComponentInteractionCreateEventArgs args2)
    {
        nueva_Facada.batallaEnFacada.Client_ComponentInteractionCreated(sender,args2);
    }
    
    
    private static Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
    {
        return Task.CompletedTask;
    }
    
}