using Library;
using System;

namespace Program;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Jugador jugador1 = new Jugador("Personaje");
		Jugador jugador2 = new Jugador("Rival");
        Jugador.Batalla.IniciarBatalla(jugador1,jugador2);
    }
}
