using Library;
using System;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;

namespace Program;

class Program
{
    static void Main()
    {
        Console.WriteLine("\n ⏩  Bienvenido a PokeWorld ⏪  ");
        Menu menujugar = new Menu();
        menujugar.MostrarMenuPrincipal();
    }
}