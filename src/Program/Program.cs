using Library;
using System;
using Discord;
using DSharpPlus;
using Discord.WebSocket;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using TokenType = Discord.TokenType;

namespace Program;

class Program
{
    
    private static async Task Main(string[] args)
    {
        var bot = new Bot();
        await bot.StartAsync();

        await Task.Delay(-1);
    }
    
    /*
    static void Main()
    {

        Console.WriteLine("\n ⏩  Bienvenido a PokeWorld ⏪  ");
        Menu menujugar = new Menu();
        menujugar.MostrarMenuPrincipal();
    }
    */
}